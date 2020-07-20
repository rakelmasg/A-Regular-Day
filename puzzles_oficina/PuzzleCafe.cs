using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class PuzzleCafe : MonoBehaviour {


	public ScriptColeccionablesOficina coleccionables;

	public LayerMask objetos;
	public Image imagenInteractuar;
	
	void OnTriggerStay(Collider other){	
		if (other.tag == "MainCamera" && coleccionables.monedas) {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a máquina de café");
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				inventario invent = GameObject.Find("Inventario").GetComponent<inventario>();
				if (Input.GetMouseButtonDown (0) && invent.IsSeleccionado("monedas")) {
					
					invent.QuitarObjeto("monedas");
					//Sonido
					PlaySound();
					//Fin sonido
					Destroy (gameObject, 0.4f);
					imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
					coleccionables.SendMessage ("CambiaEscena");
					//SceneManager.LoadScene ("Mundo1");
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
