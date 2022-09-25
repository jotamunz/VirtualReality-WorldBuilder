using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class ToolSwitch : MonoBehaviour
{
    LinkedList<GameObject> weaponList = new LinkedList<GameObject>();

    // This variable will contain the tempObject that will be in the VR world
    LinkedListNode<GameObject> actualTool;

    // These varaibles represent the prefabs that will spawn
    public Transform transformPivot;
    public GameObject weapon, scythe, hoe;

    void Start()
    {        
        GameObject tempObject = Instantiate(weapon, transformPivot.position, transform.rotation);
        tempObject.SetActive(false);
        weaponList.AddLast(tempObject);

        tempObject = Instantiate(scythe, transformPivot.position, transform.rotation);
        tempObject.SetActive(false);
        weaponList.AddLast(tempObject);

        tempObject = Instantiate(hoe, transformPivot.position, transform.rotation);
        tempObject.SetActive(false);
        weaponList.AddLast(tempObject);
         
        actualTool = weaponList.First;
    }

    // Update is called once per frame
    void Update(){}

    public void OnToolSwitch()
    {   
        actualTool.Value.SetActive(false);
        actualTool = actualTool.Next ?? weaponList.First;
        actualTool.Value.SetActive(true);
        actualTool.Value.transform.position = new Vector3(transformPivot.position.x,transformPivot.position.y,transformPivot.position.z);
        actualTool.Value.transform.Translate(transformPivot.forward * 0.3f, Space.Self);
        actualTool.Value.transform.Translate(transformPivot.up * 1.5f, Space.Self);

    }
}
