using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
 

    public void ExitGame() 
    {
        Application.Quit();    
    }

    public void OpenMenu() 
    {
        SceneManager.LoadScene("MenuScene"); 
    }
  
}
