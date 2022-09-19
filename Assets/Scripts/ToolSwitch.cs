using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class ToolSwitch : MonoBehaviour
{
    /*  This flag indicates wich tool will be displayed next
        0 = Weapon
        1 = Hoe
        2 = Scythe
    */
    public int toolFlag = 0;
    private bool pressFlag = false;

    // This variable will contain the object that will be in the VR world
    // This will change depending on toolFlag variable
    public GameObject actualTool;

    // These varaibles represent the prefabs that will spawn
    public GameObject weaponPref;
    public GameObject hoePref;
    public GameObject scythePref;

    public float DEFAULT_SCALE;  

    private List<UnityEngine.XR.InputDevice> rightControllers = new List<UnityEngine.XR.InputDevice>();

        void Start()
    {
        // Right Hand XR controller
        var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, rightControllers);

                actualTool = scythePref;
                foreach (var controller in this.rightControllers){
                    
                actualTool.transform.localScale = new Vector3(DEFAULT_SCALE, DEFAULT_SCALE, DEFAULT_SCALE);
                Instantiate(actualTool, new Vector3(0, 1, 1), Quaternion.identity);
                }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach (var controller in this.rightControllers)
        {
            bool primaryValue;
            if(pressFlag == false){
                if (controller.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out primaryValue) && primaryValue)
                {
                Debug.Log("A/Primary button is pressed.");
                pressFlag = true;
                this.toolFlag += 1;

                if (toolFlag >= 3){
                    toolFlag = 0;
                }

                if (toolFlag == 0){
                    actualTool = weaponPref;
                }

                if (toolFlag == 1){
                    actualTool = hoePref;
                }

                if (toolFlag == 2){
                    actualTool = scythePref;
                }

                actualTool.transform.localScale = new Vector3(DEFAULT_SCALE, DEFAULT_SCALE, DEFAULT_SCALE);
                Instantiate(actualTool, new Vector3(0, 1, 1), Quaternion.identity);
                } 
            }

        }

        pressFlag = false;

    }
}
