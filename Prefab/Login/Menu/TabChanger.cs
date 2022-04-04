using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabChanger : MonoBehaviour
{
    public GameObject OpenTab;
    public GameObject CloseTab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickTabChange()
    {
        CloseTab.SetActive(false);
        OpenTab.SetActive(true);
    }
}
