using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;
    private GameObject textObject;

    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.FindGameObjectWithTag("PromptText");
        promptText = textObject.GetComponent<TextMeshProUGUI>();
    }

    //Updates promptText
    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
}
