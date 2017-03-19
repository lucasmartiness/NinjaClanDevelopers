using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetPlayName : MonoBehaviour {

    Text textoRef;
	// Use this for initialization
	void Start () {
        textoRef = GetComponent<Text>();
        textoRef.text = BotaoLogin.NomeJogador;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
