using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupPotion : MonoBehaviour {

    public GameObject ball;
    int score;
    public Text scoreText;
    BallMovement b;
    PowerupSpawn ps;
    int player;
    float t;
    bool powerUpOn;
    // Use this for initialization
    void Start()
    {
        b = ball.GetComponent<BallMovement>();
        ps = this.GetComponent<PowerupSpawn>();
        t = 0;
        powerUpOn = false;
        player = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpOn)
        {
            t += Time.deltaTime;
        }
        if (t >= 5f)
        {
            powerUpOn = false;
            t = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log(collision.transform.position.x);

            //player 2 powerup

            //slowMo code
            //Time.timeScale = 0.2f;
            //do something
            Debug.Log("powerup");

            b.lives += 1;
            scoreText.text = "Lives : " + b.lives + " Score : " + score;
            powerUpOn = true;


            collision.transform.localScale = new Vector3(2.0f, 2.0f, collision.transform.localScale.z);
            this.transform.position = new Vector3(50.0f, 50.0f, this.transform.position.z);
            ps.setStayTimer(60.0f);
        }
    }
}
