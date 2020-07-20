using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinternaSliderController : MonoBehaviour {

	public LinternaController lc;			//Éste script cambia el valor del slider de la linterna de la UI en cada frame
	Slider slider;					//en función del valor "carga" del script LinternaController

	void Start () {
		slider = GetComponent<Slider> ();
	}
	

	void Update () {
		slider.value = lc.carga;
	}
}
