using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoCenario : MonoBehaviour {


    public string Tipo;
	public Jogador player;
	public bool ParedeIsLeft;



	void  OnCollisionEnter2D(Collision2D x){


		if (Tipo == "Chao") {
			if (x.transform.CompareTag("Player") ) {
			//	print (Tipo);
				Tipo = "Chao";
				player.bloquearMovimentoJogador = false;
			}

		}
		if (Tipo == "Parede") {
			if (x.transform.CompareTag("Player") ) {
				//print (Tipo);
				//Tipo = "Parede";
				player.bloquearMovimentoJogador = true;


				if ((ParedeIsLeft && player.SeraEsquerda)|| ( !ParedeIsLeft && !player.SeraEsquerda )) {
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
			player.bloquearMovimentoJogador = true;
	}
	void OnCollisionStay2D(Collision2D x){
	
		if (Tipo == "Chao" ) {
			if (x.transform.CompareTag("Player") ) {
				//print (Tipo);
				Tipo = "Chao";
				player.bloquearMovimentoJogador = false;
			}

		}



	}
}
