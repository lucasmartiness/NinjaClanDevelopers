using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent( typeof(Constantes))]


public class DadosJogador : MonoBehaviour {

	// classe de dados como vida ou dano
	[System.Serializable]
	public class DadosJogadorMemoria{

		public int vida = 10;// for debug public
		public int dano;// public for debug
		public string acao1;// public for debug only
		public string tipoMovimento; // public for debug // este especifica se o jogador vai usar movimentos simples como andar pular no chão ou movimentos parede

		public DadosJogadorMemoria(){
			vida = 0;
			dano = 0;
			tipoMovimento = "MovimentoSimples";
		}
		public void levarDano(int Dano){
			vida -= Dano;
		}
		public void setVida(int vida){

			Constantes cs = GameObject.Find ("Sistema").GetComponent<Constantes> ();
			Mathf.Clamp (vida, 0, cs.LimiteVida);

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
			}
			else if (acao == "Parado") {
				this.acao1 = acao;
			}

			else{ Debug.Log("erro, ação não reconhecida: "+acao ) ;}
			//this.acao = acao;
		}
	}

	public DadosJogadorMemoria dadosJogador;


	void Start () {
		dadosJogador = new DadosJogadorMemoria ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



}
