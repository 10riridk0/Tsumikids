using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoge : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SceneTransition.SceneFadeIn();
        if (Input.anyKey)
        {
            SoundEffect.Play("Glory of fanfare", 0.1f);
        }
    }
}
