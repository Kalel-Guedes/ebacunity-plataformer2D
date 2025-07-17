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
    public ParticleSystem particles;
    public ParticleSystem particlesJump;
    public AudioSource audioJump;
    public AudioSource audioGun;
    public AudioSource audioRun;


    void Update()
    {
        Jump();
        Movement();
        Audio();

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.linearVelocity = Vector2.up * player.forcejump;
            animator.SetBool(player.animationJump, true);
            if (particlesJump != null) particlesJump.Play();
            if (audioJump != null) audioJump.Play();
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
            if (particles != null) particles.Play();
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.linearVelocity = new Vector2(player._currentSpeed, myRigidbody.linearVelocity.y);
            myRigidbody.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool(player.animationTrigger, true);
            if (particles != null) particles.Play();
            
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
            if (audioGun != null) audioGun.Play();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_currentCoroutine != null) { StopCoroutine(_currentCoroutine); }
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
    private void Audio()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (audioRun != null) audioRun.Play();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (audioRun != null) audioRun.Stop();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (audioRun != null) audioRun.Play();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
             if (audioRun != null) audioRun.Stop();
        }

        
    }

    
    
     
}
