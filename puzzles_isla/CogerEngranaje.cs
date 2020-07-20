using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CogerEngranaje : MonoBehaviour {
	
	public ScriptColeccionables coleccionables;
	public LayerMask objetos;
	public Image imagenInteractuar;

	
	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera") {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a montón tierra");
				if (coleccionables.pala) {
					imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
					if (Input.GetMouseButtonDown (0)) {
						transform.parent.gameObject.SetActive (false);
						coleccionables.SendMessage ("ActivaEngranaje");
						inventario invent = GameObject.Find("Inventario").GetComponent<inventario>();
						invent.AñadirObjeto("engranaje");
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
