using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject saveMenu;
    public GameObject optionsMenu;
    public GameObject quitMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void LoadGame()
    {
        mainMenu.SetActive(false);
        saveMenu.SetActive(true);
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
        saveMenu.SetActive(false);
        optionsMenu.SetActive(false);
        quitMenu.SetActive(false);
    }
}
