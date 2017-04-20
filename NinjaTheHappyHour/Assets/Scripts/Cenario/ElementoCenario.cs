using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoCenario : MonoBehaviour {


    public string Tipo;
	public Jogador player;
	public bool ParedeIsLeft;



	void Start(){

		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Jogador>();
		}
	}

	void  OnCollisionEnter2D(Collision2D x){

		if (Tipo == "Escada") {
			player.movimentoId = Jogador.estadoJogador.Correr;
		}

		if (Tipo == "Chao" || Tipo == "Escada") {
			if (x.transform.CompareTag("Player") ) {
			//	print (Tipo);
				Tipo = "Chao";
				player.bloquearPuloVertival = false;
				player.numPulo = 0;
			}

		}
		if (Tipo == "Parede") {
			if (x.transform.CompareTag ("Player")) {
				//print (Tipo);
				//Tipo = "Parede";
				player.numPulo = 0;
				player.bloquearPuloVertival = true;


				if ((ParedeIsLeft && player.SeraEsquerda) || (!ParedeIsLeft && !player.SeraEsquerda)) {
					player.SeraEsquerda = !player.SeraEsquerda;
				
					player.transform.localScale = new Vector2 (player.transform.localScale.x * -1, 1);

				} else {
					player.transform.localScale = new Vector2 (player.transform.localScale.x * 1, 1);
				}
					
			}

		} 

			

	}
	void OnCollisionExit2D(Collision2D x){
		if(x.transform.tag == "Parede")
			player.bloquearPuloVertival = false;// bloqueia o pulo vertical para cima se o jogador estiver na parede

		if (Tipo == "Escada") {
			player.movimentoId = Jogador.estadoJogador.Correr;
		}

	}
	void OnCollisionStay2D(Collision2D x){
	

		if (Tipo == "Escada") {
			player.movimentoId = Jogador.estadoJogador.Correr;
		}

		if (Tipo == "Chao") {
			if (x.transform.CompareTag ("Player")) {
				//print (Tipo);
				player.numPulo = 0; 	
				Tipo = "Chao";
				player.bloquearPuloVertival = false;
				if (player.sobreChao == false) {
					player.sobreChao = true;
				}

			}

		} 


	}
}
