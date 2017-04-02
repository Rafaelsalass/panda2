using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour {


	public Rigidbody2D rb;
	public float ballForce;
    public float maxSpeed;
	bool gameStarted = false;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
    void Update (){
        rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxSpeed);
		if( Input.GetKeyUp(KeyCode.Space) && gameStarted == false ){

			transform.SetParent (null);
			rb.isKinematic = false;

            rb.AddForce (new Vector2 (0, Mathf.Abs(ballForce)));
			gameStarted = true;

		}
	}

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "downBarrier") {
            gameStarted = false;
            rb.isKinematic = true;
            //transform.position = GameObject.Find("paddleRed").transform.position;
            //rb.velocity = Vector3.zero;
            Vector3 vector = GameObject.Find("paddleRed").transform.position;
            vector.y += 0.3f;
            transform.position = vector;
            rb.velocity = Vector3.zero;
            GameObject paddle = GameObject.Find ("paddleRed");
            transform.parent = paddle.transform;
        }
    }

}