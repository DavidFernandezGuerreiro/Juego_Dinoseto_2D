using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour {

    public Transform target;
    public float speed;

    private Vector3 start, end;

	// Use this for initialization
	void Start () {
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }

        if (transform.position == target.position)
        {
            //Cuando la posición de la plataforma concuerda con la posición del target, significa que hemos llegado al final de nuestro trayecto.
            //Por tanto, si estamos al principio, vamos a decir que el target pasará a estar al final (end). 
            //Si esto no es verdad, el target estará en el principio (start).
            target.position = (target.position == start) ? end : start;
        }
    }

}
