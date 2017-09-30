using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SaveTest : MonoBehaviour
{

    [SerializeField]
    public class Player
    {
        [SerializeField]
        public int hp;
        public float atk;
        public string name;
        public List<string> items;
        public Player()
        {

            items = new List<string>();
            items.Add("ポーション");
            items.Add("エーテル");
            items.Add("エリクサー");
            hp = 10;
            atk = 100f;
            name = "クラウド";
        }

    }
    // Use this for initialization
    void Start()
    {
        //セーブデータの設定
        SaveData.SetInt("i", 10);
        SaveData.SetClass<Player>("p1", new Player());
        SaveData.Save();

        Player getPlayer = SaveData.GetClass<Player>("p1", new Player());

        Debug.Log("取得したint値は" + SaveData.GetInt("i"));
        Debug.Log(getPlayer.name);
        Debug.Log(getPlayer.items.Count + "こアイテムを持ってます");
        Debug.Log(getPlayer.items[0] + getPlayer.items[1] + getPlayer.items[2]);


    }

    // Update is called once per frame
    void Update()
    {

    }
}