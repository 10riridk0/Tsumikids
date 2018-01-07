using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_main : MonoBehaviour {

    //フェードアウトするかどうか
    public static bool fading = false;
    //ダンジョンのプログラムにミスがあったらフェードアウトするか
    public static bool isMissFading = false;
    //ステージ番号を格納する変数
    public static int stage_number;
    //敵の名前、問題番号の取得
    public static string enemy_name;
    public static int probrem_number;
    //つみひこの位置
    public static int tsumihiko_x, tsumihiko_y;
    //コルーチンを実行するためのインスタンス
    public static MonoBehaviour Dungeon;
    //コライダーを扱う
    BoxCollider2D collider2D;
    //ゴールしたかどうか
    public static bool isGoal = false;

    //どこのシーンに行くか
    public static bool back_main = false;
    public static bool trans_next = false;

    //次のステージの番号取得
    public static int next_stage_number;


    // Use this for initialization
    void Start()
    {
        collider2D = GameObject.Find("tu_mihico").GetComponent<BoxCollider2D>();
        collider2D.isTrigger = false;
        //ステージ番号の取得(ステージ情報をとるため)
        stage_number = Stage.get_stage_number();
        Debug.Log(stage_number);
        Debug.Log(Stage.start_position[stage_number - 1]);
        Destroy_Enemy.kill_Enemy();

        //つみひこの初期位置(スタート地点)を保存
        SaveData.SetInt("before_x", tsumihiko_x);
        SaveData.SetInt("before_y", tsumihiko_y);
        SaveData.Save();

        //つみひこのゲーム上の位置を設定
        Main.trans_tsumihiko = GetComponent<Transform>();
        //Debug.Log(Main.trans_tsumihiko);
        Vector3 initial = Stage.start_position[stage_number - 1];

        initial.x += (tsumihiko_x - 1) * 150;
        initial.y += (tsumihiko_y - 1) * 150;
        Main.trans_tsumihiko.position = initial;

        //コルーチンを開始するためのインスタンス
        Dungeon = this;

        //ライフ表示
        Main.life_display();

        trans_next = false;
        back_main = false;
        isGoal = false;
        fading = false;
        isMissFading = false;

        collider2D.isTrigger = true;
    }

    /*
     *つみひこのいるマス目をSaveDataの中から探す
     * fadingをfalseにしてバトルシーンに移らないようにする
     */
    private void Awake()
    {
        Debug.Log("敵は" + SaveData.GetString("isAlive"));
        tsumihiko_x = SaveData.GetInt("x", 1);
        tsumihiko_y = SaveData.GetInt("y", 1);
        if (tsumihiko_x == 0)
        {
            tsumihiko_x = 1;
            tsumihiko_y = 1;
        }
        fading = false;
        isMissFading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fading)
        {
            SceneTransition.FadeIn();
        }

        if (fading)
        {
            SceneTransition.ChangeScene("battle");
        }

        /*
         * ダンジョンのプログラムがミスってたときのif
         * true: フェードアウト/今いるシーンを再度読み込み
         * false: フェードイン
         */
        if (isMissFading)
        {
            SceneTransition.ChangeScene("Stage" + stage_number.ToString());
            Debug.Log("Stage" + stage_number + "を再度読み込みます");
            Debug.Log("Dungeon_main.cs map: " + Stage.map[Dungeon_main.stage_number - 1, Dungeon_main.tsumihiko_y, Dungeon_main.tsumihiko_x]);
        }
        else
        {
            SceneTransition.FadeIn();
        }
        //Debug.Log(trans_next);
        //Debug.Log(fading);
        if (trans_next)
        {
            SceneTransition.ChangeScene("Stage" + next_stage_number.ToString());
        }

        if (back_main)
        {
            SceneTransition.ChangeScene("main");
        }
    }

    //敵とぶつかったときの処理
    void OnTriggerEnter2D(Collider2D t)
    {
        int sum;
        sum = count_enemy();

        //敵の名前を取得
        GameObject enemy = t.gameObject;
        enemy_name = enemy.name;
        Debug.Log(enemy_name);

        //敵の問題番号取得
        Debug.Log(stage_number - 1);
        Debug.Log(tsumihiko_x);
        Debug.Log(tsumihiko_y);
        probrem_number = Stage.map[stage_number - 1, tsumihiko_y, tsumihiko_x] - 2;
        Debug.Log(probrem_number);
        Debug.Log(Stage.map[stage_number - 1, tsumihiko_y, tsumihiko_x]);
        //Debug.Log(probrem_number);

        //敵を笑わす
        Animator animator;
        animator = enemy.GetComponent<Animator>();
        animator.SetBool("wara", true);

        //敵とぶつかったときの座標を保存
        SaveData.SetInt("x", Program_Execution.x);
        SaveData.SetInt("y", Program_Execution.y);
        SaveData.SetString("enemy_name", enemy_name);
        SaveData.SetString("Stage", Stage.scene_name);
        SaveData.SetInt("enemy_num", sum);
        SaveData.SetString("isAlive", Main.isAlive);
        SaveData.Save();

        //BGM,SEの保存
        BgmFader.FadeSet();
        SoundEffect.Play("meet_enemy", 1);
        fading = true;

    }

    int count_enemy()
    {
        int sum = 0;

        for (int i = 1; i < 8; i++)
        {
            for (int j = 1; j < 8; j++)
            {
                Debug.Log(i);
                Debug.Log(j);
                if (i == tsumihiko_y && j == tsumihiko_x)
                {
                    return (sum);
                }
                if (Stage.map[stage_number - 1, i, j] > 1)
                {
                    sum++;
                }
            }
        }
        return (sum);
    }

    /*
    * 仮引数の位置につみひこを戻す関数
    * 仮引数: プログラム実行前のつみひこの位置
    */
    public static void restorePosition(int st_tsumihiko_x, int st_tsumihiko_y)
    {
        Debug.Log("st_tsumihiko_x =" + st_tsumihiko_x);
        Debug.Log("st_tsumihiko_y =" + st_tsumihiko_y);
        Debug.Log("tsumihiko_x =" + tsumihiko_x);
        Debug.Log("tsumihiko_y =" + tsumihiko_y);
        tsumihiko_x = st_tsumihiko_x;
        tsumihiko_y = st_tsumihiko_y;
    }

    /*
     * ダンジョンのプログラムにミスがあれば、isMissFadingをtrueにする
     */
     public static void programMissFading()
    {
        isMissFading = true;
    }

    //問題の取得
    public static string get_probrem(int num)
    {
        return (Enemy_data.Probrems[enemy_name[7], probrem_number]);
    }

    //ゴールした時の花火
    public static void Goal()
    {
        GameObject menu;

        Main.life = 3;

        isGoal = true;
        BgmFader.FadeSet();
        SoundEffect.Play("goal", 1);
        menu = (GameObject)Resources.Load("Dungeon/goal_menu");
        Instantiate(menu);
        Destroy(GameObject.Find("mainmenu_tumiki_004"));

        Vector3[] p = { new Vector3(-650, -300, 0), new Vector3(-300, 300, 0), new Vector3(0, -100, 0)} ;
        Dungeon.StartCoroutine(EffectPosition.fire_work(p[0], 0));
        Dungeon.StartCoroutine(EffectPosition.fire_work(p[1], 1));
        Dungeon.StartCoroutine(EffectPosition.fire_work(p[2], 2));
    }

    public static void menu(Vector3 pos)
    {
            next_stage_number = SaveData.GetString("Stage", "stage1")[5] - '0' + 1;
            SaveData.Clear();
            SaveData.SetString("Stage", "Stage" + next_stage_number.ToString());
            SaveData.Save();
        if ((pos.x >= 500 && pos.x <= 700) && (pos.y > 0 && pos.y <= 200)){
            if (SaveData.GetString("Stage") == "Stage5")
            {
                back_main = true;
                SaveData.Clear();
            }
            else
            {
                trans_next = true;
            }
        }
        else if ((pos.x >= 500 && pos.x <= 700) && (pos.y > -200 && pos.y <= 0))
        {
            SaveData.Clear();
            back_main = true;
        }
    }
}