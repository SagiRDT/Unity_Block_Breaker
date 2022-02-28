/*
 *  Block
 *  Handling the blocks functionality
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached refrences
    Level level;

    // State variables
    [SerializeField] int timesHit = 0;     // only serialize for debugging purposes

    // Start is called before the first frame update
    void Start()
    {
        CountBreakableBlocks();
    }

    // Counts the breakable blocks in the level
    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable") level.CountBlocks();
    }

    // Handle the block collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    // Handle a hit on the block
    // if the block was hit the max hits it can take - destroy it, else switch its sprite to the next sprite
    private void HandleHit()
    {
        int maxHits = hitSprites.Length + 1;
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    // switch the sprite of the block
    private void ShowNextHitSprite()
    {
        // initing the index of the sprite we want to show
        int spriteIndex = timesHit - 1;

        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array - " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        // play sound of a block collision
        PlayBlockDestroySFX();

        // destroy the block and dec the block number by 1
        Destroy(gameObject);
        level.DecBreakableBlocks();
        
        // shows a sprkles effect
        TriggerSparklesVFX();

        // inc the score after a block is destroyed
        FindObjectOfType<GameSession>().AddToScore();
    }

    // shows a sprkles effect
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

    // play sound of a block collision
    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }
}
