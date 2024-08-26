using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;
    private GameObject textObject;
    private GameObject playerInventory;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.FindGameObjectWithTag("PromptText");
        promptText = textObject.GetComponent<TextMeshProUGUI>();
        playerInventory = GameObject.FindGameObjectWithTag("InventoryPanel");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            playerInventory.SetActive(isActive);

            if (isActive)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
            }

            isActive = !isActive;
        }
    }

    //Updates promptText
    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
}
