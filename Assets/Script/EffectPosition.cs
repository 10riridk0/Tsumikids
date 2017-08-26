using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPosition : MonoBehaviour {

    public ParticleSystemScalingMode scalingMode;
    void Start ()
    {
        //this.transform.position = new Vector3(10, 10, 10);

        GameObject prefab = (GameObject)Resources.Load("EffectPrefab/Stretch 03 PS");   //Resourcesフォルダの中の「Stretch 03 PS(プレハブ)」を取得する
        ParticleSystem ps = prefab.GetComponent<ParticleSystem>();                      //パーティクルシステムのコンポーネントを取得
        //プレハブからインスタンス生成
        //Instantiate( 生成するオブジェクト,  場所, 回転): 回転はそのままなら" Quaternion.identity"らしい
        Instantiate(prefab, new Vector3(10, 10, 10), Quaternion.identity);

        scalingMode = ParticleSystemScalingMode.Hierarchy;
        transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        
    }

	void Update () {
		
	}
}
