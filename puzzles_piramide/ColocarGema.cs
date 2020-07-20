using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColocarGema : MonoBehaviour {

	public ScriptColeccionablesPiramide coleccionables;

	public LayerMask objetos;
	public Image imagenInteractuar;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera" && coleccionables.gema) {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a Obelisco");
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				inventario invent = GameObject.Find ("Inventario").GetComponent<inventario> ();
				if (Input.GetMouseButtonDown (0) && invent.IsSeleccionado("gema")) {
					coleccionables.SendMessage ("ColocaGema");
					Destroy (gameObject);
					invent.QuitarObjeto ("gema");
					Debug.Log ("TE HAS PASADO EL JUEGO LOKO");
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
