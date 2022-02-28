/*
 *  SceneLoader
 *  Handling the scene loader functionality
 *  The scene loader is responsible to load the scenes (the next level, game over, etc..)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // load the next scene
    public void LoadNextScene()
    {
        int currentScenceIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScenceIndex + 1);   
    }

    // load the start scene
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    // load the start scene
    public void QuitGame()
    {
        Application.Quit();
    }

}
