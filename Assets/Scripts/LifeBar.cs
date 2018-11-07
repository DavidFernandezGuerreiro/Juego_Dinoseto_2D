using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class LifeBar : MonoBehaviour {

    public Image health;

    float hp, maxHp = 100f; //health=salud hp->healthpoint
    
    public Image imageMuerte;
    public Image fondoMuerte;
    public Image imagenRestart;
    public Image imagenGanar;
    public Image fondoGanar;

    // Use this for initialization
    void Start () {
        hp = maxHp;	
        imageMuerte.enabled=false;
        fondoMuerte.enabled=false;
        imagenRestart.enabled=false;
        imagenGanar.enabled = false;
        fondoGanar.enabled = false;
    }
    public void Update()
    {
        RestartGame();
    }


    public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        health.transform.localScale = new Vector2(hp / maxHp, 1); 

        if (hp == 0)
        {
            imageMuerte.enabled=true;
            fondoMuerte.enabled=true;
            imagenRestart.enabled=true;
            Time.timeScale=0;
            
        }
    }

    string levelName;

    private void OnLevelWasLoaded(int level)
    {
         levelName= Application.loadedLevelName;
        if (levelName == "MapaCiudad")
        {
            levelName = "MapaCiudad";
        }
        if (levelName == "MapaBosque")
        {
            levelName = "MapaBosque";
        }
        if (levelName == "SampleScene")
        {
            levelName = "SampleScene";
        }
    }

    public void RestartGame()
    {
        if (hp == 0)
        {
            if (Input.GetMouseButton(0) == true)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(levelName);
            }
        }

        if (PlayerController.puntuacion == 5)
        {
            imagenGanar.enabled = true;
            fondoGanar.enabled = true;
            if (Input.GetMouseButton(0) == true)
            {
                //imagenGanar.enabled = false;
                //fondoGanar.enabled = false;
                PlayerController.puntuacion = 0;
                SceneManager.LoadScene(levelName);
            }
        }

    }

}
