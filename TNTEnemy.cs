using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TNTEnemy : MonoBehaviour
{
    public int eEnemyHealth = 1;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private TextMeshProUGUI AHealthText;
    public AudioSource deathSound;

    private void Start()
    {
        AHealthText = GameObject.Find("Artifact Lives Text").GetComponent<TextMeshProUGUI>();
        deathSound = GameObject.Find("TNTEnemySound").GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (eEnemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            deathSound.Play();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Artifact"))
        {
            FindObjectOfType<EnemyRandomLoot>().wasArtifact = true;
            collision.collider.GetComponent<Artifact>().health -= 15;
            var AHealth = collision.collider.GetComponent<Artifact>().health.ToString();
            AHealthText.text = "Artifact Lives Left: " + AHealth;
            deathSound.Play();
            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("Player"))
        {
            eEnemyHealth -= 1;
        }
    }
}
