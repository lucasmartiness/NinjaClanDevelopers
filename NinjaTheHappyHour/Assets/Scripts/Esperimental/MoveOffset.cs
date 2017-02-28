using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour {
    public float speed = 0.2f;
    Renderer render;
    // Use this for initialization
    Vector2 vetordeslizante;
    void Start () {
        // cria um novo vetor e capture o componente Renderer
        vetordeslizante = new Vector2(0,0);
        render = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * speed; // crie uma variavel e lhe entregue o tempo e a velocidade 
        vetordeslizante.x = offset;// modifique o valor de x
        render.material.SetTextureOffset("_MainTex", vetordeslizante);// modifique a tetura principal
	}
}
