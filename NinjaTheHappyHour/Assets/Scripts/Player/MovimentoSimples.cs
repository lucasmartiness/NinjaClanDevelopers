using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ataques) ) ]
public class MovimentoSimples : MonoBehaviour {



	// velocidade e pulo
	public float speed ;
	public float jump;
	public string direcao = "direita";
	public Vector3 movement;
	public int numeroPulos = 0;// public for debug conter
	public bool escoradoNaParede = false;// public for debug
	public string direcaoParede = "direita";
	public bool dentroDaEscada;
	public bool sobreChao;

	public void MovimentoVertical(float direcao,float speed){
		// pega o movimento multiplica pela velocidade e pelo delta time e transforma em diração global para movimentar

		movement = new Vector3(0,direcao * speed, 0);
		movement = Vector3.ClampMagnitude(movement, speed);

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		transform.Translate (movement);
		//dentroDaEscada = false;
		// animar sprite
		//SpriteController _spriteController = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<SpriteController> ();

	}
	public void MovimentoHorizontal(float direcao,float speed){
		// pega o movimento multiplica pela velocidade e pelo delta time e transforma em diração global para movimentar

		movement = new Vector3(direcao * speed, 0, 0);
		movement = Vector3.ClampMagnitude(movement, speed);

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		transform.Translate (movement);
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
	
		// animar sprite
		//SpriteController _spriteController = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<SpriteController> ();
	
	}
	public void InvertDirecao(){

		// troca a direção
		if (direcao == "esquerda") {
			direcao = "direita";
		}
		else if(direcao == "direita"){
			direcao = "esquerda";
		}
	}


	public void Pulo(Vector3 direcao,float forca){
		
		Vector3 forcaNivel = direcao * forca;
		forcaNivel *= Time.deltaTime;
		Vector3 movimentoPulo = transform.TransformDirection (forcaNivel);

		Rigidbody2D fisica = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
		fisica.velocity = new Vector2 (fisica.velocity.x, 0);
		fisica.AddRelativeForce (movimentoPulo, ForceMode2D.Impulse);
		//GetComponent<Rigidbody2D> ().AddForce (movimentoPulo,ForceMode2D.Impulse);
		numeroPulos++;
	}

	void OnCollisionStay2D(Collision2D cl){
		if(cl.gameObject.CompareTag("Chao") ) {
			direcaoParede = "";
			sobreChao = true;
		}
	}

	void OnCollisionEnter2D(Collision2D cl){
		// se jogador sobre chão zerar pulo
		if(cl.gameObject.CompareTag("Chao") ) {
			direcaoParede = "";
		}
		if(cl.gameObject.CompareTag("Chao") ||
			cl.gameObject.CompareTag ("Parede") || 
			cl.gameObject.CompareTag ("ParedeEsquerda") ||
			cl.gameObject.CompareTag ("ParedeDireita"))
		{
			numeroPulos = 0;
			escoradoNaParede = false;


		}
		if (cl.gameObject.CompareTag ("Parede") && sobreChao == false) {
			escoradoNaParede = true;
		}
		if (cl.gameObject.CompareTag ("ParedeEsquerda") && sobreChao == false) {
			escoradoNaParede = true;
			direcaoParede = "esquerda";
			AtivarGravidade (false);
			InvertDirecao ();

		}
		if (cl.gameObject.CompareTag ("ParedeDireita") && sobreChao == false) {
			escoradoNaParede = true;
			direcaoParede = "direita";
			AtivarGravidade (false);
			InvertDirecao ();
		}
	}

	void OnCollisionExit2D(Collision2D cl){

		if(cl.gameObject.CompareTag("Chao") ){
			sobreChao = false;
		}
		if (// se descolidir com uma parede escalavel "direita ou esquerda" então ativar gravidade false

			cl.gameObject.CompareTag ("ParedeDireita") || 
			cl.gameObject.CompareTag ("ParedeEsquerda") ||
			cl.gameObject.CompareTag ("Parede")  ) 
		{

			if (gameObject.CompareTag ("Player")) {
				AtivarGravidade (true);
			}
			if(!sobreChao)
		   		 InvertDirecao ();
			escoradoNaParede = false;
			//direcaoParede = "";
		}
	}
	public void AtivarGravidade(bool ativar){

		if (ativar) {
			if (gameObject.CompareTag ("Player")) {
				Rigidbody2D rb = GetComponent<Rigidbody2D> ();
				rb.gravityScale = 1;

			}
		} 
		else if(!ativar) {
			if (gameObject.CompareTag ("Player")) {
				Rigidbody2D rb = GetComponent<Rigidbody2D> ();
				rb.gravityScale = 0;
				rb.velocity = new Vector2 (0, 0);
			}
		}

	}
	// get set
	public void setEscoradoParede(bool escoradoParede) {
		this.escoradoNaParede = escoradoParede;
	}
	public bool getEscoradoParede(){
		return escoradoNaParede;
	}
		
	public void setDirecaoParede(string direcaoParede){
		this.direcaoParede = direcaoParede;
	}
	public string getDirecaoParede(){

		return direcaoParede;
	}
	public void dash(Vector3 direcao,float forca){

		Vector3 forcaNivel = direcao * forca;
		forcaNivel *= Time.deltaTime;
		Vector3 movimentoPulo = transform.TransformDirection (forcaNivel);

		Rigidbody2D fisica = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
		fisica.velocity = new Vector2 (0, fisica.velocity.y);
		fisica.AddForce (movimentoPulo, ForceMode2D.Impulse);
		//GetComponent<Rigidbody2D> ().AddForce (movimentoPulo,ForceMode2D.Impulse);
		numeroPulos++;
	}
	public void agachar(){
		CapsuleCollider2D cp = GetComponent<CapsuleCollider2D> ();
		cp.size = new Vector2 (cp.size.x, 1.84f/2);

	}
	public void levantar(){
		CapsuleCollider2D cp = GetComponent<CapsuleCollider2D> ();
		cp.size = new Vector2 (cp.size.x,1.84f);

	}
	public void atacar(string nomeAtaque){
		
	}
	public int getNumPulos(){
		return numeroPulos;
	}
	public void setNumPulos(int Pulos){
		this.numeroPulos = Pulos;
	}
	public void setDirecao(string direcao){

		if (direcao != "esquerda" && direcao != "direita") {
			Debug.Log ("erro direção incorreta");
		}

		this.direcao = direcao;
	}
	public string getDirecao(){
		return direcao;
	}
	public void setSobreChao(bool sobreChao){
		this.sobreChao = sobreChao;
	}
	public bool getSobreChao(){
		return sobreChao;
	}

}
