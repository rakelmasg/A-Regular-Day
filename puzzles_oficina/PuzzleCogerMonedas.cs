using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PuzzleCogerMonedas : MonoBehaviour {

	public ScriptColeccionablesOficina coleccionables;

	public LayerMask objetos;
	public Image imagenInteractuar;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera" && coleccionables.carpetaDejada) {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a monedas");
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				if (Input.GetMouseButtonDown (0)) {
					
					coleccionables.SendMessage ("ActivaCogerMonedas");
					inventario inventario = GameObject.Find("Inventario").GetComponent<inventario>();
					inventario.AñadirObjeto ("monedas");
					Destroy (transform.parent.gameObject);
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
