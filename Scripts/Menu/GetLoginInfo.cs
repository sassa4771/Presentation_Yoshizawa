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
        public ToggleGroup[] toggleGroup;
        public Text popUpMessage;
        //public Text ID_text;

        private int school_num;
        private string school_str;
        private int grade_num;
        private int class_num;
        private int number_num;
        private int gender_num;
        private int age_num;
        private int popup_grade_num;
        private string class_str = " ";
        private string gender_str = " ";

        SendDataToServer sendDataToServer;

        public void OnClickGetID()
        {
            string school_label = toggleGroup[0].ActiveToggles().First().GetComponentsInChildren<Text>().First(t => t.name == "Label").text;   //labelのテキストをstring型で取得
            school_num = int.Parse(school_label);   //string型で取得したテキストをint型の数値に変換して代入
            Debug.Log("School: " + school_num);

            string grade_label = toggleGroup[1].ActiveToggles().First().GetComponentsInChildren<Text>().First(t => t.name == "Label").text;
            grade_num = int.Parse(grade_label);
            Debug.Log("Grade: " + grade_num);

            string class_label = toggleGroup[2].ActiveToggles().First().GetComponentsInChildren<Text>().First(t => t.name == "Label").text;
            class_num = int.Parse(class_label);
            Debug.Log("Class: " + class_num);

            string number_label = toggleGroup[3].ActiveToggles().First().GetComponentsInChildren<Text>().First(t => t.name == "Label").text;
            number_num = int.Parse(number_label);
            Debug.Log("Number: " + number_num);

            string gender_label = toggleGroup[4].ActiveToggles().First().GetComponentsInChildren<Text>().First(t => t.name == "Label").text;
            gender_num = int.Parse(gender_label);
            Debug.Log("Gender: " + gender_label);

            string age_label = toggleGroup[5].ActiveToggles().First().GetComponentsInChildren<Text>().First(t => t.name == "Label").text;
            age_num = int.Parse(age_label);
            Debug.Log("Age: " + age_num);

            PopUpMessage(school_num, grade_num, class_num, number_num, gender_num, age_num);
        }

        public void PopUpMessage(int school_num, int grade_num, int class_num, int number_num, int gender, int age_num)
        {
            
            ConversionID(grade_num, class_num, gender);
            popUpMessage.text = "確認（かくにん）" + "\n" + "\n" +
                "学校番号（がっこうばんごう）: " + school_str + "\n" +
                "学年（がくねん）: " + popup_grade_num + "\n" +
                "学級（がっきゅう）: " + class_num + class_str + "\n" +
                "番号（ばんごう）: " + number_num + "\n" +
                "性別（せいべつ）: " + gender_str + "\n" +
                "年齢（ねんれい）: " + age_num;
            Debug.Log("PopUpMessage");
        }

        public void SendID()
        {
            DataScripts.SchoolNumber = school_str;
            DataScripts.SchoolGrade = grade_num;
            DataScripts.SchoolClass = class_num;
            DataScripts.PersonalNumber = number_num;
            DataScripts.StudentGender = gender_num;
            DataScripts.StudentAge = age_num;

            sendDataToServer = new SendDataToServer(DataScripts.SchoolNumber, DataScripts.SchoolGrade.ToString(), DataScripts.SchoolClass.ToString(), DataScripts.PersonalNumber.ToString(), DataScripts.StudentGender.ToString(), DataScripts.StudentAge.ToString());
        }

        public void ConversionID(int grade, int class_num, int gender)
        {
            if (grade <= 6)
            {
                school_str = "s" + school_num.ToString();
                popup_grade_num = grade_num;
            }
            else
            {
                school_str = "c" + school_num.ToString();
                popup_grade_num = grade_num - 6;
            }


            switch (class_num)
            {
                case 1:
                    class_str = "(A)";
                    break;
                case 2:
                    class_str = "(B)";
                    break;
                case 3:
                    class_str = "(C)";
                    break;
                case 4:
                    class_str = "(D)";
                    break;
                case 5:
                    class_str = "(E)";
                    break;
                case 6:
                    class_str = "(F)";
                    break;
                case 7:
                    class_str = "(G)";
                    break;
                case 8:
                    class_str = "(H)";
                    break;
                case 9:
                    class_str = "(I)";
                    break;
                case 10:
                    class_str = "(J)";
                    break;
                default:
                    break;
            }

            if (gender == 0)
            {
                gender_str = "男（おとこ）";
            }
            else if (gender == 1)
            {
                gender_str = "女（おんな）";
            }
            else
            {
                gender_str = null;
            }
        }
    }
}