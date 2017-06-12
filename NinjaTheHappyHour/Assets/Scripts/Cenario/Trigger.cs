using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AssemblyCSharp;
public class Trigger : MonoBehaviour {




	public static bool JogadorSobreTrigger = false;
	// Use this for initialization
	public string proxFaze ;
	public string tipo;


	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D x){


		if(x.CompareTag("Player") ) 
			{
			


				JogadorSobreTrigger = true;
				
			if(tipo == "Morte")
				GameObject.Find("Sistema"). GetComponent<Menu> ().SetMenu ("MenuPrincipal");
			
			if (tipo == "TrocarFaze") {
				// se o jogador só tem numero de chances suficientes
				GameObject jogadorX = GameObject.FindGameObjectWithTag ("Player");
				RegrasJogador regras = jogadorX.GetComponent<RegrasJogador> ();
//				regras.chances--;
			//	SceneManager.LoadScene ("Faze1");
				//SceneManager.LoadScene ("");
				GameObject.Find("Sistema"). GetComponent<Menu> ().SetMenu (proxFaze);
			}
		//	SceneManager.UnloadSceneAsync ("Vercao3dCena");
			//
			}
	}
}
