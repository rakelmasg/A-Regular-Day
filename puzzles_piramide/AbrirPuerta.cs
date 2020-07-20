using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AbrirPuerta : MonoBehaviour {

	private float lerpTime = 1;
	private float currentLerpTime = 0;
	private float distance = 5.5f;

	private Vector3 startPos;
	private Vector3 endPos;

	private bool abrir;

	void Start () {
		startPos = transform.position;
		endPos = transform.position + Vector3.up * distance;
		abrir = false;
	}

	void Update(){
		if (abrir) {
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime >= lerpTime) {
				currentLerpTime = lerpTime;
			}
			float perc = currentLerpTime / lerpTime;
			transform.position = Vector3.Lerp (startPos, endPos, perc);
		}
	}

	void Abrir(){
		//Sonido
		PlaySound();
		//Fin sonido
		abrir = true;
	}
	void PlaySound(){
		AudioSource source = GetComponent<AudioSource>();
		source.Play ();
	}

}

