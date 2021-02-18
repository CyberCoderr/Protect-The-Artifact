using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private MenuButtonController menuButtonController;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorFunctions animatorFunctions;
    [SerializeField] private int thisIndex;
    [SerializeField] private bool isPlay = false;
    [SerializeField] private bool isAchivements = false;
    [SerializeField] private bool isMenu = false;
    [SerializeField] private bool isMenuPlay = false;
    [SerializeField] private bool isQuit = false;
    [SerializeField] private bool isSurvival = false;
    [SerializeField] private bool isTimed = false;
    [SerializeField] private GameObject ACanvas;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject PlayCanvas;
    [SerializeField] private GameObject survivalButton; 
    [SerializeField] private GameObject timedButton;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animatorFunctions = GetComponent<AnimatorFunctions>();
        menuButtonController = FindObjectOfType<MenuButtonController>();
    }

    void Update()
    {
        if (menuButtonController.Index == thisIndex)
        {
            animator.SetBool("selected", true);
            if (Input.GetAxis("Submit") == 1)
            {
                animator.SetBool("pressed", true);
                if (isPlay == true)
                {
                    SceneManager.LoadScene(1);
                }

                if (isAchivements == true)
                {
                    ACanvas.SetActive(true);
                    canvas.SetActive(false);
                }

                if (isMenu == true)
                {
                    SceneManager.LoadScene(0);
                }

                if (isQuit == true)
                {
                    Application.Quit();
                }

                if (isMenuPlay == true)
                {
                    PlayCanvas.SetActive(true);
                    canvas.SetActive(false);

                }

                if (isSurvival == true)
                {
                    Player.survivalMode = true;
                    SceneManager.LoadScene(1);
                }

                if (isTimed == true)
                {
                    Player.timedMode = true;
                    SceneManager.LoadScene(1);
                }

            }
            else if (animator.GetBool("pressed"))
            {
                animator.SetBool(("pressed"), false);
                animatorFunctions.disableOnce = true;
            }
        }
        else
        {
            animator.SetBool(("selected"), false);
        }
    }
}
