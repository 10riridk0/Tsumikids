using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CoordinateRead : MonoBehaviour
{
    //csvファイルを突っ込むリスト
    public List<string[]> csvData = new List<string[]>();
    
    //仮引数: csvファイルの名前
    public void CsvRead(string dataName)
    {
        // TextAsset型にcsvロードする
        // TextAsset: テキストファイルのデータを取得できる
        // Resources.Load: Resourcesフォルダーにあるアセットを読み込む
        TextAsset csv = Resources.Load(dataName) as TextAsset;
        StringReader reader = new StringReader(csv.text);

        //文字の末尾まで繰り返す
        while (reader.Peek() > -1)
        {
            //「,」ごとに区切ってcsvData配列にぶちこむ
            //reader.ReadLine: 1行分の文字を読み取り、そのデータを文字列として返す
            string line = reader.ReadLine();
            csvData.Add(line.Split(','));
        }
        for (int i = 0; i < csvData.Count; i++) {
            for (int j = 0; j < csvData[i].Length; j++) {
                Debug.Log(csvData[i][j]);
            }       
        }
    }

    void Start()
    {
        CsvRead("data");
    }
}
