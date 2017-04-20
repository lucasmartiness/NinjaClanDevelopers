using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadosInimigo : MonoBehaviour {



		public int vida = 50;// for debug public
		//public int dano;// public for debug
		public string acao1;// public for debug only
		public string tipoMovimento; // publi


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (vida == 0)
			Destroy (gameObject);
	}
	public void levarDano(int dano){
		this.vida -= dano;
	}
}
