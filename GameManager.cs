using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static bool SlasherUnlocked = false;
    public static int SlasherTracker = 0;
    public TextMeshProUGUI NotificationText;
    [SerializeField] private bool SlasherGlitchFixBool = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SlasherTracker == 50 && SlasherGlitchFixBool == false && SlasherUnlocked == false)
        {
            SlasherUnlocked = true;
            StartCoroutine(SlasherUnlock());
        }
    }

    IEnumerator SlasherUnlock()
    {
        NotificationText.text = "Slasher Achivement Unlocked";
        yield return new WaitForSeconds(3);
        NotificationText.text = "";
        SlasherGlitchFixBool = true;
    }


}
