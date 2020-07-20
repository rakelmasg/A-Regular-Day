using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_botones_solucion : MonoBehaviour {

	string[] clicked = new string[5];
	string[] solution = {"pink_btn","green_btn","purple_btn","orange_btn","grey_btn"};
	int num = 0;
	bool complete=false;
	public GameObject Escarabajo;

	void Start(){
		Escarabajo.gameObject.SetActive (false);
	}

	public void Añadir(string n){
		if (!complete) {
			clicked [num] = n;
			num++;
			isComplete ();
		} else {
			GameObject.Find (n).GetComponentInChildren<Puzzle_botones>().activar();
		}
	}

	void isComplete (){
		if (num==solution.Length) {
			bool correcto = true;
			for (int i = 0; i < solution.Length; i++) {
				if (!clicked [i].Equals (solution [i])) {
					correcto = false;
				}
				GameObject.Find (clicked [i]).GetComponentInChildren<Puzzle_botones>().activar();
			}
			if (correcto) {
				complete = true;
				Escarabajo.gameObject.SetActive(true);
				Debug.Log ("CODIGO CORRECTO");
			} else {
				Debug.Log ("CODIGO INCORRECTO");
				num = 0;
			}
		}
	}
}
