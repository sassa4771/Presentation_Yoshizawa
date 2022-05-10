using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateXMLString : MonoBehaviour
{
    //表情認知課題
    public static string FacialExpressionRecognitionData(string target, int trial, string face, string lr, string correct, string reactionTime, int arrayLength)
    {
        string gamedata;
        int maxTrial;
        maxTrial = arrayLength;
        if(trial == 1)
        {
            gamedata =
                "<data>" + "\n" +
                "\t" + "<target>" + target + "</target>" + "\n" +
                "\t" + "<trial>" + trial.ToString() + "</trial>" + "\n" +
                "\t" + "<face>" + face + "</face>" + "\n" +
                "\t" + "<lr>" + lr + "</lr>" + "\n" +
                "\t" + "<correct>" + correct + "</correct>" + "\n" +
                "\t" + "<time>" + reactionTime + "</time>" + "\n";
            return gamedata;
        }
        else if(trial == maxTrial)
        {
            gamedata =
                "\t" + "<trial>" + trial.ToString() + "</trial>" + "\n" +
                "\t" + "<face>" + face + "</face>" + "\n" +
                "\t" + "<lr>" + lr + "</lr>" + "\n" +
                "\t" + "<correct>" + correct + "</correct>" + "\n" +
                "\t" + "<time>" + reactionTime + "</time>" + "\n" +
                "</data>";
            return gamedata;
        }
        else
        {
            gamedata =
                "\t" + "<trial>" + trial.ToString() + "</trial>" + "\n" +
                "\t" + "<face>" + face + "</face>" + "\n" +
                "\t" + "<lr>" + lr + "</lr>" + "\n" +
                "\t" + "<correct>" + correct + "</correct>" + "\n" +
                "\t" + "<time>" + reactionTime + "</time>" + "\n";
            return gamedata;
        }
    }

    //GoNoGo課題
    public static string GoNoGoData(int trial, string type, string reaction, string reactionTime, int arrayLength)
    {
        string gamedata;
        int maxTrial;
        maxTrial = arrayLength;
        if (trial == 1)
        {
            gamedata =
                "<data>" + "\n" +
                "\t" + "<trial>" + trial.ToString() + "</trial>" + "\n" +
                "\t" + "<type>" + type + "</type>" + "\n" +
                "\t" + "<reaction>" + reaction + "</reaction>" + "\n" +
                "\t" + "<time>" + reactionTime + "</time>" + "\n";
            return gamedata;
        }
        else if (trial == maxTrial)
        {
            gamedata =
                "\t" + "<trial>" + trial.ToString() + "</trial>" + "\n" +
                "\t" + "<type>" + type + "</type>" + "\n" +
                "\t" + "<reaction>" + reaction + "</reaction>" + "\n" +
                "\t" + "<time>" + reactionTime + "</time>" + "\n" +
                "</data>";
            return gamedata;
        }
        else
        {
            gamedata =
                "\t" + "<trial>" + trial.ToString() + "</trial>" + "\n" +
                "\t" + "<type>" + type + "</type>" + "\n" +
                "\t" + "<reaction>" + reaction + "</reaction>" + "\n" +
                "\t" + "<time>" + reactionTime + "</time>" + "\n";
            return gamedata;
        }
    }

    //IwoaGambling
    public static string IwoaGamblingData(int trial, string deck, string reward, string lost, string total, string reactionTime, int arrayLength)
    {
        string gamedata;
        int maxTrial;
        maxTrial = arrayLength;
        if (trial == 1)
        {
            gamedata =
                "<data>" + "\n" +
                "\t" + "<trial>" + trial.ToString() + "</trial>" + "\n" +
                "\t" + "<deck>" + deck + "</deck>" + "\n" +
                "\t" + "<reward>" + reward + "</reward>" + "\n" +
                "\t" + "<lost>" + lost + "</lost>" + "\n" +
                //"\t" + "<total>" + total + "</total>" + "\n" +
                "\t" + "<time>" + reactionTime + "</time>" + "\n";
            return gamedata;
        }
        else if (trial == maxTrial)
        {
            gamedata =
                "\t" + "<trial>" + trial.ToString() + "</trial>" + "\n" +
                "\t" + "<deck>" + deck + "</deck>" + "\n" +
                "\t" + "<reward>" + reward + "</reward>" + "\n" +
                "\t" + "<lost>" + lost + "</lost>" + "\n" +
                //"\t" + "<total>" + total + "</total>" + "\n" +
                "\t" + "<time>" + reactionTime + "</time>" + "\n" +
            "</data>";
            return gamedata;
        }
        else
        {
            gamedata =
                "\t" + "<trial>" + trial.ToString() + "</trial>" + "\n" +
                "\t" + "<deck>" + deck + "</deck>" + "\n" +
                "\t" + "<reward>" + reward + "</reward>" + "\n" +
                "\t" + "<lost>" + lost + "</lost>" + "\n" +
                //"\t" + "<total>" + total + "</total>" + "\n" +
                "\t" + "<time>" + reactionTime + "</time>" + "\n";
            return gamedata;
        }
    }
}
