using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public TextMeshProUGUI NotificationText;
    public Rigidbody2D rb;
    public static bool AlreadyBoosted = false;




    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        GetComponent<Animator>().SetTrigger("Play");

    }
    public void Update()
    {       
        ActivateBoost();
    }


    private void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(horizontal, vertical);

        transform.position += movement * Time.deltaTime * moveSpeed;
    }


    void ActivateBoost()
    {
        if (FindObjectOfType<Artifact>().health >= 20)
        {
            if (Input.GetButtonDown("B"))
            {
                StartCoroutine(Boost());
            }
        }
    }
    IEnumerator Boost()
    {
        if (AlreadyBoosted == false)
        {
            moveSpeed += 7f;
            AlreadyBoosted = true;
            yield return new WaitForSeconds(30);
            moveSpeed -= 7f;
            AlreadyBoosted = false;
            StopCoroutine(Boost());
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.gravityScale = 0;
    }
}
