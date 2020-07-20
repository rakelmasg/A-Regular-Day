using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleLinterna : MonoBehaviour {

	public ScriptColeccionables coleccionables;

	public LayerMask objetos;
	public Image imagenInteractuar;

	public GameObject linterna, linternaUI;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera") {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 5f, objetos)) {
				Debug.Log ("Mirando a mochila");
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				if (Input.GetMouseButtonDown (0)) {
					coleccionables.SendMessage ("ActivaLinterna");
					gameObject.SetActive (false);
					linterna.SetActive (true);
					linternaUI.SetActive (true);
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
