using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class StartUp
{
    static StartUp()
    {
        System.Diagnostics.Process p = new System.Diagnostics.Process();
        //p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
        p.StartInfo.FileName = "exe_python";

        //p.StartInfo.Arguments = @"python C:/Users/ict/Desktop/pic.py";

        p.Start();
    }
}
