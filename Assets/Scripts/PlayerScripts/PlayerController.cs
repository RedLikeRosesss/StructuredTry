using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField]
    internal PlayerInputScript PlayerInputScript;
    [SerializeField]
    internal MovementController MoveControl;
    [SerializeField]
    internal PlayerJump PlayerJump;
    [SerializeField]
    internal PlayerGroundDetection PlayerGroundDetection;
    [SerializeField]
    internal ModifyPlayerPhysics ModifyPlayerPhysics;
    [SerializeField]
    internal PlayerAnimationContollerScript PlayerAnimationContollerScript;
    [SerializeField]
    internal PlayerDash PlayerDash;
    [SerializeField]
    internal PlayerCollecting PlayerCollecting;

    [Header("Components")]
    internal Rigidbody2D rb;
    internal BoxCollider2D bc;

    [Header("TheRest")]
    public static PlayerController instance;
    public Vector2 check;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        MoveControl = gameObject.GetComponent<MovementController>();
        PlayerInputScript = gameObject.GetComponent<PlayerInputScript>();
        PlayerJump = gameObject.GetComponent<PlayerJump>();
        PlayerGroundDetection = gameObject.GetComponent<PlayerGroundDetection>();
        ModifyPlayerPhysics = gameObject.GetComponent<ModifyPlayerPhysics>();
        PlayerAnimationContollerScript = gameObject.GetComponent<PlayerAnimationContollerScript>();
        PlayerDash = gameObject.GetComponent<PlayerDash>();
        PlayerCollecting = gameObject.GetComponent<PlayerCollecting>();
    }

    void Update()
    {
        PlayerInputScript.SetWannaJump();
        PlayerInputScript.SetWannaDash();
        PlayerAnimationContollerScript.ChangeAnimation();
        check = new Vector2(rb.velocity.x, rb.velocity.y);
    }

    private void FixedUpdate()
    {
        PlayerGroundDetection.isGrounded();
        PlayerGroundDetection.DetectTypeOfGround();
        ModifyPlayerPhysics.ModifyPh();
        MoveControl.PlayerMove(PlayerInputScript.GetHorizontalInput());
        PlayerJump.SetJumpsCounter();
        PlayerJump.Jump();
        PlayerDash.Dash();
    }
}
