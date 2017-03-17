using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public GameObject jogador;
    // Use this for initialization
    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        SeguirJogador(jogador.transform.position.x,transform.position.y,transform.position.z);

	}
    void SeguirJogador(float x , float y,float z)
    {
        transform.position = new Vector3(x, y , z);
    }
}
