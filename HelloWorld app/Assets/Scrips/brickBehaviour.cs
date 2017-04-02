using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickBehaviour : MonoBehaviour {
    public int maxcollitions;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "ball") {
            maxcollitions--;
        }
        if (maxcollitions <= 0) {
            Destroy (gameObject);
        }
    }
}
