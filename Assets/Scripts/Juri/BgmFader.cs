using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmFader : MonoBehaviour
{
    public static float bgmFadeSpeed = 0.05f;
    public static bool isFadeOut, isFadeIn;
    public static AudioSource audioSource;

    private void FadeIn()
    {
        Debug.Log("フェードイン開始");
        audioSource.enabled = true;
        for (int vol = 0; vol < 100; vol++)
        {
            audioSource.volume = (float)(vol) / 100;
            //Debug.Log("フェードイン中>> " + audioSource.volume);
        }
        audioSource.volume = 1;
        Debug.Log("フェードイン終了");
    }

    public static void FadeSet()
    {
        if (isFadeOut)
        {
            Debug.Log("フェードアウト開始");
            for (int vol = 100; vol > 0; vol--)
            {
                audioSource.volume = (float)(vol) / 100;
                //Debug.Log("フェードアウト中>> " + audioSource.volume);
            }
            audioSource.volume = 0;
            isFadeOut = false;
            Debug.Log("フェードアウト終了");
        }
    }
    void Start()
    {
        Debug.Log("Start");
        audioSource = GetComponent<AudioSource>();  //コンポーネント取得
        FadeIn();
        isFadeOut = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}