using UnityEngine;
using UnityEngine.UI;

public class CoracaoUI : MonoBehaviour
{
	[SerializeField]
	private Sprite 
	CoracaoIntegro,
	CoracaoDanificado,
	CoracaoVisualizado;

	// debug

	public enum coracaoAcao
	{
		normal = 0,
		quebrado = 1,
		desaparecido = 2
	};
	public coracaoAcao acao = coracaoAcao.normal;

	void Update(){

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
	//debug end

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

