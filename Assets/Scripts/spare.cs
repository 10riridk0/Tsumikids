﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spare : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SceneTransition.SceneFadeIn();
        if (Input.anyKey)
        {
            SceneTransition.ChangeScene("hoge");
            BgmFader.FadeOut();
        }
	}
}
