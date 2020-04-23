using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public GameObject GokyuzuBir;
    public GameObject GokyuzuIki;

    Rigidbody2D fizikBir;
    Rigidbody2D fizikIki;
    public float backGroundSpeed = -1.5f;

    float length = 0;
    public GameObject engel;
    public int kacAdet = 5;
    GameObject[] engeller;

    float changeTime = 0;
    int Counter = 0;
    bool oyunBitti = true;

    void Start ()
    {
        fizikBir = GokyuzuBir.GetComponent<Rigidbody2D>();
        fizikIki = GokyuzuIki.GetComponent<Rigidbody2D>();

        fizikBir.velocity = new Vector2(backGroundSpeed, 0);
        fizikIki.velocity = new Vector2(backGroundSpeed, 0);

        length = GokyuzuBir.GetComponent<BoxCollider2D>().size.x;

        engeller = new GameObject[kacAdet];

        for(int i=0; i<engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel, new Vector2(-5, -20),Quaternion.identity);
            Rigidbody2D fizikEngel= engeller[i].AddComponent<Rigidbody2D>();
            fizikEngel.gravityScale = 0;
            fizikEngel.velocity = new Vector2(backGroundSpeed,0);
        }

    }


    void Update ()
    {
        if (oyunBitti)
        {
            if (GokyuzuBir.transform.position.x <= -length)
            {
                GokyuzuBir.transform.position += new Vector3(length * 2, 0);
            }
            if (GokyuzuIki.transform.position.x <= -length)
            {
                GokyuzuIki.transform.position += new Vector3(length * 2, 0);
            }

            changeTime += Time.deltaTime;
            if (changeTime > 2f)
            {
                changeTime = 0;
                float yEksenim = Random.Range(-0.50f, 1.10f);
                engeller[Counter].transform.position = new Vector3(18, yEksenim);
                Counter++;
                if (Counter >= engeller.Length)
                {
                    Counter = 0;
                }
            }
        }
        
   

    }
    public void gameOver()
    {
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); //vector2.zero
            fizikBir.velocity = Vector2.zero;
            fizikIki.velocity = Vector2.zero;
        }
        oyunBitti = false;
    }
}
