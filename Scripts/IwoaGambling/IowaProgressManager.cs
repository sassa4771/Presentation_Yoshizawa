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
        [SerializeField] GameObject End;
        SendDataToServer sendDataToServer;

        // Update is called once per frame
        void Update()
        {
            if (PointPopUpManager.endBool)
            {
                Task.SetActive(false);
                End.SetActive(true);
                SendDataIwoa();
                PointPopUpManager.endBool = false;
            }
        }

        private void SendDataIwoa()
        {
            Debug.Log(DataScripts.gamedata);
            DataScripts.pattern = 3;
            //sendDataToServer.SendData(DataScripts.pattern.ToString(), DataScripts.gamedata);
            DataScripts.gamedata = null;
        }
    }

}
