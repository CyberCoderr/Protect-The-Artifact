using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtons : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(ActivateButton());
    }

    private void OnDisable()
    {
        GetComponent<MenuButton>().enabled = false;
    }

    IEnumerator ActivateButton()
    {
        yield return new WaitForSeconds(0.17f);
        
        GetComponent<MenuButton>().enabled = true;
    }
}
