using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static bool paused;

    public static int currentWave = 0;

    public static int health = 3;

    public Transform enemyHandler;

    public GameObject[] waves;

    public GameObject bikeEnemy;

    public GameObject carEnemy;

    private static int enemiesKilled;

    private int enemiesInWave;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave(currentWave);
    }

    // Update is called once per frame
    void Update()
    {

        if (enemiesKilled >= enemiesInWave)
        {
            currentWave++;
            SpawnWave(currentWave);
        }

        if (health <= 0)
        {
            Lose();
        }
    }

    public static void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
    }

    public static void Lose()
    {
        paused = true;
        Time.timeScale = 0f;
    }

    public static void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
    }

    void NextWave()
    {

    }

    void SpawnWave(int waveNum)
    {
        foreach (var spawnPoint in waves[waveNum].GetComponentsInChildren<Transform>())
        {
            if (spawnPoint.name == "bike")
            {
                Instantiate(bikeEnemy, spawnPoint.transform.position, Quaternion.identity, enemyHandler);
                enemiesInWave++;
            }
            if (spawnPoint.name == "car")
            {
                Instantiate(carEnemy, spawnPoint.transform.position, Quaternion.identity, enemyHandler);
                enemiesInWave++;
            }
        }

    }

    public static void EnemyKilled()
    {
        enemiesKilled++;
    }

    public static void HurtPlayer()
    {
        health--;
    }
}