using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Tsumihiko : MonoBehaviour {

    // Use this for initialization
    void Start () {
        StartCoroutine("move", 'd');
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    //つみひこ移動関数
    IEnumerator move(char direction)
    {
        Transform trans_tsumihiko = GetComponent<Transform>();
        Vector3 before_change = trans_tsumihiko.position;
        Vector3 add = new Vector3(0, 0, 0);
        add = direction_dicied(add, direction);
        Debug.Log(add);

        while (true)
        {
            for (int i = 0; i < 15; i++)
            {
                yield return new WaitForSeconds(0.1f); // ３秒待つ
                
                trans_tsumihiko.position += add;
                Debug.Log(trans_tsumihiko.position);
            }

            trans_tsumihiko.position = before_change;
        }
    }

    Vector3 direction_dicied(Vector3 add, char direction)
    {
        switch (direction)
        {
            case 'u':
                add.y = 10;
                break;
            case 'd':
                add.y = -10;
                break;
            case 'r':
                add.x = 10;
                break;
            case 'l':
                add.x = -10;
                break;
        }

        return (add);
    }
}
