using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Tsumihiko : MonoBehaviour {

    public string direction;
    bool fading = false;

    // Use this for initialization
    void Start () {
        SceneTransition.FadeIn();
        Stage stage = GetComponent<Stage>();
        Transform trans_tsumihiko = GetComponent<Transform>();
        Vector3 initial = stage.start_position[0];
        trans_tsumihiko.position = initial;
    }
	
	// Update is called once per frame
	void Update () {
        if (fading)
        {
            SceneTransition.ChangeScene("battle");
        }
    }

    //つみひこ移動関数
    IEnumerator move(string direction)
    {
        Transform trans_tsumihiko = GetComponent<Transform>();
        Vector3 before_change = trans_tsumihiko.position;
        Vector3 add = new Vector3(0, 0, 0);
        add = direction_dicied(add, direction);
        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(0.1f); // ３秒待つ
                
            trans_tsumihiko.position += add;
        }

        yield return new WaitForSeconds(0.1f); // ３秒待つ
    }

    Vector3 direction_dicied(Vector3 add, string direction)
    {
        switch (direction){
            case "u":
                add.y = 10;
                break;
            case "d":
                add.y = -10;
                break;
            case "r":
                add.x = 10;
                break;
            case "l":
                add.x = -10;
                break;
        }

        return (add);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 40), "Move"))
        {
            StartCoroutine("move", direction);
        }

        direction = GUI.TextField(new Rect(10, 10, 200, 20), direction, 25);
    }

    void OnTriggerEnter2D(Collider2D t)
    {
        GameObject enemy = t.gameObject;
        Animator animator;
        animator = enemy.GetComponent<Animator>();
        animator.SetBool("wara", true);
        Debug.Log(t);
        //fading = true;
    }
}