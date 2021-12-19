using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] public float yPush = 15f;
    [SerializeField] public float xPush = 2f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;


    

    Vector2 paddleToBallVector;
      public bool hasStarted = false;


        // cashed

        AudioSource myAudioSource;
        Rigidbody2D myRigidBody2D;
        Level level;




    // Start is called before the first frame update
    void Start()
    { 
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        

        level = FindObjectOfType<Level>();
        level.CountBalls();
        

    }

    // Update is called once per frame
    void Update()
    {


              
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnClick(); 
        }    
                     

    }

    public void LaunchOnClick()
    {
       if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2 (xPush, yPush);
            hasStarted = true;
        }
    }

    public void LaunchBallSpawn()
    {
         myRigidBody2D.velocity = new Vector2 (xPush, yPush);
         PlayerPrefs.SetInt("lauchBall", 1);
    }

    
      
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    { 
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if(hasStarted)
        {
        AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
        myAudioSource.PlayOneShot(clip);
        myRigidBody2D.velocity += velocityTweak;
        }
    }
}
