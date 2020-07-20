using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sonido : MonoBehaviour {

	public Button sonido;

	void Start(){
		if(AudioListener.volume > 0f){
			sonido.GetComponent<Image> ().sprite = Resources.Load<Sprite>("Images/sonido_activo");
		}else{
			sonido.GetComponent<Image> ().sprite = Resources.Load<Sprite>("Images/sonido_desactivado");
		}
	}

	public void alternar(){
		if(AudioListener.volume > 0f){
			sonido.GetComponent<Image> ().sprite = Resources.Load<Sprite>("Images/sonido_desactivado");
			AudioListener.volume = 0f;
		}else{
			sonido.GetComponent<Image> ().sprite = Resources.Load<Sprite>("Images/sonido_activo");
			AudioListener.volume = 1f;

		}

	}
}
