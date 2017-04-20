using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {




	//public Jogador player;
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
			clip.SetBool("Idle",false);
            clip.SetBool("Running", true);
			clip.SetBool("Jump", false);
			clip.SetBool ("Cair", false);
			clip.SetBool ("Deslizar", false);
		}

		else if(executarFuncoes == "Parado")
        {
            //print("parado");
			clip.SetBool("Idle",true);
            clip.SetBool("Running", false);
			clip.SetBool ("Jump", false);
			clip.SetBool ("Cair", false);
			clip.SetBool ("Deslizar", false);
        }
		else if (executarFuncoes == "Deslizar") {
			clip.SetBool("Running", false);
			clip.SetBool("Idle",false);
			clip.SetBool("Running", false);
			clip.SetBool ("Jump", false);
			clip.SetBool ("Cair", false);
			clip.SetBool ("Deslizar", true);

		}
		else if (executarFuncoes == "Cair") {
			clip.SetBool("Running", false);
			clip.SetBool("Idle",false);
			clip.SetBool("Jump", false);
			clip.SetBool ("Cair", true);
			clip.SetBool ("Deslizar", false);
		}
		else if (executarFuncoes == "Pular") {
			clip.SetBool ("Running", false);
			clip.SetBool ("Jump", true);
			clip.SetBool ("Idle", false);
			clip.SetBool ("Deslizar", false);
		} else {
			Debug.Log ("erro na animação possivelmente o nome foi digitado errado: "+executarFuncoes);
		}
        
    }

}
