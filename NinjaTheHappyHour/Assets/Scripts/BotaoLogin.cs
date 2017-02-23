using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoLogin : MonoBehaviour {
    Text entradaDeTextoNomeUsuario;
    public GameObject CampoNome;
    public void Start()
    {
         entradaDeTextoNomeUsuario = CampoNome.GetComponent<Text>();
    }
	// Use this for initialization
    public void Login()
    {

        entradaDeTextoNomeUsuario = CampoNome.GetComponent<Text>();
        print(entradaDeTextoNomeUsuario.text);
       
    }

}
