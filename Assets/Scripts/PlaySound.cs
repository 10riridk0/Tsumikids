using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    AudioSource audioSource;
    //public AudioClip BGM;
    public AudioClip SE;

	// Use this for initialization
	void Start () {
        //AudioSourceの動的生成, コンポーネント取得
        gameObject.AddComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //クリックしたら効果音を流す
        if (Input.GetMouseButtonDown(0))
        {
            //第1引数: AudioClipの名前
            //第２引数: 大きさ
            audioSource.PlayOneShot(SE, 0.7f);
        }
	}
}
