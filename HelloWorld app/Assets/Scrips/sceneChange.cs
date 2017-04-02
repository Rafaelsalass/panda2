using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour {
    public string sceneToLoad;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.childCount == 0) {
            Destroy(GameObject.FindWithTag("ball"));
            SceneManager.LoadScene (sceneToLoad);
        }
	}
}
