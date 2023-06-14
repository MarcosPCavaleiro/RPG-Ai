using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string SceneName;

    public void Respawn()
    {
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1;
    }

    
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
