using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuertaFaro : MonoBehaviour {

	public ScriptColeccionables coleccionables;

	public LayerMask objetos;
	public Image imagenInteractuar;
	public GameObject eje;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera") {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a puerta del armario del faro");
				if (coleccionables.reloj) {
					imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
					inventario invent = GameObject.Find("Inventario").GetComponent<inventario>();
					if (Input.GetMouseButtonDown (0) && invent.IsSeleccionado("llave")) {
						coleccionables.SendMessage ("ActivaPuertaFaro");
						eje.SetActive (true);
						transform.parent.gameObject.SetActive (false);
						invent.QuitarObjeto("llave");
						imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
					}
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
