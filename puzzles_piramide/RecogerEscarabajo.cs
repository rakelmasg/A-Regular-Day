using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecogerEscarabajo : MonoBehaviour {

	public ScriptColeccionablesPiramide coleccionables;
	public GameObject pedestal;

	public LayerMask objetos;
	public Image imagenInteractuar;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera") {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a escarabajo");
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				if (Input.GetMouseButtonDown (0)) {
					coleccionables.SendMessage ("ActivaEscarabajo");
					pedestal.SetActive (true);
					inventario invent = GameObject.Find ("Inventario").GetComponent<inventario> ();
					invent.AñadirObjeto ("escarabajo");
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
