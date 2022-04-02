using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Net.Http;

public class ServerTest : MonoBehaviour
{
    public Text textMesh;
    public UnityEvent OnCompleteAction; //インスペクタから登録できる

    void Start()
    {
        DemoApplication demoApp = new DemoApplication();
        demoApp.CompleteHandler += UpdateTextCallback;
        demoApp.GetHtmlAsync();
    }

    //GetHtmlAsyncの処理が終了した後に呼び出される関数。Actionによって追加されている。
    void UpdateTextCallback(string html)
    {
        textMesh.text = html;
        OnCompleteAction?.Invoke(); //インスペクタで登録した処理が実行される
    }

    //Inspectorで登録してあるとUpdateTextCallbackから呼び出される
    public void DebugLogOK()
    {
        Debug.Log("OK");
    }
}

//DemoViewから呼び出されるクラス
public class DemoApplication
{
    private string url = "https://star2020.xsrv.jp/app_assessment/unityTest.php/?SchoolNumber=s2&SchoolGrade=2&SchoolClass=2&PersonalNumber=23&StudentGender=1&StudentAge=14&pattern=0&data1=2";

    //public delegate void OnCompleteDelegate(string html);
    //public event OnCompleteDelegate CompleteHandler;
    public event Action<string> CompleteHandler; //上の２行を書き換えた

    public async void GetHtmlAsync()
    {
        HttpClient client = new HttpClient();
        var result = await client.GetStringAsync(url);
        CompleteHandler?.Invoke(result);
    }
}