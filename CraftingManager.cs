using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{

    public int IronBars;
    public int Cpus;
    public int Leather;
    public int CorruptHeart;
    public int GunPowder;
    public Text ironText;
    
    public Text cpuText;
    
    public Text leatherText;
    
    public Text corruptHeartText;
    
    public Text gunpowderText;

    [SerializeField] private GameObject craftingPanel;
    public bool inMenu = false;
    void Update()
    {
        ironText.text = "x " + IronBars.ToString();
        cpuText.text = "x " + Cpus.ToString();
        leatherText.text = "x " + Leather.ToString();
        corruptHeartText.text = "x " + CorruptHeart.ToString();
        gunpowderText.text = "x " + GunPowder.ToString();

        if (Input.GetKeyDown(KeyCode.I))
        {
            inMenu = !inMenu;
            craftingPanel.SetActive(inMenu);
            
            FindObjectOfType<TimedEnemySpawner>().enabled = inMenu;
            FindObjectOfType<PlayerMovementController>().enabled = inMenu;
            FindObjectOfType<Timer>().enabled = inMenu;
            FindObjectOfType<Artifact>().enabled = inMenu;
            FindObjectOfType<ShootingEnemyController>().enabled = inMenu;
            FindObjectOfType<TNTEnemy>().enabled = inMenu;
            FindObjectOfType<TankEnemy>().enabled = inMenu;

            foreach (var enemy in FindObjectsOfType<EnemyController>()) 
                enemy.enabled = inMenu;
        }
        
    }
}
