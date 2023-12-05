using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Message displayed when player looking at an interactable
    public string promptmessage;

    //Function to be called by the player
    public void BaceInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //Template function to be overridden by subclasses
    }
}
