using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBarrier : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Level>().amountOfBalls = FindObjectOfType<Level>().amountOfBalls - 1;
        int numberOfBalls = FindObjectOfType<Level>().amountOfBalls + 1;
        if (numberOfBalls == 1)
        {
        SceneManager.LoadScene("Game Over");
        }
    }

}
