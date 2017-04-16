using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curiosidade : MonoBehaviour {

	[SerializeField]
	private float velocidadeHorizontal = 0;
	[SerializeField]
	private float velocidadeVertical = 0;
	velocidadeValores vx;
	// Use this for initialization
	struct velocidadeValores{
			
		public float s1,s0;
		public float t1,t0;
		public float velocidade;
		public bool trocarS1;
	}

	void Start () {

		vx = new velocidadeValores ();
		vx.s1 = vx.s0 = vx.t1 = vx.t0 = vx.velocidade = 0;
		vx.trocarS1 = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		transform.Translate (Vector2.down * 9 * Time.deltaTime );

		CaptureInput ();

		// mudar velocidade
		SetTransformHorizontal ();
		SetTransformVertical ();

		calcurarVelocidade(vx);
	}
	private void calcurarVelocidade(velocidadeValores vx){
		if (!vx.trocarS1) {

			vx.trocarS1 = !vx.trocarS1;

			vx.s0 = transform.position.x;
			vx.t0 = Time.deltaTime;

			vx.velocidade = (vx.s1 - vx.s0) / (vx.t1 - vx.t0);
			Debug.Log (vx.velocidade);
		}
		if (vx.trocarS1) {

			vx.trocarS1 = !vx.trocarS1;

			vx.s1 = transform.position.x;
			vx.t1 = Time.deltaTime;


		}





	}
	public void SetTransformHorizontal(){
		transform.Translate (Vector2.right * velocidadeHorizontal * Time.deltaTime);

	}
	public void SetTransformVertical(){
		transform.Translate (Vector2.up * velocidadeVertical * Time.deltaTime );

	}
	public void setVelocity(float velocidade){
		this.velocidadeHorizontal = velocidade;
	}
	public float getVelocity(){
		return velocidadeHorizontal;
	}

	private void CaptureInput(){

	

		if (! Input.anyKey ) 
		{
			velocidadeHorizontal = 0;
			velocidadeVertical = 0;
		}
		if(Input.GetKey(KeyCode.A) ) {
			velocidadeHorizontal = -1.7f;
		}
		if (Input.GetKey (KeyCode.D)) {
			velocidadeHorizontal = 1.7f;
		} 
		if (Input.GetKeyDown (KeyCode.W)) {
			velocidadeVertical = 200.3f;
		}



	}


}
