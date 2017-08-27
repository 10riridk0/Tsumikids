using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPosition : MonoBehaviour {

    private ParticleSystemScalingMode scalingMode;
    private float x, y, z;
    void Start ()
    {
        GameObject prefab = (GameObject)Resources.Load("EffectPrefab/Sphere 09 PS");   //Resourcesフォルダの中のプレハブを取得する
        ParticleSystem ps = prefab.GetComponent<ParticleSystem>();                      //パーティクルシステムのコンポーネントを取得

        //CoordinateReadのdata(座標)を代入。文字列として取得しているので、float.Parse(...)でキャストする
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
