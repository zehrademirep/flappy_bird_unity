using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour {

    public Sprite [] birdSprite;
    SpriteRenderer spriteRenderer;
    bool ileriGeriKontrol = true;
    int birdCounter = 0;
    float birdAnimationTime = 0;
    Rigidbody2D fizik;
    int puan = 0;
    public Text puantext;

    bool gameOver = true;
    GameControl gameControl;
    AudioSource []sesler;
    
   

	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        gameControl = GameObject.FindGameObjectWithTag("gamecontrol").GetComponent<GameControl>();
        sesler = GetComponents<AudioSource>();

        
	}
	
	
	void Update ()
    {

        if(Input.GetMouseButtonDown(0) && gameOver)
        {
            fizik.velocity = new Vector2(0, 0); //hızı 0 yaptıktan sonra kuvvet.
            fizik.AddForce(new Vector2(0,200));
            sesler[0].Play();
           
        }
        if (fizik.velocity.y>0)
        {
            transform.eulerAngles = new Vector3(0,0,45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }
        Animation();

     
	}
    void Animation()
    {
        birdAnimationTime += Time.deltaTime;
        if (birdAnimationTime > 0.2f)
        {
            birdAnimationTime = 0;
            if (ileriGeriKontrol)
            {
                spriteRenderer.sprite = birdSprite[birdCounter];
                birdCounter++; // 0 1 2 3
                if (birdCounter == birdSprite.Length)
                {
                    birdCounter--;
                    ileriGeriKontrol = false;
                }
            }
            else
            {
                birdCounter--;
                spriteRenderer.sprite = birdSprite[birdCounter];
                if (birdCounter == 0)
                {
                    birdCounter++;
                    ileriGeriKontrol = true;
                }
            }
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="Puan")
        {
            puan++;
            puantext.text = "Skor = " + puan;
            sesler[1].Play(); 
        }
        if (col.gameObject.tag=="Engel")
        {
            gameOver = false;
            sesler[2].Play();
            gameControl.gameOver();
            GetComponent<CircleCollider2D>().enabled = false;
        
        }
    }
}

