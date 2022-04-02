using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Title
{
    public class TitleManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Invoke(nameof(TitleClose), 0.5f);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TitleClose()
        {
            SceneManager.LoadScene("Login");
        }
    }
}
