using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ParticleSystem par = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule ma = par.main;
        ma.startColor = Color.red;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
