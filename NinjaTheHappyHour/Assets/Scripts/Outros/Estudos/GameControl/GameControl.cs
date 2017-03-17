using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class GameControl : MonoBehaviour {



    public static GameControl control;// um controlador estatico que aponta para o objeto que o executou 
    // Use this for initialization
    public float life;
    public float experience;
   // public GameObject gameobject;


    void Awake () {
		

        if ( control == null)// se a variavel control ainda não foi gravada então grave o objeto nela e o mantenha usando a função Dont Destroy On Load assim ongui se mantem
        {
            DontDestroyOnLoad(gameObject);// crie um Objeto "indestrutivel"
            control = this;// control aponta para esse objeto quase indestrutivel
        }
        else if(control != this){
            Destroy(gameObject);// se for outro objeto que quer escrever na variavel control  que já está escrita então o elimine
        }

    }
	
	// Update is called once per frame
	void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "experience: " + experience);
        GUI.Label(new Rect(10,30,100,30),"life: "+life);


    }

    public void SaveSomething()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData playerData = new PlayerData();
        playerData.life = GameControl.control.life;
        playerData.experiencia = GameControl.control.experience;

        bf.Serialize(file, playerData);
        file.Close();

    }
    public void LoadSomething()
    {
        //
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData playerData = (PlayerData)bf.Deserialize(file);
            GameControl.control.experience = playerData.experiencia;
            GameControl.control.life = playerData.life;


            file.Close();
        }



    }

    [System.Serializable]
    class PlayerData
    {
        public float life;
        public float experiencia;
    }


}
