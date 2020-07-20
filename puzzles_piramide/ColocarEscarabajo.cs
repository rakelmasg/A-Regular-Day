using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColocarEscarabajo : MonoBehaviour {

	public ScriptColeccionablesPiramide coleccionables;
	public AbrirPuerta puerta;

	public LayerMask objetos;
	public Image imagenInteractuar;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera" && coleccionables.escarabajo) {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a Pedestal");
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				inventario invent = GameObject.Find ("Inventario").GetComponent<inventario> ();
				if (Input.GetMouseButtonDown (0) && invent.IsSeleccionado("escarabajo")) {
					invent.QuitarObjeto ("escarabajo");
					coleccionables.SendMessage ("ColocaEscarabajo");
					puerta.SendMessage ("Abrir");
					this.gameObject.SetActive (false);
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
