using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleBotella : MonoBehaviour {

	public ScriptColeccionables coleccionables;
	public PuzzleReloj reloj;
	public LayerMask objetos;
	public Image imagenInteractuar;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera") {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a botella");
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				if (Input.GetMouseButtonDown (0)) {
					coleccionables.SendMessage ("ActivaBotella");
					this.gameObject.SetActive (false);
					inventario invent = GameObject.Find("Inventario").GetComponent<inventario>();
					invent.AñadirObjeto("acertijo");
					reloj.gameObject.SetActive (true);
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
