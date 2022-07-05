﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SendTest;

public class SendScreenManager : MonoBehaviour
{
    [SerializeField] GameObject Send;
    [SerializeField] GameObject End;
    [SerializeField] GameObject facialExplain;
    public GameObject sendMark;
    public static bool rotate = false;
    public static bool sendBool = false;
    public static bool facialSendBool = false;
    SendDataToServer sendDataToServer;

    // Update is called once per frame
    void Update()
    {
        if (sendBool)
        {
            sendBool = false;
            SendPatternAndGameData();
        }

        if (facialSendBool)
        {
            FacialSendPatternAndGameData();
            facialSendBool = false;
        }

        if (rotate)
        {
            RotateSendMark();
        }
    }

    public static void StartSendScreen()
    {
        rotate = true;
        sendBool = true;
    }

    public static void FacialStartSendScreen()
    {
        rotate = true;
        facialSendBool = true;
    }

    void RotateSendMark()
    {
        sendMark.transform.Rotate(0, 0, -1);
    }

    public void StopRotateSendMark()
    {
        rotate = false;
    }

    public void SwitchScreen()
    {
        StopRotateSendMark();
        Send.SetActive(false);
        End.SetActive(true);
    }

    public void FacialSwitchScreen()
    {
        StopRotateSendMark();
        Send.SetActive(false);
        facialExplain.SetActive(true);
    }

    //サーバー連携するまで未実装　
    public void SendPatternAndGameData()
    {
        sendDataToServer = new SendDataToServer(DataScripts.SchoolNumber, DataScripts.SchoolGrade.ToString(), DataScripts.SchoolClass.ToString(), DataScripts.PersonalNumber.ToString(), DataScripts.StudentGender.ToString(), DataScripts.StudentAge.ToString());
        sendDataToServer.SendData(DataScripts.pattern.ToString(), DataScripts.gamedata, SwitchScreen);
        //Invoke(nameof(SwitchScreen), 5.0f);
        DataScripts.gamedata = null;

        Debug.Log("---Check Start---");
        Debug.Log(DataScripts.SchoolNumber);
        Debug.Log(DataScripts.SchoolGrade.ToString());
        Debug.Log(DataScripts.SchoolClass.ToString());
        Debug.Log(DataScripts.PersonalNumber.ToString());
        Debug.Log(DataScripts.StudentGender.ToString());
        Debug.Log(DataScripts.StudentAge.ToString());
        Debug.Log("---Check Finish---");
    }

    public void FacialSendPatternAndGameData()
    {
        sendDataToServer = new SendDataToServer(DataScripts.SchoolNumber, DataScripts.SchoolGrade.ToString(), DataScripts.SchoolClass.ToString(), DataScripts.PersonalNumber.ToString(), DataScripts.StudentGender.ToString(), DataScripts.StudentAge.ToString());
        sendDataToServer.SendData(DataScripts.pattern.ToString(), DataScripts.gamedata, FacialSwitchScreen);
        //Invoke(nameof(FacialSwitchScreen), 5.0f);
        DataScripts.gamedata = null;
    }

}
