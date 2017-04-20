using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent ( typeof(CoracaoUI) )]
public class ControladoraInterface : MonoBehaviour {

	//public ArrayList  coracoes ; // lista de corações
	public GameObject Coracao;
	// Use this for initialization
	//private Vector3 LastCoracaoPosition = new Vector3(-528,244,0);




	void Start () {
	//	Instantiate(,
		//coracoes = new ArrayList<> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Q) ) {
			AddUltimoCoracao ();
		}
		if(Input.GetKeyUp(KeyCode.E) ) {
			EliminarUltimaCoracao ();
		}
		if(Input.GetKeyUp(KeyCode.R) ) {
			EliminarUltimaCoracao ();
		}
	}

	void AddUltimoCoracao(){
		
		GameObject canvas = GameObject.FindGameObjectWithTag ("Canvas");
		GameObject cv = canvas.gameObject;
		 Coracao.GetComponent<RectTransform> ().position = new Vector3(0,0,0);
		//transformUI.position = LastCoracaoPosition;
	//	coracoes.Add ( Instantiate( Coracao,cv.transform ) );
	
	}
	void DanificarUltimoCoracao(){
		//GameObject coracao = ) ; //(coracoes.LastIndexOf)
	//	coracao.GetComponent<CoracaoUI>().acao = CoracaoUI.coracaoAcao.quebrado;
	}
	void ConcertarUltimoCoracao(){
	//	GameObject coracao = coracoes.FindIndex (coracoes.LastIndexOf); //(coracoes.LastIndexOf)
	//	coracao.GetComponent<CoracaoUI>().acao = CoracaoUI.coracaoAcao.normal;
	}
	void EliminarUltimaCoracao(){
		//coracoes.RemoveAt (coracoes.LastIndexOf);
	}
}
