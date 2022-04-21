using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Login;

public class IDErrorPopUpManager : MonoBehaviour
{
    [SerializeField] GameObject cautionPopUp;
    [SerializeField] Text cautionText;

    /// <summary>
    /// 選択されていない項目があった場合は警告のポップアップを表示し、すべて選択されている場合は選択されている番号などをポップアップで表示する
    /// </summary>
    public void OnClickSendButton() //popup,popup(error)
    {
        if (GetLoginInfo.school_num == 0 || GetLoginInfo.grade_num == 0 || GetLoginInfo.number_num == 0 || GetLoginInfo.gender_num == 2 || GetLoginInfo.age_num == 0) //error
        {
            Debug.Log("error");
            cautionPopUp.SetActive(true);
            cautionText.text = null;
            if (GetLoginInfo.school_num == 0)
            {
                cautionText.text += "学校番号が選択されていません";
            }
            if (GetLoginInfo.grade_num == 0)
            {
                cautionText.text += "\n" + "\n" + "学年が選択されていません";
            }
            if (GetLoginInfo.number_num == 0)
            {
                cautionText.text += "\n" + "\n" + "出席番号が選択されていません";
            }
            if (GetLoginInfo.gender_num == 2)
            {
                cautionText.text += "\n" + "\n" + "性別が選択されていません";
            }
            if (GetLoginInfo.age_num == 0)
            {
                cautionText.text += "\n" + "\n" + "年齢が選択されていません";
            }
        }
    }
}