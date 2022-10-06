using System;
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.XR.ARFoundation;

public class FaceSwap : MonoBehaviour

{

    public List<Material> faceMaterials = new List<Material>();

    private ARFaceManager faceManager;

    private int faceMaterialIndex = 0;

    void Start()

    {

        faceManager = GetComponent<ARFaceManager>();

    }

    

    public void SwitchFace()

    {
        Debug.Log("ZDAROWA");
        foreach(ARFace face in faceManager.trackables)

        {

            face.GetComponent<Renderer>().material = faceMaterials[faceMaterialIndex];

        }

        faceMaterialIndex++;

        if(faceMaterialIndex > faceMaterials.Count)

        {

            faceMaterialIndex = 0;

        }
        
    }

}