using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public GameObject gameOverText;
    public GameObject gameOverPanel;
    public GameObject startUi;
    public Text highScoreText;
    public Text scoreText;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreManager.scoreManagerInstance.getScore().ToString();
    }

    public void GameStart()
    {
        startUi.SetActive(false);
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        highScoreText.text = "HIGH SCORE : " + PlayerPrefs.GetInt("HighScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
