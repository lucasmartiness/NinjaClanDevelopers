using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MovimentoSimples)) ]
[RequireComponent(typeof(SpriteController) )]
[RequireComponent(typeof(DadosJogador) ) ]

public class RegrasJogador : MonoBehaviour {
	// ISTO É UMA "CLASSE" so que não na verdade é um codico procedural com classes componente
	// Use this for initialization


	// script do jogador
	MovimentoSimples _movimentoJogador;
	SpriteController _spriteController;
	DadosJogador _dadosJogador;


	void Start () {
		// pega o componente do jogador
		_movimentoJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimentoSimples> ();
		_dadosJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<DadosJogador> ();
		_spriteController = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<SpriteController> ();
		_movimentoJogador.setDirecao ("esquerda");
	}
	
	// Update is called once per frame
	void Update () {


		// CAPTURAR INPUT 
		CapturarInput ();

		// REGRAS
		VerificarDirecao();



		/*******************************************************************************************************************************/
		// MAQUINA DE ESTADOS
		/*******************************************************************************************************************************/
		if (_movimentoJogador.getEscoradoParede()) { // se o jogador estiver escorado na parede
		
			_dadosJogador.dadosJogador.setTipoMovimento ("MovimentoParede");
			if (_movimentoJogador.movement.y > 0 || _movimentoJogador.GetComponent<Rigidbody2D> ().velocity.y > 0) { // subindo
				_dadosJogador.dadosJogador.setAcao ("SubindoParede");
			}
			if (_movimentoJogador.movement.y < 0 || _movimentoJogador.GetComponent<Rigidbody2D> ().velocity.y < 0) { // subindo
				_dadosJogador.dadosJogador.setAcao ("SubindoParede");
			}

		
		} if (!_movimentoJogador.getEscoradoParede()) {

			//MovimentoSimples
			_dadosJogador.dadosJogador.setTipoMovimento ("MovimentoSimples");
			if (Input.GetAxis ("Horizontal") != 0 && _movimentoJogador.movement.y == 0) {		// existe movimento horizontal mas não vertical
				
				_dadosJogador.dadosJogador.setAcao ("AndandoHorizontal");
			}

			if (_movimentoJogador.movement.x == 0 && _movimentoJogador.movement.y == 0) {	// nenhum movimento
				_dadosJogador.dadosJogador.setAcao ("Parado");
			}
			if (_movimentoJogador.movement.y > 0 || _movimentoJogador.GetComponent<Rigidbody2D> ().velocity.y > 0) { // subindo
				_dadosJogador.dadosJogador.setAcao ("PuloSimples");
			}
			if (_movimentoJogador.movement.y < 0 || _movimentoJogador.GetComponent<Rigidbody2D> ().velocity.y < 0) { // subindo
				_dadosJogador.dadosJogador.setAcao ("Caindo");
			}

		}
		/*******************************************************************************************************************************/
		// ESTADOS ANIMAÇÕES
		/*******************************************************************************************************************************/
		if ( _dadosJogador.dadosJogador.getAcao() == "AndandoHorizontal") {
			_spriteController.executarAnimacaoJogador ("Correr");
		}
		if (_dadosJogador.dadosJogador.getAcao() == "Parado" ) {
			_spriteController.executarAnimacaoJogador ("Parado");
		}
		if (_dadosJogador.dadosJogador.getAcao () == "PuloSimples") {
			_spriteController.executarAnimacaoJogador ("Pular");
		}	
		if (_dadosJogador.dadosJogador.getAcao () == "Caindo") {
			_spriteController.executarAnimacaoJogador ("Cair");
		}
		/*******************************************************************************************************************************/
	}


	void CapturarInput(){

		// captura movimento e pulo
		if (_dadosJogador.dadosJogador.getTipoMovimento () == "MovimentoSimples") {

			_movimentoJogador.MovimentoHorizontal (Input.GetAxis ("Horizontal"), _movimentoJogador.speed);// aciona o movimento do jogador

			if (Input.GetKeyUp (KeyCode.W)) { // SE FOR EXECUTADO O PULO 

				if (_movimentoJogador.getNumPulos () < 2) // se menos que dois pulos
					_movimentoJogador.Pulo (Vector3.up, _movimentoJogador.jump);

			}

		} 
		else if (_dadosJogador.dadosJogador.getTipoMovimento () == "MovimentoEscada") {
			_movimentoJogador.MovimentoVertical (Input.GetAxis ("Vertical"), _movimentoJogador.speed);// aciona o movimento do jogador

		}
		else if (_dadosJogador.dadosJogador.getTipoMovimento () == "MovimentoParede") {
			_movimentoJogador.MovimentoVertical (Input.GetAxis ("Vertical"), _movimentoJogador.speed*2);// aciona o movimento do jogador

			if (Input.GetKeyUp (KeyCode.A) &&
				
				_movimentoJogador.getDirecaoParede()=="direita") { // SE FOR EXECUTADO O PULO 

				if (_movimentoJogador.getNumPulos () < 2 ) // se menos que dois pulos
					_movimentoJogador.Pulo (new Vector3(-1,2), _movimentoJogador.jump);

			}
			if (Input.GetKeyUp (KeyCode.D) &&
				
				_movimentoJogador.getDirecaoParede() == "esquerda" ) { // SE FOR EXECUTADO O PULO 

				if (_movimentoJogador.getNumPulos () < 2) // se menos que dois pulos
					_movimentoJogador.Pulo (new Vector3(1,1.2f), _movimentoJogador.jump);

			}
		}


		if (_movimentoJogador.movement.x < 0) {
			//_movimentoJogador.setDirecao ("esquerda");

		}
		if (_movimentoJogador.movement.x > 0) {
		//	_movimentoJogador.setDirecao ("direita");
		}

		// realizar ataque
		if(Input.GetButtonUp("Fire1") ) { 

			// se esquerda aponte o ataque a esquerda
			if (_movimentoJogador.getDirecao() == "esquerda") {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Ataques> ().AtaqueSabre (_movimentoJogador.transform.position + new Vector3(-2,0,0), true);
			}
			// se direita aponte o atque a direita
			else{
				GameObject.FindGameObjectWithTag("Player").GetComponent<Ataques>().AtaqueSabre(_movimentoJogador.transform.position + new Vector3(2,0,0),false);
				Debug.Log ("fire");
			}
		}
	}

	void VerificarDirecao(){
		
		float velocidade_x = _movimentoJogador.movement.x;


		// se o movimento for ao contrario da direção então inverta
		if(	velocidade_x > 0 && _movimentoJogador.getDirecao () == "esquerda" 
			|| velocidade_x < 0 && _movimentoJogador.getDirecao () == "direita") {
			_movimentoJogador.InvertDirecao();

			_spriteController.GetComponent<SpriteRenderer> ().flipX = !_spriteController.GetComponent<SpriteRenderer> ().flipX;
		}

	

	}
}
