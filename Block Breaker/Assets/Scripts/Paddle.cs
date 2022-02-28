/*
 *  Paddle
 *  Handling the paddle functionality
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Config params
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // Cached refrences
    GameSession theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(Mathf.Clamp(GetXPos(), minX, maxX), transform.position.y);
        transform.position = paddlePos;
    }

    // return the new x pos of the paddle
    private float GetXPos()
    {
        // if auto play is on return the ball x pos - make the paddle follow the ball
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        // else - return the mouse x pos - make the paddle move acordding to the user input 
        else
        {
            return (Input.mousePosition.x / Screen.width * screenWidthInUnits);
        }
    }
}
