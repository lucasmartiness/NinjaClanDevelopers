using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;


public class DanoGeral : MonoBehaviour
{	

	[SerializeField]
	private string nome;

	[SerializeField]	
	private int dano;

	//private Personagem Inimigo;

	// ataque de acordo com o tipo

	void Update(){

		acaoAtaque ();
		gameObject.name = nome;

	}

	 void acaoAtaque( )
	{
		if(nome=="AtaqueBalisticoCanhao")
			StartCoroutine ("endObject",5.5f);
		if(nome=="AtaqueEspadaSimples")
			StartCoroutine ("endObject",0.5f);
	}

	public void sumir()
	{
		// remover vida inimigo

		// desligar e destruir
		GameObject thisGui = gameObject;
		Destroy (thisGui);
	}
	IEnumerator endObject(float tempo){
	

			for (float x = 0; x < tempo; x += Time.deltaTime) {

				yield return null;
			}
		
		
		sumir();
	}
	void OnTriggerEnter2D(Collider2D cl){

		if (nome == "AtaqueBalisticoCanhao") {
			if (cl.gameObject.CompareTag ("Player")) {
				Debug.Log ("ataque do  inimigo no jogador " +  cl.gameObject.name);
				DadosJogador dj = GameObject.FindGameObjectWithTag ("Player").GetComponent<DadosJogador>();
				dj.dadosJogador.levarDano (dano);
				Destroy (gameObject);
			}
		}
		if (nome == "AtaqueEspadaSimples") {
			//Debug.Log ("ataque do jogador no inimigo " + cl.gameObject.name);
			if (cl.gameObject.CompareTag ("Inimigo")) {
				
				DadosInimigo di = GameObject.Find (cl.name).GetComponent<DadosInimigo>();
				di.levarDano (dano);
			}
		}
	}



}

