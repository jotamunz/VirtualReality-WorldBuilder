using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This will change the material of the object when the harador hits it
public class AllowCrop : MonoBehaviour
{
    public GameObject nextSoilState  ;  

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Hoe"){
            GameObject cropSoil = Instantiate(nextSoilState, transform.position, transform.rotation);
            Destroy(gameObject, 0);
        } 
    }
}   