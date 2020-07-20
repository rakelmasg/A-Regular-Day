using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptColeccionablesPiramide : MonoBehaviour {

	public bool palanca, escarabajo, ankh, horus, gema, escarabajoColocado, ankhColocado, horusColocado, gemaColocada, abc;

	public Text feedback;
	public Animator anim;

	public Image fade;

	void Start(){
		palanca = false;
		escarabajo = false;
		ankh = false;
		horus = false;
		gema = false;
		escarabajoColocado = false;
		ankhColocado = false;
		horusColocado = false;
		gemaColocada = false;
		abc = false;
		feedback.enabled = false;

	}

	void ActivaPalanca(){
		palanca = true;
		Debug.Log ("Palanca recogida");
		StartCoroutine (ShowFeedback ("Palanca recogida", 4));
	}

	void ActivaEscarabajo(){
		escarabajo = true;
		Debug.Log ("Escarabajo recogido");
		StartCoroutine (ShowFeedback ("Escarabajo recogido", 4));
	}

	void ActivaAnkh(){
		ankh = true;
		Debug.Log ("Ankh recogido");
		StartCoroutine (ShowFeedback ("Ankh recogido", 4));
	}

	void ActivaHorus(){
		horus = true;
		Debug.Log ("Ojo de Horus recogido");
		StartCoroutine (ShowFeedback ("Ojo de Horus recogido", 4));
	}

	void ActivaAbecedario(){
		abc = true;
		Debug.Log ("Abecedario recogido");
		StartCoroutine (ShowFeedback ("Abecedario recogido", 4));
	}

	void ActivaGema(){
		gema = true;
		Debug.Log ("Gema recogida");
		StartCoroutine (ShowFeedback ("Gema recogida", 4));
	}

	void ColocaEscarabajo(){
		escarabajoColocado = true;
		Debug.Log ("Escarabajo Colocado");
	}

	void ColocaAnkh(){
		ankhColocado = true;
		Debug.Log ("Ankh Colocado");
	}

	void ColocaHorus(){
		horusColocado = true;
		Debug.Log ("Horus Colocado");
	}

	void ColocaGema(){
		gemaColocada = true;
		Debug.Log ("Gema Colocada");
		StartCoroutine(cambiaEscena());
	}

	IEnumerator ShowFeedback(string txt, float tiempo){
		feedback.enabled = true;
		feedback.text = txt;
		yield return new WaitForSeconds (tiempo);
		feedback.enabled = false;
	}


	IEnumerator cambiaEscena(){
		anim.SetBool ("Fade", true);
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("GameOver");
	}


		
}
