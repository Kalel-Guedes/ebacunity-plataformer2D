using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public Vector2 velocity;

    public float speed;
    public float speedRun;
    public float _currentSpeed;


    public float forcejump;

    void Update()
    {
        Jump();
        Movement();       

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.linearVelocity = Vector2.up * forcejump;
        }
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.linearVelocity = new Vector2(-_currentSpeed, myRigidbody.linearVelocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.linearVelocity = new Vector2(_currentSpeed, myRigidbody.linearVelocity.y);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }
    }
}
