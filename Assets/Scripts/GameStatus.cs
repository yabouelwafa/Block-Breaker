using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

    


public class GameStatus : MonoBehaviour
{

    [Range(0.1f , 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockdestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
   

    


    // state variables 
    [SerializeField] public int currentScore = 0;


    private void Awake()
    {       
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddtoScore()
    {
        currentScore = currentScore + pointsPerBlockdestroyed;
        scoreText.text = currentScore.ToString();

    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }



}
