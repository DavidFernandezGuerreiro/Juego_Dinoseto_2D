using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoger : MonoBehaviour {
    
	public void OnTriggerEnter2D(Collider2D col){
		if(col.transform.CompareTag("Player")){
			//PlayerController.puntuacion++;
			//Destroy(gameObject);    		
		}
	}
}
