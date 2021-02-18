using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints = new Transform[8];
    public bool isActive = true;
    public AudioSource EasyToMedium;
    public AudioSource MediumToHard;
    public AudioSource HardToInsane;

    private System.Random random = new System.Random();
    private Coroutine _firstTimeRoutine;

    private void Start()
    {
        if (isActive == true)
        {
            StartCoroutine(Spawn());
        }
        else
        {
            StopCoroutine(Spawn());
        }

    }

    public IEnumerator Spawn()
    {
        if (_firstTimeRoutine == null)
            _firstTimeRoutine = StartCoroutine(FirstTimer());
        // wait for 5 seconds
        yield return new WaitForSeconds(6);
        if (isActive == true)
        {

            // get a random number of enemies from 1 to the total number of spawn locations
            int numberOfEnemiesToSpawn = Random.Range(1, spawnPoints.Length);

            // convert the array of spawn points to a list so we can do magic on it
            List<Transform> listOfSpawnPoints = spawnPoints.ToList();

            // randomly sort the list of spawn points, then take the first x, where x is the number of enemies to spawn this time
            var randomSpawns = listOfSpawnPoints.OrderBy(x => random.Next()).Take(numberOfEnemiesToSpawn);

            // loop through the new, shorter, list of spawn points and create an enemy at each one
            foreach (var spawnPoint in randomSpawns)
            {
                Instantiate(enemyPrefab, spawnPoint);
            }

            // do it all again
            StartCoroutine(Spawn());
        }
        else
        {
            StopCoroutine(Spawn());
        }
    }
    public IEnumerator FirstTimer()
    {
        yield return new WaitForSeconds(75);
        if (isActive == true)
        {
            EasyToMedium.Play();
            StopCoroutine(Spawn());
            StartCoroutine(HarderSpawn());         
        }
        // else  // Don't need to do this here because it'll automatically stop at the end of the method
        // {
        //     StopCoroutine(FirstTimer());
        // }

        _firstTimeRoutine = null; // setting it to null so we can tell it's finished running
    }
    public IEnumerator HarderSpawn()
    {
        StartCoroutine(SecondTimer());
        StopCoroutine(FirstTimer());

        // wait for 5 seconds
        yield return new WaitForSeconds(4);
        
        if (isActive == true)
        {
            // get a random number of enemies from 1 to the total number of spawn locations
            int numberOfEnemiesToSpawn = Random.Range(1, spawnPoints.Length);

            // convert the array of spawn points to a list so we can do magic on it
            List<Transform> listOfSpawnPoints = spawnPoints.ToList();

            // randomly sort the list of spawn points, then take the first x, where x is the number of enemies to spawn this time
            var randomSpawns = listOfSpawnPoints.OrderBy(x => random.Next()).Take(numberOfEnemiesToSpawn);

            // loop through the new, shorter, list of spawn points and create an enemy at each one
            foreach (var spawnPoint in randomSpawns)
            {
                Instantiate(enemyPrefab, spawnPoint);
            }

            // do it all again
            StartCoroutine(HarderSpawn());
        }
        else
        {
            StopCoroutine(HarderSpawn());
        }
    }
    public IEnumerator SecondTimer()
    {

        yield return new WaitForSeconds(90);
        if (isActive == true)
        {
            StopCoroutine(HarderSpawn());
            StartCoroutine(UltraHardSpawn());
            MediumToHard.Play();
            
        }
        else
        {
            StopCoroutine(SecondTimer());
        }

    }
    public IEnumerator UltraHardSpawn()
    {
        StartCoroutine(ThirdTimer());
        StopCoroutine(SecondTimer());
        // wait for 5 seconds
        yield return new WaitForSeconds(2);

        if (isActive == true)
        {
            // get a random number of enemies from 1 to the total number of spawn locations
            int numberOfEnemiesToSpawn = Random.Range(1, spawnPoints.Length);

            // convert the array of spawn points to a list so we can do magic on it
            List<Transform> listOfSpawnPoints = spawnPoints.ToList();

            // randomly sort the list of spawn points, then take the first x, where x is the number of enemies to spawn this time
            var randomSpawns = listOfSpawnPoints.OrderBy(x => random.Next()).Take(numberOfEnemiesToSpawn);

            // loop through the new, shorter, list of spawn points and create an enemy at each one
            foreach (var spawnPoint in randomSpawns)
            {
                Instantiate(enemyPrefab, spawnPoint);
            }

            // do it all again
            StartCoroutine(UltraHardSpawn());
        }
        else
        {
            StopCoroutine(UltraHardSpawn());
        }
    }
    public IEnumerator ThirdTimer()
    {

        yield return new WaitForSeconds(180);
        if (isActive == true)
        {
            StopCoroutine(UltraHardSpawn());
            StartCoroutine(ImpossibleSpawn());
            HardToInsane.Play();
            
        }
        else
        {
            StopCoroutine(ThirdTimer());
        }

    }
    public IEnumerator ImpossibleSpawn()
    {
        StopCoroutine(ThirdTimer());
        // wait for 5 seconds
        yield return new WaitForSeconds(1);

        if (isActive == true)
        {
            // get a random number of enemies from 1 to the total number of spawn locations
            int numberOfEnemiesToSpawn = Random.Range(1, spawnPoints.Length);

            // convert the array of spawn points to a list so we can do magic on it
            List<Transform> listOfSpawnPoints = spawnPoints.ToList();

            // randomly sort the list of spawn points, then take the first x, where x is the number of enemies to spawn this time
            var randomSpawns = listOfSpawnPoints.OrderBy(x => random.Next()).Take(numberOfEnemiesToSpawn);

            // loop through the new, shorter, list of spawn points and create an enemy at each one
            foreach (var spawnPoint in randomSpawns)
            {
                Instantiate(enemyPrefab, spawnPoint);
            }

            // do it all again
            StartCoroutine(ImpossibleSpawn());
        }
        else
        {
            StopCoroutine(ImpossibleSpawn());
        }
    }
}
