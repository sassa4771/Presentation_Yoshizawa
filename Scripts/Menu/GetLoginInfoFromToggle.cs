using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Login;

namespace Login
{
    public class GetLoginInfoFromToggle : MonoBehaviour
    {
        ToggleGroup[] toggleGroup = new ToggleGroup[6];

        // Start is called before the first frame update
        void Start()
        {
            toggleGroup[0] = GameObject.Find("ToggleGroupSchool").gameObject.GetComponent<ToggleGroup>();
            toggleGroup[1] = GameObject.Find("ToggleGroupGrade").gameObject.GetComponent<ToggleGroup>();
            toggleGroup[2] = GameObject.Find("ToggleGroupClass").gameObject.GetComponent<ToggleGroup>();
            toggleGroup[3] = GameObject.Find("ToggleGroupNumber").gameObject.GetComponent<ToggleGroup>();
            toggleGroup[4] = GameObject.Find("ToggleGroupGender").gameObject.GetComponent<ToggleGroup>();
            toggleGroup[5] = GameObject.Find("ToggleGroupAge").gameObject.GetComponent<ToggleGroup>();
        }

        /// <summary>
        /// それぞれのtoggleにアタッチする。選択されているtoggleのlabelのテキストを取得する
        /// </summary>
        /// <param name="label">学校番号->0, 学年->1, 学級->2, 出席番号->3, 性別->4, 年齢->5（Inspector上で選択）</param>
        public void OnClickGetID(int label)
        {
            switch (label)
            {
                case 0:
                    string school_label = toggleGroup[0].ActiveToggles().First().GetComponentsInChildren<Text>().First(t => t.name == "Label").text;   //labelのテキストをstring型で取得
                    GetLoginInfo.school_num = int.Parse(school_label);   //string型で取得したテキストをint型の数値に変換して代入
                    Debug.Log("School: " + GetLoginInfo.school_num);
                    return;
                case 1:
                    string grade_label = toggleGroup[1].ActiveToggles().First().GetComponentsInChildren<Text>().First(t => t.name == "Label").text;
                    GetLoginInfo.grade_num = int.Parse(grade_label);
                    Debug.Log("Grade: " + grade_label);
                    return;
                case 2:
                    string class_label = toggleGroup[2].ActiveToggles().First().GetComponentsInChildren<Text>().First(t => t.name == "Label").text;
                    GetLoginInfo.class_num = int.Parse(class_label);
                    Debug.Log("Class: " + class_label);
                    return;
                case 3:
                    string number_label = toggleGroup[3].ActiveToggles().First().GetComponentsInChildren<Text>().First(t => t.name == "Label").text;
                    GetLoginInfo.number_num = int.Parse(number_label);
                    Debug.Log("Number: " + number_label);
                    return;
                case 4:
                    string gender_label = toggleGroup[4].ActiveToggles().First().GetComponentsInChildren<Text>().First(t => t.name == "Label").text;
                    GetLoginInfo.gender_num = int.Parse(gender_label);
                    Debug.Log("Gender: " + gender_label);
                    return;
                case 5:
                    string age_label = toggleGroup[5].ActiveToggles().First().GetComponentsInChildren<Text>().First(t => t.name == "Label").text;
                    GetLoginInfo.age_num = int.Parse(age_label);
                    Debug.Log("Age: " + age_label);
                    return;
                default:
                    return;
            }
        }

    }

}
