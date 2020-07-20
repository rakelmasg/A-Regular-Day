using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleDejarCarpeta : MonoBehaviour {

	public ScriptColeccionablesOficina coleccionables;
	public GameObject carpeta, monedas;

	public LayerMask objetos;
	public Image imagenInteractuar;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera" && coleccionables.carpeta) {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a mesa");
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				inventario invent = GameObject.Find("Inventario").GetComponent<inventario>();
				if (Input.GetMouseButtonDown (0) && invent.IsSeleccionado("carpeta")) {
					
					coleccionables.SendMessage ("ActivaDejarCarpeta");
					carpeta.SetActive (true);
					monedas.SetActive (true);
					invent.QuitarObjeto("carpeta");
					Destroy (gameObject);
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
