using UnityEngine;
using TMPro;
using System.Collections;
using System;
using UnityEngine.UI;

public class Artifact : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI BoostActivatedText;
    public GameObject[] spawnPoints;
    public TextMeshProUGUI TimerText;
    public AudioSource ArtifactTakeDamage;
    public GameObject endCanvas;


    private void Start()
    {
        var HealthText = health.ToString();
        LivesText.text = "Artifact Lives Left: " + HealthText;
    }

    void Update()
    {
        if (health <= 0)
        {
            if(health <= -1)
            {
                health = 0;
                LivesText.text = "Artifact Lives Left: 0";
            }

            Player.survivalMode = false;
            
            DestroyGameObjects();
            GetComponent<Animator>().SetTrigger("DeathTrigger");
            TimerText.enabled = false;
            FindObjectOfType<PlayerMovementController>().enabled = false;
            StartCoroutine(CanvasEnableWait());

        }

    }

    IEnumerator CanvasEnableWait()
    {
        yield return  new  WaitForSeconds(6);
        endCanvas.SetActive(true);
    }


    public void DestroyGameObjects()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int e = 0; e < enemies.Length; e++)
            Destroy(enemies[e]);

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        for(int i = 0; i<spawnPoints.Length; i++)
        Destroy(spawnPoints[i]);
        
        spawnPoints = GameObject.FindGameObjectsWithTag("SEnemy");
        for(int s = 0; s<spawnPoints.Length; s++)
            Destroy(spawnPoints[s]);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        FindObjectOfType<EnemyRandomLoot>().wasArtifact = true;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
            var HealthText = health.ToString();
            Destroy(collision.gameObject);
            LivesText.text = "Artifact Lives Left: " + HealthText;
            ArtifactTakeDamage.Play();
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 2;
            var HealthText = health.ToString();
            Destroy(collision.gameObject);
            LivesText.text = "Artifact Lives Left: " + HealthText;
            ArtifactTakeDamage.Play();
        }
    }
}
