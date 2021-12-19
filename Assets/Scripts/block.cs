using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    // config paramaters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkelsVFX;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] Rigidbody2D ball;
    Ball ballClone;




    // cached refrence
    Level level;


    // state variables
    [SerializeField] int timesHit; //

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit() ;
        }

    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite Is Missing From Array");
        }
    }


    private void HandleHit()
    {
    timesHit++;   
    int maxHits = hitSprites.Length + 1;        
     if (timesHit >= maxHits)
     {
        DestroyBlock();    
        ballClone = Instantiate(ball, transform.position, transform.rotation).GetComponent<Ball>();
     }
    else
    {
        ShowNextHitSprite();
    }
    }



    private void DestroyBlock()
    {
        PlayerPrefs.SetInt("lauchBall", 0);    
       
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.blockBroken();
        TriggerSparklesVFX();
        

    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameStatus>().AddtoScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkelsVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }


}