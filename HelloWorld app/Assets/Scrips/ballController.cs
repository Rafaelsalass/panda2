using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ballController : MonoBehaviour {


	public Rigidbody2D rb;
	public float ballForce;
    public float maxSpeed;
	bool gameStarted = false;
    bool isLaunchButtonPressed = false;
	public int life;
    public string sceneToLoad;
    public Text playerLivesText;

	// Use this for initialization
	void Start () {
        playerLivesText.text = "LIVES:" + life;
	}

	// Update is called once per frame
    void Update (){
        
        rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxSpeed);
        if (GameObject.Find ("Bricks").transform.childCount <= 0) {
            SceneManager.LoadScene (sceneToLoad);
        }
        if( isLaunchButtonPressed && gameStarted == false ){

			transform.SetParent (null);
			rb.isKinematic = false;
			rb.AddForce (new Vector2 ( Mathf.Abs(ballForce), Mathf.Abs(ballForce)));
			gameStarted = true;
            isLaunchButtonPressed = false;
		}
	}

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "downBarrier") {
			life--;
            playerLivesText.text = "LIVES:" + life;
            gameStarted = false;
            rb.isKinematic = true;
			if (life > 0) {
				Vector3 vector = GameObject.Find ("paddleRed").transform.position;
				vector.y += 0.3f;
				transform.position = vector;
				rb.velocity = Vector3.zero;
				GameObject paddle = GameObject.Find ("paddleRed");
				transform.parent = paddle.transform;
			}
            else if(life == 0){
                SceneManager.LoadScene ("gameOver");

			}
        }
    }

    public void launcButton(){
        isLaunchButtonPressed = true;
    }

}