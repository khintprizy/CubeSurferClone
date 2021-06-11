using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    public bool isGameOver = false;

    public Action GameEnd = delegate { };

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

        GameEnd += ResetSpeed;
        GameEnd += ReloadWithDelay;
        GameEnd += Failed;
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
        SceneManager.LoadScene("Main");
    }
    void ReloadWithDelay()
    {
        Invoke("ReloadScene", 2);
    }

    public void Failed()
    {
        isGameOver = true;
        //ResetSpeed();
        Debug.Log("Game Over!!!!!!");
    }
}
