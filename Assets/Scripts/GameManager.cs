using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    public bool isGameEnd { get ; set; } = false;
    public bool isGameStart { get; set; } = false;
    public TMP_Text Txt_Score;
    public GameObject Restart_Menu;
    
    public int score = 0;
    public int total_Time = 100;

    float empty_time = 0;

    private void Update()
    {
        //Update_Time();
        //Update_Text();
        
    }
    void Update_Text()
    {
        if (isGameStart)
        {
            Txt_Score.text = "Time : " +total_Time.ToString() + "\nSCORE : " + score.ToString();
            
        }
    }
    void Update_Time()
    {
        if(isGameStart)
        {
            empty_time += Time.deltaTime;
            if (empty_time >= 1)
            {
                empty_time = 0;
                total_Time -= 1;
                if(total_Time <= 0)
                {
                    Txt_Score.text = "Time OVER " + "\nTotal SCORE : " + score.ToString();
                    isGameStart = false;
                    OnGameEnd();
                }
            }
        }
        
    }
    void OnGameEnd()
    {
        GameObject[] all_animals = GameObject.FindGameObjectsWithTag("Animal");
        for (int i = 0;i < all_animals.Length; i++)
        {
            all_animals[i].GetComponent<Animal>().Destroy_animal();
        }
        StartCoroutine(OpenRestartMenu());
    }
    IEnumerator OpenRestartMenu()
    {
        total_Time = 100;
        score = 0;
        yield return new WaitForSeconds(3f);
        Restart_Menu.SetActive(true);
    }

    public void MoveScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
}
