using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IowaGambling;

namespace IowaGambling
{
    public class IowaProgressManager : MonoBehaviour
    {
        [SerializeField] GameObject Task;
        [SerializeField] GameObject End;

        // Update is called once per frame
        void Update()
        {
            if (PointPopUpManager.endBool)
            {
                Task.SetActive(false);
                End.SetActive(true);
                PointPopUpManager.endBool = false;
            }
        }
    }

}
