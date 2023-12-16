using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        this.TurnOffInstruction();
    }

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
        this.instruction.SetActive(true);
    }

    public void TurnOffInstruction()
    {
        this.instruction.SetActive(false);
    }   
}
