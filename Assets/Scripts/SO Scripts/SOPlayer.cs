using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayer : ScriptableObject
{
    [Header("PlayerFisica")]    
    public Vector2 velocity;
    public float speed;
    public float speedRun;
    public float _currentSpeed;
    public float forcejump;

    [Header("PlayerAnimation")]
    public string animationTrigger = "Walk";
    public string animationJump = "Jump";
    

    [Header("PlayerGun")]
    public Bullet prefabBullet;
    public float timeShoot = .2f;
    private Coroutine _currentCoroutine;
}
