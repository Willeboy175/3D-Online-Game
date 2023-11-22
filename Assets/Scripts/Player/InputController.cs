using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SettingsController.CreateKeyBinds();
        SettingsController.ResetKeyBinds();
        SettingsController.SaveKeyBinds();
        SettingsController.LoadKeyBinds();
    }

    // Update is called once per frame
    void Update()
    {
        if (SettingsController.keyBinds["forward"] == KeyCode.W && Input.GetKeyDown(SettingsController.keyBinds["forward"]))
        {
            print("forward");
        }
        if (SettingsController.keyBinds["backward"] == KeyCode.S && Input.GetKeyDown(SettingsController.keyBinds["backward"]))
        {
            print("backward");
        }
        if (SettingsController.keyBinds["right"] == KeyCode.D && Input.GetKeyDown(SettingsController.keyBinds["right"]))
        {
            print("right");
        }
        if (SettingsController.keyBinds["left"] == KeyCode.A && Input.GetKeyDown(SettingsController.keyBinds["left"]))
        {
            print("left");
        }
        if (SettingsController.keyBinds["jump"] == KeyCode.Space && Input.GetKeyDown(SettingsController.keyBinds["jump"]))
        {
            print("jump");
        }
        if (SettingsController.keyBinds["sprint"] == KeyCode.LeftShift && Input.GetKeyDown(SettingsController.keyBinds["sprint"]))
        {
            print("sprint");
        }
    }

    //Returns float value using the right and left keybinds
    public static float HorizontalAxis()
    {
        float Axis = 0;
        bool right = false;
        bool left = false;

        if (Input.GetKey(SettingsController.keyBinds["right"]))
        {
            Axis = 1;
            right = true;
        }

        if (Input.GetKey(SettingsController.keyBinds["left"]))
        {
            Axis = -1;
            left = true;
        }

        if (right && left)
        {
            Axis = 0;
        }

        return Axis;
    }

    //Returns float value using the forward and backwards keybinds
    public static float VerticalAxis()
    {
        float Axis = 0;
        bool forward = false;
        bool backward = false;

        if (Input.GetKey(SettingsController.keyBinds["forward"]))
        {
            Axis = 1;
            forward = true;
        }
        if (Input.GetKey(SettingsController.keyBinds["backward"]))
        {
            Axis = -1;
            backward = true;
        }
        if (forward && backward)
        {
            Axis = 0;
        }

        return Axis;
    }
}
