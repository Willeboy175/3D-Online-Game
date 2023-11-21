using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedInputs : MonoBehaviour
{
    public static Dictionary<string, KeyCode> keyBinds = new Dictionary<string, KeyCode>();

    public void SavedKeyBinds()
    {
        keyBinds.Add("forward", KeyCode.W);
        keyBinds.Add("backward", KeyCode.S);
        keyBinds.Add("right", KeyCode.D);
        keyBinds.Add("left", KeyCode.A);
        keyBinds.Add("jump", KeyCode.Space);
        keyBinds.Add("sprint", KeyCode.LeftShift);
    }
    

    public static void SaveKeyBinds()
    {
        foreach (string key in SavedInputs.keyBinds.Keys)
        {

            //cast the enum to an int
            int intRepresentation = (int)keyBinds[key];

            //Save the keybind
            PlayerPrefs.SetInt(key, intRepresentation);
        }

        //Write the changes to disk
        PlayerPrefs.Save();
    }

    public static void LoadKeyBinds(string key)
    {
        keyBinds[key] = (KeyCode)PlayerPrefs.GetInt(key);
        
    }
}
