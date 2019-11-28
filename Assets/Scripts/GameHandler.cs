using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (currentWave > waves.Length)
        {
            Win();
        }

        if (enemiesKilled >= enemiesInWave && !paused)
        {
            StartCoroutine(SpawnWave(currentWave));
            currentWave++;
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

    void Win()
    {

    }

    IEnumerator SpawnWave(int waveNum)
    {

        paused = true;

        var waveSeq = WaveText.NewWave(waveNum + 1);

        yield return waveSeq.WaitForCompletion();

        paused = false;

        foreach (var spawnPoint in waves[waveNum].GetComponentsInChildren<Transform>())
        {
            if (spawnPoint != null)
            {
                var spawnTrans = spawnPoint.transform;
                if (spawnPoint.name == "bike")
                {
                    var e = Instantiate(bikeEnemy, new Vector2(spawnTrans.position.x, spawnTrans.position.y + 10), Quaternion.identity, enemyHandler);
                    e.GetComponent<EnemyTween>().MoveToPosition(spawnTrans.position);
                    enemiesInWave++;
                }
                if (spawnPoint.name == "car")
                {
                    var e = Instantiate(carEnemy, new Vector2(spawnTrans.position.x, spawnTrans.position.y + 10), Quaternion.identity, enemyHandler);
                    e.GetComponent<EnemyTween>().MoveToPosition(spawnTrans.position);
                    enemiesInWave++;
                }
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