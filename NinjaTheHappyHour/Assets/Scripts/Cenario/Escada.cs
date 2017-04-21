using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escada : MonoBehaviour {


	bool jogadorSobreEscada;


	// Use this for initialization
	void Start () {

		jogadorSobreEscada = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (jogadorSobreEscada == true ) {
			MovimentoSimples rj = GameObject.FindGameObjectWithTag ("Player").GetComponent<MovimentoSimples> ();
			rj.dentroDaEscada = true;
		
		//	rj.AtivarGravidade (true);

		} if(jogadorSobreEscada == false ) {
			MovimentoSimples rj = GameObject.FindGameObjectWithTag ("Player").GetComponent<MovimentoSimples> ();
			rj.dentroDaEscada = false;
		}

	}
	void OnTriggerStay2D(Collider2D cl){
		if(cl.gameObject.CompareTag("Player") ){
			if(Input.GetKeyUp(KeyCode.W) )
				jogadorSobreEscada = true;
			//jogador = cl.gameObject;
			//Debug.Log("jogador na escada");
		}
	}
	void OnTriggerExit2D(Collider2D cl){
		if(cl.gameObject.CompareTag("Player") ){
			jogadorSobreEscada = false;

		}
	}
}
