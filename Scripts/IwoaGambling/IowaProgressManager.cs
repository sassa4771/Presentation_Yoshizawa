using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IowaGambling;
using SendTest;

namespace IowaGambling
{
    public class IowaProgressManager : MonoBehaviour
    {
        [SerializeField] GameObject Task;
        [SerializeField] GameObject Send;
        [SerializeField] GameObject End;
        SendDataToServer sendDataToServer;

        // Update is called once per frame
        void Update()
        {
            if (PointPopUpManager.endBool)
            {
                Task.SetActive(false);
                DataScripts.pattern = 3;
                Debug.Log(DataScripts.gamedata);
                if (AccountCheck.registered)
                {
                    Send.SetActive(true);   //
                    SendScreenManager.StartSendScreen();    //
                }
                else
                {
                    End.SetActive(true);
                }
                PointPopUpManager.endBool = false;
            }
        }
    }

}
