using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Random = UnityEngine.Random;


public class ImagePlaceHolder : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; //The sprite renderer that will display the random image
    public Sprite sprite;              //An Array of sprites that will be used for the image randomization
    void Start()
    {
        // Set this timer variable as soon as the script starts so it's ready for the update function
        spriteRenderer.sprite = sprite;
    }
}

