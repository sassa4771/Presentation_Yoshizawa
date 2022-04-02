using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FacialExpressionRecognition;

namespace FacialExpressionRecognition
{
    public class TapManager : MonoBehaviour
    {
        public static bool left = false;
        public static bool right = false;

        public void OnTapArea(string AreaName)
        {
            if (AreaName == "Left")
            {
                left = true;
            }
            else if(AreaName == "Right")
            {
                right = true;
            }
        }
    }
}
