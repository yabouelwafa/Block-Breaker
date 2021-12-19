using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField]int breakableBlocks;
    SceneLoader SceneLoader;
    [SerializeField] public int amountOfBalls;

    private void Start()
    {
        SceneLoader = FindObjectOfType<SceneLoader>();
    }


    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void CountBalls()
    {
        amountOfBalls++;
    }


        public void blockBroken()
    {
        breakableBlocks = breakableBlocks - 1;

        if (breakableBlocks<= 0)
        {
            SceneLoader.LoadNextScene();
        }
    }   





}
