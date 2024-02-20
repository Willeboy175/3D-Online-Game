using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject newGameMenu;
    public GameObject loadGameMenu;
    public GameObject optionsMenu;
    public GameObject quitMenu;
    public Toggle multiplayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void NewGame()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(true);
    }

    public void LoadGame()
    {
        mainMenu.SetActive(false);
        loadGameMenu.SetActive(true);
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Quit()
    {
        mainMenu.SetActive(false);
        quitMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        quitMenu.SetActive(false);
    }
}
