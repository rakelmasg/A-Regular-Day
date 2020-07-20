using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptColeccionablesOficina : MonoBehaviour {

	public bool carpeta, carpetaDejada, monedas;
	public Text pensamientos;
	public Text controles;
	public Text feedback;

	public Animator anim;

	void Start(){
		carpeta = false;
		carpetaDejada = false;
		monedas = false;
		StartCoroutine (ShowMessage 
			("Qué tarde es... pero necesito terminar el informe. Encima me he dejado la CARPETA en la sala de reuniones, tengo que ir a por ella.", 9));	//USA ESTO CADA VEZ QUE QUIERAS MOSTRAR TEXTO DURANTE UNOS SEGUNDOS
		StartCoroutine(ShowControls(10));
		feedback.enabled = false;
	}

	void ActivaCarpeta(){
		StartCoroutine(ShowControls(8));
		carpeta = true;
		Debug.Log ("Carpeta recogida");
		StartCoroutine (ShowFeedback ("Carpeta recogida", 4));
		StartCoroutine (ShowMessage 
			("Volveré a mi MESA a terminar el informe y así podré irme a casa de una vez.", 7));	//USA ESTO CADA VEZ QUE QUIERAS MOSTRAR TEXTO DURANTE UNOS SEGUNDOS
		controles.text = "Utiliza la rueda del ratón para seleccionar la carpeta.";
	}

	void ActivaDejarCarpeta(){
		carpetaDejada = true;
		StartCoroutine (ShowMessage 
			("Me muero de sueño. Debería tomarme un CAFÉ, pero no tengo suelto para la máquina...", 10));
	}

	void ActivaCogerMonedas(){
		monedas = true;
		StartCoroutine (ShowFeedback ("Monedas recogidas", 4));
		StartCoroutine (ShowMessage 
			("Con esto podré sacar un café. Ya se lo devolveré mañana...", 6));
	}

	void CambiaEscena(){
		StartCoroutine(fade ());
	}


	IEnumerator ShowMessage(string message, float delay){
		pensamientos.text = message;
		pensamientos.enabled = true;
		yield return new WaitForSeconds (delay);
		pensamientos.enabled = false;
	}

	IEnumerator ShowControls(float delay){
		controles.enabled = false;
		yield return new WaitForSeconds (delay);
		controles.enabled = true;
		yield return new WaitForSeconds (10);
		controles.enabled = false;
	}

	IEnumerator ShowFeedback(string message, float delay){
		feedback.text = message;
		feedback.enabled = true;
		yield return new WaitForSeconds (delay);
		feedback.enabled = false;
	}

	IEnumerator fade(){
		anim.SetBool ("Fade", true);
		yield return new WaitForSeconds (1.3f);
		SceneManager.LoadScene ("Mundo1");
	}
}
