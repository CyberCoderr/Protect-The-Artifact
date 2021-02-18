using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float currentTime = 0;
    float startTime = 0;
    public float timeStart = 180f;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private GameObject TModeCanvas;
    [SerializeField] private Text TModeResultText;

    void Start()
    {
        if (Player.survivalMode == true){startTime = Time.time;}

        if (Player.timedMode == true)
        {
            TimerText.text = timeStart.ToString("f2");
            StartCoroutine(EndTimedMode());
        }
    }


    void Update()
    {
        if (Player.survivalMode == true)
        {
            float time = Time.time - startTime;
            string minutes = ((int)time / 60).ToString();
            string seconds = (time % 60).ToString("f2");
            TimerText.text = minutes + ":" + seconds;
        }

        if (Player.timedMode == true)
        {
            timeStart -= Time.deltaTime;
            TimerText.text = timeStart.ToString("f2");
        }

    }

    IEnumerator EndTimedMode()
    {
        yield return new WaitForSeconds(180);
        FindObjectOfType<TimedEnemySpawner>().enabled = false;
        FindObjectOfType<PlayerMovementController>().enabled = false;
        TModeCanvas.SetActive(true);
        TModeResultText.text = "Your artifact survived with " + FindObjectOfType<Artifact>().health.ToString() + " health";
        Player.timedMode = false;
    }
}
