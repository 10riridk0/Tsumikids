using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPosition : MonoBehaviour {

    void Start ()
    {
        ParticleSystemScalingMode scalingMode;                                           //scalingModeをいじるために宣言しとく
        float x, y, z;                                                                   //座標x, y, zを格納する
        GameObject prefab;

        //Resourcesフォルダの中のプレハブを取得する
        int random = Random.Range(0, 3);
        if (random == 0)
        {
            prefab = (GameObject)Resources.Load("EffectPrefab/Triangle 11 PS red");
        }
        else if (random == 1)
        {
            prefab = (GameObject)Resources.Load("EffectPrefab/Triangle 11 PS blue");
        }
        else
        {
            prefab = (GameObject)Resources.Load("EffectPrefab/Triangle 11 PS yellow");
        }

        ParticleSystem ps = prefab.GetComponent<ParticleSystem>();                       //パーティクルシステムのコンポーネントを取得
        //CoordinateReadのdata(座標)を代入。文字列として取得しているので、float.Parse(..)でキャストする
        x = float.Parse(CoordinateRead.data[0][0]);
        y = float.Parse(CoordinateRead.data[0][1]);
        z = float.Parse(CoordinateRead.data[0][2]);

        //プレハブからインスタンス生成
        //Instantiate( 生成するオブジェクト,  場所, 回転): 回転はそのままなら" Quaternion.identity"らしい
        Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
        scalingMode = ParticleSystemScalingMode.Hierarchy;                              //ScalingModeをHierarchyにする
        transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);                        //エフェクトの大きさを0.05にする
    }

	void Update () {
		
	}
}
