using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingPopupText : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        GetComponent<Animator>().SetBool("Trigger", true);
        yield return new WaitForSeconds(0.20f);
        GetComponent<Animator>().SetBool("Trigger", false);
        gameObject.SetActive(false);
    }
}
