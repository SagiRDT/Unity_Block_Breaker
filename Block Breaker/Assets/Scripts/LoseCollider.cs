/*
 *  LoseCollider
 *  Handling the lose collider functionality
 *  The game is over when the lose collider trigger activates
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    // if the trigger was activaed te game is over, tell the scene manager to load game over scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Game Over");
    }
}
