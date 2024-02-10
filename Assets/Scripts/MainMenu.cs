using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject startText;
    public GameObject credits;
    
    public void OnStartPress()
    {
        mainMenu.SetActive(false);
        startText.SetActive(true);
        credits.SetActive(false);
    }
    public void OnStartGamePress()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitPress()
    {
        Application.Quit();
    }
    public void OnCreditsPress()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
        startText.SetActive(false);
    }
    public void OnBackPress() {
        mainMenu.SetActive(true);
        credits.SetActive(false);
        startText.SetActive(false);
    }
}
