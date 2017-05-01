using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : MonoBehaviour {

	// Use this for initialization

	public string movimentoID;

	public Vector3 posInicial;
	public Vector3 posFinal;
	bool esquerda = false;
	public int distancia;
	public	float velocidade;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (movimentoID == "andar") 
		{
			MovimentarPeloId ( distancia);
		}
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
