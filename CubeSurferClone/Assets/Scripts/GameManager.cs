using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    public bool isGameOver = false;

    public Action GameWin = delegate { };
    public Action GameFail = delegate { };

    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        GameWin += ResetSpeed;
        GameWin += ReloadWithDelay;
        GameWin += GameOver;

        GameFail += ResetSpeed;
        GameFail += LoadNextLevelWithDelay;
        GameFail += GameOver;
    }

    private void Start()
    {
        player = PlayerMovement.instance.gameObject;
    }

    public void ResetSpeed()
    {
        player.GetComponent<PlayerMovement>().speed = 0;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void ReloadWithDelay()
    {
        Invoke("ReloadScene", 2);
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void LoadNextLevelWithDelay()
    {
        Invoke("LoadNextLevel", 3);
    }
}
