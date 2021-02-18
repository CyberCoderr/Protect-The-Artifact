using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TankEnemy : MonoBehaviour
{

    public TextMeshProUGUI NotificationText;
    public int tHealth = 5;
    public GameObject deathEffect;
    private bool deathCalled = false;
    public SpriteRenderer spriteRenderer;
    public AudioSource deathSound;

    private Vector3 cameraInitialPosition;
    public float shakeMagnitude = 0.05f, shakeTime = 0.5f;
    public Camera mainCamera;
    public float destroyTime = 3f;

    public Slider healthSlider;
    

    private void Start()
    {
        NotificationText = GameObject.Find("Artifact Lives Text").GetComponent<TextMeshProUGUI>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;
        deathSound = GameObject.Find("BossSound").GetComponent<AudioSource>();
    }

    void ShakeIt()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
        
    }

    void StartCameraShaking()
    {
        
        float shakingCameraOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float shakingCameraOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
        cameraIntermadiatePosition.x += shakingCameraOffsetX;
        cameraIntermadiatePosition.y += shakingCameraOffsetY;
        mainCamera.transform.position = cameraIntermadiatePosition;
        
    }

    void StopCameraShaking()
    {
        
        CancelInvoke("StartCameraShaking");
        StartCoroutine(DestroyWait());
        mainCamera.transform.position = cameraInitialPosition;
        
        Time.timeScale = 1;
        
    }

    private void Update()
    {
        if (tHealth <= 0 && deathCalled == false)
        {
            deathCalled = true; 
            Destroy(GetComponent<BoxCollider2D>());
            spriteRenderer.color = new Color(1,1,1,0);
            Time.timeScale = 0.4f;
            deathSound.Play();
            deathEffect.SetActive(true);
            ShakeIt();
            
        }

        if (tHealth == 4)
        {
            healthSlider.value = 0.80f;
        }
        else if (tHealth == 3)
        {
            healthSlider.value = 0.60f;
        }
        else if(tHealth == 2)
        {
            healthSlider.value = 0.40f;
        }
        else if (tHealth == 1)
        {
            healthSlider.value = 0.20f;
        }
        else if(tHealth == 0)
        {
            healthSlider.value = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Artifact"))
        {
            FindObjectOfType<EnemyRandomLoot>().wasArtifact = true;
            collision.gameObject.GetComponent<Artifact>().health -= 30;
            var healthText = FindObjectOfType<Artifact>().health.ToString();
            NotificationText.text = "Artifact Lives Left: " + healthText;
            deathSound.Play();
            tHealth -= 5;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (tHealth >= 2)
            {
                tHealth -= 1;
                StartCoroutine(HitEffect());
                
                
            }
            else if (tHealth <= 1)
            {
                tHealth -= 1;
                collision.gameObject.GetComponent<Rigidbody2D>().mass = 1000000;
            }
        }
    }

    IEnumerator DestroyWait()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
    IEnumerator HitEffect()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
