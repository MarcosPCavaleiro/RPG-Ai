using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    
    #region  Singleton

    public static PlayerManager instance;
    Scene currentScene;
    string sceneName;

    void Awake() 
    {
       instance = this;
    }

    #endregion

    public GameObject player;
    public GameObject deathMenu;

    public void KillPlayer()
    {
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(5);
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "Phase3")
        {
            SceneManager.LoadScene("Restart");
        }
        else
        {
        deathMenu.SetActive(true);
        Time.timeScale = 0;
        }
    } 
}   
