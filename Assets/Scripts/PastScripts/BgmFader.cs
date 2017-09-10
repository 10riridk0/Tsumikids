using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmFader : MonoBehaviour
{
    public static float bgmFadeSpeed = 0.07f;
    //public static bool isFadeOut = false, isFadeIn = false;
    public static bool isBgm = false;
    public static AudioSource audioSource;

    public static void BgmFadeOut()
    {
        Debug.Log("BGMフェードアウト開始");
        if (!isBgm)
        {
            audioSource.volume -= bgmFadeSpeed;
            if (audioSource.volume <= 0)
            {
                isBgm = true;
                Debug.Log("BGMフェードアウト終了");
            }
        }
    }
    public static void BgmFadeIn()
    {
        Debug.Log("BGMフェードイン開始");
        if (isBgm)
        {
            audioSource.volume += bgmFadeSpeed;
            if (audioSource.volume >= 1)
            {
                isBgm = false;
                Debug.Log("BGMフェードイン終了");
            }
        }
    }
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  //コンポーネント取得
    }

    // Update is called once per frame
    void Update()
    {
    }
}
