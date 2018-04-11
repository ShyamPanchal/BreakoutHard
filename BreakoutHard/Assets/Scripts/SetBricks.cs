using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBricks : MonoBehaviour {
    //initial game objects
    public GameObject[] Bricks;
    public float offset;
    // Use this for initialization
    void Start () {
        
        for (float i = offset; i < 7.9; i=i+ offset)
        {
            for(int j = 0; j < Bricks.Length; j++)
            {
                Instantiate(Bricks[j], new Vector3(i, Bricks[j].transform.position.y, 0), Quaternion.identity);
                Instantiate(Bricks[j], new Vector3(-i, Bricks[j].transform.position.y, 0), Quaternion.identity);
            }
        }
	}
}
