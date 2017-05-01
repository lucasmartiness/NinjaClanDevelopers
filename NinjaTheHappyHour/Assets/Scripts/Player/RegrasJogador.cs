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
	public MovimentoSimples _movimentoJogador;
	public SpriteController _spriteController;
	public DadosJogador _dadosJogador;
	public GameObject jogadorX;

	void Start () {
		jogadorX = GameObject.FindGameObjectWithTag ("Player");
		// pega o componente do jogador
		_movimentoJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimentoSimples> ();
		_dadosJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<DadosJogador> ();
		_spriteController = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<SpriteController> ();
		//_movimentoJogador.setDirecao ("esquerda");
	}
	
	// Update is called once per frame

	void FixedUpdate()
	{
		// CAPTURAR INPUT 
		CapturarInput ();
	}
	void Update () {





		// REGRAS
		VerificarDirecao();



		/*******************************************************************************************************************************/
		// MAQUINA DE ESTADOS
		/*******************************************************************************************************************************/
		//*******MODO DE ESTADOS ESCORADO NA PAREDE *******************/

		if (_movimentoJogador.getEscoradoParede() &&
			!_movimentoJogador.dentroDaEscada && 
			!_movimentoJogador.getSobreChao()
		)
		{ // se o jogador estiver escorado na parede
		
			_dadosJogador.dadosJogador.setTipoMovimento ("MovimentoParede");
			if (_movimentoJogador.movement.y > 0 || _movimentoJogador.GetComponent<Rigidbody2D> ().velocity.y > 0) { // subindo
				_dadosJogador.dadosJogador.setAcao ("SubindoParede");
			}
			if (_movimentoJogador.movement.y < 0 || _movimentoJogador.GetComponent<Rigidbody2D> ().velocity.y < 0) { // subindo
				_dadosJogador.dadosJogador.setAcao ("DescendoParede");
			}

		
		} 
		if (!_movimentoJogador.getEscoradoParede() )
		  {

				// se jogador estiver na escada
			if (_movimentoJogador.dentroDaEscada) {
				_movimentoJogador.AtivarGravidade (false);
				_dadosJogador.dadosJogador.setTipoMovimento ("MovimentoEscada");
			}
		
			if(!_movimentoJogador.dentroDaEscada){
				_movimentoJogador.AtivarGravidade (true);
				_dadosJogador.dadosJogador.setTipoMovimento ("MovimentoSimples");
			}

		}

		// se o jogador estiver dentro da escada informe a maquina de estados o modo de estado e desligue a gravidade
		/*

		*/
		/**********MODO DE ESTADO NÃO ESCORADO NA PAREDE**************/
		if (!_movimentoJogador.getEscoradoParede() &&
			!_movimentoJogador.dentroDaEscada ) {// se estiver fora da escada e da parede então está no chão

			//MovimentoSimples
			_dadosJogador.dadosJogador.setTipoMovimento ("MovimentoSimples");// SET MODO DE ESTADO OU TIPO DE MOVIMENTO PARA SIMPLES CASO NÃO ESTEJA NA PAREDE
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

		//***************** SE FOR EXECUTADO O DASH **********************/

		// captura movimento e pulo
		// ****** SE MODO DE ESTADO FOR PARA MOVIMENTO SIMPLES ENTÃO CAPTURE TECLAS PARA MOVIMENTO SIMPLES *************/
		if (_dadosJogador.dadosJogador.getTipoMovimento () == "MovimentoSimples" &&
			!_movimentoJogador.dentroDaEscada ) {

			_movimentoJogador.MovimentoHorizontal (Input.GetAxis ("Horizontal"), _movimentoJogador.speed);// aciona o movimento do jogador

			//*****************SE FOR EXECUTADO O PULO ***********************/
			if (Input.GetKeyUp (KeyCode.W)) { // SE FOR EXECUTADO O PULO 

				if (_movimentoJogador.getNumPulos () < 2) // se menos que dois pulos
					_movimentoJogador.Pulo (Vector3.up, _movimentoJogador.jump);

			}
			if (Input.GetKeyUp (KeyCode.LeftShift)) {
				if(_movimentoJogador.getDirecao() == "esquerda")
					_movimentoJogador.dash (Vector3.left,350);
				if(_movimentoJogador.getDirecao() == "direita" ) 
					_movimentoJogador.dash (Vector3.right,350);
			}

			// ****************** SE O JOGADOR SE AGAIXAR ************************/
			if (Input.GetKeyDown(KeyCode.LeftControl)) {
				_movimentoJogador.agachar ();
				_dadosJogador.dadosJogador.acao1 = "Agachado";
			}
			// ****************** SE O JOGADOR SE LEVANTAR ************************/
			if ( Input.GetKeyUp(KeyCode.LeftControl)  ) {
				_movimentoJogador.levantar ();
				_dadosJogador.dadosJogador.acao1 = "Parado";
			}
		} 
		// ********** SE MODO DE ESTADO FOR PARA ESCADA OU JOGADOR SOBRE ESCADA *************/
		if (_dadosJogador.dadosJogador.getTipoMovimento () == "MovimentoEscada") {
			_movimentoJogador.MovimentoVertical (Input.GetAxis ("Vertical"), _movimentoJogador.speed);// aciona o movimento do jogador
			_movimentoJogador.MovimentoHorizontal(Input.GetAxis("Horizontal"),_movimentoJogador.speed);
		}
		// ********** SE MODO DE ESTADO FOR PARA PAREDE OU JOGADOR SOBRE PAREDE *************/
		if (_dadosJogador.dadosJogador.getTipoMovimento () == "MovimentoParede") {
			_movimentoJogador.MovimentoVertical (Input.GetAxis ("Vertical"), _movimentoJogador.speed);// aciona o movimento do jogador

			if ( 
				_movimentoJogador.getNumPulos () < 2 &&
				_movimentoJogador.getDirecaoParede()=="direita" ) 
			{ // SE FOR EXECUTADO O PULO  DA DIREITA PARA ESQUERDA

				if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.S)) {// diagonal inferior
					_movimentoJogador.Pulo (new Vector3 (-1, -1.2f), _movimentoJogador.jump/3);
				}
				else if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.W)) {// diagolan superior
					_movimentoJogador.Pulo (new Vector3 (-1, 1.2f), _movimentoJogador.jump/2);
				}

			}
			if (
				_movimentoJogador.getNumPulos () < 2 &&
				_movimentoJogador.getDirecaoParede() == "esquerda" ) 
			{ // SE FOR EXECUTADO O PULO DA ESQUERDA PARA DIREITA

		
				if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.S)) { // diagonal inferior
					_movimentoJogador.Pulo (new Vector3 (1, -1.2f), _movimentoJogador.jump/3);
				}
				else if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.W)) {// diagonal superior
					_movimentoJogador.Pulo (new Vector3 (1, 1.2f), _movimentoJogador.jump/2);
				}
			}
		}

		/*
		if (_movimentoJogador.movement.x < 0) {
			//_movimentoJogador.setDirecao ("esquerda");

		}
		if (_movimentoJogador.movement.x > 0) {
		//	_movimentoJogador.setDirecao ("direita");
		}
	*/
		// se click de ataque
		if(Input.GetButtonUp("Fire1") ) { 

			// se esquerda aponte o ataque a esquerda
			if (_movimentoJogador.getDirecao() == "esquerda") {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Ataques> ().AtaqueSabre (_movimentoJogador.transform.position + new Vector3(-2,0,0), true,"AtaqueEspadaSimples");
			}
			// se direita aponte o atque a direita
			else{
				GameObject.FindGameObjectWithTag("Player").GetComponent<Ataques>().AtaqueSabre(_movimentoJogador.transform.position + new Vector3(2,0,0),false,"AtaqueEspadaSimples");
				Debug.Log ("fire");
			}
		}
	}

	void VerificarDirecao(){
		
		float velocidade_x = _movimentoJogador.movement.x;


		// se o movimento for ao contrario da direção então inverta
		if(	velocidade_x > 0 && jogadorX.GetComponentInChildren<SpriteRenderer>().flipX == true // flip x true é esquerda
			|| velocidade_x < 0 && jogadorX.GetComponentInChildren<SpriteRenderer>().flipX == false) {// flip x true é direita
			_movimentoJogador.InvertDirecao();

			_spriteController.GetComponent<SpriteRenderer> ().flipX = !_spriteController.GetComponent<SpriteRenderer> ().flipX;
		}

		if (jogadorX.GetComponentInChildren<SpriteRenderer>().flipX == true) {
			_movimentoJogador.setDirecao ("esquerda");

		}
		if (velocidade_x < 0 && jogadorX.GetComponentInChildren<SpriteRenderer>().flipX == false) {
				_movimentoJogador.setDirecao ("direita");
		}

	

	}
}
