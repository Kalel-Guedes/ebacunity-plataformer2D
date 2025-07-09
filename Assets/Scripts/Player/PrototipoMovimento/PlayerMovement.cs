using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*
    public Vector2 velocity;
    public float speed;
    public float speedRun;
    public float _currentSpeed;
    public float forcejump;
    public string animationTrigger = "Walk";
    public string animationJump = "Jump";    
    public Bullet prefabBullet;
    public float timeShoot = .2f;
    */
    public SOPlayer player;
    private Coroutine _currentCoroutine;
    public Rigidbody2D myRigidbody;    
    public Transform shootPoint;
    public Transform sideReference;
    public Animator animator;

    void Update()
    {
        Jump();
        Movement();

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.linearVelocity = Vector2.up * player.forcejump;
            animator.SetBool(player.animationJump, true);
        }
        else
        {
            animator.SetBool(player.animationJump, false);
        }
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.linearVelocity = new Vector2(-player._currentSpeed, myRigidbody.linearVelocity.y);
            myRigidbody.transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool(player.animationTrigger, true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.linearVelocity = new Vector2(player._currentSpeed, myRigidbody.linearVelocity.y);
            myRigidbody.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool(player.animationTrigger, true);
        }
        else
        {
            animator.SetBool(player.animationTrigger, false);
        }


        if (Input.GetKey(KeyCode.LeftControl))
        {
            player._currentSpeed = player.speedRun;
            animator.speed = 1.5f;

        }
        else
        {
            player._currentSpeed = player.speed;
            animator.speed = 1f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if(_currentCoroutine != null){ StopCoroutine(_currentCoroutine); }
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Spawnitem();
            yield return new WaitForSeconds(player.timeShoot);
        }
    }

    private void Spawnitem()
    {

        var obj = Instantiate(player.prefabBullet);
        obj.transform.position = shootPoint.transform.position;
        obj.side = sideReference.transform.localScale.x;

        //obj.transform.SetParent(null);
        //obj.GetComponent<Rigidbody>().AddForce(Force);

    }
    
     
}
