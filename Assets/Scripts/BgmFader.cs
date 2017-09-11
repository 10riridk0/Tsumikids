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
        Debug.Log("YO");
        audioSource.enabled = true;
        for (int vol = 0; vol < 100; vol++)
        {
            Debug.Log("フェードイン中>> " + audioSource.volume);
            audioSource.volume = (float)(vol / 100);
        }
        audioSource.volume = 1;
    }

    public static void FadeOut()
    {
        if (isFadeOut)
        {
            Debug.Log("フェードアウト中>> " + audioSource.volume);
            audioSource.volume -= bgmFadeSpeed;
            if (audioSource.volume >= 1)
            {
                isFadeOut = false;
                Destroy(audioSource);
                Debug.Log("BGMフェードアウト終了");
            }
        }
    }
    void Start()
    {
        Debug.Log("Start");
        audioSource = GetComponent<AudioSource>();  //コンポーネント取得
        isFadeOut = true;
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
    }
}