using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiradorPalanca : MonoBehaviour {

	public bool girar;

	private Vector3 palancaStartRot;
	private Vector3 palancaEndRot;
	private float lerpTime = 3;
	private float currentLerpTime = 0;

	void Start () {
		girar = false;
		palancaStartRot = transform.rotation.eulerAngles;
		palancaEndRot = transform.rotation.eulerAngles + new Vector3 (90f, 0f, 0f);
	}

	void Update () {
		if (girar) {
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime >= lerpTime) {
				currentLerpTime = lerpTime;
			}
			float percRotation = currentLerpTime / 0.8f; //la rotación se alarga durante 0.8 seg
			transform.eulerAngles = Vector3.Lerp (palancaStartRot, palancaEndRot, percRotation);
		}
	}
}