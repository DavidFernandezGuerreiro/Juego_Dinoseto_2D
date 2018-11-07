using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 6.5f;

    public Text textoContador;
    public static int puntuacion;

    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spr;
    private bool jump;
    private bool doubleJump;
    private bool movement = true;

    private GameObject healthbar;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        healthbar = GameObject.Find("Healthbar");
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        if (grounded)
        {
            doubleJump = true;//salto de precaución
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                jump = true;
                doubleJump = true;
            }else if (doubleJump)
            {
                jump = true;
                doubleJump = false;
            }
        }
	}

    void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded)
        {
            rb2d.velocity = fixedVelocity;
        }

        float h = Input.GetAxis("Horizontal");
        if (!movement) h = 0;

        rb2d.AddForce(Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
    }

    string levelName;
    private void OnLevelWasLoaded(int level)
    {
        levelName = Application.loadedLevelName;
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
    //CUANDO EL PLAYER CAE AL VACÍO, QUE VUELVA A APARECER EN ESAS COORDENADAS:

    void OnBecameInvisible()
    {
        //transform.position = new Vector3(-2, 0, 0);
        SceneManager.LoadScene(levelName);
        puntuacion = 0;
    }

    public void EnemyJump()
    {
        jump = true;
    }

    public void EnemyKnockBack(float enemyPosX)
    {
        healthbar.SendMessage("TakeDamage", 15);
        
        jump = true;
       

        float side = Mathf.Sign(enemyPosX - transform.position.x); //side=lado
        rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);

        movement = false; 
        Invoke("EnableMovement", 0.7f);

        Color color = new Color(255/255f, 70/255f, 0/255f);
        spr.color = color; 
    }

    void EnableMovement()
    {
        movement = true;
        spr.color = Color.white;
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag=="Point"){
            puntuacion++;
            Destroy(other.gameObject);
                Debug.Log(puntuacion);
            
        }
        textoContador.text = puntuacion.ToString();
        
    }

    

}
