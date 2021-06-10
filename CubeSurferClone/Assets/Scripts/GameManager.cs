using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    public bool isGameOver = false;

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
    }

    private void Start()
    {
        player = PlayerMovement.instance.gameObject;
    }

    public void RestartGame()
    {
        player.GetComponent<PlayerMovement>().speed = 0;
        Invoke("ReloadScene", 2);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void Failed()
    {
        isGameOver = true;
        RestartGame();
        Debug.Log("Game Over!!!!!!");
    }
}
