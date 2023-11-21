using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedInputs : MonoBehaviour
{
    public static Dictionary<string, KeyCode> keyBinds = new Dictionary<string, KeyCode>();

    //Resets keybinds to default
    //Also creates the dictionary
    public static void CreateKeyBinds()
    {
        keyBinds.Add("forward", KeyCode.W);
        keyBinds.Add("backward", KeyCode.S);
        keyBinds.Add("right", KeyCode.D);
        keyBinds.Add("left", KeyCode.A);
        keyBinds.Add("jump", KeyCode.Space);
        keyBinds.Add("sprint", KeyCode.LeftShift);
    }

    //Saves the current keybinds to a PlayerPrefs
    public static void SaveKeyBinds()
    {
        foreach (string key in keyBinds.Keys)
        {
            //cast the enum to an int
            int intRepresentation = (int)keyBinds[key];

            //Save the keybind
            PlayerPrefs.SetInt(key, intRepresentation);
        }

        //Write the changes to disk
        PlayerPrefs.Save();
    }

    public static void LoadKeyBinds()
    {
        string[] keys = new string[keyBinds.Count];
        int length = 0;

        //Writes the strings in keybinds to an array
        foreach (string key in keyBinds.Keys)
        {
            keys[length] = key;
            length++;
        }

        //Loads keybinds using the array
        for (int i = 0; i < keyBinds.Count; i++)
        {
            int intRepresentation = PlayerPrefs.GetInt(keys[i]);

            keyBinds[keys[i]] = (KeyCode)intRepresentation;
        }
    }

    public static void ResetKeyBinds()
    {
        keyBinds.Clear();

        keyBinds.Add("forward", KeyCode.W);
        keyBinds.Add("backward", KeyCode.S);
        keyBinds.Add("right", KeyCode.D);
        keyBinds.Add("left", KeyCode.A);
        keyBinds.Add("jump", KeyCode.Space);
        keyBinds.Add("sprint", KeyCode.LeftShift);
    }


}
