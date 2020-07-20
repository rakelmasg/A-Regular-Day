using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalancaController : MonoBehaviour {

	public PuertaController puerta;
	//public GameObject palanca;
	public Image imagenInteractuar;

	private Color colorII = new Color(1f, 1f, 1f, 1f);
	private bool mostrarImagen = true; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
			if (mostrarImagen) {
				imagenInteractuar.color = colorII;
			}
			if (Input.GetButtonDown ("Interactuar")) {
				Debug.Log ("Boton pulsado");
				puerta.Abrir ();
				imagenInteractuar.color = Color.clear;
				mostrarImagen = false;
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			imagenInteractuar.color = Color.clear;
		}
	}
}
