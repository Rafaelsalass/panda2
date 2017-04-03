using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuSceneChange : MonoBehaviour {
    public int level;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeScene(){
        switch (level) {
        case 1:
            SceneManager.LoadScene ("level1");
            break;
        case 2:
            SceneManager.LoadScene ("level2");
            break;
        case 3:
            SceneManager.LoadScene ("level3");
            break;
        case 4:
            SceneManager.LoadScene ("level4");
            break;
        case 5:
            SceneManager.LoadScene ("Menu");
            break;
        case 6:
            SceneManager.LoadScene ("credits");
            break;
        }
    }
}
