using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Random = UnityEngine.Random;


public class ImageRandomizer : MonoBehaviour
{
    public SpriteRenderer randomSpriteRenderer; //The sprite renderer that will display the random image
    public Sprite[] randomSprites;              //An Array of sprites that will be used for the image randomization

    private int RandomImageIndex = 0;           //Keep track of which image we're currently displaying
    private float ImageChangeTimer;      
    void Start()
    {
        // Set this timer variable as soon as the script starts so it's ready for the update function
        randomSpriteRenderer.sprite = randomSprites[0];
    }
}

