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
        SettingsController.LoadKeyBinds();
    }

    // Update is called once per frame
    void Update()
    {
        if (SettingsController.keyBinds["forward"] == KeyCode.W && Input.GetKeyDown(KeyCode.W))
        {
            print("W");
        }
        if (SettingsController.keyBinds["backward"] == KeyCode.S && Input.GetKeyDown(KeyCode.S))
        {
            print("S");
        }
        if (SettingsController.keyBinds["right"] == KeyCode.D && Input.GetKeyDown(KeyCode.D))
        {
            print("D");
        }
        if (SettingsController.keyBinds["left"] == KeyCode.A && Input.GetKeyDown(KeyCode.A))
        {
            print("A");
        }
        if (SettingsController.keyBinds["jump"] == KeyCode.Space && Input.GetKeyDown(KeyCode.Space))
        {
            print("Space");
        }
        if (SettingsController.keyBinds["sprint"] == KeyCode.LeftShift && Input.GetKeyDown(KeyCode.LeftShift))
        {
            print("LeftShift");
        }
    }

    //Returns float value using the right and left keybinds
    public static float HorizontalAxis()
    {
        float Axis = 0;
        bool right = false;
        bool left = false;

        if (Input.GetKeyDown(SettingsController.keyBinds["right"]))
        {
            Axis = 1;
            right = true;
        }

        if (Input.GetKeyDown(SettingsController.keyBinds["left"]))
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

        if (Input.GetKeyDown(SettingsController.keyBinds["forward"]))
        {
            Axis = 1;
            forward = true;
        }
        if (Input.GetKeyDown(SettingsController.keyBinds["backward"]))
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
