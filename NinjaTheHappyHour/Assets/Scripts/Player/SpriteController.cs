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
		if (executarFuncoes == "Agachar") {
			clip.SetBool ("Idle", false);
			clip.SetBool ("Running", false);
			clip.SetBool ("Jump", false);
			clip.SetBool ("Cair", false);
			clip.SetBool ("Deslizar", false);
			clip.SetBool ("Atacar", false);
			clip.SetBool ("Agachar", true);
		}
		if (executarFuncoes == "Correr") {
			clip.SetBool ("Agachar", false);

			clip.SetBool ("Idle", false);
			clip.SetBool ("Running", true);
			clip.SetBool ("Jump", false);
			clip.SetBool ("Cair", false);
			clip.SetBool ("Deslizar", false);
			clip.SetBool ("Atacar", false);
		} else if (executarFuncoes == "Atacar") {
			clip.SetBool ("Idle", false);
			clip.SetBool ("Agachar", false);
			clip.SetBool ("Running", false);
			clip.SetBool ("Jump", false);
			clip.SetBool ("Cair", false);
			clip.SetBool ("Deslizar", false);
			clip.SetBool ("Atacar", true);
			Debug.Log ("Atacar");
		}
		else if(executarFuncoes == "Parado")
        {
            //print("parado");
			clip.SetBool("Idle",true);
			clip.SetBool ("Agachar", false);
            clip.SetBool("Running", false);
			clip.SetBool ("Jump", false);
			clip.SetBool ("Cair", false);
			clip.SetBool ("Deslizar", false);
			clip.SetBool ("Atacar", false);
        }
		else if (executarFuncoes == "Deslizar") {
			clip.SetBool("Running", false);
			clip.SetBool("Idle",false);
			clip.SetBool("Running", false);
			clip.SetBool ("Jump", false);
			clip.SetBool ("Cair", false);
			clip.SetBool ("Deslizar", true);
			clip.SetBool ("Agachar", false);
			clip.SetBool ("Atacar", false);

		}
		else if (executarFuncoes == "Cair") {
			clip.SetBool("Running", false);
			clip.SetBool("Idle",false);
			clip.SetBool ("Agachar", false);
			clip.SetBool("Jump", false);
			clip.SetBool ("Cair", true);
			clip.SetBool ("Deslizar", false);
			clip.SetBool ("Atacar", false);
		}
		else if (executarFuncoes == "Pular") {
			clip.SetBool ("Running", false);
			clip.SetBool ("Jump", true);
			clip.SetBool ("Idle", false);
			clip.SetBool ("Deslizar", false);
			clip.SetBool ("Atacar", false);
			clip.SetBool ("Agachar", false);
		} else {
			Debug.Log ("erro na animação possivelmente o nome foi digitado errado: "+executarFuncoes);
		}
        
    }

}
