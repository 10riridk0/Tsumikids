using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sub : MonoBehaviour {
    private bool flag;
	// Use this for initialization
	void Start () {
        flag = false;
    }
	
	// Update is called once per frame
	void Update () {
        SceneTransition.FadeIn();
        if (Input.GetMouseButtonDown(0))
        {
            flag = true;
            if(flag)
            {
                SceneTransition.ChangeScene("SoundTestScene");
            }
        }

    }
}
