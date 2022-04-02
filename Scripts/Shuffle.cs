using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    public static void ShuffleImage(Sprite[] sprites)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            Sprite temp = sprites[i];
            int randomIndex = Random.Range(0, sprites.Length);
            sprites[i] = sprites[randomIndex];
            sprites[randomIndex] = temp;
        }
    }

    public static void ShuffleImageAndString(Sprite[] sprites, string[] strings)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            Sprite temp = sprites[i];
            string temp_str = strings[i];
            int randomIndex = Random.Range(0, sprites.Length);
            sprites[i] = sprites[randomIndex];
            strings[i] = strings[randomIndex];
            sprites[randomIndex] = temp;
            strings[randomIndex] = temp_str;
        }
    }

    public static void ShuffleFacialExpression(string[] str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            string temp = str[i];
            int randomIndex = Random.Range(0, str.Length);
            str[i] = str[randomIndex];
            str[randomIndex] = temp;
        }
    }

    public static void ShuffleInt(int[] intArray)
    {
        for (int i = 0; i < intArray.Length; i++)
        {
            int temp = intArray[i];
            int randomIndex = Random.Range(0, intArray.Length);
            intArray[i] = intArray[randomIndex];
            intArray[randomIndex] = temp;
        }
    }
}

