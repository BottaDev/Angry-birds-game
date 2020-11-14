using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;

    public float timeToLose = 10f;
    public GameObject[] balls;
    public GameObject pivotPoint;

    [Header("UI Objects")]
    public GameObject winText;
    public GameObject loseText;
    public GameObject resetButton;

    private int totalEnemies;
    private int enemiesCount = 0;
    private int playerAttempts = 0;
    private bool winGame = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        Instantiate(balls[0], pivotPoint.transform.position, Quaternion.identity);
    }

    public void CheckGame()
    {
        enemiesCount++;

        if (enemiesCount == totalEnemies)
            WinGame();
    }

    private void WinGame()
    {
        winGame = true;

        winText.SetActive(true);

        resetButton.SetActive(true);
    }

    private void LoseGame()
    {
        loseText.SetActive(true);

        resetButton.SetActive(true);
    }

    public IEnumerator StartLoseCountDown()
    {
        yield return new WaitForSeconds(timeToLose);

        if (!winGame)
            LoseGame();
    }

    public void AddAttempt()
    {
        playerAttempts++;

        if (playerAttempts == balls.Length)
            StartCoroutine(StartLoseCountDown());
        else
            StartCoroutine(SpawnBall(2f));
    }

    public IEnumerator SpawnBall(float time)
    {
        yield return new WaitForSeconds(time);

        Instantiate(balls[playerAttempts], pivotPoint.transform.position, Quaternion.identity);
    }
}
