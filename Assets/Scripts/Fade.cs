using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    public static float alfa;                 //アルファ値を操作する変数
    public static float speed = 0.007f;       //アルファ値が変化する速さ変数
    public static float r, g, b;                     //RGBを操作する変数
    static Image image;                       //フェードイン・アウトするためのImage
    private RectTransform imageSize;          //Imageのサイズ変更のために使う  
    public static bool isFade = false;     //フェードアウトしていない: false, フェードアウトした: true

    public static void Fadein()
    {
        image.color = new Color(r, g, b, alfa);
        alfa -= speed;
        if (alfa <= 0)
        {
            isFade = false;
            SceneTransitionBefore.flag = false;
            Debug.Log("isFade>> " + isFade);
            Debug.Log("SceneTransitionBefore.flag>> " + SceneTransitionBefore.flag) ;
        }
    }

    public static void Fadeout()
    {
        alfa += speed;
        image.color = new Color(r, g, b, alfa);
        if (alfa >= 1)
        {
            isFade = true;
        }
    }

    void Start()
    {
        image = GetComponent<Image>();                                      //コンポーネント取得(色変更のため)
        imageSize = GameObject.Find("Panel").GetComponent<RectTransform>(); //コンポーネント取得(サイズ変更のため)

        imageSize.sizeDelta = new Vector2(110, 200);                        //サイズ変更

        //RGB値を黒に初期化しておく
        r = 0.1f;
        g = 0.1f;
        b = 0.1f;
    }

    void Update()
    {
    }
}