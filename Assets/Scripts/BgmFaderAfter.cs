﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmFaderAfter : MonoBehaviour {

    private float bgmFadeSpeed = 0.007f;
    AudioSource audioSource;
    private void BgmFadeIn()
    {
        Debug.Log("in>> " + audioSource.volume);
        audioSource.volume += bgmFadeSpeed;
        if (audioSource.volume >= 1)
        {
            Debug.Log("BGMフェードイン終了");
        }
    }

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();  //コンポーネント取得
    }
	
	// Update is called once per frame
	void Update () {
        BgmFadeIn();
	}
}
