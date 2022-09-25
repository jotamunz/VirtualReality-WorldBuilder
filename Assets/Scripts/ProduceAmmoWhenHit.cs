using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This will change the material of the object when the harador hits it
public class ProduceAmmoWhenHit : MonoBehaviour
{
    public GameObject ammoToDrop;
    public int ammoQuant, hitsBeforeCropping;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Axe") hitsBeforeCropping--;
        if (collision.gameObject.tag == "Axe" && hitsBeforeCropping == 0){

            float[] angles = { 10, 30, 60, 90};  // This just could be a random within a range
            LinkedList<float> anglesList = new LinkedList<float>(angles);
            LinkedListNode<float> current = anglesList.First;

            for(int counter=0;counter < ammoQuant; counter++){
                yield return new WaitForSeconds(0.4f);
                GameObject genericAmmo = Instantiate(ammoToDrop, transform.position, transform.rotation);

                // Position at a proper upper point
                genericAmmo.transform.Translate(0.0f, 1.0f, 0.0f);
                genericAmmo.transform.Rotate(0.0f, current.Value, 0.0f, Space.Self);

                // Apply force to the object
                genericAmmo.GetComponent<Rigidbody>().AddForce(transform.up * 200);
                genericAmmo.GetComponent<Rigidbody>().AddForce(genericAmmo.transform.right * 50);                

                current = current.Next ?? current.List.First;
            }
            Destroy(gameObject, 0.3f);
        }
    }
}   