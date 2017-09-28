using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program_Execution : MonoBehaviour {

    public static char instruction;
    int[,,] tsumihiko_cell = new int[3, 8, 8];
    public static Vector3 before_change;
    public static Vector3 add;// = new Vector3(0, 0, 0);
    public static Stage stage;
    public static char name_initial;
    public static Program_Execution instance;

    // Use this for initialization
    void Start () {
        //exe("uuu");
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void Awake()
    {
        instance = this;
        stage = GetComponent<Stage>();
    }

    //つみひこ移動関数
    static IEnumerator move(char direction)
    {
        add = new Vector3(0, 0, 0);
        //before_change = main.trans_tsumihiko.position;
        add = direction_dicied(add, direction);
        for (int i = 0; i < 15; i++)
        {
            Dungeon_main.trans_tsumihiko.position += add;
            //Debug.Log(direction);

            yield return new WaitForSeconds(0.1f);
        }
    }

    static Vector3 direction_dicied(Vector3 add, char direction)
    {
        switch (direction){
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

    static IEnumerator Attack(char actions)
    {
        yield return null;
    }

    /*void OnGUI()
    {
        directions = GUI.TextField(new Rect(10, 10, 200, 20), directions, 25);
        if (GUI.Button(new Rect(10, 10, 100, 40), "Move"))
        {
            StartCoroutine(Read(directions, 'S'));
        }
    }*/

    static IEnumerator Read(string program, char scene_initial)
    {
        //MonoBehaviour execute = new MonoBehaviour();
        for (int i = 0; i < program.Length; i++)
        {
            instruction = program[i];
            Debug.Log(instruction);

            if (scene_initial == 'S')
            {
                instance.StartCoroutine(move(instruction));
            }
            else if (scene_initial == 'b'){
                instance.StartCoroutine(Attack(instruction));
            }
            
            //yield return move(directions);
            yield return new WaitForSeconds(2.2f);
        }
    }

    public static void exe(string pro)
    {
        name_initial = Stage.scene_name[0];
        Debug.Log(pro);
        Debug.Log(instance);
        instance.StartCoroutine(Read(pro, name_initial));
    }
}