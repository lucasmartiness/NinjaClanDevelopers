using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public GameObject jogador;
    // Use this for initialization
	public Vector2 PosicaoJogadorNaCamera;
	Camera componenteCamera;

	public float movimentoCameraVertical ; // quantidade de movimento que a camera irá multiplicar a sua propria posição 


	public float valorLimiteBaixo = 0.8f;// valor maximo que a camera aceita antes de se mover para sima acompanhando o jogador caso ele suba
	public float valorLimiteAlto = 0.2f;// valor maximo que a camera aceita antes de se mover para baixo acompanhando o jogador caso ele desca

    void Start () {
		componenteCamera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {

		// copie a posição no eixo x do jogador aqui fora e dentro configura a posição y
		if(jogador == null)
			jogador = GameObject.FindGameObjectWithTag("Player");
		
		SeguirJogador(jogador.transform.position.x,transform.position.y,transform.position.z);

	}
    void SeguirJogador(float x , float y,float z)
	{
		
		transform.position = new Vector3 (x, y, z);

		PosicaoJogadorNaCamera = componenteCamera.WorldToViewportPoint (jogador.transform.position);


		// VALORES PosicaoJogadorNaCamera.Y PROXIMOS DE 0 INDICAM QUE O PERSONAGEM ESTÁ MUITO EMBAIXO NA TELA MAS VALORES ALTOS INDICAM QUE O PERSONAGEM ESTÁ MUITO NO ALTO DA TELA
		// SE FOR 0 ENTÃO O PERSONAGEM ESTÁ NA INFERIOR DA TELA SE FOR 1 O PERSONAGEM ESTARÁ NA LINHA SUPERIOR A DA TELA
		// se o jogador ficar fora do centro da camera ou fora dos valores < 20 ou > 80% então a camera copia a posição do jogador no eixo y
		if (PosicaoJogadorNaCamera.y < valorLimiteBaixo) {
			Vector3 vetor = transform.position;
			vetor.y -= movimentoCameraVertical * Time.deltaTime;
			transform.position = vetor;

		}
		if (PosicaoJogadorNaCamera.y > valorLimiteAlto) {
			Vector3 vetor = transform.position;
			vetor.y += movimentoCameraVertical * Time.deltaTime;
			transform.position = vetor;

		} 
		Vector3 vetorX = Vector3.zero;
		vetorX.x = transform.position.x;
		vetorX.z = transform.position.z;
		vetorX.y = transform.position.y + Input.mouseScrollDelta.y;
		transform.position = vetorX;
	
	}
}
