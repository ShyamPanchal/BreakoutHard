using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody2D rb;
    public float speed;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = (new Vector2(move, 0f)) * speed;
        rb.position = new Vector2(
            Mathf.Clamp(rb.position.x, -7f, 7f),
            rb.position.y);
    }
}
