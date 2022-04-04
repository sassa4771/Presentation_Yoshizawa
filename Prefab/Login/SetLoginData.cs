using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLoginData : MonoBehaviour
{
    /// <summary>
    /// 「学校番号」のToggleボタンにアタッチする。押した際にDataScriiptsに登録される
    /// </summary>
    /// <param name="SchoolNumber"></param>
    public void ToggleClickRegistSchoolNumber(string SchoolNumber)
    {
        if (this.gameObject.GetComponent<Toggle>().isOn)
        {
            DataScripts.SchoolNumber = SchoolNumber;
            Debug.LogError("You Select SchoolNumber = " + DataScripts.SchoolNumber);
        }
    }

    /// <summary>
    /// 「学年」のToggleボタンにアタッチする。押した際にDataScriiptsに登録される
    /// このとき「学校番号」に小学生なら「s」、中学生なら「c」を追加で入れる。
    /// </summary>
    /// <param name="SchoolGrade"></param>
    public void ToggleClickRegisterSchoolGrade(int SchoolGrade)
    {
        if (this.gameObject.GetComponent<Toggle>().isOn)
        {
            DataScripts.SchoolGrade = SchoolGrade;
            Debug.LogError("You Select SchoolGrade = " + DataScripts.SchoolGrade);
        }
    }

    /// <summary>
    /// 「学級」のToggleボタンにアタッチする。押した際にDataScriiptsに登録される
    /// </summary>
    /// <param name="SchoolClass"></param>
    public void ToggleClickRegisterSchoolClass(int SchoolClass)
    {
        if (this.gameObject.GetComponent<Toggle>().isOn)
        {
            DataScripts.SchoolClass = SchoolClass;
            Debug.LogError("You Select SchoolClass = " + DataScripts.SchoolClass);
        }
    }

    /// <summary>
    /// 「出席番号」のToggleボタンにアタッチする。押した際にDataScriiptsに登録される
    /// </summary>
    /// <param name="PersonalNumber"></param>
    public void ToggleClickRegisterPersonalNumber(int PersonalNumber)
    {
        if (this.gameObject.GetComponent<Toggle>().isOn)
        {
            DataScripts.PersonalNumber = PersonalNumber;
            Debug.LogError("You Select PersonalNumber = " + DataScripts.PersonalNumber);
        }
    }

    /// <summary>
    /// 「性別」のToggleボタンにアタッチする。押した際にDataScriiptsに登録される
    /// </summary>
    /// <param name="StudentGender"></param>
    public void ToggleClickRegisterStudentGender(int StudentGender)
    {
        if (this.gameObject.GetComponent<Toggle>().isOn)
        {
            DataScripts.StudentGender = StudentGender;
            Debug.LogError("You Select StudentGender = " + DataScripts.StudentGender);
        }
    }

    /// <summary>
    /// 「年齢」のToggleボタンにアタッチする。押した際にDataScriiptsに登録される
    /// </summary>
    /// <param name="StudentAge"></param>
    public void ToggleClickRegisterStudentAge(int StudentAge)
    {
        if (this.gameObject.GetComponent<Toggle>().isOn)
        {
            DataScripts.StudentAge = StudentAge;
            Debug.LogError("You Select StudentAge = " + DataScripts.StudentAge);
        }
    }
}
