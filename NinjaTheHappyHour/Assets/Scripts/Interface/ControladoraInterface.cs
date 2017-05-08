using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControladoraInterface : MonoBehaviour {

	//public ArrayList  coracoes ; // lista de corações
	public   GameObject Coracao1;
	public   GameObject Coracao2;
	public   GameObject Coracao3;
	public   GameObject Coracao4;
	public   GameObject CoracaoM;
	// Use this for initialization
	//private Vector3 LastCoracaoPosition = new Vector3(-528,244,0);


	GameObject jogador;

	void Start () {
		jogador = GameObject.FindGameObjectWithTag ("Player");

		// seta os valores correspondentes ao estado do coração por exemplo 9 para coração danificado 10 para coração integro e os outros valores o coração fica invisivel
		CoracaoM.GetComponent<CoracaoUI> ().setRegrasCoracao (9, 10);

		Coracao4.GetComponent<CoracaoUI> ().setRegrasCoracao (7, 10);

		Coracao3.GetComponent<CoracaoUI> ().setRegrasCoracao (5, 10);

		Coracao2.GetComponent<CoracaoUI> ().setRegrasCoracao (3, 10);

		Coracao1.GetComponent<CoracaoUI> ().setRegrasCoracao (1,10);

	}
	
	// Update is called once per frame
	void Update () {

		//,

		Coracao1.GetComponent<CoracaoUI> ().updateRegrasCoracao ( jogador.GetComponent<DadosJogador> ().dadosJogador.getVida ());
		Coracao2.GetComponent<CoracaoUI> ().updateRegrasCoracao ( jogador.GetComponent<DadosJogador> ().dadosJogador.getVida ());

		Coracao3.GetComponent<CoracaoUI> ().updateRegrasCoracao ( jogador.GetComponent<DadosJogador> ().dadosJogador.getVida ());

		Coracao4.GetComponent<CoracaoUI> ().updateRegrasCoracao ( jogador.GetComponent<DadosJogador> ().dadosJogador.getVida ());

		CoracaoM.GetComponent<CoracaoUI> ().updateRegrasCoracao ( jogador.GetComponent<DadosJogador> ().dadosJogador.getVida ());

	}


}
