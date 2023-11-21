using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode right = KeyCode.D;
    public KeyCode left = KeyCode.A;
    public KeyCode jump = KeyCode.Space;
    public KeyCode sprint = KeyCode.LeftShift;

    // Start is called before the first frame update
    void Start()
    {
        SavedInputs.CreateKeyBinds();
        SavedInputs.LoadKeyBinds();
    }

    // Update is called once per frame
    void Update()
    {
        if (SavedInputs.keyBinds["forward"] == KeyCode.W && Input.GetKeyDown(KeyCode.W))
        {
            print("W");
        }
        if (SavedInputs.keyBinds["backward"] == KeyCode.S && Input.GetKeyDown(KeyCode.S))
        {
            print("S");
        }
        if (SavedInputs.keyBinds["right"] == KeyCode.D && Input.GetKeyDown(KeyCode.D))
        {
            print("D");
        }
        if (SavedInputs.keyBinds["left"] == KeyCode.A && Input.GetKeyDown(KeyCode.A))
        {
            print("A");
        }
        if (SavedInputs.keyBinds["jump"] == KeyCode.Space && Input.GetKeyDown(KeyCode.Space))
        {
            print("Space");
        }
        if (SavedInputs.keyBinds["sprint"] == KeyCode.LeftShift && Input.GetKeyDown(KeyCode.LeftShift))
        {
            print("LeftShift");
        }
    }
}
