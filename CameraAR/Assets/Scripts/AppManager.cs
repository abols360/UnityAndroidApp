using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    
    public void ExitGame() 
    {
        Application.Quit();    
    }

    public void RestartProject() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene
        //SceneManager.LoadScene(currentSceneIndex);
    }

    
}
