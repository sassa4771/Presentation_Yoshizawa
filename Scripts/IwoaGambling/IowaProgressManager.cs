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
        SendDataToServer sendDataToServer;

        // Update is called once per frame
        void Update()
        {
            if (PointPopUpManager.endBool)
            {
                Task.SetActive(false);
                Send.SetActive(true);
                DataScripts.pattern = 3;
                SendScreenManager.StartSendScreen();    //
                PointPopUpManager.endBool = false;
            }
        }
    }

}
