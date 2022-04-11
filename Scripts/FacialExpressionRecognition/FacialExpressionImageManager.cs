using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SendTest;

namespace FacialExpressionRecognition
{
    public class FacialExpressionImageManager : MonoBehaviour
    {
        public FacialExpressionImageHolder facialExpressionImageHolder;
        public FacialProgressManager facialProgressManager;
        [SerializeField] private Image[] image;
        private Sprite[] facialImages = new Sprite[36];
        private string[] facialNames = new string[36];  //data
        private string targetFacialName;    //data
        private float display = 200f;
        private float noReactionInterval = 4000f;
        private float firstInterval = 600f;
        private int maximumTime = 800;
        private int minmumTime = 400;
        public Text targetImageName;
        private int[] LR = new int[36]; //data
        private string lr;
        private bool leftBool = false;
        private bool rightBool = false;

        private string isCorrect = null;    //data

        private float reactionTime = 0f;    //data
        private bool timerBool = false;

        public static bool EndBool = false;

        private IEnumerator coroutine;
        private IEnumerator noReactionTimer;
        private IEnumerator randomTimer;

        SendDataToServer sendDataToServer;

        void Start()
        {
            CreateLRArray();
        }

        void Update()
        {
            GetLeftorRight();
        }

        private void FixedUpdate()
        {
            FixedUpdateTimer();
        }

        private void CreateLRArray()
        {
            for (int i = 0; i < LR.Length / 2; i++)
            {
                LR[i] = 0;
            }
            for(int i = LR.Length / 2; i < LR.Length; i++)
            {
                LR[i] = 1;
            }
        }


        void GetLeftorRight()
        {
            if (TapManager.left)
            {
                StopTimer();
                StartCoroutine(randomTimer);
                TapManager.left = false;
                leftBool = true;
            }
            if (TapManager.right)
            {
                StopTimer();
                StartCoroutine(randomTimer);
                TapManager.right = false;
                rightBool = true;
            }
        }

        public void OnClickStartRandomImage()
        {
            CreateFacialImages();
            Shuffle.ShuffleImageAndString(facialImages, facialNames);
            Shuffle.ShuffleInt(LR);
            Invoke(nameof(StartRandomImage), firstInterval * 0.001f);
        }

        void CreateFacialImages()
        {
            switch (targetImageName.text)
            {
                case "しあわせ":
                    CreateFacialArray(facialExpressionImageHolder.Happy, facialExpressionImageHolder.Disgust,
                        facialExpressionImageHolder.Fear, facialExpressionImageHolder.Anger,
                        "Happy", "Disgust", "Fear", "Anger");
                    targetFacialName = "Happy";
                    break;
                case "けんお":
                    CreateFacialArray(facialExpressionImageHolder.Disgust, facialExpressionImageHolder.Happy,
                        facialExpressionImageHolder.Fear, facialExpressionImageHolder.Anger,
                        "Disgust", "Happy", "Fear", "Anger");
                    targetFacialName = "Disgust";
                    break;
                case "おそれ":
                    CreateFacialArray(facialExpressionImageHolder.Fear, facialExpressionImageHolder.Disgust,
                        facialExpressionImageHolder.Happy, facialExpressionImageHolder.Anger,
                        "Fear", "Disgust", "Happy", "Anger");
                    targetFacialName = "Fear";
                    break;
                case "いかり":
                    CreateFacialArray(facialExpressionImageHolder.Anger, facialExpressionImageHolder.Disgust,
                        facialExpressionImageHolder.Fear, facialExpressionImageHolder.Happy,
                        "Anger", "Disgust", "Fear", "Happy");
                    targetFacialName = "Anger";
                    break;
                default:
                    break;
            }
        }

        void CreateFacialArray(Sprite[] target, Sprite[] other1, Sprite[] other2, Sprite[] other3,
            string facialName1, string facialName2, string facialName3, string facialName4)
        {
            for (int i = 0; i < 18; i++)
            {
                int rdm = Random.Range(0, target.Length);
                facialImages[i] = target[rdm];
                facialNames[i] = facialName1;
            }
            for (int i = 18; i < 24; i++)
            {
                int rdm = Random.Range(0, other1.Length);
                facialImages[i] = other1[rdm];
                facialNames[i] = facialName2;
            }
            for (int i = 24; i < 30; i++)
            {
                int rdm = Random.Range(0, other2.Length);
                facialImages[i] = other2[rdm];
                facialNames[i] = facialName3;
            }
            for (int i = 30; i < 36; i++)
            {
                int rdm = Random.Range(0, other3.Length);
                facialImages[i] = other3[rdm];
                facialNames[i] = facialName4;
            }
        }

