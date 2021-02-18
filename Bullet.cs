using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject artifact;
    [SerializeField] private float speed = 2f;
    public float rotationSpeed = 10f;

    private Quaternion lookDirection;
    private Vector3 direction;

    void Start()
    {
        artifact = GameObject.Find("Artifact");

    }
    void Update()
    {
        var actualSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, artifact.transform.position, actualSpeed);
        transform.up = artifact.transform.position - transform.position;

    }
}
