using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Login
{
    public class GetLoginInfo : MonoBehaviour
    {
        public ToggleGroup[] toggleGroup;
        public Text popUpMessage;
        //public Text ID_text;

        private int school_num;
        private int grade_num;
        private int class_num;
        private int number_num;
        private int age_num;

        private string class_str = " ";
        private string gender_str = " ";
        private string gender_str_no_furigana = " ";


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
            Debug.Log("Gender: " + gender_label);

            string age_label = toggleGroup[5].ActiveToggles().First().GetComponentsInChildren<Text>().First(t => t.name == "Label").text;
            age_num = int.Parse(age_label);
            Debug.Log("Age: " + age_num);

            PopUpMessage(school_num, grade_num, class_num, number_num, gender_label, age_num);
            //RecordID(school_num, grade_num, class_num, number_num, gender_label, age_num);
        }

        public void PopUpMessage(int school_num, int grade_num, int class_num, int number_num, string gender, int age_num)
        {
            ConversionID(class_num, gender);
            popUpMessage.text = "確認（かくにん）" + "\n" + "\n" +
                "学校番号（がっこうばんごう）: " + school_num + "\n" +
                "学年（がくねん）: " + grade_num + "\n" +
                "学級（がっきゅう）: " + class_num + class_str + "\n" +
                "番号（ばんごう）: " + number_num + "\n" +
                "性別（せいべつ）: " + gender_str + "\n" +
                "年齢（ねんれい）: " + age_num;
            Debug.Log("PopUpMessage");
        }

        //DataScriptに送る処理
        //中学生の学年は７、８、９にして送信（ラベルは今まで通り）
        //gradeが中学生（7〜9）の場合、datascriptにいれるschoolnumberにcをつける、小学生ならsをつける処理


        public void ConversionID(int class_num, string gender)
        {
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

            if (gender == "Men")
            {
                gender_str = "男（おとこ）";
                gender_str_no_furigana = "男";
            }
            else if (gender == "Women")
            {
                gender_str = "女（おんな）";
                gender_str_no_furigana = "女";
            }
        }

        public void RecordID(int school_num, int grade_num, int class_num, int number_num, string gender, int age_num)
        {
            ConversionID(class_num, gender);
            //ID_text.text = "学校番号: " + school_num + "  " + grade_num + "年" + class_num + class_str + "組" + number_num + "番 " + gender_str_no_furigana + " " + age_num + "歳";
            Debug.Log("RecordID");
        }
    }
}