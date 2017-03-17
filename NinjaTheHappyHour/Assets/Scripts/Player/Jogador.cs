using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{


   // public SpriteController.AnimadorDelegate animatorDelegatorPlayer;

	public SpriteController ctrSprite;

    // Use this for initialization
    private Rigidbody2D rb;// componente Fisica
    public GameObject sprite;// componente sprite
    public bool SeraEsquerda = false;// direita
    public float Velocidade;// componente de Velocidade Maxima
    public float Tamanho = 3;// componente de tamanho altura e largura maxima
    //private int Estado;
    public int ForcaPulo;// Força de impulso do pulo

    // definição dos estados para maquinas de estado
    public enum estadoJogador{ Parado , Agachar, OlharCima ,Nascer, Correr,Morrer,Cair ,Pular, SubirEscada,Bater,Dash,Deslizar };
    enum ataqueJogador { SocoSimples, ChuteSimples, SocoComplexo, SocoCorrendo };
    // variaveis que armazenam o estado
    public estadoJogador movimentoId;
    ataqueJogador ataqueId;
	public Animator clip;
	public bool bloquearMovimentoJogador = false;

    void Start()
    { 
		clip = GetComponentInChildren < Animator >();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

		AtualizarEstado();
        ReceberInput();
        
		ctrSprite.executarAnimacaoJogador(movimentoId.ToString());
    }



    // local para armazenar os estados para animações 
    private void AtualizarEstado()
    {


		if (!(rb.velocity.x == 0 && rb.velocity.y == 0)&& !bloquearMovimentoJogador)
        {
            movimentoId = estadoJogador.Correr;
        }

        // se pulo
		if (rb.velocity.y > 0 && !bloquearMovimentoJogador)
        {
            movimentoId = estadoJogador.Pular;
        }

		if (rb.velocity.y < 0 && !bloquearMovimentoJogador)
        {
            movimentoId = estadoJogador.Cair ;
        }

        // animar corrida
		if ( (rb.velocity.x > -0.1 && rb.velocity.x < 0.1 )&& ( rb.velocity.y > -0.1 && rb.velocity.y < 0.1) )
        {
            movimentoId = estadoJogador.Parado;
            
        }
		if (rb.velocity.y < 0 && bloquearMovimentoJogador) {
			movimentoId = estadoJogador.Deslizar;
		}

    }
    private void ReceberInput()
    {
        // captura os botões A e D seta esquerda e direita e joystick (horizontal) do controle
        float MovimentoHorizontal = Input.GetAxis("Horizontal") * 10;

        // Configurar para indicar que o movimentoId será de correr
		if (!bloquearMovimentoJogador) {
			Correr (MovimentoHorizontal);
			Pular ();
		}
		else {
			
			PularDiagonal ();
		}


    }


    void atack()
    {

    }
    public void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, ForcaPulo), ForceMode2D.Impulse);
        }
    }
	public void PularDiagonal(){

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if(!SeraEsquerda) rb.AddRelativeForce (new Vector2 (ForcaPulo, 1.5f * ForcaPulo), ForceMode2D.Impulse); // Pular na diagonal Oposta ao do muro a direita
			else rb.AddRelativeForce (new Vector2 (-ForcaPulo, 2* ForcaPulo), ForceMode2D.Impulse); // Pular na diagonal oposta ao muro a esquerda
		}
	}
    public void morrer()
    {

    }

    public void dash()
    {

    }

    public void deslizarNaParede()
    {

    }
    public void Correr(float Horizontal)
    {
        // função que controla a direção escalar do objeto"sentido"
        // e atribuir direção fora o principal né que e acionar formça enquanto a velocidade for limitada conforme Requisitos
       
        // mudar direção
        // se esquerda mas a figura estiver na direita

        if (SeraEsquerda && rb.velocity.x >= 0.1f )// valores positivos são direita ou seja o personagem está indo para a direita
        {
            SeraEsquerda = !SeraEsquerda;// mudar da esquerda para direita
            sprite.transform.localScale = new Vector2(transform.localScale.x * Tamanho, transform.localScale.y * Tamanho);
               
        }
        // se direita mas a figura estiver na esquerda
        if (!SeraEsquerda && rb.velocity.x <= -0.1f)
        {
            SeraEsquerda = !SeraEsquerda;// mudar da direita para esquerda
            
            sprite.transform.localScale = new Vector2(-transform.localScale.x * Tamanho, transform.localScale.y * Tamanho);

        }

        // movimentar
        if(rb.velocity.x < Velocidade && rb.velocity.x > -Velocidade )// se entre -3 e 3 de velocidade então adicione a força
			rb.AddForce(new Vector2(Horizontal * 10, 0));
		//print (movimentoId);
    }




    void OnCollisionEnter(Collision collision)
    {

                Debug.Log("colidio com o chão");
           
    }




}
