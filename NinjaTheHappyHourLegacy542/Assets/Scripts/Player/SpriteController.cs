using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {




	public Jogador player;
    public Animator clip;
	// Use this for initialization
	void Start () {


        clip = GetComponent<Animator>();

        //animatorDelegatorPlayer = executarAnimacaoJogador;

	

    }
    public void executarAnimacaoJogador(string executarFuncoes)
    {
        if (executarFuncoes == "Correr")
        {
            clip.SetBool("Running", true);
        }
        if(executarFuncoes == "Parado")
        {
            //print("parado");
            clip.SetBool("Running", false);
        }
		if (executarFuncoes == "Deslizar") {
		
		}
		if (executarFuncoes == "Cair") {

		}
		if (executarFuncoes == "") {

		}
        
    }

}
