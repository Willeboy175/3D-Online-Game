using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    // Start is called before the first frame update
    void Start()
    {
        
        promptText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
}
