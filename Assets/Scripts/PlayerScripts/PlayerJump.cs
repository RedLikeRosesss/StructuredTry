using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private int jumpsCounterValue = 2;
    [SerializeField]
    internal int jumpsCounter = 0;
    [SerializeField]
    internal bool wannaJump;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float standartJumpForce = 8;
    [SerializeField]
    private float fromSandJumpForce = 3;

    [SerializeField]
    internal float jumpTimer;
    [SerializeField]
    internal float jumpDelay = 0.25f;

    void Start()
    {
        wannaJump = false;
    }

    public void Jump()
    {
        if (wannaJump == true)
        {            
            CanPlayerJump();
        }
    }

    private bool PlayerFalls()
    {
        return jumpsCounter == 2 
                && PlayerController.Instance.PlayerGroundDetection.IsTouchingSurface() == false 
                && PlayerController.Instance.PlayerWallDetection.IsTouchingSurface() == false;
    }

    private void CanPlayerJump()
    {
        if (PlayerFalls() == false)
        {
            JumpWithDelay();
        }
    }

    private void JumpWithDelay()
    {
        if (jumpTimer > Time.time && jumpsCounter > 0)
        {
            if(PlayerController.Instance.PlayerWallDetection.IsTouchingSurface() == true
                     && PlayerController.Instance.PlayerGroundDetection.IsTouchingSurface() == false)
            {
                JumpFromWall();
            } 
            else
            {
                JumpFromGround();
            }
        }
        else if (jumpTimer < Time.time)
        {
            wannaJump = false;
        }
    }

    private void JumpFromGround()
    {        
        if (jumpsCounter == jumpsCounterValue)
        {
            SetJumpForce();
            PlayerController.Instance.PlayerAnimationContollerScript.SingleJumpAnimation();
        }
        else if (jumpsCounter > 0 && jumpsCounter < jumpsCounterValue)
        {
            SetJumpForce();
            PlayerController.Instance.PlayerAnimationContollerScript.DoubleJumpAnimation();
        }
        PlayerController.Instance.rb.gravityScale = 1;
        PlayerController.Instance.rb.velocity = new Vector2(PlayerController.Instance.rb.velocity.x, 0);
        PlayerController.Instance.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpsCounter--;
        wannaJump = false;
    }

    private void JumpFromWall()
    {
        if (jumpsCounter == 1)
        {
            SetJumpForce();
            PlayerController.Instance.PlayerAnimationContollerScript.SingleJumpAnimation();
        }
        PlayerController.Instance.rb.gravityScale = 1;
        PlayerController.Instance.rb.velocity = new Vector2(PlayerController.Instance.rb.velocity.x, 0);
        PlayerController.Instance.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpsCounter--;
        wannaJump = false;
    }

    public void SetJumpsCounter()
    {
        if (PlayerController.Instance.PlayerGroundDetection.IsTouchingSurface() == true)
        {
            jumpsCounter = jumpsCounterValue;
        }
        else if (PlayerController.Instance.PlayerWallDetection.IsTouchingSurface() == true)
        {
            jumpsCounter = 1;
        }
    }

    void SetJumpForce()
    {
        if (PlayerController.Instance.PlayerGroundDetection.surfaceTag == "SandGround")
        {
            jumpForce = fromSandJumpForce;
        }
        else
        {
            jumpForce = standartJumpForce;
        }
    }
}
