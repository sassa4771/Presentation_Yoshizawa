using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FacialExpressionRecognition;

namespace FacialExpressionRecognition
{
    public class FacialProgressManager : MonoBehaviour
    {
        public FacialExpressionImageHolder facialExpressionImageHolder;
        [SerializeField] private Image[] image;
        public GameObject Task;
        public GameObject Explain;
        public GameObject Send;
        public GameObject End;
        public GameObject backButton;
        [SerializeField] private Text FacialExpressionText;
        private int ProgressCounter;
        private string[] FacialExpressionName = { "Happy", "Disgust", "Fear", "Anger" };

        // Start is called before the first frame update
        void Start()
        {
            ProgressCounter = 0;
            FacialExpressionImageManager.EndBool = false;
            Shuffle.ShuffleFacialExpression(FacialExpressionName);
            for (int i = 0; i < FacialExpressionName.Length; i++)
            {
                Debug.Log(FacialExpressionName[i]);
            }
            Shuffle.ShuffleImage(facialExpressionImageHolder.Happy);
            Shuffle.ShuffleImage(facialExpressionImageHolder.Disgust);
            Shuffle.ShuffleImage(facialExpressionImageHolder.Fear);
            Shuffle.ShuffleImage(facialExpressionImageHolder.Anger);
            DataScripts.gamedata = null;    //開始前にgamedataの中身を消去
        }

        // Update is called once per frame
        void Update()
        {
            if (FacialExpressionImageManager.EndBool)
            {
                ProgressCounter += 1;
                if (ProgressCounter < FacialExpressionName.Length)
                {
                    backButton.SetActive(false);
                    Task.SetActive(false);
                    if (AccountCheck.registered)
                    {
                        Send.SetActive(true);
                        SendScreenManager.FacialStartSendScreen();
                    }
                    else
                    {
                        Explain.SetActive(true);
                    }
                }
                else
                {
                    Task.SetActive(false);
                    if (AccountCheck.registered)
                    {
                        Send.SetActive(true);   //
                        SendScreenManager.StartSendScreen();    //
                    }
                    else
                    {
                        End.SetActive(true);
                    }
                }
                FacialExpressionImageManager.EndBool = false;
            }

            if (ProgressCounter < FacialExpressionName.Length)
            {
                ShowFacialExpression(ProgressCounter);
            }
        }

        void ShowFacialExpression(int i)
        {
            switch (FacialExpressionName[i])
            {
                case "Happy":
                    FacialExpressionText.text = "しあわせ";
                    LoadImage(facialExpressionImageHolder.Happy);
                    break;
                case "Disgust":
                    FacialExpressionText.text = "けんお";
                    LoadImage(facialExpressionImageHolder.Disgust);
                    break;
                case "Fear":
                    FacialExpressionText.text = "おそれ";
                    LoadImage(facialExpressionImageHolder.Fear);
                    break;
                case "Anger":
                    FacialExpressionText.text = "いかり";
                    LoadImage(facialExpressionImageHolder.Anger);
                    break;
                default:
                    break;
            }
        }

        void LoadImage(Sprite[] FacialImages)
        {
            for (int i = 0; i < image.Length; i++)
            {
                image[i].sprite = FacialImages[i];
            }
        }
    }
}

