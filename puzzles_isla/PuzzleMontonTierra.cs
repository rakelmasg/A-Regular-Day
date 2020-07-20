using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PuzzleMontonTierra : MonoBehaviour {


	public ScriptColeccionables coleccionables;
	public GameObject engranaje;
	public LayerMask objetos;
	public Image imagenInteractuar;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera") {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a montón tierra");

				if (coleccionables.pala  && coleccionables.linterna) {
					imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
					inventario invent = GameObject.Find("Inventario").GetComponent<inventario>();
					if (Input.GetMouseButtonDown (0)) {
						if (invent.IsSeleccionado ("pala")) {

							//Sonido
							PlaySound ();
							//Fin sonido

							transform.parent.gameObject.SetActive (false);
							engranaje.gameObject.SetActive (true);
							invent.QuitarObjeto ("pala");
							imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
						}else{
							
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


	void PlaySound(){
		AudioSource source = GetComponent<AudioSource>();
		source.Play ();
	}

}
