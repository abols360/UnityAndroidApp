using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    [SerializeField] GameObject instruction;
    public void ExitGame() 
    {
        Application.Quit();    
    }

    public void OpenInstraction() 
    {
        Application.Quit();    
    }

    public void OpenMainScene() 
    {
        SceneManager.LoadScene("Anchors");   
    }

    public void TurnOnInstruction()
    {
        instruction.SetActive(true);
    }

    public void TurnOffInstruction()
    {
        instruction.SetActive(false);
    }

    public void RestartProject() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene
        //SceneManager.LoadScene(currentSceneIndex);
    }

    
}
