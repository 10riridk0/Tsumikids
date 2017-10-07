using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public  static string isAlive;
    public static int life = 3;
    public static Transform trans_tsumihiko;

    // Use this for initialization
    void Start () {
        
	}

    private void Awake()
    {
        isAlive = SaveData.GetString("isAlive", "111111");
        Debug.Log(isAlive);
    }

    // Update is called once per frame
    void Update () {
       // life_display();
	}

    public static void life_display()
    {
        GameObject instance_life = (GameObject)Resources.Load("Other_Prefabs/lives/life"  + life.ToString());
        //life.hideFlags
        Instantiate(instance_life, new Vector3(-63, 440, life), Quaternion.identity);
        instance_life.name = "life" + life.ToString();
        Debug.Log(instance_life.name);

        instance_life = GameObject.Find("life" + (life + 1).ToString() + "(Clone)");
        if (instance_life == null)
        {
            Destroy(GameObject.Find("life3"));
        }
        Destroy(instance_life);
    }

    public static IEnumerator disp_error(int error)
    {
        GameObject error_obj;
        error_obj = (GameObject)Resources.Load("ErrorPrefab/" + error.ToString());
        error_obj = Instantiate(error_obj) as GameObject;

        yield return new WaitForSeconds(5.2f);

        Destroy(error_obj);

        yield return null;
    }
}
