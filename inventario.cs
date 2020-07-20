using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventario : MonoBehaviour {
	
	const int orthographicSizeMin = 1;
	const int orthographicSizeMax = 6;
	GameObject[] marcos = new GameObject[5];
	GameObject[] imagenes = new GameObject[5];
	string[] objetos = new string[5];
	int actual = 2, anterior;
	GameObject img;

	void Start(){
		imagenes[0] = GameObject.Find("item1");
		imagenes[1] = GameObject.Find("item2");
		imagenes[2] = GameObject.Find("item3");
		imagenes[3] = GameObject.Find("item4");
		imagenes[4] = GameObject.Find("item5");
		marcos[0] = GameObject.Find("frame1");
		marcos[1] = GameObject.Find("frame2");
		marcos[2] = GameObject.Find("frame3");
		marcos[3] = GameObject.Find("frame4");
		marcos[4] = GameObject.Find("frame5");
		img = GameObject.Find ("Imagen");
		img.SetActive(false);
	} 

	void Update () {
		anterior = actual;
    	if (Input.GetAxis("Mouse ScrollWheel") > 0) 
     	{
			actual--;
    	 }
    	if (Input.GetAxis("Mouse ScrollWheel") < 0) 
    	{
			actual++;
     	}
		if (actual < 0) {
			actual = 4;
		} else if (actual > 4) {
			actual = 0;
		}
		marcos [anterior].GetComponent<Image> ().sprite =  Resources.Load<Sprite>("Images/marco_gris");
		marcos [actual].GetComponent<Image> ().sprite = Resources.Load<Sprite>("Images/marco");
		if (IsSeleccionado ("acertijo")) {
			img.SetActive (true);
			img.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/acertijo");
		} else if (IsSeleccionado ("abecedario")) {
			img.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/abecedario");
			img.SetActive (true);
		} else {
			img.SetActive (false);
		}
	}

	public void AñadirObjeto(string name){
		int pos = 0;
		for (int i = 0; i < objetos.Length; i++) {
			if (objetos [i] == null) {
				objetos [i] = name;
				pos = i;
				break;
			}
		}
		imagenes [pos].GetComponent<Image> ().sprite = Resources.Load<Sprite>("Images/"+name);
	}

	public void QuitarObjeto(string name){
		for (int i = 0; i < objetos.Length; i++) {
			if (objetos [i] == name) {
				objetos [i] = null;
				imagenes [i].GetComponent<Image> ().sprite = Resources.Load<Sprite>("Images/transparente");
				break;
			}
		}
	}

	public bool IsSeleccionado(string name){
		return objetos [actual] == name;
	}

}
