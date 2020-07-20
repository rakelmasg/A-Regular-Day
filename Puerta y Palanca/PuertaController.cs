using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaController : MonoBehaviour {

	public GameObject palanca;

	private Vector3 startPos;
	private Vector3 endPos;
	private Vector3 palancaStartRot;
	private Vector3 palancaEndRot;

	private float lerpTime = 3;
	private float currentLerpTime = 0;
	private float distance = 3f;

	private bool abierta = false;
	private bool abrir = false;

	void Start () {
		startPos = transform.position;
		endPos = transform.position + Vector3.up * distance;
		palancaStartRot = palanca.transform.rotation.eulerAngles;
		palancaEndRot = palanca.transform.rotation.eulerAngles + new Vector3 (90f, 0f, 0f);
	}

	void Update () {
		if (abrir) {
			abierta = true;
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime >= lerpTime) {
				currentLerpTime = lerpTime;
			}
			float perc = currentLerpTime / lerpTime;
			float percRotation = currentLerpTime / 0.8f; //la rotación se alarga durante 0.8 seg
			transform.position = Vector3.Lerp (startPos, endPos, perc);
			palanca.transform.eulerAngles = Vector3.Lerp (palancaStartRot, palancaEndRot, percRotation);
		}
	}

	public void Abrir(){
		if (!abierta){
			abrir = true;
			//palanca.transform.Rotate(new Vector3(90f,0f,0f));
		}
	}
}
