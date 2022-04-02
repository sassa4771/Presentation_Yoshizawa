using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using IowaGambling;

namespace IowaGambling
{
    public class PointDataBase : MonoBehaviour
    {
        [SerializeField] private string rewardFileName;
        [SerializeField] private string lostFileName;
        TextAsset rewardCSV;
        TextAsset lostCSV;
        public static List<string[]> rewardDatas = new List<string[]>();
        public static List<string[]> lostDatas = new List<string[]>();

        void Start()
        {
            rewardCSV = Resources.Load(rewardFileName) as TextAsset;
            lostCSV = Resources.Load(lostFileName) as TextAsset;
            StringReader rewardReader = new StringReader(rewardCSV.text);
            StringReader lostReader = new StringReader(lostCSV.text);

            while(rewardReader.Peek() != -1)
            {
                string line = rewardReader.ReadLine();
                rewardDatas.Add(line.Split(','));
            }
            while(lostReader.Peek() != -1)
            {
                string line = lostReader.ReadLine();
                lostDatas.Add(line.Split(','));
            }

            //Debug.Log("-----------Reward-----------");
            //for (int i = 0; i < 40; i++)
            //{
            //    Debug.Log(i + 1 + ": " + rewardDatas[i][0] + ", " + rewardDatas[i][1] + ", " + rewardDatas[i][2] + ", " + rewardDatas[i][3]);
            //}

            //Debug.Log("-----------Lost-----------");
            //for (int i = 0; i < 40; i++)
            //{
            //    Debug.Log(i + 1 + ": " + lostDatas[i][0] + ", " + lostDatas[i][1] + ", " + lostDatas[i][2] + ", " + lostDatas[i][3]);
            //}
        }
    }
}

