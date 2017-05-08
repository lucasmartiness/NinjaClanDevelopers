using UnityEngine;
using UnityEngine.UI;

public class CoracaoUI : MonoBehaviour
{
	[SerializeField]
	private Sprite 
	CoracaoIntegro,
	CoracaoDanificado,
	CoracaoVisualizado;

	int coracaoQuebrado,coracaoNormal;// valor que representa o coração no estado normal e quebrado
	int valor;// valor da vida do jogador
	// debug

	public enum coracaoAcao
	{
		normal = 0,
		quebrado = 1,
		desaparecido = 2
	};
	public coracaoAcao acao = coracaoAcao.normal;

	void Update(){

		if (valor == coracaoQuebrado) {
			acao = coracaoAcao.quebrado;
		} 
		else if (valor >= coracaoQuebrado && valor <= coracaoNormal) {
			acao = coracaoAcao.normal;
		} 
		else {
			acao = coracaoAcao.desaparecido;
		}


		if (acao == coracaoAcao.normal) {
			CoracaoVisualizado = MudarCoracaoVisualizadoJanela ("coraçãoIntegro");
		}

		if (acao == coracaoAcao.quebrado) {
			CoracaoVisualizado = MudarCoracaoVisualizadoJanela ("coraçãoDanificado");

		}
		if (acao == coracaoAcao.desaparecido) {
			CoracaoVisualizado = MudarCoracaoVisualizadoJanela ("coraçãoDesaparecido");
		}
		MostrarCoracaoVisualizadoJanela ();


	}
	public void setRegrasCoracao(int valorCoracaoQuebrado,int valorCoracaoIntegro){
		coracaoQuebrado = valorCoracaoQuebrado;
		coracaoNormal = valorCoracaoIntegro;
	
	}
	//debug end
	public void setRegrasCoracao(int valorCoracaoQuebrado,int valorCoracaoIntegro,int valorAtual){
		coracaoQuebrado = valorCoracaoQuebrado;
		coracaoNormal = valorCoracaoIntegro;
		this.valor = valorAtual;
	}
	public void updateRegrasCoracao(int valorAtual){
		this.valor = valorAtual;
	}
	public void SetCoracaoIntegro(Sprite img)
	{
		CoracaoIntegro = img;
	}

	public void SetCoracaoDanificado(Sprite img)
	{
		CoracaoDanificado = img;
	}

	public Sprite GetCoracaoIntegro()
	{
		return CoracaoIntegro;
	}
	public Sprite GetCoracaoDanificado()
	{
		return CoracaoDanificado;
	}

	public Sprite MudarCoracaoVisualizadoJanela(string coracaoNome)
	{
		if (coracaoNome == "coraçãoIntegro") {
			// mude a cor do componente para não transparente ou branco
			SetColor(new Color32(255,255,255,255) );
			return CoracaoIntegro;
		} 
		else if (coracaoNome == "coraçãoDanificado") {
			// mude a cor do componente para não transparente ou branco
			SetColor(new Color32(255,255,255,255) );
			return CoracaoDanificado;
		}
		else{
			// mudar alpha do coração visualizado para invizivel
			LimparCoracaoVisualizadoJanela();
			return CoracaoVisualizado;
		}
		
		
	}

	public void LimparCoracaoVisualizadoJanela()
	{
		SetColor(new Color32(0,0,0,0) );
	}

	public void MostrarCoracaoVisualizadoJanela()
	{
		GetComponent<Image> ().sprite = CoracaoVisualizado;
	}

	private void SetColor(Color32 cor){

		Image imagem = GetComponent<Image> ();
		imagem.color = cor;

	}

}

