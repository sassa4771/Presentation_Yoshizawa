using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpOpen : MonoBehaviour
{
    public GameObject PopUp;
    private Animator animator;

    void Start()
    {
        //animator = PopUp.GetComponent<Animator>();
    }

    public void OnClickPopUpOpen()
    {
        //animator.SetBool("Active", true);
        PopUp.SetActive(true);
    }
}
