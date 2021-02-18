
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingEnemyController : MonoBehaviour
{

    [SerializeField] private float speed = 1f;
    public GameObject[] waypoints;
    int current = 0;
    float WPradius = 1;
    public static bool shooterExists = false;
    public float health = 2f;
    public Slider healthSlider;
    public Rigidbody2D rb;
    public ParticleSystem enemyKill;

    [SerializeField] private GameObject bullet;

    private void Awake()
    {
        shooterExists = true;
    }
    private void Start()
    { 
        InvokeRepeating("Shoot", 2f, 8f);
        rb = GetComponent<Rigidbody2D>();
        waypoints = GameObject.FindGameObjectsWithTag("ShootingPoint");
    }
    private void FixedUpdate()
    {

        if(Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if(current >= waypoints.Length)
            {
                current = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);


        if (health == 1f)
        {
            healthSlider.value = 0.50f;  
        }
        
    }


    public void Shoot()
    {   
        Instantiate(bullet, transform.position, Quaternion.identity);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<EnemyRandomLoot>().wasArtifact = true;
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Instantiate(enemyKill, transform.position, Quaternion.identity);
        }
    }

}
