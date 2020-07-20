using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColocarAnkh : MonoBehaviour {

	public ScriptColeccionablesPiramide coleccionables;
	public AbrirPuerta puertaPiramide;

	public LayerMask objetos;
	public Image imagenInteractuar;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera" && coleccionables.ankh) {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a Pedestal de Ankh");
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				inventario invent = GameObject.Find ("Inventario").GetComponent<inventario>();
				if (Input.GetMouseButtonDown (0) && invent.IsSeleccionado("ankh")) {
					coleccionables.SendMessage ("ColocaAnkh");
					invent.QuitarObjeto ("ankh");
					Destroy (gameObject);
					if (coleccionables.horusColocado) {
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
