using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class objectCreator : MonoBehaviour
{
    public float DEFAULT_SCALE;  
    public GameObject newObject;

   void Start()
    {
    }

    void Update()
    {
    }


    public void createObject() 
    {   
        newObject.transform.localScale = new Vector3(DEFAULT_SCALE, DEFAULT_SCALE, DEFAULT_SCALE);
        Instantiate(newObject, new Vector3(0, 1, 1), Quaternion.identity);
    }
}
