using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text totalScoreText;

    [SerializeField]
    private int score = 0;
    [SerializeField]
    private Text scoreText;


    private static UIManager _instance;
    public static UIManager instance
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
    }

    private void Start()
    {
        int a = PlayerPrefs.GetInt("Score");
        totalScoreText.text = a.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();

        //int a = GetScore() + amount;
        //PlayerPrefs.SetInt("Score", a);
        //totalScoreText.text = a.ToString();

    }

    int GetScore()
    {
        int a = PlayerPrefs.GetInt("Score");
        totalScoreText.text = a.ToString();
        return a;
    }

    public void CalculateAndAddToTotal(int multiplier)
    {
        int levelFinishScore = score * multiplier + GetScore();
        PlayerPrefs.SetInt("Score", levelFinishScore);
        totalScoreText.text = levelFinishScore.ToString();
    }
}
