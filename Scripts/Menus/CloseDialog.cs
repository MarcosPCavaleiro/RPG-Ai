using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDialog : MonoBehaviour
{
   
    public GameObject modal;

    public void Close () {
        modal.SetActive (!modal.activeInHierarchy);
        Time.timeScale = 1;
    }
}
