using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataques : MonoBehaviour {
	// CLASSE QUE GERA UM ITEM QUE TEM COMO COMPONENTE DANO GERAL
	// LISTA DE ATAQUES
	public GameObject ataqueEspada ;
	public GameObject tiroTorreta;
	public float forcaTiro;
	public bool maquinaAutoExecutora = false;
	public string tipoArma;
	public Vector3 posicaoTiro;
	public bool isLeft;
	float timer = 0;

	// maquina estado ataque
	public string acaoAtaque;


	void Update(){

		if (maquinaAutoExecutora) {
			if (tipoArma == "canhaoVerde") {


				if (timer < 3) {
					acaoAtaque = "carregandoArma";
					timer += Time.deltaTime;
					}
			}
				if(timer >= 3 ) {
					acaoAtaque = "atirando";
				AtaqueTiroTorreta (posicaoTiro,isLeft);
					timer = 0;
				}


				
		}
	}
	public void AtaqueSabre(Vector3 position,bool Left,string nomeAtaque){


		GameObject espada = Instantiate (ataqueEspada,position,new Quaternion());
		espada.name = nomeAtaque;
		if (Left) {
			Vector3 scaleTmp = espada.transform.localScale;
			scaleTmp.x *= -1;
			espada.transform.localScale = scaleTmp;
		}
	}
	public void AtaqueTiroTorreta(Vector3 position,bool Left){


		GameObject tiro = Instantiate (tiroTorreta, transform.position+position, new Quaternion (0, 0, 0, 0));
			tiro.name = "ataqueTiroTorreta";

			Rigidbody2D rb = tiro.GetComponent<Rigidbody2D> ();
			

			rb.AddForce (new Vector2 (forcaTiro, 0) );
	

			
			tiro.GetComponent<DanoGeral> ().isLeft = isLeft;
			

		if (Left) {
				Vector3 scaleTmp = tiro.transform.localScale;
				scaleTmp.x *= -1;
				tiro.transform.localScale = scaleTmp;

				timer += Time.deltaTime;
			}
		
	}


}
