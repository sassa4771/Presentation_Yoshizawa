using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IowaGambling
{
    public class PointPopUpManager : MonoBehaviour
    {
        public GameObject PointPopUp;
        private float displayTime = 2.0f;
        public static bool endBool = false;

        public void OnClickPointPopUpOpenAndAutoClose()
        {
            PointPopUp.SetActive(true);
            Invoke(nameof(PopUpClose), displayTime);
        }

        public void PopUpClose()
        {
            PointPopUp.SetActive(false);
            PointManager.timerBool = true;
            if(PointManager.trial == PointManager.maxTrial)
            {
                endBool = true;
            }
        }

    }
}