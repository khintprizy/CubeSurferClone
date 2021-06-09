using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    private GameObject player;

    public Text scoreText;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        int a = PlayerPrefs.GetInt("Score");
        scoreText.text = a.ToString();
    }

    public void RestartGame()
    {
        player.GetComponent<PlayerMovement>().speed = 0;
        Invoke("ReloadScene", 2);
    }

    public void AddScore(int amount)
    {
        score = GetScore();
        score = score + amount;
        PlayerPrefs.SetInt("Score", score);
        scoreText.text = GetScore().ToString(); 
    }

    int GetScore()
    {
        int a = PlayerPrefs.GetInt("Score");
        scoreText.text = a.ToString();
        return a;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Main");
    }
}
