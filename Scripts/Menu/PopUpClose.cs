using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpClose : MonoBehaviour
{
    public GameObject PopUp;

    public void OnClickPopUpClose()
    {
        PopUp.SetActive(false);
    }
}
