using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour {


	public Rigidbody2D rb;
	public float ballForce;
    public float maxSpeed;
	bool gameStarted = false;
    bool isLaunchButtonPressed = false;
	int life=5;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
    void Update (){
        rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxSpeed);
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
            gameStarted = false;
            rb.isKinematic = true;
			if (life > 0) {
				Vector3 vector = GameObject.Find ("paddleRed").transform.position;
				vector.y += 0.3f;
				transform.position = vector;
				rb.velocity = Vector3.zero;
				GameObject paddle = GameObject.Find ("paddleRed");
				transform.parent = paddle.transform;
			} else {
				Destroy (gameObject);
			}
        }
    }

    public void launcButton(){
        isLaunchButtonPressed = true;
    }

}