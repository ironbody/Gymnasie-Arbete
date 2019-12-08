using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static bool paused;

    public static int currentWave = 0;

    public int health = 3;

    public Transform enemyHandler;

    public GameObject[] waves;

    public GameObject bikeEnemy;

    public GameObject carEnemy;

    public GameObject pauseMenu;
    public GameObject loseMenu;
    public GameObject winMenu;

    private static int enemiesKilled;

    private int enemiesInWave;

    private bool lost;
    private bool won;
    public static bool spawningWave;

    public GameObject heart;

    public GameObject heartsParent;

    private List<GameObject> hearts;

    private AudioManager audioManager;

    private bool invulnerable = false;
    public float invulnerableTime;
    private float lastHit;

    // Start is called before the first frame update
    void Start()
    {
        lost = false;
        paused = false;
        won = false;
        currentWave = 0;
        Resume();

        hearts = new List<GameObject>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentWave > waves.Length)
        {
            Win();
        }

        if (enemiesKilled >= enemiesInWave && !paused && !spawningWave)
        {
            currentWave++;
            StartCoroutine(SpawnWave(currentWave - 1));

        }

        if (health <= 0)
        {
            Lose();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !lost && !won)
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (invulnerable)
        {
            if (Time.time > lastHit + invulnerableTime)
            {
                invulnerable = false;
            }
        }

    }

    public void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Lose()
    {
        paused = true;
        lost = true;
        Time.timeScale = 0f;
        loseMenu.SetActive(true);
    }

    public void Win()
    {
        paused = true;
        Time.timeScale = 0f;
        winMenu.SetActive(true);
    }

    IEnumerator SpawnWave(int waveNum)
    {

        spawningWave = true;
        enemiesKilled = 0;
        enemiesInWave = 0;

        SetHearts(3);

        var waveSeq = WaveText.NewWave(waveNum + 1);

        yield return waveSeq.WaitForCompletion();

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
        spawningWave = false;

    }

    private void SetHearts(int num)
    {
        var remainingHealth = hearts.Count;

        for (int i = 0; i < num - remainingHealth; i++)
        {
            GameObject h = Instantiate(heart, heartsParent.transform);
            RectTransform hTrans = h.gameObject.GetComponent<RectTransform>();

            hTrans.anchoredPosition = new Vector2(-120 + (30 * i), 250);
            hearts.Add(h);
        }

        health = num;
    }

    private void RemoveHeart()
    {
        Destroy(hearts[hearts.Count - 1]);
        hearts.RemoveAt(hearts.Count - 1);
    }

    public static void EnemyKilled()
    {
        enemiesKilled++;
    }

    public void HurtPlayer()
    {
        if (invulnerable)
        {
            return;
        }
        lastHit = Time.time;
        health--;
        RemoveHeart();
        invulnerable = true;
    }

}