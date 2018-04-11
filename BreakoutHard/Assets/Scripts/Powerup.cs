using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    public GameObject Paddle;
    public GameObject ball;
    PowerupSpawn ps;
    float t;
    bool powerUpOn;
	// Use this for initialization
	void Start () {
        ps = this.GetComponent<PowerupSpawn>();
        t = 0;
        powerUpOn = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (powerUpOn)
        {
            t += Time.deltaTime;
        }
        if (t >= 5f)
        {
            //slow Mo
            //Time.timeScale = 1;
            //do something : revert
            Paddle.transform.localScale += new Vector3(-1.5f, 0f, 0f);
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
                Debug.Log("Plyer Left");

            //slowMo code
            //Time.timeScale = 0.2f;
            //do something
            Paddle.transform.localScale += new Vector3(1.5f,0f,0f);
            Debug.Log("powerup");
                powerUpOn = true;
                
            
            collision.transform.localScale = new Vector3(2.0f, 2.0f, collision.transform.localScale.z);
            this.transform.position = new Vector3(50.0f, 50.0f, this.transform.position.z);
            ps.setStayTimer(10.0f);
        }
    }
}
