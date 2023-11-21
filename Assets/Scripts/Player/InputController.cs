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
        LoadSavedControls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSavedControls()
    {
        forward = SavedInputs.forward;
        backward = SavedInputs.backward;
        right = SavedInputs.right;
        left = SavedInputs.left;
        jump = SavedInputs.jump;
        sprint = SavedInputs.sprint;
    }

    public void SaveControls()
    {

    }

    public void ResetToDefaultControls()
    {
        SavedInputs.forward = KeyCode.W;
        SavedInputs.backward = KeyCode.S;
        SavedInputs.right = KeyCode.D;
        SavedInputs.left = KeyCode.A;
        SavedInputs.jump = KeyCode.Space;
        SavedInputs.sprint = KeyCode.LeftShift;
    }
}
