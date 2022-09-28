using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropCrop : MonoBehaviour
{
    public GameObject seedDropPrefab, cropDropPrefab;
    public int seedDropAmount, cropDropAmount, hitpoints;
    private float spawnDelay = 0.4f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Scythe") hitpoints--;
        if (collision.gameObject.tag == "Scythe" && hitpoints == 0)
        {
            GenerateDrops(seedDropPrefab, seedDropAmount);
            GenerateDrops(cropDropPrefab, cropDropAmount);
            Destroy(gameObject, spawnDelay);
        }
        yield return new WaitForSeconds(0f);
    }

    IEnumerator GenerateDrops(GameObject dropPrefab, int amount)
    {
        float[] angles = { 10, 30, 60, 90};  // This just could be a random within a range
        LinkedList<float> anglesList = new LinkedList<float>(angles);
        LinkedListNode<float> current = anglesList.First;

        for(int counter=0; counter < amount; counter++){
            yield return new WaitForSeconds(spawnDelay);
            GameObject drop = Instantiate(dropPrefab, transform.position, transform.rotation);

            // Position at a proper upper point
            drop.transform.Translate(0.0f, 1.0f, 0.0f);
            drop.transform.Rotate(0.0f, current.Value, 0.0f, Space.Self);

            // Apply force to the object
            drop.GetComponent<Rigidbody>().AddForce(transform.up * 200);
            drop.GetComponent<Rigidbody>().AddForce(transform.right * 50);                

            current = current.Next ?? current.List.First;
        }
    }
}   