using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public  int chances ;

	public static RegrasJogador regrasJogador;


	void Start(){
		
		//
		DontDestroyOnLoad (gameObject);


		if (regrasJogador != null) {

			Destroy (gameObject);

		}
		else{


			regrasJogador = this;
			//
			regrasJogador.chances = 2;


		}


		regrasJogador.jogadorX = GameObject.FindGameObjectWithTag ("Player");
		// pega o componente do jogador
		regrasJogador._movimentoJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimentoSimples> ();
		regrasJogador._dadosJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<DadosJogador> ();
		regrasJogador._spriteController = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<SpriteController> ();
		//_movimentoJogador.setDirecao ("esquerda");
		regrasJogador._dadosJogador.dadosJogador.setVida (6);



	}

	
	// Update is called once per frame
	public void DestruirAoSair(){
		Destroy(gameObject);
	}
	void FixedUpdate()
	{
		GameObject.Find ("contadorChances").GetComponent<Text> ().text = chances.ToString ();
		if (_movimentoJogador != null
		    && _spriteController != null
		    && _dadosJogador != null
		    && jogadorX != null) {


			// CAPTURAR INPUT 
			CapturarInput ();
		//	Debug.Log ("quantidade de chances: " + chances);
		}
	}
	void ExecutarRegrasJogador(){



		// REGRAS
		VerificarDirecao();

		if (regrasJogador._dadosJogador.dadosJogador.vida <= 0) {

			// se o jogador tem algum check point com as informações gravadas e numero de chances suficientes

			// se o jogador só tem numero de chances suficientes
			regrasJogador._dadosJogador.dadosJogador.vida = 6;
			regrasJogador.chances--;
			SceneManager.LoadScene ("Faze1");
			// se o jogador não tem chances não então execute denovo a cena ou chame game over
			if (chances <= 0) {
			//	Debug.Log ("FIM DA FAZE chances = " + regrasJogador.chances);
				Destroy (gameObject);
				SceneManager.LoadScene ("MenuPrincipal");

			}
			//SceneManager.LoadScene ("PrototipoBasico4");

		}

		/*******************************************************************************************************************************/
		// MAQUINA DE ESTADOS
		/*******************************************************************************************************************************/
		//*******MODO DE ESTADOS ESCORADO NA PAREDE *******************/

		if (regrasJogador._movimentoJogador.getEscoradoParede() &&
			!regrasJogador._movimentoJogador.dentroDaEscada && 
			!regrasJogador._movimentoJogador.getSobreChao()
		)
		{ // se o jogador estiver escorado na parede

			//Rigidbody2D rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D> ();
			//rb.velocity = new Vector2 (rb.velocity.x, 0);
			//Debug.Log ("teste colisão com parede");
			// desligado o movimento se subir parede
			// desligado o movimento se subir parede
			// desligado o movimento se subir parede
			// desligado o movimento se subir parede
			regrasJogador._dadosJogador.dadosJogador.setTipoMovimento ("MovimentoParede");
			if (regrasJogador._movimentoJogador.movement.y > 0 || regrasJogador._movimentoJogador.GetComponent<Rigidbody2D> ().velocity.y > 0) { // subindo
				//_dadosJogador.dadosJogador.setAcao ("SubindoParede");
			}
			if (regrasJogador._movimentoJogador.movement.y < 0 || regrasJogador._movimentoJogador.GetComponent<Rigidbody2D> ().velocity.y < 0) { // subindo
				//regrasJogador._dadosJogador.dadosJogador.setAcao ("DescendoParede");
			}


		} 
		if (!regrasJogador._movimentoJogador.getEscoradoParede() )
		{

			// se jogador estiver na escada
			if (regrasJogador._movimentoJogador.dentroDaEscada) {
				regrasJogador._movimentoJogador.AtivarGravidade (false);
				regrasJogador._dadosJogador.dadosJogador.setTipoMovimento ("MovimentoEscada");
			}

			if(!regrasJogador._movimentoJogador.dentroDaEscada){
				regrasJogador._movimentoJogador.AtivarGravidade (true);
				regrasJogador._dadosJogador.dadosJogador.setTipoMovimento ("MovimentoSimples");
			}

		}

		// se o jogador estiver dentro da escada informe a maquina de estados o modo de estado e desligue a gravidade
		/*

		*/
		/**********MODO DE ESTADO NÃO ESCORADO NA PAREDE**************/
		// se estiver fora da escada e da parede então está no chão
		if (!regrasJogador._movimentoJogador.getEscoradoParede() &&
			!regrasJogador._movimentoJogador.dentroDaEscada ) {

			//MovimentoSimples
			regrasJogador._dadosJogador.dadosJogador.setTipoMovimento ("MovimentoSimples");// SET MODO DE ESTADO OU TIPO DE MOVIMENTO PARA SIMPLES CASO NÃO ESTEJA NA PAREDE



			if (Input.GetAxis ("Horizontal") != 0 &&regrasJogador._movimentoJogador.movement.y == 0) {		// existe movimento horizontal mas não vertical

				regrasJogador._dadosJogador.dadosJogador.setAcao ("AndandoHorizontal");
			}

			if (regrasJogador._movimentoJogador.movement.x == 0 && regrasJogador._movimentoJogador.movement.y == 0) {	// nenhum movimento
				regrasJogador._dadosJogador.dadosJogador.setAcao ("Parado");
			}
			if (regrasJogador._movimentoJogador.movement.y > 0 || regrasJogador._movimentoJogador.GetComponent<Rigidbody2D> ().velocity.y > 0) { // subindo
				regrasJogador._dadosJogador.dadosJogador.setAcao ("PuloSimples");
			}
			if (regrasJogador._movimentoJogador.movement.y < 0 || regrasJogador._movimentoJogador.GetComponent<Rigidbody2D> ().velocity.y < 0) { // subindo
				regrasJogador._dadosJogador.dadosJogador.setAcao ("Caindo");
			}

			if (Input.GetButton ("Fire1")) {
			regrasJogador._dadosJogador.dadosJogador.setAcao ("Atacar");
			} 
			if (Input.GetKey ( KeyCode .S) ) {
				regrasJogador._dadosJogador.dadosJogador.setAcao ("Agachar");
			}


		}
		/*******************************************************************************************************************************/
		// ESTADOS ANIMAÇÕES
		/*******************************************************************************************************************************/

		if ( regrasJogador._dadosJogador.dadosJogador.getAcao() == "AndandoHorizontal") {
			regrasJogador._spriteController.executarAnimacaoJogador ("Correr");
		}
		if (regrasJogador._dadosJogador.dadosJogador.getAcao() == "Parado" ) {
			regrasJogador._spriteController.executarAnimacaoJogador ("Parado");
		}
		if (regrasJogador._dadosJogador.dadosJogador.getAcao () == "PuloSimples") {
			regrasJogador._spriteController.executarAnimacaoJogador ("Pular");
		}	
		if (regrasJogador._dadosJogador.dadosJogador.getAcao () == "Caindo") {
			regrasJogador._spriteController.executarAnimacaoJogador ("Cair");
		}
	
		if (regrasJogador._dadosJogador.dadosJogador.getAcao () == "Atacar") {
			regrasJogador._spriteController.executarAnimacaoJogador ("Atacar");
		}

		if (regrasJogador._dadosJogador.dadosJogador.getAcao () == "Agachar") {
			regrasJogador._spriteController.executarAnimacaoJogador ("Agachar");
		}
		/*******************************************************************************************************************************/



	}
	void Update () {


		if (_movimentoJogador != null
		   && _spriteController != null
		   && _dadosJogador != null
		   && jogadorX != null) {
			ExecutarRegrasJogador ();
		}
	}


	void CapturarInput(){

		//***************** SE FOR EXECUTADO O DASH **********************/

		// captura movimento e pulo
		// ****** SE MODO DE ESTADO FOR PARA MOVIMENTO SIMPLES ENTÃO CAPTURE TECLAS PARA MOVIMENTO SIMPLES *************/

		if (regrasJogador._dadosJogador.dadosJogador.getTipoMovimento () == "Ataque") {
		
		}

		if (regrasJogador._dadosJogador.dadosJogador.getTipoMovimento () == "MovimentoSimples" &&
			!regrasJogador._movimentoJogador.dentroDaEscada ) {


			if (regrasJogador._dadosJogador.dadosJogador.getAcao () != "Agachar" )
			regrasJogador._movimentoJogador.MovimentoHorizontal (Input.GetAxis ("Horizontal"), regrasJogador._movimentoJogador.speed);// aciona o movimento do jogador

			//*****************SE FOR EXECUTADO O PULO ***********************/
			if (Input.GetKeyDown (KeyCode.W)) { // SE FOR EXECUTADO O PULO 

				if (regrasJogador._movimentoJogador.getNumPulos () < 2) // se menos que dois pulos
					regrasJogador._movimentoJogador.Pulo (Vector3.up, regrasJogador._movimentoJogador.jump);

			}
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				if(regrasJogador._movimentoJogador.getDirecao() == "esquerda")
					regrasJogador._movimentoJogador.dash (Vector3.left,regrasJogador._movimentoJogador.dashpower);
				if(regrasJogador._movimentoJogador.getDirecao() == "direita" ) 
					regrasJogador._movimentoJogador.dash (Vector3.right,regrasJogador._movimentoJogador.dashpower);
			}

			// ****************** SE O JOGADOR SE AGAIXAR ************************/
			if (Input.GetKeyDown(KeyCode.S)) {
				regrasJogador._movimentoJogador.agachar ();
				regrasJogador._dadosJogador.dadosJogador.acao1 = "Agachar";
				regrasJogador._dadosJogador.dadosJogador. setAcao ("Agachar");
			}
			// ****************** SE O JOGADOR SE LEVANTAR ************************/
			if ( Input.GetKeyUp(KeyCode.S)  ) {
				regrasJogador._movimentoJogador.levantar ();
				regrasJogador._dadosJogador.dadosJogador.acao1 = "Parado";
			}
			if (!Input.GetKey (KeyCode.S)) {
				regrasJogador._movimentoJogador.levantar ();
			}
		} 
		// ********** SE MODO DE ESTADO FOR PARA ESCADA OU JOGADOR SOBRE ESCADA *************/
		if (regrasJogador._dadosJogador.dadosJogador.getTipoMovimento () == "MovimentoEscada") {
			regrasJogador._movimentoJogador.MovimentoVertical (Input.GetAxis ("Vertical"), _movimentoJogador.speed);// aciona o movimento do jogador
			regrasJogador._movimentoJogador.MovimentoHorizontal(Input.GetAxis("Horizontal"),_movimentoJogador.speed);
		}
		// ********** SE MODO DE ESTADO FOR PARA PAREDE OU JOGADOR SOBRE PAREDE *************/
		if (regrasJogador._dadosJogador.dadosJogador.getTipoMovimento () == "MovimentoParede") {
			//regrasJogador._movimentoJogador.MovimentoVertical (Input.GetAxis ("Vertical"), regrasJogador._movimentoJogador.speed);// aciona o movimento do jogador

			if ( 
				regrasJogador._movimentoJogador.getNumPulos () < 2 &&
				regrasJogador._movimentoJogador.getDirecaoParede()=="direita" ) 
			{ // SE FOR EXECUTADO O PULO  DA DIREITA PARA ESQUERDA

				if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.S)) {// diagonal inferior
					regrasJogador._movimentoJogador.Pulo (new Vector3 (-1, -1.2f), regrasJogador._movimentoJogador.jump/3);
				}
				else if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.W)) {// diagolan superior
					regrasJogador._movimentoJogador.Pulo (new Vector3 (-1, 1.2f), regrasJogador._movimentoJogador.jump/2);
				}


			}
			if (
				regrasJogador._movimentoJogador.getNumPulos () < 2 &&
				regrasJogador._movimentoJogador.getDirecaoParede() == "esquerda" ) 
			{ // SE FOR EXECUTADO O PULO DA ESQUERDA PARA DIREITA

		
				if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.S)) { // diagonal inferior
					regrasJogador.	_movimentoJogador.Pulo (new Vector3 (1, -1.2f), _movimentoJogador.jump/3);
				}
				else if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.W)) {// diagonal superior
					regrasJogador._movimentoJogador.Pulo (new Vector3 (1, 1.2f),regrasJogador. _movimentoJogador.jump/2);
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
		if(Input.GetButtonUp("Fire1") && !regrasJogador._movimentoJogador.escoradoNaParede ) { 
		//	regrasJogador._dadosJogador.dadosJogador.setAcao ("Atacar");
			regrasJogador._spriteController.executarAnimacaoJogador ("Atacar");
			// se esquerda aponte o ataque a esquerda
			if (regrasJogador._movimentoJogador.getDirecao() == "esquerda") {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Ataques> ().AtaqueSabre (regrasJogador._movimentoJogador.transform.position + new Vector3(-2,0,0), true,"AtaqueEspadaSimples");
			}
			// se direita aponte o atque a direita
			else{
				GameObject.FindGameObjectWithTag("Player").GetComponent<Ataques>().AtaqueSabre(regrasJogador._movimentoJogador.transform.position + new Vector3(2,0,0),false,"AtaqueEspadaSimples");
				Debug.Log ("fire");
			}
		}

	}

	void VerificarDirecao(){
		
		float velocidade_x = regrasJogador._movimentoJogador.movement.x;


		// se o movimento for ao contrario da direção então inverta
		if(	velocidade_x > 0 && regrasJogador.jogadorX.GetComponentInChildren<SpriteRenderer>().flipX == true // flip x true é esquerda
			|| velocidade_x < 0 && regrasJogador.jogadorX.GetComponentInChildren<SpriteRenderer>().flipX == false) {// flip x true é direita
			regrasJogador._movimentoJogador.InvertDirecao();

			regrasJogador._spriteController.GetComponent<SpriteRenderer> ().flipX = !regrasJogador._spriteController.GetComponent<SpriteRenderer> ().flipX;
		}

		if (regrasJogador.jogadorX.GetComponentInChildren<SpriteRenderer>().flipX == true) {
			regrasJogador._movimentoJogador.setDirecao ("esquerda");

		}
		if (velocidade_x < 0 && regrasJogador.jogadorX.GetComponentInChildren<SpriteRenderer>().flipX == false) {
			regrasJogador._movimentoJogador.setDirecao ("direita");
		}

	

	}
}
