using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalancaFaroController : MonoBehaviour {


	public ScriptColeccionables coleccionables;
	public GiradorPalanca palanca;

	public LayerMask objetos;
	public Image imagenInteractuar;
	public Text pensamientos;

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera") {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {
				Debug.Log ("Mirando a palanca");
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				if (Input.GetMouseButtonDown (0)) {
					if(coleccionables.ejeEngranaje){
						coleccionables.SendMessage ("ActivaPalanca");
						palanca.girar = true;
						Destroy (gameObject);
						imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
					}else{
						StartCoroutine (ShowMessage ("No funciona, parece que está atascada", 4));
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

	IEnumerator ShowMessage(string txt, float tiempo){
		pensamientos.enabled = true;
		pensamientos.text = txt;
		yield return new WaitForSeconds (tiempo);
		pensamientos.enabled = false;
	}
}
