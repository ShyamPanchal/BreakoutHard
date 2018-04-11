using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {
    Rigidbody2D rb;
    public float speed;
    public GameObject player;
    bool gamepaused;
    float time;
    public int score;
    public int lives;
    public Text scoreText;
    public bool gameOver;
    public GameObject back;
    GameController g;
    bool gameOverNotCalled;
	// Use this for initialization
	void Start () {
        gameOverNotCalled = true;
        gameOver = false;
        g = back.GetComponent<GameController>();
        score = 0;
        lives = 3;
        rb = GetComponent<Rigidbody2D>();        
        gamepaused = true;
        time = 0f;
        scoreText.text = "Lives : " + lives + " Score : " + score;
    }
	
	// Update is called once per frame
	void Update () {
        if (lives == 0)
        {
            gameOver = true;
        }
        if (!gameOver)
        {
            if (gamepaused)
            {
                time += Time.deltaTime;
                player.transform.position = new Vector3(0f, -4.5f, 0f);
            }
            if (time > 3f)
            {
                gamepaused = false;
                rb.velocity = (new Vector2(0.5f, -1f)) * speed;
                time = 0f;
            }
        }
        else
        {
            scoreText.text = " Score : " + score;
            if (gameOverNotCalled)
            {
                //g.gameOver = true;
                g.GameOver();
                gameOverNotCalled = false;
            }
        }
        if(score >= 780)
        {
            //load next scene
        }
        
        
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Brick")
        {
            score += 10;
            scoreText.text = "Lives : "+lives+" Score : " + score;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "BottomBoundary")
        {
            this.transform.position = new Vector3(0f,-3.5f,0f);
            rb.velocity = Vector2.zero;
            player.transform.position = new Vector3(0f, -4.5f, 0f);
            gamepaused = true;
            time = 0f;
            lives--;
            scoreText.text = "Lives : " + lives + " Score : " + score;
        }
        
    }
}
