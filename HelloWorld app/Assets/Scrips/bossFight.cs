using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bossFight : MonoBehaviour {
    int bossLives = 25;
    int playerLives = 5;
    bool playing = false;
    bool ballMoving = false;
    Vector3 ballStartPosition;
    public Rigidbody2D ballRB;
    public Text bossLivesText;
    public Text playerLivesText;
	// Use this for initialization
	void Start () {
        ballStartPosition = ballRB.transform.position;
	}
	
	// Update is called once per frame
    void Update () {
        if (playerLives == 0) {
            SceneManager.LoadScene ("gameOVer");
        }
        if (bossLives == 0) {
            SceneManager.LoadScene ("bossDead");
        }
        ballRB.velocity = Vector3.ClampMagnitude (ballRB.velocity, 8);
        if (playing && !ballMoving) {
            addforce ();
        }
	}

    void addforce(){
        ballMoving = true;
        int random = Random.Range (1, 2);
        ballRB.isKinematic = false;
        switch (random) {
        case 1:
            ballRB.AddForce (new Vector2 (-80, -250));
            break;
        case 2:
            ballRB.AddForce (new Vector2 (80, -250));
            break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        //ballRB.velocity = Vector3.zero;
        if (collision.gameObject.tag == "downBarrier") {
            playerLives--;
            playerLivesText.text = "PLAYER:" + playerLives;
            ballMoving = false;
            ballRB.transform.position = ballStartPosition;
        }
        else if (collision.gameObject.tag == "bossEye") {
            bossLives--;
            bossLivesText.text = "BOSS:" + bossLives;
            ballMoving = false;
            ballRB.transform.position = ballStartPosition;
        }
    }

    public void activateFigh(){
        playing = true;
    }
}
