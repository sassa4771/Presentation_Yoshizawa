using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountCheck : MonoBehaviour
{
    public static bool registered = true;

    public void OnClickRegistered()
    {
        registered = true;
    }

    public void OnClickNoregistration()
    {
        registered = false;
    }
}
