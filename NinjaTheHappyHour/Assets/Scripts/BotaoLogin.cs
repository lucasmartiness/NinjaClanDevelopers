using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BotaoLogin : MonoBehaviour {


    public Text entradaDeTextoNomeUsuario;
    public GameObject CampoNome;
    public static string NomeJogador;
    public void Start()
    {
         entradaDeTextoNomeUsuario = CampoNome.GetComponent<Text>();
    }
	// Use this for initialization
    public void Login()
    {
        // Função de butão pressionado
        entradaDeTextoNomeUsuario = CampoNome.GetComponent<Text>();
        NomeJogador = entradaDeTextoNomeUsuario.text.ToString();
        print(entradaDeTextoNomeUsuario.text);
        SceneManager.LoadScene("GamePlayPrototipo");
    }

}
