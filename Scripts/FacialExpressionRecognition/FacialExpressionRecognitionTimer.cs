using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FacialExpressionRecognition;

namespace FacialExpressionRecognition
{
    public class FacialExpressionRecognitionTimer : MonoBehaviour
    {
        public static float reactionTime = 0f;
        public bool timerBool = false;

        private void FixedUpdate()
        {
            Debug.Log(Time.deltaTime);
            if (timerBool)
            {
                reactionTime += Time.deltaTime;
            }
        }

        public void StartReactionTimer()
        {
            timerBool = true;
        }
    }
}

