using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using static NativeGallery; // Use 'using static' instead of 'using'

public class PhotoController : MonoBehaviour
{
    
    public void TakePhoto()
    {
        StartCoroutine(CapturePhoto());
    }

    IEnumerator CapturePhoto()
    {    
        // Wait for the next frame to avoid rendering issues
        yield return null;

        // Create a Texture2D and read the camera pixels
        var photoTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        photoTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        photoTexture.Apply();

        // Save the photo to the gallery       
        var currentDateXml = DateTime.Now.ToString("dd-MM-yyyy");
        var dayTimeXml = DateTime.Now.ToString("HH-mm-ss");
        var fileName = "UnityAR" + currentDateXml + "-" + dayTimeXml + ".png";
        SaveImageToGallery(photoTexture, "UnityAR", fileName);
    }
}
