using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverCheck : MonoBehaviour 
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Head")
        {
            SceneManager.Instance.GameOver();
        }
    }
}
