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

			rb.AddForce (new Vector2 (0, ballForce));
			gameStarted = true;

		}
	}

}