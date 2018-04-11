using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public bool playerWin;
    public bool gameOver;
    public bool lastLevel;
    public AudioClip gameOverAudio;
    public AudioClip playerWinAudio;
    public GameObject cam;
    AudioSource audio1;
    public string nextScene;
    public GameObject PlayerWinPanel;
    public GameObject GameOverPanel;
    // Use this for initialization
    void Start () {
        playerWin = false;
        audio1 = this.GetComponent<AudioSource>();
        if(audio1 == null)
        {
            Debug.Log("--------_____------------");
        }
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        if (bricks.Length == 0)
        {
            //player win situation
            Debug.Log("Player Win");
            if (lastLevel)
            {
                Debug.Log("Last Level Win");
                if (!playerWin)
                {
                    PlayerWins();
                    playerWin = true;
                }
                
            }
            else
            {
                SceneManager.LoadScene(nextScene);
            }
        }
        else
        {
            Debug.Log(bricks.Length);
        }
        if (gameOver)
        {
            GameOver();
            gameOver = false;
        }

	}
    public void GameOver()
    {
        //show game over 
        Debug.Log("GameOver was Called");
        Animator an = GameOverPanel.GetComponent<Animator>();
        if (an == null)
        {
            Debug.Log("null");
        }
        an.enabled = !an.enabled;
        AudioSource temp = cam.GetComponent<AudioSource>();
        temp.Stop();

        audio1.clip = gameOverAudio;
        audio1.Play();
    }
    void PlayerWins()
    {
        Animator an = PlayerWinPanel.GetComponent<Animator>();
        if (an == null)
        {
            Debug.Log("null");
        }
        an.enabled = !an.enabled;
        AudioSource temp = cam.GetComponent<AudioSource>();
        temp.Stop();

        audio1.clip = playerWinAudio;
        audio1.Play();
    }
}
