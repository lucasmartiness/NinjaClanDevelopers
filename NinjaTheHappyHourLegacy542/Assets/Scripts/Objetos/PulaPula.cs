using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulaPula : MonoBehaviour {

	Animator animacao;
	// Use this for initialization
	public float tempo;
	bool ativarContador = false;
	//bool ativarAudio = false;
	//AudioClip audio;
	void Start () {
		animacao = GetComponent<Animator> ();
	}

	void Update(){
		ContarTempoAnimacao ();
	}

	void OnTriggerEnter2D(){
		ativarContador = true;
	}
	void ContarTempoAnimacao(){

		if (ativarContador) {
			if (tempo < 1) {
				// ligue a animação

				animacao.SetBool ("AnimarPulaPula", true);
				tempo += Time.deltaTime;

			} else if (tempo > 1) {
				// desligue a animação
				animacao.SetBool ("AnimarPulaPula", false);

				tempo = 0;
				ativarContador = false;
			}
		}

	}
	

}
