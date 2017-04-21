using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DadosJogador : MonoBehaviour {

	public int LimiteVida ;
	// classe de dados como vida ou dano
	[System.Serializable]
	public class DadosJogadorMemoria{

		public int vida ;// for debug public
		public int dano;// public for debug
		public string acao1;// public for debug only
		public string tipoMovimento; // public for debug // este especifica se o jogador vai usar movimentos simples como andar pular no chão ou movimentos parede

	
		public void levarDano(int Dano){
			vida -= Dano;
		}
		public void adicionarVida(int Vida){
			vida += Vida;
		}
		public void setVida(int vida){

			this.vida = vida;
		}
		public int getVida(){
			return vida;
		}

		public string getAcao(){
			return acao1;
		}
		public void setTipoMovimento(string tipoMovimento){
			this.tipoMovimento = tipoMovimento;
		}
		public string getTipoMovimento(){
			return tipoMovimento;
		}
		public void setAcao(string acao){

			if (acao == "AndandoHorizontal") {
				this.acao1 = acao;
			} else if (acao == "PuloSimples") {
				this.acao1 = acao;
			} else if (acao == "Caindo") {
				this.acao1 = acao;
			} else if (acao == "Parado") {
				this.acao1 = acao;
			} else if (acao == "Agachado" || acao == "Agaixado" || acao == "Agaichado") {
				this.acao1 = acao;
			}

			else{ Debug.Log("erro, ação não reconhecida: "+acao ) ;}
			//this.acao = acao;
		}
	}

	public DadosJogadorMemoria dadosJogador;


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	//	Constantes cs = GameObject.Find ("Sistema").GetComponent<Constantes> ();
		dadosJogador.vida = Mathf.Clamp (dadosJogador.vida, 0, LimiteVida);
	}



}
