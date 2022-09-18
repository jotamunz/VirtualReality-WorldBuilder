using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This will change the material of the object when the harador hits it
public class GrowAmmo : MonoBehaviour
{
    public GameObject cropFirstState, cropSecondState, seed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator  OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Seed"){
            Destroy(other.gameObject, 1);
            yield return new WaitForSeconds(1);
            GameObject smallCrop = Instantiate(cropFirstState, transform.position, transform.rotation);
            Destroy(smallCrop, 5);
            yield return new WaitForSeconds(5);
            GameObject grownCrop = Instantiate(cropSecondState, transform.position, transform.rotation);
            Destroy(grownCrop, 30);
        } 
    }
}   