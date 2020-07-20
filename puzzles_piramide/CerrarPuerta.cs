using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class CerrarPuerta : MonoBehaviour {

	public Text pensamientos;
	private float lerpTime = 1;
	private float currentLerpTime = 0;
	private float distance = 7f;

	private Vector3 startPos;
	private Vector3 endPos;

	private bool cerrar;

	void Start () {
		
		startPos = transform.position;
		endPos = transform.position - Vector3.up * distance;
		cerrar = false;
	}

	void Update(){
		if (cerrar) {
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime >= lerpTime) {
				currentLerpTime = lerpTime;
			}
			float perc = currentLerpTime / lerpTime;
			transform.position = Vector3.Lerp (startPos, endPos, perc);
		}
	}

	void Cerrar(){
		//Sonido
		PlaySound();
		//Fin sonido
		StartCoroutine (ShowMessage ("Parece que estoy atrapado aquí, tendré que buscar la manera de abrir el mural.", 3f));
		cerrar = true;
		StartCoroutine (desactivarCerrar ());
	}


	IEnumerator desactivarCerrar(){
		yield return new WaitForSeconds (10);
		cerrar = false;
	}

	void PlaySound(){
		AudioSource source = GetComponent<AudioSource>();
		source.Play ();
	}

	IEnumerator ShowMessage(string message, float delay){
		pensamientos.text = message;
		pensamientos.enabled = true;
		yield return new WaitForSeconds (delay);
		pensamientos.enabled = false;
	}

}
