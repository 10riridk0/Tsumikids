using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPosition : MonoBehaviour {
	void Start ()
    {
        //this.transform.position = new Vector3(10, 10, 10);

        //Resourcesフォルダの中の「Stretch 03 PS(プレハブ)」を取得する
        GameObject prefab = (GameObject)Resources.Load("EffectPrefab/Stretch 03 PS");
        //プレハブからインスタンス生成
        //Instantiate( 生成するオブジェクト,  場所, 回転): 回転はそのままなら" Quaternion.identity"らしい
        Instantiate(prefab, new Vector3(1, 1, 1), Quaternion.identity);
    }

	void Update () {
		
	}
}
