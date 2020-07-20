using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntradaPiramide : MonoBehaviour {
	
	public Text pensamientos;
	public CerrarPuerta puerta;


	void Start(){
		pensamientos.enabled = false;
		StartCoroutine (ShowMessage ("Y ahora dónde estoy...", 5f));

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			puerta.SendMessage ("Cerrar");

			Destroy (gameObject);
			//gameObject.SetActive (false);
		}
	}



	IEnumerator ShowMessage(string message, float delay){
		pensamientos.text = message;
		pensamientos.enabled = true;
		yield return new WaitForSeconds (delay);
		pensamientos.enabled = false;
	}


}
