using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawn : MonoBehaviour {

    float spawnTimer;
    float staytimer;
    float stayTime;
    bool spawn;
    bool stay;
	// Use this for initialization
	void Start () {
        spawnTimer = .0f;
        spawn = false;
        stay = true;
        staytimer = 0.0f;
        stayTime = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		if(spawn == true)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > 1.0f)
            {
                float xrange = Random.Range(0f,8f);
                float yrange = Random.Range(0f,-3.5f);
                float randomX, randomY;
                randomX = ((Random.value) > 0.5 ? 1.0f : -1.0f) * xrange;
                randomY = yrange;
                this.transform.position = new Vector3(randomX,randomY,this.transform.position.z);
                spawn = false;
                stay = true;
                staytimer = 0f;
            }
        }
        if(stay == true)
        {
            staytimer += Time.deltaTime;
            if(staytimer > stayTime)
            {
                this.transform.position = new Vector3(50.0f, 50.0f, this.transform.position.z);
                stay = false;
                spawn = true;
                spawnTimer = 0f;
            }
        }
	}

    public void setStayTimer(float timer)
    {
        Debug.Log(staytimer);
        stayTime = timer;
        Debug.Log(staytimer);
    }
}
