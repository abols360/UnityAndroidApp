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

    public void ShowNextAnimal()
    {
        // animalModels.transform.GetChild(0).gameObject.SetActive(false);
        // animalModels.transform.GetChild(1).gameObject.SetActive(true);
       
    }

    public void ShowPreviousAnimal()
    {
      
    }

    
}
