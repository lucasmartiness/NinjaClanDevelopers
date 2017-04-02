using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;


public class DanoEspada : MonoBehaviour
{	

	[SerializeField]
	private string nome;

	[SerializeField]	
	private int dano;

	//private Personagem Inimigo;
	private GameObject inimigo;

	// ataque de acordo com o tipo

	void Update(){

		acaoAtaque ();


	}

	 void acaoAtaque( )
	{
		
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
	void OnCollisionEnter(Collision cl){
		if (!cl.gameObject.CompareTag ("Player")) {
			//StartCoroutine ("endObject",0.5f);
		}
	}



}

