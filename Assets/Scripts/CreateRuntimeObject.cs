using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CreateRuntimeObject : MonoBehaviour
{
    public float DEFAULT_SCALE;  
    public GameObject newObject;


    public void createNewObject() 
    {   
        newObject.transform.localScale = new Vector3(DEFAULT_SCALE, DEFAULT_SCALE, DEFAULT_SCALE);
        Instantiate(newObject, new Vector3(0, 0, 0), Quaternion.identity);
    }
} 
