using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject instruction;

    [SerializeField] private GameObject background;

    [SerializeField] private Material blackMaterial;


    
    private void Start()
    {
        this.TurnOffInstruction();
    }

    public void ExitGame() 
    {
        Application.Quit();    
    }

    public void OpenMainScene() 
    {
        
        SceneManager.LoadScene("Anchors");  
        background.GetComponent<MeshRenderer>().material = blackMaterial;
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
