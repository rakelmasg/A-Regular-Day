using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColocarHorus : MonoBehaviour {

	public ScriptColeccionablesPiramide coleccionables;
	public AbrirPuerta puertaPiramide;
	public LayerMask objetos;
	public Image imagenInteractuar;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera" && coleccionables.horus) {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a Pedestal de Horus");
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				inventario invent = GameObject.Find ("Inventario").GetComponent<inventario>();
				if (Input.GetMouseButtonDown (0) && invent.IsSeleccionado("horus")) {
					coleccionables.SendMessage ("ColocaHorus");
					invent.QuitarObjeto ("horus");
					Destroy (gameObject);
					if (coleccionables.ankhColocado) {
						puertaPiramide.SendMessage ("Abrir");
					}
					imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
				}
			} else {
				imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
			}
		}
	}

	void OnTriggerExit(){
		imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
	}
}
