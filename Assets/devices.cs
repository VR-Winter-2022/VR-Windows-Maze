using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devices : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
UnityEngine.XR.InputDevices.GetDevices(inputDevices);

foreach (var device in inputDevices)
{
    //Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.characteristics.ToString()));
}
var leftHandedControllers = new List<UnityEngine.XR.InputDevice>();
var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller;
UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, leftHandedControllers);

foreach (var device in leftHandedControllers)
{
    //Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
}
    }
}
