using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class AirInput : MonoBehaviour
{
    public static bool up1, up2, down1, down2, right1, right2, left1, left2, card11, card21, card31, card12, card22, card32;
    List<int> current_devices;
    private void OnEnable()
    {
        up1 = up2 = down1 = down2 = right1 = right2 = left1 = left2 = card11 = card21 = card31 = card12 = card22 = card32 = false;
    }
    private void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
    }

    private void FixedUpdate()
    {
        card11 = card21 = card31 = card12 = card22 = card32 = false;
    }
    void OnMessage(int fromDeviceID, JToken data)
    {
        if (current_devices == null || current_devices.Count <= 2)
        {
            current_devices = AirConsole.instance.GetControllerDeviceIds();
        }
        
        if (fromDeviceID == current_devices[0])
        {
            string dataAction = data["action"].ToString();
            if (dataAction.Contains("card"))
            {
                if (dataAction.Contains("1"))
                {
                    card11 = true;
                }
                else if (dataAction.Contains("2"))
                {
                    card21 = true;
                }
                else
                {
                    card31 = true;
                }
            }
            else
            {
                bool value = dataAction.Contains("start");
                if (dataAction.Contains("up"))
                {
                    up1 = value;
                }
                else if (dataAction.Contains("down"))
                {
                    down1 = value;
                }
                else if (dataAction.Contains("right"))
                {
                    right1 = value;
                }
                else
                {
                    left1 = value;
                }
            }
        }
        else
        {
            string dataAction = data["action"].ToString();
            if (dataAction.Contains("card"))
            {
                if (dataAction.Contains("1"))
                {
                    card12 = true;
                }
                else if (dataAction.Contains("2"))
                {
                    card22 = true;
                }
                else
                {
                    card32 = true;
                }
            }
            else
            {
                bool value = dataAction.Contains("start");
                if (dataAction.Contains("up"))
                {
                    up2 = value;
                }
                else if (dataAction.Contains("down"))
                {
                    down2 = value;
                }
                else if (dataAction.Contains("right"))
                {
                    right2 = value;
                }
                else
                {
                    left2 = value;
                }
            }
        }
    }

    private void OnDestroy()
    {
        if (AirConsole.instance != null)
        {
            AirConsole.instance.onMessage -= OnMessage;
        }
    }
}