        void StartRandomImage()
        {
            randomTimer = RandomTimer();
            noReactionTimer = NoReactionTimer();
            coroutine = RandomImage();
            StartCoroutine(coroutine);
        }

        private IEnumerator RandomImage()
        {
            int i = 0;
            while (i < facialImages.Length)
            {
                image[LR[i]].sprite = facialImages[i];
                StartTimer();

                yield return new WaitForSeconds(display * 0.001f);

                image[LR[i]].sprite = null;

                ResetNoReactionTimer();
                ResetRandomTimer();
                StartCoroutine(noReactionTimer);

                yield return null;

                LRToString(LR[i]);
                isCorrect = Judge(facialNames[i]);
                //gamedataにそれぞれのデータを格納していく
                DataScripts.gamedata += CreateXMLString.FacialExpressionRecognitionData(targetFacialName, i + 1, facialNames[i], lr, isCorrect, (reactionTime*1000f).ToString("f0"), facialImages.Length);

                ResetBools();
                yield return null;
                i++;
            }
            DataScripts.pattern = 1;
            EndBool = true;

            yield break;
        }

        private void LRToString(int i)
        {
            switch (i)
            {
                case 0:
                    lr = "left";
                    break;
                case 1:
                    lr = "right";
                    break;
                default:
                    break;
            }
        }

        private IEnumerator RandomTimer()
        {
            StopCoroutine(coroutine);

            StopCoroutine(noReactionTimer);
            ResetNoReactionTimer();

            int rdmTime = Random.Range(minmumTime, maximumTime);

            yield return new WaitForSeconds(rdmTime * 0.001f);

            StartCoroutine(coroutine);
        }

        private IEnumerator NoReactionTimer()
        {
            StopCoroutine(coroutine);

            yield return new WaitForSeconds((noReactionInterval - display) * 0.001f);

            StartCoroutine(coroutine);
        }

        private void ResetRandomTimer()
        {
            randomTimer = null;
            randomTimer = RandomTimer();
        }

        private void ResetNoReactionTimer()
        {
            noReactionTimer = null;
            noReactionTimer = NoReactionTimer();
        }

        private string Judge(string facialName)
        {
            switch (targetImageName.text)
            {
                case "しあわせ":
                    if(facialName == "Happy")
                    {
                        if (leftBool)
                        {
                            return "correct";
                        }
                        else
                        {
                            return "incorrect";
                        }
                    }
                    else
                    {
                        if (rightBool)
                        {
                            return "correct";
                        }
                        else
                        {
                            return "incorrect";
                        }
                    }
                case "けんお":
                    if (facialName == "Disgust")
                    {
                        if (leftBool)
                        {
                            return "correct";
                        }
                        else
                        {
                            return "incorrect";
                        }
                    }
                    else
                    {
                        if (rightBool)
                        {
                            return "correct";
                        }
                        else
                        {
                            return "incorrect";
                        }
                    }
                case "おそれ":
                    if (facialName == "Fear")
                    {
                        if (leftBool)
                        {
                            return "correct";
                        }
                        else
                        {
                            return "incorrect";
                        }
                    }
                    else
                    {
                        if (rightBool)
                        {
                            return "correct";
                        }
                        else
                        {
                            return "incorrect";
                        }
                    }
                case "いかり":
                    if (facialName == "Anger")
                    {
                        if (leftBool)
                        {
                            return "correct";
                        }
                        else
                        {
                            return "incorrect";
                        }
                    }
                    else
                    {
                        if (rightBool)
                        {
                            return "correct";
                        }
                        else
                        {
                            return "incorrect";
                        }
                    }
                default:
                    return null;
            }

        }

        void ResetBools()
        {
            leftBool = false;
            rightBool = false;
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
