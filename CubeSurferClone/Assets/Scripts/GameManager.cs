using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    private bool _isGameOver = false;
    public bool isGameOver
    {
        get
        {
            return _isGameOver;
        }
        set
        {
            _isGameOver = value;
        }
    }

    public Action GameWin = delegate { };
    public Action GameFail = delegate { };

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        GameWin += ResetSpeed;
        GameWin += LoadNextLevelWithDelay;
        GameWin += GameOver;

        GameFail += ResetSpeed;
        GameFail += ReloadWithDelay;
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
        _isGameOver = true;
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
