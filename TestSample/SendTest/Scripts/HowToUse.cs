using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SendTest
{
    public class HowToUse : MonoBehaviour
    {
        SendDataToServer SendDataToServer;
        string pattern;
        string gamedata;

        // Start is called before the first frame update
        void Start()
        {
            //Loginシーンで設定する値のセットアップ
            string SchoolNumber = "s1";
            int SchoolGrade = 2;
            int SchoolClass = 3;
            int PersonalNumber = 12;
            int StudentGender = 0;
            int StudentAge = 7;

            //SendDataToServerスクリプトの追加（※ここでログイン情報をコンストラクタの引数に渡す）
            SendDataToServer = new SendDataToServer(SchoolNumber, SchoolGrade.ToString(), SchoolClass.ToString(), PersonalNumber.ToString(), StudentGender.ToString(), StudentAge.ToString());

            //ゲーム終了時に送るデータ
            pattern = "1";
            //※注意：gamedataはstringで送るため「"」をつけないようにする。また、スペースを少なくする統一をしてほしい。→スペースが統一されてないと後解析で大変になる
            gamedata = "<data>" + "\n" +  "<target>happy</target><trial num=1><face>happy</face><lr>left</lr><correct>yes</correct><reactiontime>1000</reactiontime></trial><trial num=2><face>anger</face><lr>right</lr><correct>no</correct><reactiontime>2300</reactiontime></trial></data>";
        }

        //ボタンを押されたときの処理
        public void ButtonClickSend()
        {
            SendDataToServer.SendData(pattern, gamedata);
        }

        //ボタンを押されたときの処理
        public void ButtonClickSendandCallBack()
        {
            SendDataToServer.SendData(pattern, gamedata, CallBack);
        }

        //コールバックで呼び出される処理
        public void CallBack()
        {
            Debug.Log("This Function is Called from SendDataToServer Scripts");
        }
    }
}