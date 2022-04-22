using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using SendTest;

namespace Login
{
    public class GetLoginInfo : MonoBehaviour
    {
        public static int school_num;
        public static int grade_num;
        public static int class_num;
        public static int number_num;
        public static int gender_num;
        public static int age_num;

        SendDataToServer sendDataToServer;

        private void Start()
        {
            grade_num = 0;
            class_num = 0;
            number_num = 0;
            gender_num = 2;
            age_num = 0;
        }

        /// <summary>
        /// DataScriptsのオブジェクトにそれぞれのデータを格納する
        /// </summary>
        public void SendID()
        {
            DataScripts.SchoolNumber = ConversionSchool(school_num, grade_num);
            DataScripts.SchoolGrade = grade_num;
            DataScripts.SchoolClass = class_num;
            DataScripts.PersonalNumber = number_num;
            DataScripts.StudentGender = gender_num;
            DataScripts.StudentAge = age_num;

            sendDataToServer = new SendDataToServer(DataScripts.SchoolNumber, DataScripts.SchoolGrade.ToString(), DataScripts.SchoolClass.ToString(), DataScripts.PersonalNumber.ToString(), DataScripts.StudentGender.ToString(), DataScripts.StudentAge.ToString());
        }

        /// <summary>
        /// 小学校なら先頭に”ｓ”を、中学校なら先頭に”ｃ”をつけてstring型で返す
        /// </summary>
        /// <param name="school">学校番号</param>
        /// <param name="grade">学年</param>
        /// <returns>先頭にアルファベット付きの学校番号</returns>
        private string ConversionSchool(int school, int grade) //popup
        {
            string school_str;
            if (grade <= 6) //小学生
            {
                school_str = "s" + school.ToString();
                return school_str;
            }
            else if (grade <= 9) //中学生
            {
                school_str = "c" + school.ToString();
                return school_str;
            }
            else  //高校生
            {
                school_str = "k" + school.ToString();
                return school_str;
            }
        }
    }
}