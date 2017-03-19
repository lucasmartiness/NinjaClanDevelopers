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
	public bool sobreChao = false;
    // definição dos estados para maquinas de estado
    public enum estadoJogador{ Parado , Agachar, OlharCima ,Nascer, Correr,Morrer,Cair ,Pular, SubirEscada,Bater,Dash,Deslizar };
    enum ataqueJogador { SocoSimples, ChuteSimples, SocoComplexo, SocoCorrendo };
    // variaveis que armazenam o estado
    public estadoJogador movimentoId;
    ataqueJogador ataqueId;
	public Animator clip;
	public bool bloquearPuloVertival = false;
	public Vector2 movimento;// = new Vector2(10,0);
    void Start()
    { 
		movimento = new Vector2 (0, 0);
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
    private void AtualizarEstado() // apenas animação
    {


		// se a velocidade for -1 no eixo y vertical e o pulo não estiver bloqueado então caia
		if (rb.velocity.y < -2  )
		{
			movimentoId = estadoJogador.Cair ;
		}
		// se não estiver parado mas sobre chão e pulo não bloqueado então corra
		if (!(rb.velocity.x == 0)&&   sobreChao)
        {
            movimentoId = estadoJogador.Correr;
        }

        // se pulo
		//se a velocidade horizontal for baixa e a vertical for entre 0 e 0.1 então fique parado
		if ((rb.velocity.x > -0.1 && rb.velocity.x < 0.1 )&& ( rb.velocity.y > -1 && rb.velocity.y < 0.1) )
		{
			movimentoId = estadoJogador.Parado;

		}// pule se a velocidade for positivo e não estiver bloqueado
		if (rb.velocity.y > 1 )
        {
            movimentoId = estadoJogador.Pular;
        }



		// se o pulo vertival for desativado então o jogador está na parede e seu pulo será diagonal conforme a função Receber imput
		if (rb.velocity.y < 0 && bloquearPuloVertival) {
			movimentoId = estadoJogador.Deslizar; // o jogador irá deslizar

		}


    }
    private void ReceberInput()
    {
        // captura os botões A e D seta esquerda e direita e joystick (horizontal) do controle
        float MovimentoHorizontal = Input.GetAxis("Horizontal") * 10;

        // Configurar para indicar que o movimentoId será de correr
		if (!bloquearPuloVertival) {// se o pulo for bloqueado então o jogador pode correr e executar pulo diagonal conforme else se não ele pode pular normalmente
			Correr (MovimentoHorizontal);
			Pular ();
		}
		else {
			Correr (MovimentoHorizontal);
			PularDiagonal ();
		}


    }


    void atack()
    {

    }
    public void Pular()
    {
		if (Input.GetKeyDown(KeyCode.Space) && movimentoId!=estadoJogador.Cair)
        {
            rb.AddForce(new Vector2(0, ForcaPulo), ForceMode2D.Impulse);
        }
    }
	public void PularDiagonal(){

		if (Input.GetKeyDown(KeyCode.Space) && movimentoId!=estadoJogador.Cair)
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
		if (rb.velocity.y < 0) {
			sobreChao = false;
		}
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
		if (rb.velocity.x < Velocidade && rb.velocity.x > -Velocidade) {
			// se entre -3 e 3 de velocidade então adicione a força
			//bloquearPuloVertival = false;
			movimento.x = Horizontal * 2;
			rb.AddForce (movimento);
		}
    }




    void OnCollisionEnter2D(Collision2D collision)
    {

                Debug.Log("colidio com o chão");
           
    }




}
