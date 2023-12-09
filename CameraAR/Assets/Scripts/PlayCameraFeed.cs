using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCameraFeed : MonoBehaviour
{
    private WebCamTexture webCamTexture;

    public int number;
    // Start is called before the first frame update
    void Start()
    {
        if (WebCamTexture.devices.Length == 0)
        {
            Debug.Log("No cameras available");
        }
        else
        { 
            var device = WebCamTexture.devices[number];            
            this.webCamTexture = new WebCamTexture(device.name);
            this.gameObject.GetComponent<Renderer>().material.mainTexture = this.webCamTexture;   
            this.webCamTexture.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
