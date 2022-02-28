/*
 *  GameSession
 *  Handling the game session
 *  Theres only 1 game session obj (its a Singleton class) - a new game session obj will be create only 
 *  when starting the game or reseting it (reseting the game destroy the curr game session)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // config params
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 85;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // state variables
    [SerializeField] int currentScore = 0;

    // on awake check if this game obj is the only 1 of his type(Singleton GameStatus - there can be only 1)
    private void Awake()
    {
        // get the number of GameStatus objects
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        // if theres already other game status obj destroy yourself
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        // else - dont destroy yourself on the next scene
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    // Start is called before the first frame update
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    // add pointsPerBlockDestroyed to our curr score
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    // Reset the game
    public void ResetGame()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    // return the status of auto play
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

}
