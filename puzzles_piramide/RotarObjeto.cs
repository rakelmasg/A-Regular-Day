using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarObjeto : MonoBehaviour {

	void Update () {
		transform.Rotate (new Vector3 (0f, 1f, 0f),Space.World);
	}
}
