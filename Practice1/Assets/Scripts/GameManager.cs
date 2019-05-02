using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public static GameManager instance;
    public int currentLevel = 1;
    public int hightestLevel = 2;

    private HudManager hudManager;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        hudManager = FindObjectOfType<HudManager>();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;

        if (score > highScore)
        {
            highScore = score;
        }

        if (hudManager != null)
            hudManager.ResetHud();
        else
        {
            hudManager = FindObjectOfType<HudManager>();
            hudManager.ResetHud();
        }
    }

    public void ResetGame()
    {
        score = 0;
        currentLevel = 1;

        if (hudManager != null)
            hudManager.ResetHud();
        else
        {
            hudManager = FindObjectOfType<HudManager>();
            hudManager.ResetHud();
        }
            

        SceneManager.LoadScene("Level1");
    }

    public void NextLevel()
    {
        
        if(hightestLevel > currentLevel)
        {
            currentLevel++;
            SceneManager.LoadScene("Level" + currentLevel);
        }
        else
        {
            ResetGame();
        }
        
    }
}
