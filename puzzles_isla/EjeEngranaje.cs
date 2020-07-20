using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EjeEngranaje : MonoBehaviour {

	public ScriptColeccionables coleccionables;
	public GameObject engranaje;
	public LayerMask objetos;
	public Image imagenInteractuar;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera") {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a eje del engranaje");
				if (coleccionables.engranaje) {
					imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
					inventario invent = GameObject.Find("Inventario").GetComponent<inventario>();
					if (Input.GetMouseButtonDown (0)) {
						if(invent.IsSeleccionado("engranaje")){
							engranaje.SetActive(true);
							coleccionables.SendMessage ("ActivaEjeEngranaje");
							gameObject.SetActive (false);
							invent.QuitarObjeto("engranaje");
							imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
						}else{
							//TODO decir qeue falta una pieza
						}
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
