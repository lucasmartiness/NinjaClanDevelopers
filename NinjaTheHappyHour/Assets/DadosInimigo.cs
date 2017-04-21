using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Ataques))]
public class DadosInimigo : MonoBehaviour {



		public int vida ;// for debug public
		//public int dano;// public for debug
		public string acao1;// public for debug only
		Ataques _ataqueInimigo;
		
	// Use this for initialization
	void Start () {
		_ataqueInimigo = GetComponent<Ataques> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (_ataqueInimigo.maquinaAutoExecutora)
			//************  SE O INIMIGO TIVER UMA AMRA DO TIPO CANHÃO VERDE Q ESTIVER ATIRANDO ENTÃO ATAQUE
			if (_ataqueInimigo.tipoArma == "canhaoVerde") {
					

				if (_ataqueInimigo.acaoAtaque == "atirando") {
						// executar animação de tiro para arma
					Animator anim = GetComponentInChildren<Animator>();
					anim.Play ("Idle");
				//	Debug.Log ("atirando");
				//Animator cl;

					acao1 = "atirando";
				}
			if (_ataqueInimigo.acaoAtaque == "carregandoArma") {
				// executar animação de carregando 
				Animator anim = GetComponentInChildren<Animator> ();
				anim.Play ("Tiro");
				acao1 = "esperando";
				//Debug.Log ("esperando");
			} 
			else {
				Debug.Log ("falha acao ataque");
			}

			}
						
			


		if (vida == 0)
			Destroy (gameObject);
	}
	public void levarDano(int dano){
		this.vida -= dano;
	}
}
