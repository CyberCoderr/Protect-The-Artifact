using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    public AudioSource EnemyKill;
    public ParticleSystem enemyKillParticles;
    public TextMeshProUGUI NotificationText;
    public TextMeshProUGUI LivesText;
    public static bool timedMode = false;
    public static bool survivalMode = false;
    public ParticleSystem SEnemyKillParticles;
    public ParticleSystem bulletKillParticles;
    public SpriteRenderer SEnemyRenderer;

    private void Start()
    {
        EnemyKill = GetComponent<AudioSource>();
    }

    private void Update()
    {
      if(PlayerMovementController.AlreadyBoosted == false)
        {
            if (Input.GetButtonDown("B"))
            {
                StartCoroutine(BoostNotificationHandler());
            }
        }
      else
        {

        }
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            EnemyKill.Play();
            Instantiate(enemyKillParticles, transform.position, Quaternion.identity);

            if (GameManager.SlasherUnlocked == false)
            {
                GameManager.SlasherTracker += 1;
            }
            else
            {
                GameManager.SlasherTracker += 0;
            }

            if (FindObjectOfType<Artifact>().health <= 99 && survivalMode == true && timedMode == false)
            {
                FindObjectOfType<Artifact>().health += 1;
                LivesText.text = "Artifact Lives Left: " + FindObjectOfType<Artifact>().health.ToString();
            }
            else if (FindObjectOfType<Artifact>().health >= 100 && survivalMode == true && timedMode == false)
            {
                FindObjectOfType<Artifact>().health += 0;
            }
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            EnemyKill.Play();
            Instantiate(bulletKillParticles, transform.position, Quaternion.identity);

        }
        if (collision.gameObject.CompareTag("SEnemy"))
        {
            if (FindObjectOfType<ShootingEnemyController>().health >= 2)
            {
                FindObjectOfType<ShootingEnemyController>().health -= 1;
                StartCoroutine(SEnemyHitEffect());
                Instantiate(SEnemyKillParticles, transform.position, Quaternion.identity);
                EnemyKill.Play();
            }
            else if (FindObjectOfType<ShootingEnemyController>().health <= 1)
            {
                EnemyKill.Play();
                Destroy(collision.gameObject);
                Instantiate(SEnemyKillParticles, transform.position, Quaternion.identity);
                ShootingEnemyController.shooterExists = false;

            }

            if (FindObjectOfType<Artifact>().health <= 95 && survivalMode == true)
            {
                FindObjectOfType<Artifact>().health += 5;
                LivesText.text = "Artifact Lives Left: " + FindObjectOfType<Artifact>().health.ToString();
            }
            else if (FindObjectOfType<Artifact>().health <= 96 && survivalMode == true && timedMode == false)
            {
                FindObjectOfType<Artifact>().health += 0;
            }
        }
    }


        IEnumerator SEnemyHitEffect()
        {
            SEnemyRenderer = GameObject.Find("ShootingEnemyPrefab(Clone)").GetComponent<SpriteRenderer>();

            SEnemyRenderer.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.2f);
            SEnemyRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.2f);
            SEnemyRenderer.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.2f);
            SEnemyRenderer.color = new Color(1, 1, 1, 1);
        }

        IEnumerator BoostNotificationHandler()
        {
            FindObjectOfType<Artifact>().health -= 15;
            var HealthText = FindObjectOfType<Artifact>().health.ToString();
            LivesText.text = "Artifact Lives Left: " + HealthText;
            NotificationText.text = "Boost Activated for 30 seconds!";
            yield return new WaitForSeconds(3);
            NotificationText.text = "";
        }

        IEnumerator AlreadyBoostedHandler()
        {
            NotificationText.text = "Boost Already Active!";
            yield return new WaitForSeconds(3);
            NotificationText.text = "";
        }

}
