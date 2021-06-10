using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    public static UIManager instance;
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
        int a = PlayerPrefs.GetInt("Score");
        scoreText.text = a.ToString();
    }

    public void AddScore(int amount)
    {
        int a = GetScore() + amount;
        PlayerPrefs.SetInt("Score", a);
        scoreText.text = a.ToString();
    }

    int GetScore()
    {
        int a = PlayerPrefs.GetInt("Score");
        scoreText.text = a.ToString();
        return a;
    }
}
