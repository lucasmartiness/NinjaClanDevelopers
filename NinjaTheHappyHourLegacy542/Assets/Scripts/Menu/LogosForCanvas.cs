using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogosForCanvas : MonoBehaviour
{
    // Classe que cria o efeito fade in e fade out
    public int SceneIndexToChangeScene = 2;
    public bool setScene = false;
    private float fadeOutConter = 0;
    private float fadeInConter = 0;
    public float startTime;
    public float conter;
    public float TimeApresentacao = 2000;//
    public float FadeInEndTime = 1000;
    public float fadeInTime = 1000;// atenção  o fade in time também é usado como start time diferente do fade out que tem 2 variaveis uma start e uma time
    public float fadeOutStartTime = 3000;
    public float fadeOutTime = 1000;
    private Image render;
    public float colorAlpha;
    private float proporcaoFadeIn;// é a procorção para converter o delta tempo de start e limit por conter
    private float proporcaoFadeOut;

    private Color32 FadeInColor = new Color32(255, 255, 255, 0);
    private Color32 FadeOutColor = new Color32(255, 255, 255, 0);

    void Start()
    {



        fadeOutStartTime = TimeApresentacao + fadeInTime;

        fadeOutConter = ((fadeOutStartTime - TimeApresentacao) / 1000);

        proporcaoFadeIn = 255 / (fadeInTime);// assim o tempo é relacionado com os bits
        proporcaoFadeOut = 255 / (fadeOutTime);


        print("Proporção de tempo" + proporcaoFadeIn);

        conter = startTime / 1000; // converter valor start em 1000
        render = GetComponent<Image>();
        render.color = FadeInColor;
    }


    void Update()
    {
        // atualiza o contador adicionando tempo
        //print( "os bits "+ setAlphaBits());
        timeFadeInApresentOut();
        // UpdateConterDecrement();



    }
    Byte setAlphaBitsFade(float conter, float proporcao, String fadeTag)
    {// função que não permite que alpha chege a 256 estourando 8 bits
        colorAlpha = proporcao * conter;

        colorAlpha *= 1000;// restaura uma proporção que não será destruida caso 0.255 então é 0 bits de alpha 
        // para resolver o erro de conversão de float para bits é só multiplicar por 1000     
        if (colorAlpha > 255)
        {
            print("passou 255 " + fadeTag);
            colorAlpha = 255;
        }
        if (colorAlpha < 0 || (colorAlpha > 0 && colorAlpha < 5))
        {
            print("passou < 0" + fadeTag);
            colorAlpha = 0;
        }

        return Convert.ToByte(colorAlpha);
    }
    float tmpConter = 0;
    void timeFadeInApresentOut()
    {


        // fade in
        if (tmpConter < startTime / 1000)
        {
            print("delay");
            tmpConter += Time.deltaTime;

        }
        else
        {

            if (conter >= startTime / 1000 && conter < (FadeInEndTime + startTime) / 1000)// converte segundos em milesimos
            {
                print("x1");
                fadeInConter += Time.deltaTime;
                FadeInColor.a = setAlphaBitsFade(fadeInConter, proporcaoFadeIn, "in");

                render.color = FadeInColor;// 
                conter += Time.deltaTime;

            }

            if (conter >= (FadeInEndTime + startTime) / 1000 && conter <= (TimeApresentacao + startTime) / 1000)
            {
                conter += Time.deltaTime;
                print("x2");
            }
            if (conter >= (TimeApresentacao + startTime) / 1000 && conter < (TimeApresentacao + startTime + fadeOutTime) / 1000)
            {
                print("x3" + conter);
                fadeOutConter -= Time.deltaTime;
                conter += Time.deltaTime;
                FadeOutColor.a = setAlphaBitsFade(fadeOutConter, proporcaoFadeOut, "out");
                //print("Os bits"+setAlphaBits());// 
                render.color = FadeOutColor;// 

            }
            if (conter >= (TimeApresentacao + startTime + fadeOutTime) / 1000)
            {
                if (setScene == true)
                {
                    SceneManager.LoadScene(SceneIndexToChangeScene);
                }
            }


        }


    }


}
