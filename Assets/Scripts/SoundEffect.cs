using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*アタッチして使うスクリプトだよ*/
public class SoundEffect : MonoBehaviour {

    public static AudioSource audioSource;
    public static AudioClip SE;

    //効果音再生の関数
    //第1引数：効果音の名前, 第２引数：音の大きさ
    public static void Play(string seName, float volume)
    {
        audioSource.clip = Resources.Load("SE/" + seName) as AudioClip;
        audioSource.volume = volume;
        audioSource.Play();
    }

	// Use this for initialization
	void Start () {
        //AudioSourceの動的生成, コンポーネント取得
        gameObject.AddComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
