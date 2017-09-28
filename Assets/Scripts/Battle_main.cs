using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        //SceneTransition.ChangeScene("Stage1");
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update () {
        SceneTransition.FadeIn();
    }
}
