using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public Vector2 velocity;

    public float speed;
    public float speedRun;
    public float _currentSpeed;

    public string animationTrigger = "Walk";
    public string animationJump = "Jump";
    public Animator animator;
    


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
            animator.SetBool(animationJump, true);
        }
        else
        {
           animator.SetBool(animationJump, false); 
        }
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.linearVelocity = new Vector2(-_currentSpeed, myRigidbody.linearVelocity.y);
            myRigidbody.transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool(animationTrigger, true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.linearVelocity = new Vector2(_currentSpeed, myRigidbody.linearVelocity.y);
            myRigidbody.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool(animationTrigger, true);
        }
        else
        {
           animator.SetBool(animationTrigger, false); 
        }


        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
            animator.speed = 1.5f;

        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1f;
        }
    }
}
