using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_botones : MonoBehaviour {

	Puzzle_botones_solucion solucion;
	private bool presionado;
	public LayerMask objetos;
	public Image imagenInteractuar;
	private bool activo = true;

	void Start () {
		solucion = GameObject.Find("BOTONES_PUZZLE").GetComponent<Puzzle_botones_solucion>();
	}

	public void activar(){
		this.transform.parent.transform.Translate(Vector3.left *3f * Time.deltaTime);
		activo = true;
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera") {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos) && activo) {
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				if (Input.GetMouseButtonDown (0) ) {
					activo = false;
					this.transform.parent.transform.Translate (Vector3.right * 3f * Time.deltaTime);
					imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
					StartCoroutine ("añadir");
				}
			} else {
				imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
			}
		}
	}

	void OnTriggerExit(){
		imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
	}

	IEnumerator añadir(){
		yield return new WaitForSeconds (0.2f);
		solucion.Añadir (this.transform.parent.gameObject.name);
	}
		
}
