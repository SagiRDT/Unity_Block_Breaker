/*
 *  Ball
 *  Handling the ball functionality
*/

using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float launchVelocityX = 2f;
    [SerializeField] float launchVelocityY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    // State variables
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    // Locking the ball to the paddle before the player lunch it
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    // Lunch the ball on mouse click (LMB)
    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(launchVelocityX, launchVelocityY);
            hasStarted = true;
        }
    }

    // Handling the ball collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            // playing a ball collision sound
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);

            // making sure the ball wont get "stucked" in a loop of bouncing between the walls
            Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
