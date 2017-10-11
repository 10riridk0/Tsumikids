using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_effect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator delete()
    {
        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
