using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoGeral : MonoBehaviour
{	
	// se refere as ações da bala ou da espadada
	[SerializeField]
	private string nome;

	[SerializeField]	
	private int dano;

	public bool isLeft;
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
					DadosJogador dj =cl.GetComponent<DadosJogador>();
					dj.dadosJogador.levarDano (dano);
					Destroy (gameObject);
				Debug.Log ("causar dano no jogador");
				}
				if (cl.gameObject.CompareTag ("Chao") ||
					cl.gameObject.CompareTag("ParedeDireita")||
					cl.gameObject.CompareTag("ParedeEsquerda") 
					)
					{
						Destroy (gameObject);
					}
					//if(cl.gameObject.layer
			}

		 // se nome deste ataque for ataque espada simples e a tag for a do inimigo então lhe tire dano
			//Debug.Log ("ataque do jogador no inimigo " + cl.gameObject.name);
			if ( cl.gameObject.CompareTag ("Inimigo") && nome == "AtaqueEspadaSimples")
			{
				
				DadosInimigo di = cl.GetComponent<DadosInimigo>();
				di.levarDano (dano);
				Debug.Log ("acertando o inimigo  "+ cl.name );

			}
			if (cl.name == "AtaqueBalisticoCanhao"&& name == "AtaqueEspadaSimples") {

				//cl.GetComponent<Rigidbody2D>()

				//Destroy (cl.gameObject);
				Debug.Log ("rebater  ");

				DanoGeral dg = cl.GetComponent<DanoGeral> ();
				Rigidbody2D rb = cl.GetComponent<Rigidbody2D> ();

			Random x = new Random();
		
				if (dg.isLeft == true) {
				rb.velocity = new Vector3 (-10,0   );
				rb.rotation = 35;
					//	rb.AddForce (  new Vector3 (1000, 0, 0) );
					dg.isLeft = !dg.isLeft;

				} if (dg.isLeft == false)  {
					rb.velocity = new Vector3 (	10, 0);
				rb.rotation = -35;
					//	rb.AddForce ( new Vector3 (-1000, 0, 0) ) ;
					dg.isLeft = !dg.isLeft;
				}


			}
	}

}
