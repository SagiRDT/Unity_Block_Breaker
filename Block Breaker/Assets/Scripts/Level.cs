/*
 *  Level
 *  Handling the level data (blocks number, etc)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // config params
    [SerializeField] int breakableBlocks;   // Serialize for debugging

    // Cached refrences
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // inc the breakable blocks mone by 1
    public void CountBlocks()
    {
        breakableBlocks++;
    }

    // dec the breakable blocks mone by 1
    public void DecBreakableBlocks()
    {
        breakableBlocks--;

        // if all the blocks are gone - load the next level
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

}

