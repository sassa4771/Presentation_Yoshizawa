using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoNoGo;
using SendTest;

namespace GoNoGo
{
    public class GoNoGoImageManager : MonoBehaviour
    {
        [SerializeField] private Sprite goImage;
        [SerializeField] private Sprite noGoImage;
        private Sprite[] goNoGoImages = new Sprite[50];
        private string[] goNoGoNames = new string[50];  //data
        [SerializeField] private Image image;
        private int display = 100;
        private int minInterval = 1000;
        private int maxInterval = 1500;
        private IEnumerator randomDisplayImage;
        private IEnumerator reactionTimer;
        private IEnumerator noReactionTimer;
        private bool tapBool = false;
        public static bool endBool = false;
        private string isReaction = null;   //data

        private float reactionTime = 0f;    //data
        private bool timerBool = false;

        SendDataToServer sendDataToServer;

        void Update()
        {
            TrialStart();
            GetTap();
        }

        private void FixedUpdate()
        {
            FixedUpdateTimer();
        }

        private void TrialStart()
        {
            if (GoNoGoProgressManager.trialStart)
            {
                Debug.Log("Start");
                randomDisplayImage = RandomDisplayImage();
                reactionTimer = ReactionTimer();
                noReactionTimer = NoReactionTimer();
                StartCoroutine(randomDisplayImage);
                GoNoGoProgressManager.trialStart = false;
            }
        }

        private void GetTap()
        {
            if (tapBool)
            {
                StopTimer();
                StartCoroutine(reactionTimer);
                tapBool = false;
            }
        }

        public void OnTapAction()
        {
            tapBool = true;
        }

        public void OnClickImageShuffle()
        {
            CreateGoNoGoArray(goImage, noGoImage, "go", "nogo");
            Shuffle.ShuffleImageAndString(goNoGoImages, goNoGoNames);
        }

        void CreateGoNoGoArray(Sprite go, Sprite noGo, string goName, string noGoName)
        {
            for(int i = 0; i < 40; i++)
            {
                goNoGoImages[i] = go;
                goNoGoNames[i] = goName;
            }
            for (int i = 40; i < 50; i++)
            {
                goNoGoImages[i] = noGo;
                goNoGoNames[i] = noGoName;
            }
        }

        private IEnumerator RandomDisplayImage()
        {
            int i = 0;
            while(i < goNoGoImages.Length)
            {
                image.color = Color.white;
                image.sprite = goNoGoImages[i];
                StartTimer();
                Debug.Log(i + 1 + ": " + goNoGoNames[i]);
                yield return new WaitForSeconds(display * 0.001f);

                image.sprite = null;
                image.color = Color.black;

                ResetReactionTimer();
                ResetNoReactionTimer();

                StartCoroutine(noReactionTimer);
                yield return null;
                DataScripts.gamedata += CreateXMLString.GoNoGoData(i + 1, goNoGoNames[i], isReaction, (reactionTime * 1000).ToString("f0"), goNoGoImages.Length);
                i++;
                yield return null;
            }
            DataScripts.pattern = 2;
            yield return new WaitForSeconds(1500 * 0.001f);
            endBool = true;
            yield break;
        }

        private IEnumerator ReactionTimer()
        {
            StopCoroutine(randomDisplayImage);
            StopCoroutine(noReactionTimer);
            ResetNoReactionTimer();

            int rdmInterval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(rdmInterval * 0.001f);
            isReaction = "yes";
            Debug.Log(isReaction);
            StartCoroutine(randomDisplayImage);
        }

        private IEnumerator NoReactionTimer()
        {
            StopCoroutine(randomDisplayImage);

            int rdmInterval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(rdmInterval * 0.001f);
            isReaction = "no";
            Debug.Log(isReaction);
            StartCoroutine(randomDisplayImage);
        }

        private void ResetReactionTimer()
        {
            reactionTimer = null;
            reactionTimer = ReactionTimer();
        }

        private void ResetNoReactionTimer()
        {
            noReactionTimer = null;
            noReactionTimer = NoReactionTimer();
        }

        private void FixedUpdateTimer()
        {
            if (timerBool)
            {
                reactionTime += Time.deltaTime;
            }
        }

        private void StartTimer()
        {
            reactionTime = 0f;
            timerBool = true;
        }

        private void StopTimer()
        {
            Debug.Log("Reaction Time: " + reactionTime);
            timerBool = false;
        }
    }
}
