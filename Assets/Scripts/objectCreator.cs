    using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class objectCreator : MonoBehaviour
{
    private const float DEFAULT_SCALE = 0.5f;
    private float scaleX = DEFAULT_SCALE, scaleY = DEFAULT_SCALE, scaleZ = DEFAULT_SCALE;    
    public string objectTypeName;
    private AudioSource source;

   void Start()
    {
    }

    void Update()
    {
    }


    public void createObject() 
    {
        Console.WriteLine(objectTypeName+"Holaaa");
        GameObject newObject;   
        switch(objectTypeName){
            case "sphere":
                 newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
            case "cube":
                newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
            case "cylinder":
                newObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                break;
            default: 
                newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
        }
        
        newObject.transform.position = new Vector3(0, 3, 1);
        newObject.transform.localScale = new Vector3(scaleX,scaleY,scaleZ);
        newObject.AddComponent<Rigidbody>();
        newObject.AddComponent<XRGrabInteractable>();
        
    }
}
