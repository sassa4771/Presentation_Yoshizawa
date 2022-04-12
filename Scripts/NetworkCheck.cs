using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCheck : MonoBehaviour
{
    [SerializeField] GameObject networkPopup;

    public void OnTapNetworkCheck()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            networkPopup.SetActive(true);
        }
        else
        {
            Debug.Log("Network: OK");
        }
    }

    public void OnTapPopupClose()
    {
        networkPopup.SetActive(false);
    }

}
