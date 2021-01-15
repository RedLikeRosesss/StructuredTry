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
            WhenToJump();
        }
    }

    private void WhenToJump()
    {
        if (jumpsCounter == 2 && PlayerController.instance.PlayerGroundDetection.isGrounded() == false)
        {

        }
        else
        { 
            JumpWithDelay();
        }
    }

    private void JumpWithDelay()
    {
        if (jumpTimer > Time.time && jumpsCounter == 0 && PlayerController.instance.PlayerGroundDetection.isGrounded() == true)
        {
            jumpsCounter = jumpsCounterValue;
            JumpAction();
        }
        else if (jumpTimer > Time.time && jumpsCounter > 0)
        {
            JumpAction();
        }
        else if (jumpTimer < Time.time)
        {
            wannaJump = false;
        }
    }

    private void JumpAction()
    {        
        if (jumpsCounter == jumpsCounterValue)
        {
            SetJumpForce();
            PlayerController.instance.PlayerAnimationContollerScript.SingleJumpAnimation();
        }
        else if (jumpsCounter > 0 && jumpsCounter < jumpsCounterValue)
        {
            SetJumpForce();
            PlayerController.instance.PlayerAnimationContollerScript.DoubleJumpAnimation();
        }
        PlayerController.instance.rb.gravityScale = 1;
        PlayerController.instance.rb.velocity = new Vector2(PlayerController.instance.rb.velocity.x, 0);
        PlayerController.instance.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpsCounter--;
        wannaJump = false;
    }

    public void SetJumpsCounter()
    {
        if (PlayerController.instance.PlayerGroundDetection.isGrounded() == true)
        {
            jumpsCounter = jumpsCounterValue;
        }
    }

    void SetJumpForce()
    {
        if (PlayerController.instance.PlayerGroundDetection.groundTag == "SandGround")
        {
            jumpForce = fromSandJumpForce;
        }
        else
        {
            jumpForce = standartJumpForce;
        }
    }
}
