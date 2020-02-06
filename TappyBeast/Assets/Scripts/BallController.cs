using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float upForce;
    private bool started;
    Rigidbody2D rb;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(started == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                started = true;
                rb.bodyType = RigidbodyType2D.Dynamic;
                GameManager.instance.GameStart();
            }
            
        }
        else if(started && !gameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));
                
            }
        } 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Pipe" && !gameOver)
        {
            gameOver = true;
            GameManager.instance.GameOver();

            GetComponent<Animator>().Play("playerDead");
        }
        if(col.gameObject.tag == "ScoreChecker" && !gameOver)
        {
            ScoreManager.scoreManagerInstance.IncrementScore();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        gameOver = true;
        GameManager.instance.GameOver();
        GetComponent<Animator>().Play("playerDead");
    }
}
