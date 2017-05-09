using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaPerseguicao : MonoBehaviour {

	GameObject inimigo;
	void OnTriggerEnter2D(Collider2D cl)
	{
		// se jogador entrar na area de perseguição

		if (cl.CompareTag ("Player")) {
		

			if (inimigo != null && inimigo.tag == "Inimigo") {
				inimigo.gameObject.GetComponent<MovimentoInimigo> ().dentroAreaPerseguicao = true;
			}
		} else { // se inimigo colidir no trigger da area de perseguição
			if(cl.gameObject != null)
				inimigo = cl.gameObject;
		}

	}

	void OnTriggerStay2D(Collider2D cl)
	{
		// se inimigo estiver na area de perseguição
		if(cl.CompareTag("Inimigo") ){
			if(cl.gameObject != null)
			inimigo = cl.gameObject;


			cl.gameObject.GetComponent<MovimentoInimigo>().dentroAreaPerseguicao = true;
		}

	}
	void OnTriggerExit2D(Collider2D cl)
	{
		// se inimigo sair da area de perseguição
		if(cl.gameObject != null)
		if(cl.CompareTag("Inimigo") ){
			cl.gameObject.GetComponent<MovimentoInimigo>().dentroAreaPerseguicao = false;
		}
	}
}
