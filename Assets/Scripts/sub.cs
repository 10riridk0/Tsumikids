using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sub : MonoBehaviour {

    private bool flag = false;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        SceneTransition.FadeIn();
        //SceneTransition.ChangeScene("SoundTestScene");

    }
}
