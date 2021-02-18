using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyRandomLoot : MonoBehaviour
{
    [SerializeField] private int ELootChance;
    [SerializeField] private int ESLootChance;
    [SerializeField] private int BELootChance;
    [SerializeField] private int TNTLootChance;
    public bool isEnemy;
    public bool isSEnemy;
    public bool isTNTEnemy;
    public bool isBossEnemy;
    public Text ironPopupText;
    public Text cpuPopupText;
    public Text leatherPopupText;
    public Text corruptHeartPopupText;
    public Text gunpowderPopupText;
    public bool wasArtifact = false;

    private void Start()
    {
        ironPopupText = GameObject.Find("Iron Bar").transform.Find("IronIncreaseText").GetComponent<Text>();
        cpuPopupText = GameObject.Find("MicroProcessor").transform.Find("IncreaseText").GetComponent<Text>();
        leatherPopupText = GameObject.Find("Leather").transform.Find("IncreaseText").GetComponent<Text>();
        corruptHeartPopupText = GameObject.Find("CorruptHeart").transform.Find("IncreaseText").GetComponent<Text>();
        gunpowderPopupText = GameObject.Find("Gunpowder").transform.Find("IncreaseText").GetComponent<Text>();


    }

    public void OnDestroy()
    {


        if (!wasArtifact)
        {


            if (isEnemy == true)
            {
                ELootChance = Random.Range(1, 10);
                int GoodLoot = Random.Range(0, 3);

                if (ELootChance >= 1)
                {

                    FindObjectOfType<CraftingManager>().IronBars += 1;
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+1";
                }

                if (ELootChance >= 5)
                {

                    FindObjectOfType<CraftingManager>().IronBars += 2;
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+3";

                }

                if (ELootChance == 7 && GoodLoot >= 2)
                {

                    FindObjectOfType<CraftingManager>().IronBars += 2;
                    FindObjectOfType<CraftingManager>().CorruptHeart += 1;
                    FindObjectOfType<CraftingManager>().Leather += 1;
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+5";
                    corruptHeartPopupText.gameObject.SetActive(true);
                    corruptHeartPopupText.text = "+1";
                    leatherPopupText.gameObject.SetActive(true);
                    leatherPopupText.text = "+1";


                }

                if (ELootChance == 9 && GoodLoot >= 3)
                {

                    FindObjectOfType<CraftingManager>().IronBars += 2;
                    FindObjectOfType<CraftingManager>().CorruptHeart += 1;
                    FindObjectOfType<CraftingManager>().Cpus += 1;
                    FindObjectOfType<CraftingManager>().Leather += 2;
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+5";
                    cpuPopupText.gameObject.SetActive(true);
                    cpuPopupText.text = "+1";
                    leatherPopupText.gameObject.SetActive(true);
                    leatherPopupText.text = "+2";
                    corruptHeartPopupText.gameObject.SetActive(true);
                    corruptHeartPopupText.text = "+1";

                }
            }

            if (isTNTEnemy == true)
            {
                TNTLootChance = Random.Range(1, 10);
                int GLoot = Random.Range(0, 3);

                if (TNTLootChance >= 1)
                {
                    FindObjectOfType<CraftingManager>().GunPowder += 1;
                    gunpowderPopupText.gameObject.SetActive(true);
                    gunpowderPopupText.text = "+1";

                }

                if (TNTLootChance >= 3 && GLoot >= 2)
                {
                    FindObjectOfType<CraftingManager>().IronBars += 1;
                    FindObjectOfType<CraftingManager>().GunPowder += 1;
                    gunpowderPopupText.gameObject.SetActive(true);
                    gunpowderPopupText.text = "+1";
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+1";

                }

                if (TNTLootChance >= 7 && GLoot >= 2)
                {
                    FindObjectOfType<CraftingManager>().IronBars += 1;
                    FindObjectOfType<CraftingManager>().GunPowder += 2;
                    FindObjectOfType<CraftingManager>().CorruptHeart += 1;
                    FindObjectOfType<CraftingManager>().Cpus += 1;
                    FindObjectOfType<CraftingManager>().Leather += 1;
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+1";
                    cpuPopupText.gameObject.SetActive(true);
                    cpuPopupText.text = "+1";
                    leatherPopupText.gameObject.SetActive(true);
                    leatherPopupText.text = "+1";
                    corruptHeartPopupText.gameObject.SetActive(true);
                    corruptHeartPopupText.text = "+1";
                    gunpowderPopupText.gameObject.SetActive(true);
                    gunpowderPopupText.text = "+2";
                }

                if (TNTLootChance >= 9 && GLoot == 3)
                {
                    FindObjectOfType<CraftingManager>().IronBars += 2;
                    FindObjectOfType<CraftingManager>().GunPowder += 3;
                    FindObjectOfType<CraftingManager>().CorruptHeart += 2;
                    FindObjectOfType<CraftingManager>().Cpus += 2;
                    FindObjectOfType<CraftingManager>().Leather += 2;
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+2";
                    cpuPopupText.gameObject.SetActive(true);
                    cpuPopupText.text = "+2";
                    leatherPopupText.gameObject.SetActive(true);
                    leatherPopupText.text = "+2";
                    corruptHeartPopupText.gameObject.SetActive(true);
                    corruptHeartPopupText.text = "+2";
                    gunpowderPopupText.gameObject.SetActive(true);
                    gunpowderPopupText.text = "+3";
                }
            }


            if (isSEnemy == true)
            {
                ESLootChance = Random.Range(1, 10);
                int ExtraLoot = Random.Range(0, 3);

                if (ESLootChance >= 1)
                {
                    FindObjectOfType<CraftingManager>().GunPowder += 1;
                    FindObjectOfType<CraftingManager>().IronBars += 1;
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+1";
                    gunpowderPopupText.gameObject.SetActive(true);
                    gunpowderPopupText.text = "+1";
                }

                if (ESLootChance >= 3 && ExtraLoot >= 1)
                {
                    FindObjectOfType<CraftingManager>().IronBars += 2;
                    FindObjectOfType<CraftingManager>().GunPowder += 2;
                    FindObjectOfType<CraftingManager>().Leather += 1;
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+2";
                    leatherPopupText.gameObject.SetActive(true);
                    leatherPopupText.text = "+1";
                    gunpowderPopupText.gameObject.SetActive(true);
                    gunpowderPopupText.text = "+2";
                }

                if (ESLootChance >= 7 && ExtraLoot >= 2)
                {
                    FindObjectOfType<CraftingManager>().IronBars += 2;
                    FindObjectOfType<CraftingManager>().GunPowder += 2;
                    FindObjectOfType<CraftingManager>().CorruptHeart += 1;
                    FindObjectOfType<CraftingManager>().Cpus += 1;
                    FindObjectOfType<CraftingManager>().Leather += 1;
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+2";
                    cpuPopupText.gameObject.SetActive(true);
                    cpuPopupText.text = "+1";
                    leatherPopupText.gameObject.SetActive(true);
                    leatherPopupText.text = "+1";
                    corruptHeartPopupText.gameObject.SetActive(true);
                    corruptHeartPopupText.text = "+1";
                    gunpowderPopupText.gameObject.SetActive(true);
                    gunpowderPopupText.text = "+2";
                }

                if (ESLootChance >= 9 && ExtraLoot == 3)
                {
                    FindObjectOfType<CraftingManager>().IronBars += 3;
                    FindObjectOfType<CraftingManager>().GunPowder += 3;
                    FindObjectOfType<CraftingManager>().CorruptHeart += 2;
                    FindObjectOfType<CraftingManager>().Cpus += 1;
                    FindObjectOfType<CraftingManager>().Leather += 2;
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+3";
                    cpuPopupText.gameObject.SetActive(true);
                    cpuPopupText.text = "+1";
                    leatherPopupText.gameObject.SetActive(true);
                    leatherPopupText.text = "+2";
                    corruptHeartPopupText.gameObject.SetActive(true);
                    corruptHeartPopupText.text = "+2";
                    gunpowderPopupText.gameObject.SetActive(true);
                    gunpowderPopupText.text = "+3";
                }
            }

            if (isBossEnemy == true)
            {

                BELootChance = Random.Range(1, 10);
                int UltraLoot = Random.Range(0, 3);

                if (BELootChance >= 1)
                {
                    FindObjectOfType<CraftingManager>().GunPowder += 5;
                    FindObjectOfType<CraftingManager>().IronBars += 3;
                    FindObjectOfType<CraftingManager>().Cpus += 2;
                    FindObjectOfType<CraftingManager>().Leather += 3;
                    FindObjectOfType<CraftingManager>().CorruptHeart += 1;
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+3";
                    cpuPopupText.gameObject.SetActive(true);
                    cpuPopupText.text = "+2";
                    leatherPopupText.gameObject.SetActive(true);
                    leatherPopupText.text = "+3";
                    corruptHeartPopupText.gameObject.SetActive(true);
                    corruptHeartPopupText.text = "+1";
                    gunpowderPopupText.gameObject.SetActive(true);
                    gunpowderPopupText.text = "+5";
                }

                if (BELootChance >= 3 && UltraLoot >= 1)
                {
                    FindObjectOfType<CraftingManager>().IronBars += 7;
                    FindObjectOfType<CraftingManager>().GunPowder += 9;
                    FindObjectOfType<CraftingManager>().Cpus += 3;
                    FindObjectOfType<CraftingManager>().Leather += 5;
                    FindObjectOfType<CraftingManager>().CorruptHeart += 3;
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+7";
                    cpuPopupText.gameObject.SetActive(true);
                    cpuPopupText.text = "+3";
                    leatherPopupText.gameObject.SetActive(true);
                    leatherPopupText.text = "+5";
                    corruptHeartPopupText.gameObject.SetActive(true);
                    corruptHeartPopupText.text = "+3";
                    gunpowderPopupText.gameObject.SetActive(true);
                    gunpowderPopupText.text = "+9";
                }

                if (BELootChance >= 7 && UltraLoot >= 2)
                {
                    FindObjectOfType<CraftingManager>().IronBars += 12;
                    FindObjectOfType<CraftingManager>().GunPowder += 15;
                    FindObjectOfType<CraftingManager>().CorruptHeart += 1;
                    FindObjectOfType<CraftingManager>().Cpus += 5;
                    FindObjectOfType<CraftingManager>().Leather += 6;
                    FindObjectOfType<CraftingManager>().CorruptHeart += 5;
                    ironPopupText.gameObject.SetActive(true);
                    ironPopupText.text = "+12";
                    cpuPopupText.gameObject.SetActive(true);
                    cpuPopupText.text = "+5";
                    leatherPopupText.gameObject.SetActive(true);
                    leatherPopupText.text = "+6";
                    corruptHeartPopupText.gameObject.SetActive(true);
                    corruptHeartPopupText.text = "+1";
                    gunpowderPopupText.gameObject.SetActive(true);
                    gunpowderPopupText.text = "+2";
                }

                if (BELootChance >= 9 && UltraLoot == 3)
                {
                    FindObjectOfType<CraftingManager>().IronBars += 15;
                    FindObjectOfType<CraftingManager>().GunPowder += 20;
                    FindObjectOfType<CraftingManager>().CorruptHeart += 2;
                    FindObjectOfType<CraftingManager>().Cpus += 8;
                    FindObjectOfType<CraftingManager>().Leather += 8;
                    FindObjectOfType<CraftingManager>().CorruptHeart += 10;
                }
            }
        }
    }
}
