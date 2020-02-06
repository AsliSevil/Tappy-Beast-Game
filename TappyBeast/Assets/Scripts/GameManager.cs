using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameOver;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOver = false;
        ScoreManager.scoreManagerInstance.StopScore();
        UiManager.instance.GameOver();
        GameObject.Find("PipeSpawner").GetComponent<PipeSpawner>().stopSpawningPipes();
    }

    public void GameStart()
    {
        UiManager.instance.GameStart();
        GameObject.Find("PipeSpawner").GetComponent<PipeSpawner>().StartSpawningPipes();
    }
}
