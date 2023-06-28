using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {

            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public bool isGameEnd = false;
    
    
    public int score = 0;
    public int total_Time = 100;

    float empty_time = 0;

    private void Update()
    {
        Update_Time();
    }
    void Update_Time()
    {
        empty_time += Time.deltaTime;
        if(empty_time >= 1 && !isGameEnd)
        {
            empty_time = 0;
            total_Time -= 1;
            if(total_Time <= 0)
            {
                GameOver();
            }
        }
    }

    public void Add_Score(int score)
    {
        this.score += score;
    }
    void GameOver()
    {
        isGameEnd = true;
    }
}
