using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPosition : MonoBehaviour {

    static float x, y, z;                                                                   //座標x, y, zを格納する
    static GameObject prefab;
    public static GameObject effect;
    void Start()
    {
        //Resourcesフォルダの中のプレハブを取得する
        
    }
    private void Update()
    {
        
    }

    public static IEnumerator tsumiki_effect(Vector3 posi)
    {
        int random = Random.Range(0, 3);
        Debug.Log(random);
        if (random == 0)
        {
            prefab = (GameObject)Resources.Load("EffectPrefab/Pulse 04 PS red");
        }
        else if (random == 1)
        {
            prefab = (GameObject)Resources.Load("EffectPrefab/Pulse 04 PS blue");
        }
        else
        {
            prefab = (GameObject)Resources.Load("EffectPrefab/Pulse 04 PS orange");
        }

        //ParticleSystem ps = prefab.GetComponent<ParticleSystem>();                       //パーティクルシステムのコンポーネントを取得
        //CoordinateReadのdata(座標)を代入。文字列として取得しているので、float.Parse(..)でキャストする
        /*x = float.Parse(CoordinateRead.data[0][0]);
        y = float.Parse(CoordinateRead.data[0][1]);
        z = float.Parse(CoordinateRead.data[0][2]);*/

        //プレハブからインスタンス生成
        //Instantiate( 生成するオブジェクト,  場所, 回転): 回転はそのままなら" Quaternion.identity"らしい
        effect = Instantiate(prefab, posi, Quaternion.identity);
        Debug.Log(effect);

        yield return new WaitForSeconds(1.5f);

        Destroy(effect);
    }
}
