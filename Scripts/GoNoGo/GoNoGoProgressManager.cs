using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoNoGo;

namespace GoNoGo
{
    public class GoNoGoProgressManager : MonoBehaviour
    {
        [SerializeField] GameObject StartText;
        [SerializeField] GameObject Task;
        [SerializeField] GameObject EndText;
        [SerializeField] GameObject Send;
        private int startTextTime = 2000;
        private int minFirstInterval = 1000;
        private int maxFirstInterval = 1500;
        public static bool trialStart = false;

        // Update is called once per frame
        void Update()
        {
            if (GoNoGoImageManager.endBool)
            {
                StartCoroutine(nameof(EndTextTimer));
                GoNoGoImageManager.endBool = false;
            }
        }

        public void OnClickStartText()
        {
            StartCoroutine(nameof(StartTextTimer));
        }

        private IEnumerator StartTextTimer()
        {
            yield return new WaitForSeconds(startTextTime * 0.001f);
            StartText.SetActive(false);
            Task.SetActive(true);
            StartCoroutine(nameof(FirstTimer));
        }

        private IEnumerator FirstTimer()
        {
            int rdmInterval = Random.Range(minFirstInterval, maxFirstInterval);
            yield return new WaitForSeconds(rdmInterval * 0.001f);
            trialStart = true;
        }

        private IEnumerator EndTextTimer()
        {
            Task.SetActive(false);
            EndText.SetActive(true);
            yield return new WaitForSeconds(2000 * 0.001f);
            EndText.SetActive(false);
            Send.SetActive(true);   //
            SendScreenManager.StartSendScreen();    //
        }
    }
}
