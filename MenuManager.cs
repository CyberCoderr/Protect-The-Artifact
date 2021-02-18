using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuCanvas;
    [SerializeField] private GameObject AchivementsCanvas;
    [SerializeField] private GameObject AboutCanvas;

    public void IfClickedOnAboutButton()
    {
        MainMenuCanvas.SetActive(false);
        AboutCanvas.SetActive(true);
    }
    public void IfClickedOnQuitButton()
    {
        Application.Quit();
    }
    public void IfClickedOnPlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void IfClickedOnBackInAboutButton()
    {
        MainMenuCanvas.SetActive(true);
        AboutCanvas.SetActive(false);
    }
    public void IfClickedOnAchivementsButton()
    {
        MainMenuCanvas.SetActive(false);
        AchivementsCanvas.SetActive(true);
    }
    public void IfClickedOnBackInAchivementsButton()
    {
        MainMenuCanvas.SetActive(true);
        AchivementsCanvas.SetActive(false);
    }
}
