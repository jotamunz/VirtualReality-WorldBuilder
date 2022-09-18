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

    // This variable will contain the object that will be in the VR world
    // This will change depending on toolFlag variable
    public GameObject actualTool;

    // These varaibles represent the prefabs that will spawn
    public GameObject weapongPref;
    public GameObject hoePref;
    public GameObject scythePref;

    private UnityEngine.XR.InputDevice rightHand;
    
    void Start()
    {
        // Right Hand XR controller
        var rightControllers = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesWithRole(UnityEngine.XR.InputDeviceRole.RightHanded, rightController);
        foreach (var device in rightControllers)
        {
            Debug.Log(string.Format("Device name '{0}' has role '{1}'", device.name, device.role.ToString()));
        }

        if (rightControllers != null){

            rightHand = rightControllers[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool primaryValue;
        if (rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out primaryValue) && primaryValue)
        {
            Debug.Log("A/Primary button is pressed.");
            this.toolFlag += 1;

            if (toolFlag >= 3){
                toolFlag = 0;
            }
        }
    }
}
