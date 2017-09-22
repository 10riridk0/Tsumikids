using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CoordinateRead : MonoBehaviour
{
    //csvファイルを突っ込むリスト
    public static List<string[]> data = new List<string[]>();
    
    //仮引数: csvファイルの名前
    public void CsvRead(string dataName)
    {
        // TextAsset型にcsvロードする
        // TextAsset: テキストファイルのデータを取得できる
        // Resources.Load: Resourcesフォルダーにあるアセットを読み込む
        TextAsset csv = Resources.Load("Coordinate/" + dataName) as TextAsset;
        StringReader reader = new StringReader(csv.text);

        //文字の末尾まで繰り返す
        while (reader.Peek() > -1)
        {
            //「,」ごとに区切ってdata配列にぶちこむ
            //reader.ReadLine: 1行分の文字を読み取り、そのデータを文字列として返す
            string line = reader.ReadLine();
            data.Add(line.Split(','));
        }
        for (int i = 0; i < data.Count; i++) {
            for (int j = 0; j < data[i].Length; j++) {
                Debug.Log(data[i][j]);
            }       
        }
    }

    void Start()
    {
        CsvRead("data");
    }
}
