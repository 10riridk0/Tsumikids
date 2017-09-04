using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmFader : MonoBehaviour
{
    private float bgmFadeSpeed = 0.05f;
    private bool flag = false;
    AudioSource audioSource;

    private void BgmFadeOut()
    {
        audioSource.volume -= bgmFadeSpeed;
        if (audioSource.volume <= 0)
        {
            Destroy(gameObject);
            Debug.Log("終了");
        }
    }

    private void BgmFadeIn()
    {
        if (!flag)
        {
            audioSource.volume = 0;
        }
        audioSource.volume += bgmFadeSpeed;
        if (audioSource.volume >= 1)
        {
            Debug.Log("終了");
        }
    }
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  //コンポーネント取得
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneTransitionBefore.flag)
        {
            if (!Fade.isFade)
            {
                BgmFadeOut();
            }
            if (Fade.isFade)
            {
                BgmFadeIn();
            }
        }
    }
}
