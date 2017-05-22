using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(DadosInimigo)) ]
[RequireComponent(typeof(Animator)) ]
public class MovimentoInimigo : MonoBehaviour {

	// Use this for initialization

	public string movimentoID;
	float timer;
	public Vector3 posInicial;
	public Vector3 posFinal;
	bool esquerda = false;
	public int distancia;
	public	float velocidade;
	public float DistanciaPerseguicao;
	public float DistanciaAtaqueInimigoPerseguidor;
	public bool dentroAreaPerseguicao;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

			

		// regras do inimigo perseguidor
			if (GetComponent<DadosInimigo> ().tipoInimigo == "perseguidor" ) {
				
				ChecarDistanciaJogador ();
				if (movimentoID == "perseguindo") {
					GetComponentInChildren<Animator> ().SetBool ("Perseguir", true);
				} else {
					GetComponentInChildren<Animator> ().SetBool ("Perseguir", false);
				}
			} 


		// regras do inimigo atirador
			else if (GetComponent<DadosInimigo> ().tipoInimigo == "atiradorParado") {


			} 
			else {
			
				if (movimentoID == "andar") 
				{
					MovimentarPeloId ( distancia);
				}
			}
	}
	void ChecarDistanciaJogador(){
		
		GameObject jogador = GameObject.FindGameObjectWithTag ("Player");
		Vector3 distanciaDoJogador = jogador.transform.position - transform.position;

		// **************************************************************************************//
		// perseguir jogador 
		// **************************************************************************************//

		if (distanciaDoJogador.x <  DistanciaPerseguicao && distanciaDoJogador.x > -DistanciaPerseguicao
			&& distanciaDoJogador.y < 5 && distanciaDoJogador.y > -5) 
		{

			PerseguirPeloId (jogador,distanciaDoJogador);
			//Debug.Log ("perto");
		}
		// **************************************************************************************//
		// criar ataque do inimigo contra o jogador
		// **************************************************************************************//

		if (timer < 3) {
			
			timer += Time.deltaTime;
		}
	
		if (timer >= 3) {


			movimentoID = "atacando";

			timer = 0;

			if (distanciaDoJogador.x/4 <  0  && distanciaDoJogador.y < 5 && distanciaDoJogador.y > -5 )

			{
				// criar ataque
				// mudar direção do ataque para esquerda - new Vector3(1.5f,0,0)
				GetComponent<Ataques>().AtaqueSabre(transform.position - new Vector3(1.5f,0,0),true,"AtaqueEspadaInimigo");
				//Debug.Log ("perto");
			}
			// // mudar direção do ataque para direita new Vector3(1.5f,0,0)
			if ( distanciaDoJogador.x/4 > 0 && distanciaDoJogador.y < 5 && distanciaDoJogador.y > -5 )  {
				GetComponent<Ataques>().AtaqueSabre(transform.position+new Vector3(1.5f,0,0),false,"AtaqueEspadaInimigo");

			}
		}

	}
	void PerseguirPeloId(GameObject alvo,Vector3 distanciaJogador){


		// animar jogador para andar


		// pega o sprite renderer para mudar sua direção caso precise 
		if (distanciaJogador.x > 0) {
			GetComponentInChildren<SpriteRenderer> ().flipX = false;// esquerda

		} else {
			GetComponentInChildren<SpriteRenderer> ().flipX = true;// direita

		}
	//	Debug.Log (distanciaJogador.x);
		distanciaJogador.y = 0;

		if (dentroAreaPerseguicao) {
			transform.Translate (distanciaJogador * Time.deltaTime);
			movimentoID = "perseguindo";
		}
		// persegue o jogador

	}


	void MovimentarPeloId(int distancia)
	{
		
		posFinal = posInicial;
		posFinal.x = posInicial.x + distancia;


		if (esquerda == true) {

			transform.Translate (new Vector3 (-velocidade, 0, 0));

				if (
					transform.position.x <= posInicial.x && 
					transform.position.x >= posInicial.x - 2
					) 
				{
					esquerda = false;
				GetComponentInChildren<SpriteRenderer> ().flipX = false;
				}
		}
		if (esquerda == false) {


			transform.Translate (new Vector3 (velocidade, 0, 0));

				if (
					transform.position.x >= posFinal.x &&
					transform.position.x <= posFinal.x + 2
					)
				{
					esquerda = true;
					GetComponentInChildren<SpriteRenderer> ().flipX = true;
				}
		}
	}


}
