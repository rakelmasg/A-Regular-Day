using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_columnas : MonoBehaviour {
	private int cont = 1;
	public Image imagenInteractuar;
	public LayerMask objetos;
	private bool complete = false;
	private bool activo = true;

	void Start(){
		(GameObject.Find ("Columna 2")).GetComponent<Renderer> ().material.color = Color.red;
		(GameObject.Find ("Columna 4")).GetComponent<Renderer> ().material.color = Color.red;
		(GameObject.Find ("Columna 6")).GetComponent<Renderer> ().material.color = Color.red;
		(GameObject.Find ("Columna 8")).GetComponent<Renderer> ().material.color = Color.red;
	}



	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera") {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos) ) {
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);
				if (Input.GetMouseButtonDown (0) && activo) {
					accionar ();
				}
			} else {
				imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
			}
		}
	}

	void OnTriggerExit(){
		imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);
	}

	void accionar ()
	{	 
		activo = false;
		Debug.Log ("accionar");
		Material cube_mat = transform.parent.GetComponent<Renderer> ().material;
		Material cube_right_mat = null, cube_left_mat = null;

		if ( transform.parent.name == "Columna 1") {
			cube_right_mat = (GameObject.Find ("Columna 2")).GetComponent<Renderer> ().material;
			cube_left_mat = (GameObject.Find ("Columna 8")).GetComponent<Renderer> ().material;
		} else if (transform.parent.name == "Columna 2") {
			cube_right_mat = (GameObject.Find ("Columna 3")).GetComponent<Renderer> ().material;
			cube_left_mat = GameObject.Find ("Columna 1").GetComponent<Renderer> ().material;
		} else if (transform.parent.name == "Columna 3") {
			cube_right_mat = (GameObject.Find ("Columna 4")).GetComponent<Renderer> ().material;
			cube_left_mat = (GameObject.Find ("Columna 2")).GetComponent<Renderer> ().material;
		} else if (transform.parent.name == "Columna 4") {
			cube_right_mat = (GameObject.Find ("Columna 5")).GetComponent<Renderer> ().material;
			cube_left_mat = (GameObject.Find ("Columna 3")).GetComponent<Renderer> ().material;
		} else if (transform.parent.name == "Columna 5") {
			cube_right_mat = (GameObject.Find ("Columna 6")).GetComponent<Renderer> ().material;
			cube_left_mat = (GameObject.Find ("Columna 4")).GetComponent<Renderer> ().material;
		} else if (transform.parent.name == "Columna 6") {
			cube_right_mat = (GameObject.Find ("Columna 7")).GetComponent<Renderer> ().material;
			cube_left_mat = (GameObject.Find ("Columna 5")).GetComponent<Renderer> ().material;
		} else if (transform.parent.name == "Columna 7") {
			cube_right_mat = (GameObject.Find ("Columna 8")).GetComponent<Renderer> ().material;
			cube_left_mat = (GameObject.Find ("Columna 6")).GetComponent<Renderer> ().material;
		} else {
			cube_right_mat = GameObject.Find ("Columna 1").GetComponent<Renderer> ().material;
			cube_left_mat = (GameObject.Find ("Columna 7")).GetComponent<Renderer> ().material;
		}

		toggleColor (cube_mat);
		toggleColor (cube_right_mat);
		toggleColor (cube_left_mat);

		isDone ();
		StartCoroutine ("Wait");

	}

	void toggleColor(Material m){
		if (m.color == Color.red) {
			m.color=Color.yellow;
		} else {
			m.color=Color.red;
		}
	}

	void isDone(){
		if ((GameObject.Find ("Columna 1")).GetComponent<Renderer> ().material.color == Color.red) {
			if ((GameObject.Find ("Columna 2")).GetComponent<Renderer> ().material.color == Color.red) {
				if ((GameObject.Find ("Columna 3")).GetComponent<Renderer> ().material.color == Color.red) {
					if ((GameObject.Find ("Columna 4")).GetComponent<Renderer> ().material.color == Color.red) {
						if ((GameObject.Find ("Columna 5")).GetComponent<Renderer> ().material.color == Color.red) {
							if ((GameObject.Find ("Columna 6")).GetComponent<Renderer> ().material.color == Color.red) {
								if ((GameObject.Find ("Columna 7")).GetComponent<Renderer> ().material.color == Color.red) {
									if ((GameObject.Find ("Columna 8")).GetComponent<Renderer> ().material.color == Color.red) {
										complete = true;
									}
								}
							}
						}
					}
				}
			}
		}
	}

	void Update(){
		if (complete && cont < 194) {
			(GameObject.Find ("Columnas_puzzle")).transform.Translate (Vector3.down * 1.5f * Time.deltaTime);	
			cont++;
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (0.4f);
		activo = true;
	}
}
