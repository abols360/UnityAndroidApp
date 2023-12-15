using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    // Start is called before the first frame update
   private CanvasGroup fadeGroup;
   private float fadeInSpeed = 0.33f;

    private void Start() 
    {
        this.fadeGroup = FindObjectOfType<CanvasGroup>();
        this.fadeGroup.alpha = 1;

    }

    private void Update()
    {
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
        
    }
}
