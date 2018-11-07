using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CargaNivel(string pNombreNivel){
		//SceneManagement.LoadScene(pNombreNivel);
		SceneManager.LoadScene(pNombreNivel);
	}

	public void SalirJuego(){
		Application.Quit();
	}

}
