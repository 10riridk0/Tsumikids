using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    public static float alfa;   //アルファ値を操作する変数
    float speed = 0.02f;        //アルファ値が変化する速さ変数
    float r, g, b;              //RGBを操作する変数

    private void Fadein()
    {
        GetComponent<Image>().color = new Color(r, g, b, alfa);
        alfa -= speed;
    }

    private void Fadeout()
    {
        GetComponent<Image>().color = new Color(r, g, b, alfa);
        alfa += speed;
    }

    void Start () {
        //Panelの色を変化させるためにRGBを取得する
        r = GetComponent<Image>().color.r;
        g = GetComponent<Image>().color.g;
        b = GetComponent<Image>().color.b;
        alfa = GetComponent<Image>().color.a;
        alfa = 1;
    }

    void Update()
    {
        Fadein();
    }
}
