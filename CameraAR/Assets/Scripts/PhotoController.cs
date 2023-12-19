using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using static NativeGallery; // Use 'using static' instead of 'using'

public class PhotoController : MonoBehaviour
{
    public RawImage photoDisplay;

    void Start()
    {
        // Request camera permission here if necessary
    }

    public void TakePhoto()
    {
        StartCoroutine(CapturePhoto());
    }

    IEnumerator CapturePhoto()
    {
        // Request camera permission here if necessary

        // Wait for the next frame to avoid rendering issues
        yield return null;

        // Create a Texture2D and read the camera pixels
        Texture2D photoTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        photoTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        photoTexture.Apply();

        // Display the photo on a RawImage or save it to the gallery
        if (photoDisplay != null)
        {
            photoDisplay.texture = photoTexture;
        }

        // Save the photo to the gallery
       
        var currentDateXml = DateTime.Now.ToString("dd-MM-yyyy");
        var dayTimeXml = DateTime.Now.ToString("HH-mm-ss");
        var fileName = "UnityAR" + currentDateXml + "-" + dayTimeXml + ".png";
        Permission permission = SaveImageToGallery(photoTexture, "UnityAR", fileName);
        
        if (permission == Permission.Granted)
        {
            Debug.Log("Photo saved to the gallery");
        }
        else
        {
            Debug.LogError("Failed to save photo to the gallery. Permission not granted.");
        }
    }
}
