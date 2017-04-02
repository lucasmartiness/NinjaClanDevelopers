using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MorteTrigger : MonoBehaviour {


	public static bool JogadorSobreTrigger = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D x){
		if(x.CompareTag("Player") ) 
			{
			JogadorSobreTrigger = true;
				print ("morte");
		//	SceneManager.UnloadSceneAsync ("Vercao3dCena");
			//SceneManager.LoadScene ("Vercao3dCena");
			}
	}
}
