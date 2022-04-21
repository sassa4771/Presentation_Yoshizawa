using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Login;

public class SendPopUpManager : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    [SerializeField] Text popUpMessage;

    public void OnClickSendPopUp()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.LogError("Not connected to the network");
        }
        else
        {
            if (GetLoginInfo.school_num == 0 || GetLoginInfo.grade_num == 0 || GetLoginInfo.number_num == 0 || GetLoginInfo.gender_num == 2 || GetLoginInfo.age_num == 0) //error
            {
                Debug.Log("error");
            }
            else    //popup
            {
                popUp.SetActive(true);
                PopUpMessage(GetLoginInfo.school_num, GetLoginInfo.grade_num, GetLoginInfo.class_num, GetLoginInfo.number_num, GetLoginInfo.gender_num, GetLoginInfo.age_num);
            }
        }
    }

    /// <summary>
    /// ポップアップのメッセージを表示させる
    /// </summary>
    /// <param name="school_num">学校番号</param>
    /// <param name="grade_num">学年</param>
    /// <param name="class_num">学級</param>
    /// <param name="number_num">出席番号</param>
    /// <param name="gender">性別</param>
    /// <param name="age_num">年齢</param>
    public void PopUpMessage(int school_num, int grade_num, int class_num, int number_num, int gender, int age_num) //popup
    {
        popUpMessage.text = "確認（かくにん）" + "\n" + "\n" +
            "学校番号（がっこうばんごう）: " + ConversionSchool(school_num, grade_num) + "\n" +
            "学年（がくねん）: " + ConversionGrade(grade_num) + "\n" +
            "学級（がっきゅう）: " + class_num + ConversionClass(class_num) + "\n" +
            "番号（ばんごう）: " + number_num + "\n" +
            "性別（せいべつ）: " + ConversionGender(gender) + "\n" +
            "年齢（ねんれい）: " + age_num;
        Debug.Log("PopUpMessage");
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
        else if(grade <= 9) //中学生
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

    /// <summary>
    /// アルファベット版の学級番号も一緒につけて学級番号をstring型で返す
    /// </summary>
    /// <param name="class_num">学級</param>
    /// <returns>アルファベット付きの学級</returns>
    private string ConversionClass(int class_num)   //popup
    {
        string class_str;
        switch (class_num)
        {
            case 1:
                class_str = "(A)";
                return class_str;
            case 2:
                class_str = "(B)";
                return class_str;
            case 3:
                class_str = "(C)";
                return class_str;
            case 4:
                class_str = "(D)";
                return class_str;
            case 5:
                class_str = "(E)";
                return class_str;
            case 6:
                class_str = "(F)";
                return class_str;
            case 7:
                class_str = "(G)";
                return class_str;
            case 8:
                class_str = "(H)";
                return class_str;
            case 9:
                class_str = "(I)";
                return class_str;
            case 10:
                class_str = "(J)";
                return class_str;
            default:
                return null;
        }

    }

    /// <summary>
    /// 中学生の学年は７〜９で処理しているため、表示する際に１〜３で表示するために変換をする
    /// </summary>
    /// <param name="grade">学年</param>
    /// <returns>小学生なら１〜６、中学生なら１〜３</returns>
    private int ConversionGrade(int grade)  //popup
    {
        int popup_grade_num;

        if (grade <= 6) //小学生
        {
            popup_grade_num = grade;
            return popup_grade_num;
        }
        else if(grade <= 9) //中学生
        {
            popup_grade_num = grade - 6;
            return popup_grade_num;
        }
        else  //高校生
        {
            popup_grade_num = grade - 9;
            return popup_grade_num;
        }
    }

    /// <summary>
    /// 性別は０と１で処理しているため、表示する際に男女表記にするために変換をする
    /// </summary>
    /// <param name="gender">性別</param>
    /// <returns>"男（おとこ）"または"女（おんな）"</returns>
    private string ConversionGender(int gender) //popup
    {
        string gender_str;

        if (gender == 0)
        {
            gender_str = "男（おとこ）";
            return gender_str;
        }
        else if (gender == 1)
        {
            gender_str = "女（おんな）";
            return gender_str;
        }
        else
        {
            gender_str = null;
            return gender_str;
        }
    }
}
