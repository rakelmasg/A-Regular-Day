/*
	Fecha creación: 27/12/2017 
	Autor: Raquel Mas
	
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Volver: MonoBehaviour {

	public void volver(){
		SceneManager.LoadScene("MenuPrincipal");
	}

}
