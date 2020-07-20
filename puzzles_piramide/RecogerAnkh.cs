using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class RecogerAnkh : MonoBehaviour {

	//En éste script explicaremos el funcionamiento de los puzzles de todo el juego, ya que todos siguen la misma estructura	
	//en cuanto a scripting
	
	//Los scripts de los puzzles están asociados a triggers que se encuentran alrededor de los objetos con los que el jugador
	//puede interactuar, y que son hijos de dicho objeto. Por ello las funciones que manejan su comportamiento son OnTriggerStay y OnTriggerExit.
	
	public Text pensamientos;		//Pensamientos es el texto de la UI en el que se muestra lo que piensa el personaje
	public ScriptColeccionablesPiramide coleccionables;	//Coleccionables es un script que controla los objetos/puzzles
								//que hemos recogido/resuelto, mediante variables booleanas
	public LayerMask objetos;				//Objetos es la capa del escenario donde se encuentran los objetos con los que podemos interactuar
	public Image imagenInteractuar;				//ImagenInteractuar es la imagen de la mano que se muestra al poder interactuar con un objeto

	void OnTriggerStay(Collider other){
		if (other.tag == "MainCamera") {
			if (Physics.Raycast (other.transform.position, other.transform.forward, 3f, objetos)) {	//Al entrar en el collider, comprobamos si estamos mirando al objeto con el que hay que interactuar mediante un Raycasting desde la cámara
				Debug.Log ("Mirando a ankh");							//Si es así:
				imagenInteractuar.color = new Color (1f, 1f, 1f, 1f);				//Mostramos la imagen de la mano, para que el jugador sepa que puede interactuar con un objeto
				inventario invent = GameObject.Find ("Inventario").GetComponent<inventario> ();	//Si es un puzzle para el que es necesario un objeto concreto, necesitaremos el objeto inventario
				if (Input.GetMouseButtonDown (0)) {
					if(!invent.IsSeleccionado("palanca")){					//Si no tenemos el objeto seleccionado, el jugador dice que necesita ese objeto
						StartCoroutine (ShowMessage ("Voy a necesitar algo para arrancarlo.", 4));
					} else{									//Si lo tiene seleccionado:	
						//Sonido
						PlaySound();							//Suena un efecto de sonido, para que el jugador sepa que ha interactuado con el objeto
						//Fin sonido
						coleccionables.SendMessage ("ActivaAnkh");			//Cambia la variable booleana del script Coleccionables
						Destroy (transform.parent.gameObject, 0.2f);			//Destruye el objeto padre del Trigger, para no poder volver a interactuar con el objeto
						invent.QuitarObjeto ("palanca");				//Quita/añade objetos al inventario si procede
						invent.AñadirObjeto ("ankh");
						imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);		//Pone la imagen de la mano totalmente invisible
					}
			} else {
				imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);				//Si estás en el collider pero no mirando al objeto, transparenta la imagen de la mano
				}
			}
		}
	}


	void OnTriggerExit(){
		imagenInteractuar.color = new Color (1f, 1f, 1f, 0f);		//Si sales del collider sin interactuar con el objeto, transparenta la imagen de la mano
	}

	void PlaySound(){							//Script que reproduce el sonido
		AudioSource source = GetComponent<AudioSource>();
		source.Play ();
	}

	IEnumerator ShowMessage(string message, float delay){			//Script que permite mostrar texto (los "pensamientos") durante un tiempo determinado usando Corutinas
		pensamientos.text = message;
		pensamientos.enabled = true;
		yield return new WaitForSeconds (delay);
		pensamientos.enabled = false;
	}


}
