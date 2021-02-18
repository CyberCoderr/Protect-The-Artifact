using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public int Index;
    [SerializeField] private bool keyDown;
    [SerializeField] private int maxIndex;
    public AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    if (Index < maxIndex)
                    {
                        Index++;
                    }
                    else
                    {
                        Index = 0;
                    }
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    if (Index > 0)
                    {
                        Index--;
                    }
                    else
                    {
                        Index = maxIndex;
                    }
                }

                keyDown = true;

            }
        }
        else
        {
            keyDown = false;
        }
    }
}
