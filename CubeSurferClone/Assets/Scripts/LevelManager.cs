using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> allLevels = new List<Level>();
    public List<Level> previousLevels = new List<Level>();

    public Vector3 spawnPos = new Vector3(0, 0, 0);

    private static LevelManager _instance;
    public static LevelManager instance
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
        //PlayerPrefs.SetInt("CurrentLevel", 0);
        LoadLevel(GetCurrentLevel());
    }

    public void LoadLevel(int levelNumber)
    {
        //clampten dolayi son level bittiginde basa donecek
        Level level = allLevels[Mathf.Clamp(levelNumber, 0, allLevels.Count - 1)];

        if (level == null)
        {
            Debug.Log("No level found");
            return;
        }

        foreach (Level go in previousLevels)
        {
            Destroy(go);
        }

        Instantiate(allLevels[levelNumber].levelPrefab, spawnPos, transform.rotation);
        previousLevels.Add(level);
    }

    public int GetCurrentLevel()
    {
        int a = PlayerPrefs.GetInt("CurrentLevel", 0);
        return a;
    }
    public void IncreaseCurrentLevel()
    {
        int a = GetCurrentLevel() + 1;

        if (a > 2)
        {
            a = 0;
        }

        PlayerPrefs.SetInt("CurrentLevel", a);
    }
}
