using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataScripts : ScriptableObject
{
    //ログインで使用する
    public static string SchoolNumber;      //学校番号を保持する
    public static int SchoolGrade;          //生徒の学年を保持する
    public static int SchoolClass;          //生徒のクラスを保持する
    public static int PersonalNumber;       //生徒の出席番号を保持する
    public static int StudentGender;        //生徒の性別を保持する
    public static int StudentAge;           //生徒の年齢を保持する

    //ゲーム開始してから使用する変数（※ゲームごとに初期化が必要）
    public static int pattern;              //ゲームの種類を保持
    public static string gamedata;          //XML形式でゲームデータを保持する
}