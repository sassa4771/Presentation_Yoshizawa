using UnityEngine;
using UnityEngine.Events;
using System.Net.Http;

namespace SendTest
{
    public class SendDataToServer
    {
        private string UrlOrigin = "https://star2020.xsrv.jp/app_assessment/UnityPresentation.php/";
        private string SchoolNumber;
        private string SchoolGrade;
        private string SchoolClass;
        private string PersonalNumber;
        private string StudentGender;
        private string StudentAge;

        //コンストラクタ
        public SendDataToServer(string SchoolNumber, string SchoolGrade, string SchoolClass, string PersonalNumber, string StudentGender, string StudentAge)
        {
            this.SchoolNumber = SchoolNumber;
            this.SchoolGrade = SchoolGrade;
            this.SchoolClass = SchoolClass;
            this.PersonalNumber = PersonalNumber;
            this.StudentGender = StudentGender;
            this.StudentAge = StudentAge;
        }

        //コールバック付きのサーバー送信メソッド
        public async void SendData(string pattern, string gamedata, UnityAction CallBack)
        {
            HttpClient client = new HttpClient();
            var url = MakeURL(SchoolNumber, SchoolGrade, SchoolClass, PersonalNumber, StudentGender, StudentAge, pattern, gamedata);
            var result = await client.GetStringAsync(url);

            //サーバーからの返信表示
            Debug.Log("result= " + result);

            //サーバーからの結果が帰ってきたあとに実行される処理。
            CallBack();
        }

        //コールバックなしのサーバー送信メソッド
        public async void SendData(string pattern, string gamedata)
        {
            HttpClient client = new HttpClient();
            var url = MakeURL(SchoolNumber, SchoolGrade, SchoolClass, PersonalNumber, StudentGender, StudentAge, pattern, gamedata);
            var result = await client.GetStringAsync(url);

            //サーバーからの返信表示
            Debug.Log("result= " + result);
        }

        //URLを生成するメソッド
        private string MakeURL(string SchoolNumber, string SchoolGrade, string SchoolClass, string PersonalNumber, string StudentGender, string StudentAge, string pattern, string gamedata)
        {
            //?SchoolNumber=s2&SchoolGrade=2&SchoolClass=2&PersonalNumber=23&StudentGender=1&StudentAge=14&pattern=0&gamedata=2
            return UrlOrigin + "?SchoolNumber=" + SchoolNumber + "&SchoolGrade=" + SchoolGrade + "&SchoolClass=" + SchoolClass + "&PersonalNumber=" + PersonalNumber + "&StudentGender=" + StudentGender + "&StudentAge=" + StudentAge + "&pattern=" + pattern + "&gamedata=" + gamedata;
        }
    }
}