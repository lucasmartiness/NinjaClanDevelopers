using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {


	public void SetMenu(string menuName){
	//	this.
		SceneManager.LoadScene(menuName);
	}
	public void SairJogo(){

		Application.Quit ();

	}
	public void FecharJanela(GameObject janela){
		GameObject.Destroy(janela);
	}
	public void AbrirJanela(GameObject janela){
		GameObject.Instantiate(janela);



	//	GJanela.SetActive (true);

	}
}
