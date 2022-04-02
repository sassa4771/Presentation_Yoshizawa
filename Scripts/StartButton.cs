using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject Explain;
    public GameObject Task;

    public void OnClickStartButton()
    {
        Explain.SetActive(false);
        Task.SetActive(true);
    }
}
