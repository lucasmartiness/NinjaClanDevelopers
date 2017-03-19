using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameAdjusts : MonoBehaviour {

    // Use this for initialization
    void OnGUI()
    {
        if (GUI.Button(new Rect(0,100,100,30),"Adicione Vida"))
        {
            GameControl.control.life+=10;
        }
        if (GUI.Button(new Rect(0, 150, 100, 30), "Subtraia Vida"))
        {
            GameControl.control.life -= 10;
        }
        if (GUI.Button(new Rect(0, 200, 100, 30), "Adicione Expe"))
        {
            GameControl.control.experience += 10;
        }
        if (GUI.Button(new Rect(0, 250, 100, 30), "Subraia Exp"))
        {
            GameControl.control.experience -= 10;
        }
        if(GUI.Button(new Rect(0, 300, 100, 30), "Save Game") )
        {
            GameControl.control.SaveSomething();
        }
        if (GUI.Button(new Rect(0, 350, 100, 30), "Load Game"))
        {
            GameControl.control.LoadSomething();
        }
        print(Application.persistentDataPath);

    }
  


}
