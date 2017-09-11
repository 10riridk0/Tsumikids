using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmFader : MonoBehaviour
{
    public static float bgmFadeSpeed = 0.05f;
    //public static bool isFadeOut = false, isFadeIn = false;
    public static bool isFadeOut = false, isFadeIn = false;
    public static AudioSource audioSource;

    public static void BgmFadeOut()
    {
        Debug.Log("BGMフェードアウト>> " + audioSource.volume);
        if (!isFadeOut)
        {
            audioSource.volume -= bgmFadeSpeed;
            if (audioSource.volume <= 0)
            {
                isFadeOut = true;
                Debug.Log("BGMフェードアウト終了");
            }
        }
    }
    public static void BgmFadeIn()
    {
        Debug.Log("BGMフェードイン>> " + audioSource.volume);
        if (!isFadeIn)
        {
            audioSource.volume += bgmFadeSpeed;
            if (audioSource.volume >= 1)
            {
                isFadeIn = false;
                Debug.Log("BGMフェードイン終了");
            }
        }
    }
    // Use this for initialization
    void Start()
    {
        Debug.Log("Start入りました");
        audioSource = GetComponent<AudioSource>();  //コンポーネント取得
        isFadeIn = false;
        isFadeOut = false;
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
