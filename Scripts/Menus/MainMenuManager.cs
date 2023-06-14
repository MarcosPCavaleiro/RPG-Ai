using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Phase1");
        Time.timeScale = 1;
    }

    
    public void Quit()
    {
        Application.Quit();
    }
}
