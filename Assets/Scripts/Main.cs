using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public bool[] isAlive = new bool[5];
    public static int life = 3;
    public static Transform trans_tsumihiko;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        life_display();
	}

    void life_display()
    {
        GameObject life = GameObject.Find("life");
        //life.hideFlags
        //Instantiate(life, new Vector3(-63, 440, 0), Quaternion.identity);
    }
}
