//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;

    // Besarnya gaya awal yang diberikan untuk mendorong bola
    //public float xInitialForce = 50;
    //public float yInitialForce = 15;
    public float initialForce = 50;
    public float maxYForce = 15;

    private Vector2 trajectoryOrigin;
    float maxVelocity = -1;

    // Start is called before the first frame update
    void Start()
    {
        trajectoryOrigin = transform.position;
        rigidBody2D = GetComponent<Rigidbody2D>();

        // Mulai game
        RestartGame(2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }

    void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;

        // Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }

    void RestartGame(float time)
    {
        // Kembalikan bola ke posisi semula
        ResetBall();

        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", time);
    }

    void PushBall()
    {
        
        float yRandomInitialForce = Random.Range(-maxYForce, maxYForce);
        float randomDirection = Random.Range(0, 2);


        Vector2 force;
        if (randomDirection < 1.0f)
        {
            float forceX = Mathf.Sqrt((initialForce*initialForce)-(yRandomInitialForce*yRandomInitialForce));
            force = new Vector2(-forceX, yRandomInitialForce);
        }
        else
        {
            float forceX = Mathf.Sqrt((initialForce * initialForce) - (yRandomInitialForce * yRandomInitialForce));
            force = new Vector2(forceX, yRandomInitialForce);
        }

        rigidBody2D.AddForce(force);





    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }


}
