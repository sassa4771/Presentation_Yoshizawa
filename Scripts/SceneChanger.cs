using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject attentionPopUp;

    public void OnClickSceneChange(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void OnClickSceneChangeAttention()   //For BackButton
    {
        attentionPopUp.SetActive(true);
    }

    public void OnClickPopUpCancelButton()   //For PopupButton
    {
        attentionPopUp.SetActive(false);
    }
}
