using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esconderijo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D cl){


		float distanciaMaxX = 15;
		if (Input.GetKeyDown ( KeyCode.S) ) 
		if (cl.gameObject.CompareTag ("Player")) {

			cl.gameObject.GetComponentInChildren<SpriteRenderer> ().color = Color.black;

			Debug.Log ("estou no matinho");
			GameObject [] objects = GameObject.FindGameObjectsWithTag ("Inimigo");

			foreach( GameObject x in objects ){

				Vector2 distancia = x.gameObject.transform.position  - cl.gameObject.transform.position;

			//	if (distancia.x < distanciaMaxX && distancia.x > - distanciaMaxX) {
				x.GetComponent<Ataques> ().jogadorEscondido = true;
			//	}


			}

			//cl.GetComponentInChildren<Color>().
		}
	}
	void OnTriggerExit2D(Collider2D cl){

		float distanciaMaxX = 10;

		if (cl.gameObject.CompareTag ("Player")) {
			Debug.Log ("sai do matinho");
			GameObject [] objects = GameObject.FindGameObjectsWithTag ("Inimigo");
			cl.gameObject.GetComponentInChildren<SpriteRenderer> ().color = Color.white;


			foreach( GameObject x in objects ){
				
				Vector2 distancia = cl.gameObject.transform.position - x.gameObject.transform.position;


			//	if (distancia.x < distanciaMaxX && distancia.x > - distanciaMaxX) {
				x.GetComponent<Ataques> ().jogadorEscondido = false;
				//}

			}

		}
	}

}
