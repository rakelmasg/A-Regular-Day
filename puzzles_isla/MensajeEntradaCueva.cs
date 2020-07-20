using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MensajeEntradaCueva : MonoBehaviour {

	public ScriptColeccionables coleccionables;
	public Text pensamientos;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && !coleccionables.linterna) {
			StartCoroutine(ShowMessage ("Está demasiado oscuro. Necesito algo de luz para ver qué hago.", 6));
		}
	}


	IEnumerator ShowMessage(string txt, float tiempo){
		pensamientos.enabled = true;
		pensamientos.text = txt;
		yield return new WaitForSeconds (tiempo);
		pensamientos.enabled = false;
		Destroy (gameObject);
	}
}
