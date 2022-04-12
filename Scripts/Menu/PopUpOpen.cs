using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpOpen : MonoBehaviour
{
    public GameObject PopUp;

    void Start()
    {
        //animator = PopUp.GetComponent<Animator>();
    }

    public void OnClickPopUpOpen()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.LogError("Not connected to the network");
        }
        else
        {
            PopUp.SetActive(true);
        }
    }
}
