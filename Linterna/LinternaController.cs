using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinternaController : MonoBehaviour {

	Light linterna;		//El objeto FPSController tiene un objeto hijo llamado Linterna. Éste objeto es al que está asociado
	public float carga;	//éste script. Tiene un componente Light (una luz focal), que es al que llamamos "linterna"

	void Start () {
		linterna = GetComponent<Light> ();	//La luz siempre está activada, y con el script lo que hacemos es regular
		linterna.intensity = 0;			//su intensidad y su carga (el tiempo que podemos tenerla encendida)
		carga = 100;
	}

	void Update () {
		if (Input.GetMouseButtonDown(1)) {		//Si pulsamos click izquierdo, cambiamos la intensidad en función
			if (linterna.intensity == 0) {		//de si la luz está "encendida" (intensidad 10) o "apagada"
				linterna.intensity = 10;	//(intensidad 0)
			} else {
				linterna.intensity = 0;
			}
		}

		if (linterna.intensity == 10) {			//Si está encendida, sustraemos una cantidad de carga en cada 
			carga = carga - 5 * Time.deltaTime;	//unidad de tiempo
		}

		if (carga < 100 && linterna.intensity == 0) {	//Si está apagada y la carga es menor que 100, añadimos una 
			carga = carga + 5 * Time.deltaTime;	//cantidad de carga
			if (carga > 100) {
				carga = 100;			//Nos aseguramos de que la carga nunca sea mayor que 100
			}
		}

		if (carga <= 0) {
			linterna.intensity = 0;			//También nos aseguramos de que la carga nunca sea menor que 0
		}

	}
}
