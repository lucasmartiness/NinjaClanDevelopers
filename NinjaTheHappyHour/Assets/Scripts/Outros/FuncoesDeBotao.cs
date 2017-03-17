using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FuncoesDeBotao : MonoBehaviour {

    
	// Use this for initialization

    public void SetSceneByPressButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
