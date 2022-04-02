using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject BackScenePopUp;

    public void OnClickSceneChange(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void OnClickSceneChangeAttention()   //For BackButton
    {
        BackScenePopUp.SetActive(true);
    }

    public void OnClickPopUpButton(string ButtonName)   //For PopupButton
    {
        if(ButtonName == "Back")
        {
            BackScenePopUp.SetActive(false);
            SceneManager.LoadScene("Select");
        }
        else if(ButtonName == "Cancel")
        {
            BackScenePopUp.SetActive(false);
        }
    }
}
