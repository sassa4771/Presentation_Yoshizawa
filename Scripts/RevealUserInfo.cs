using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevealUserInfo : MonoBehaviour
{
    //DataScriptsにあるユーザー情報を表示する。
    string GradeNumber; //小学生を表す「s」または、中学生を表す「c」が入る
    string RevealSchoolGrade;
    // Start is called before the first frame update
    void Start()
    {
        //表示用の学年に変更する（7,8,9→1,2,3）
        if (DataScripts.SchoolGrade > 6) RevealSchoolGrade = (DataScripts.SchoolGrade - 6).ToString();

        this.GetComponent<Text>().text = "学校番号：" + DataScripts.SchoolNumber + ", 学年：" + RevealSchoolGrade + ", 学級：" + DataScripts.SchoolClass + ", 出席番号：" + DataScripts.PersonalNumber;
    }
}
