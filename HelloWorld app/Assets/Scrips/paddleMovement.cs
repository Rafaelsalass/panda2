using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleMovement : MonoBehaviour {
	public Rigidbody2D rb;
	public float speed;
	public float maxX;
    bool isAndroidPlatform = false;
	// Use this for initialization

	void Start () {
        #if UNITY_ANDROID
        isAndroidPlatform = true;
        #else 
        isAndroidPlatform = false;
        #endif
        if (isAndroidPlatform) {
            Debug.Log ("android");
        }
	}

	// Update is called once per frame
	void Update () {
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp (pos.x, -maxX, maxX);
        transform.position = pos;
	}

    public void moveLeft(){
        rb.velocity = new Vector2 (-speed, 0);
    }

    public void moveRight(){
        rb.velocity = new Vector2 (speed, 0);
    }

    public void setVelocityZero(){
        rb.velocity = Vector2.zero;
    }
}
