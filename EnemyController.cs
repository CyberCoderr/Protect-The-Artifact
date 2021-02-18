using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This tells Unity to add a Rigidbody2D when this script is added
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    // Contains a list of all enemies the use of this is you're not checking for the enemies each update so it is alot more efficent
    // It is static so that there is only one list that all enemy controllers use instead of a list for every controller. This is alot more efficient and faster
    private static List<EnemyController> enemies;

    // In the editor just define the artifact (made it lower case as thats the standard formatting for C#)
    [SerializeField] public GameObject artifact;
    // Speed changed to speedMultiplier as it makes a bit more sense
    [SerializeField] public float speedMultiplier = 1f;
    // Maximum speed the enemy can move
    [SerializeField] public float maxVelocity = 1f;
    // Friction to slow them down
    [SerializeField] public float frictionMultiplier = 1f;
    // Repel sensitivity is based on how close the enemy needs to get before it repels
    [SerializeField] public float repelSensitivity = 1f;
    // Repel multiplier is how fast it will repel the enemy away
    [SerializeField] public float repelMultiplier = 1f;

    // This hold the rigidbody for easy use
    private Rigidbody2D rb;

    // Put some stuff in awake instead as it executes before Start();
    private void Awake()
    {
        artifact = GameObject.Find("Artifact");

        // Check if the enemies list doesn't exist
        if (enemies == null)
        {
            // Create EnemyController list
            enemies = new List<EnemyController>();
        }

        // Get Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Check if a Rigidbody2D exists
        if (rb == null)
        {
            // Created a Rigidbody2D if it doesn't exist yet
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        // Turn off gravity as it isnt needed
        rb.gravityScale = 0;
    }

    // If an enemy is created when it's enabled (which by default it is) add it to the list
    private void OnEnable()
    {
        enemies.Add(this);
    }

    // Remove enemy on disable to save on processing as the enemy is no longer in use (this also prevents an error)
    private void OnDisable()
    {
        enemies.Remove(this);
    }

    // Placed in FixedUpdate(); because physics type stuff should be calculated in there as it's executed more
    void FixedUpdate()
    {
        // For Organisation
            Movement();
    }



    private void Movement()
    {
        // Get the current velocity for modification in new movement
        Vector3 velocity = rb.velocity;

        // Get direction towards artifact
        Vector3 directionTowardsArtifact = (artifact.transform.position - transform.position).normalized;
        // Add a movement towards the artifact
        velocity += directionTowardsArtifact * speedMultiplier * Time.deltaTime;

        // For every enemy in the scene
        foreach (EnemyController enemy in enemies)
        {
            // Find the enemy's distance
            float distance = (enemy.transform.position - transform.position).sqrMagnitude;

            // If it is within the range of the sensitivity
            if (distance <= repelSensitivity)
            {
                // Get the direction to the enemy
                Vector3 direction = (enemy.transform.position - transform.position).normalized;
                // Add to the new position for the movement away from the enemy
                velocity += -direction * repelMultiplier * Time.deltaTime;
            }
        }

        // Check if moving right else if check if moving left
        if (velocity.x > 0)
        {
            // Apply friction towards left direction
            velocity.x -= frictionMultiplier * Time.deltaTime;
            // Make sure we dont make the velocity moving towards left
            velocity.x = Mathf.Clamp(velocity.x, 0, maxVelocity);
        }
        else if (velocity.x < 0)
        {
            // Apply friction towards right direction
            velocity.x += frictionMultiplier * Time.deltaTime;
            // Make sure we dont make the velocity moving towards right
            velocity.x = Mathf.Clamp(velocity.x, -maxVelocity, 0);
        }

        // Check if moving up else if check if moving down
        if (velocity.y > 0)
        {
            // Apply friction towards down direction
            velocity.y -= frictionMultiplier * Time.deltaTime;
            // Make sure we dont make the velocity moving towards down
            velocity.y = Mathf.Clamp(velocity.y, 0, maxVelocity);
        }
        else if (velocity.y < 0)
        {
            // Apply friction towards up direction
            velocity.y += frictionMultiplier * Time.deltaTime;
            // Make sure we dont make the velocity moving towards up
            velocity.y = Mathf.Clamp(velocity.y, -maxVelocity, 0);
        }

        // Makes sure that velocity.x is within the minimum speed of -maxVelocity and max of maxVelocity
        velocity.x = Mathf.Clamp(velocity.x, -maxVelocity, maxVelocity);
        // Makes sure that velocity.y is within the minimum speed of -maxVelocity and max of maxVelocity
        velocity.y = Mathf.Clamp(velocity.y, -maxVelocity, maxVelocity);

        // Set the rb velocity to the new velociy
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
