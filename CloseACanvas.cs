using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseACanvas : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject ACanvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ACanvas.SetActive(false);
            Canvas.SetActive(true);
        }

    }
}
