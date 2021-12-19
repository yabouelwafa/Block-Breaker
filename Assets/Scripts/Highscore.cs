using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Highscore : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI highScoreText;

    private void Start()
    {
        AddHighScore();
        highScoreText.text =  PlayerPrefs.GetInt("highScore").ToString();

    } 

    
    
    public void AddHighScore()
    {
        if (FindObjectOfType<GameStatus>().currentScore > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", FindObjectOfType<GameStatus>().currentScore);
        }
    
    }
}   




























































