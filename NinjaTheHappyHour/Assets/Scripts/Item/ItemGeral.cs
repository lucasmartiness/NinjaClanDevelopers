using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;


public class ItemGeral : MonoBehaviour
{	

	[SerializeField]
	public string nome;

	public string efeito;
	//private Personagem Inimigo;
	public int quantidade;
	// ataque de acordo com o tipo

	void Update(){

		animacaoItem ();
		gameObject.name = nome;

	}

	void animacaoItem( )
	{
		
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
	void Efeito(){
		if(efeito == "adicionarVidaJogador"){
			DadosJogador dj = GameObject.FindGameObjectWithTag ("Player").GetComponent<DadosJogador>();
			dj.dadosJogador.adicionarVida ( quantidade);
		}
		else{
			Debug.Log("efeito irregular verifique erro de digitação");
		}

	}
	void OnTriggerEnter2D(Collider2D cl){


			if (cl.gameObject.CompareTag ("Player")) {
			//	Debug.Log ("jogador pegou o item de nome: " + nome);
				Efeito ();
				//dj.dadosJogador.levarDano (dano);
				Destroy (gameObject);
			}

	}



}

