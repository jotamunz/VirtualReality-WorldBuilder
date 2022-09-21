using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class ToolSwitch : MonoBehaviour
{
    /*  This flag indicates wich tool will be displayed next
        0 = Weapon
        1 = Hoe
        2 = Scythe
    */
    private int toolFlag = 0;   

    // This variable will contain the object that will be in the VR world
    // This will change depending on toolFlag variable
    private GameObject actualTool;

    // These varaibles represent the prefabs that will spawn
    public GameObject weapon;
    public GameObject hoe;
    public GameObject scythe;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void OnToolSwitch()
    {
        this.toolFlag += 1;

        if (toolFlag >= 3){
            toolFlag = 0;
        }

        if (toolFlag == 0){
            actualTool = weapon;
        }

        if (toolFlag == 1){
            actualTool = hoe;
        }

        if (toolFlag == 2){
            actualTool = scythe;
        }
        Instantiate(actualTool, transform.position, Quaternion.identity);
    }
}
