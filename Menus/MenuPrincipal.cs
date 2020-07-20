/*
	Fecha creación: 25/12/2017 
	Autor: Raquel Mas
	
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

	public void iniciarJuego(){
		SceneManager.LoadScene ("Mundo0");
	}

	public void irAContacto(){
		SceneManager.LoadScene ("Creditos");
	}

	public void irAConfiguracion(){
		SceneManager.LoadScene ("Configuracion");
	}


}
