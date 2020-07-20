using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptColeccionables : MonoBehaviour {

	public bool botella, reloj, linterna, pala, engranaje, puertaFaro, ejeEngranaje;

	public Text controles;
	public Text pensamientos;
	public Text feedback;

	public Animator anim;

	void Start(){
		botella = false;
		reloj = false;
		linterna = false;
		pala = false;
		engranaje = false;
		puertaFaro = false;
		ejeEngranaje = false;
		controles.enabled = false;
		feedback.enabled = false;
		StartCoroutine (ShowMessage ("Mierda, me he dormido. Un momento, esto no es la oficina...", 6));
	}

	void ActivaBotella(){
		botella = true;
		Debug.Log ("Botella abiertaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
		StartCoroutine(ShowFeedback("Mensaje de la botella recogido",4));
	}

	void ActivaReloj(){
		reloj = true;
		Debug.Log ("Llave del reloj cogida");
		StartCoroutine(ShowFeedback("Llave del reloj obtenida",4));
	}

	void ActivaLinterna(){
		linterna = true;
		Debug.Log ("Linterna recogida");
		StartCoroutine (ShowControls ());
		StartCoroutine(ShowFeedback("Linterna recogida",4));
	}

	void ActivaPala(){
		pala = true;
		Debug.Log ("Pala recogida");
		StartCoroutine(ShowFeedback("Pala recogida",4));
	}

	void ActivaEngranaje(){
		engranaje = true;
		Debug.Log ("Engranaje recogido");
		StartCoroutine(ShowFeedback("Engranaje recogido",4));
	}

	void ActivaPuertaFaro(){
		puertaFaro = true;
		Debug.Log ("Abierta puerta del faro");
	}

	void ActivaEjeEngranaje(){
		ejeEngranaje = true;
		Debug.Log ("Colocado engranaje");
	}

	void ActivaPalanca(){
		Debug.Log ("Palanca girada");
		StartCoroutine (cargaPiramide());
	}

	IEnumerator ShowControls(){
		controles.enabled = true;
		controles.text = "Usa el botón derecho del ratón para encender/apagar la linterna";
		yield return new WaitForSeconds (10);
		controles.enabled = false;
	}

	IEnumerator ShowMessage(string txt, float tiempo){
		pensamientos.enabled = true;
		pensamientos.text = txt;
		yield return new WaitForSeconds (tiempo);
		pensamientos.enabled = false;
	}

	IEnumerator ShowFeedback(string txt, float tiempo){
		feedback.enabled = true;
		feedback.text = txt;
		yield return new WaitForSeconds (tiempo);
		feedback.enabled = false;
	}

	IEnumerator cargaPiramide(){
		anim.SetBool ("FadeBlanco", true);
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("Mundo2");
	}
}
