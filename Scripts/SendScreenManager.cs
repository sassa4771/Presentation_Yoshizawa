using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sendBool)
        {
            SendPatternAndGameData();
            sendBool = false;
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
    void SendPatternAndGameData()
    {
        //sendDataToServer.SendData(DataScripts.pattern.ToString(), DataScripts.gamedata, SwitchScreen);
        Invoke(nameof(SwitchScreen), 5.0f);
        DataScripts.gamedata = null;
    }

    void FacialSendPatternAndGameData()
    {
        //sendDataToServer.SendData(DataScripts.pattern.ToString(), DataScripts.gamedata, FacialSwitchScreen);
        Invoke(nameof(FacialSwitchScreen), 5.0f);
        DataScripts.gamedata = null;
    }

}
