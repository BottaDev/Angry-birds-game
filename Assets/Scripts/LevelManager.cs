using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;

    public float timeToLose = 10f;
    public GameObject[] balls;

    [Header("UI Objects")]
    public GameObject winText;
    public GameObject loseText;
    public GameObject resetButton;

    private int totalEnemies;
    private int enemiesCount = 0;
    private int playerAttempts;
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
    }
}
