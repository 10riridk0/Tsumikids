﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sub : MonoBehaviour {
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        SceneTransition.FadeIn();
        BgmFader.BgmFadeIn();
        if (Input.anyKey)
        {
            SceneTransition.ChangeScene("spare");
            BgmFader.BgmFadeOut();
        }
    }
}
