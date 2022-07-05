using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IowaGambling;

namespace IowaGambling
{
    public class PointManager : MonoBehaviour
    {
        public static int number;   //data
        public static int rewardPoint;  //data
        public static int lostPoint;    //data
        public static int totalPoint;   //data
        private int[] deck = { 1, 2, 3, 4 };
        public static int trial = 0;
        public static int maxTrial = 50;
        private float reactionTime = 0f;    //data
        public static bool timerBool = false;

        public Text PopUpText;
        public Text PointWindowText;

        private int card1;
        private int card2;
        private int card3;
        private int card4;

        // Start is called before the first frame update
        void Start()
        {
            number = 0;
            rewardPoint = 0;
            lostPoint = 0;
            totalPoint = 0;
            trial = 0;

            card1 = 0;
            card2 = 0;
            card3 = 0;
            card4 = 0;

            DataScripts.gamedata = null;    //開始前にgamedataの中身を消去
        }

        private void FixedUpdate()
        {
            FixedUpdateTimer();
        }

        public void OnClickStartButton()
        {
            Shuffle.ShuffleInt(deck);
            StartTimer();
        }

        public void OnClickCard(int cardNumber)
        {
            StopTimer();
            trial += 1;
            if(trial <= maxTrial)
            {
                //PointCalculation(trial, deck[cardNumber - 1]);
                NewPointCalculation(deck[cardNumber - 1]);
                PopUpMessage(cardNumber);
                PointWindow();
                DataScripts.gamedata += CreateXMLString.IwoaGamblingData(trial, cardNumber.ToString(), rewardPoint.ToString(), lostPoint.ToString(), totalPoint.ToString(), (reactionTime * 1000).ToString("f0"), maxTrial);
                reactionTime = 0f;
            }
        }

        private void PopUpMessage(int cardNum)
        {
            PopUpText.text = "えらんだカードのすうじ：" + cardNum + "\n" + "\n" +
                "もらえたポイント" + rewardPoint + "\n" +
                "なくなったポイント：" + lostPoint + "\n" + "\n" +
                "ぜんぶのポイント：" + totalPoint; 
        }

        private void PointWindow()
        {
            PointWindowText.text = "ぜんぶのポイント：" + totalPoint;
        }

        private void PointCalculation(int trialNum, int cardNum)
        {
            rewardPoint = int.Parse(PointDataBase.rewardDatas[trialNum - 1][cardNum - 1]);
            lostPoint = int.Parse(PointDataBase.lostDatas[trialNum - 1][cardNum - 1]);
            totalPoint += rewardPoint + lostPoint;  //修正
        }

        /// <summary>
        /// 獲得ポイントと損失ポイントを取得し、合計ポイントに加算する
        /// </summary>
        /// <param name="cardNum">選択した山札の番号</param>
        private void NewPointCalculation(int cardNum)
        {
            switch (cardNum)
            {
                case 1:
                    rewardPoint = int.Parse(PointDataBase.rewardDatas[card1][cardNum - 1]);
                    lostPoint = int.Parse(PointDataBase.lostDatas[card1][cardNum - 1]);
                    card1 += 1;
                    break;
                case 2:
                    rewardPoint = int.Parse(PointDataBase.rewardDatas[card2][cardNum - 1]);
                    lostPoint = int.Parse(PointDataBase.lostDatas[card2][cardNum - 1]);
                    card2 += 1;
                    break;
                case 3:
                    rewardPoint = int.Parse(PointDataBase.rewardDatas[card3][cardNum - 1]);
                    lostPoint = int.Parse(PointDataBase.lostDatas[card3][cardNum - 1]);
                    card3 += 1;
                    break;
                case 4:
                    rewardPoint = int.Parse(PointDataBase.rewardDatas[card4][cardNum - 1]);
                    lostPoint = int.Parse(PointDataBase.lostDatas[card4][cardNum - 1]);
                    card4 += 1;
                    break;
                default:
                    break;
            }
            totalPoint += rewardPoint + lostPoint;
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