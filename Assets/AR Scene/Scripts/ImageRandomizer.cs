using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Random = UnityEngine.Random;


enum CategoriesEnum
{
    Geography,
    Sports,
    History,
    Movies
}

public class ImageRandomizer : MonoBehaviour
{
    public SpriteRenderer randomSpriteRenderer; //The sprite renderer that will display the random image
    public Sprite[] randomSprites;              //An Array of sprites that will be used for the image randomization

    public float timeBetweenChange;      //The amount of time between switching the image
    public float timeUntilStopping = 5.0f;   
    
    private int RandomImageIndex = 0;           //Keep track of which image we're currently displaying
    private float ImageChangeTimer;
    private string categories;
    
    private GameObject categoriesGameObject;
    private GameObject geographyGameObject;
    private GameObject historyGameObject;
    private GameObject moviesGameObject;
    private GameObject sportsGameObject;

    void Start()
    {
        // Set this timer variable as soon as the script starts so it's ready for the update function
        ImageChangeTimer = timeBetweenChange;
        timeBetweenChange = Random.Range(0.1f, 0.9f);
        categoriesGameObject  = GameObject.FindGameObjectWithTag("Categories");
        geographyGameObject = GameObject.FindGameObjectWithTag("Geography");
        historyGameObject = GameObject.FindGameObjectWithTag("History");
        moviesGameObject = GameObject.FindGameObjectWithTag("Movies");
        sportsGameObject = GameObject.FindGameObjectWithTag("Sports");
    }

    void Update()
    {
        pickCategory();
        Debug.Log(randomSpriteRenderer.sprite + "OPAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }

    private void pickCategory()
    {
        // Remove delta time from both active timers. This subtracts a small amount of time from the
        // overall time we described in "timeBetweenChange" and "timeUntilStopping"
        ImageChangeTimer -= Time.deltaTime;
        timeUntilStopping -= Time.deltaTime;

        // If we've fully run out of time we need to select a final random image
        if (timeUntilStopping <= 0.0f)
        {
            // The final image will be selected at random
            randomSpriteRenderer.sprite = randomSprites[Random.Range(0, randomSprites.Length)]; 
            categories = randomSpriteRenderer.sprite.ToString();

            if (CategoriesEnum.Geography.ToString() == categories)
            {
                GameObject.FindGameObjectWithTag("AR Session Origin").GetComponent<ARFaceManager>().facePrefab = geographyGameObject;
                geographyGameObject.SetActive(true);
            }
            if (CategoriesEnum.History.ToString() == categories)
            {
                GameObject.FindGameObjectWithTag("AR Session Origin").GetComponent<ARFaceManager>().facePrefab = historyGameObject;
                historyGameObject.SetActive(true);
            }
            if (CategoriesEnum.Sports.ToString() == categories)
            {
                GameObject.FindGameObjectWithTag("AR Session Origin").GetComponent<ARFaceManager>().facePrefab = sportsGameObject;
                sportsGameObject.SetActive(true);
            }
            if (CategoriesEnum.Movies.ToString() == categories)    
            {
                GameObject.FindGameObjectWithTag("AR Session Origin").GetComponent<ARFaceManager>().facePrefab = moviesGameObject;
                moviesGameObject.SetActive(true);
            }

            Console.Out.WriteLine(       "FacePrefab " + GameObject.FindGameObjectWithTag("AR Session Origin").GetComponent<ARFaceManager>().facePrefab);
            Debug.Log("FacePrefab " + GameObject.FindGameObjectWithTag("AR Session Origin").GetComponent<ARFaceManager>().facePrefab);

            // Destroy this script immediately stopping it from running anymore in the future
            //DestroyImmediate(this);

            // Return so no other code runs in this Update function call
            return;
        }

        // If RandomizationTimer is less than or equal to zero it's time for a new image
        if (ImageChangeTimer <= 0.0f)
        {
            // To ensure we see all the images we increase the RandomImageIndex to see the next
            // image in the array
            RandomImageIndex++;

            // If our index has gone past the end of the array, reset it to zero so the cycle
            // can start again
            if (RandomImageIndex >= randomSprites.Length)
            {
                RandomImageIndex = 0;
            }

            //Assign the new sprite to the sprite renderer
            randomSpriteRenderer.sprite = randomSprites[RandomImageIndex];

            //Reset the "RandomizationTimer" to start counting down again
            ImageChangeTimer = timeBetweenChange;
        }
    }
}
