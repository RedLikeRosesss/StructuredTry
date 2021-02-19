
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationContollerScript : MonoBehaviour
{
    private Animator animator;
    public bool facingRight;
    [SerializeField]
    private ParticleSystem rightDashParticles;
    [SerializeField]
    private ParticleSystem leftDashParticles;
    [SerializeField]
    private ParticleSystem rightDashTrack;
    [SerializeField]
    private ParticleSystem leftDashTrack;

    private void Start()
    {
        facingRight = true;
        animator = gameObject.GetComponent<Animator>();
    }

    public void ChangeAnimation()
    {
        DoPlayerNeedFlip();
        OnGroundAnimation();
        FallAnimation();
        HorizontalAxisTrack();
    }

    private void DoPlayerNeedFlip()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                transform.position.z));

        Vector3 difference = mousePosition - transform.position;

        if ( (difference.x >= 0 && !facingRight) || (difference.x < 0 && facingRight) ) 
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }

    internal void DoubleJumpAnimation()
    {
        animator.SetBool("isSingleJump", false);
        animator.SetBool("isDoubleJump", true);
        animator.SetBool("isFall", false);
    }

    internal void SingleJumpAnimation()
    {
        animator.SetBool("isSingleJump", true);
        animator.SetBool("isFall", false);
    }

    internal void FallAnimation()
    {
        if (PlayerController.Instance.rb.velocity.y < -0.1f)
        {
            animator.SetBool("isSingleJump", false);
            animator.SetBool("isFall", true);
        }
    }

    internal void OnGroundAnimation()
    {
        if (PlayerController.Instance.PlayerGroundDetection.IsTouchingSurface())
        {
            animator.SetBool("isFall", false);
            animator.SetBool("isGrounded", true);
            animator.SetBool("isSingleJump", false);
            animator.SetBool("isDoubleJump", false);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }
    }

    internal void HorizontalAxisTrack()
    {
        animator.SetFloat("horizontal", Mathf.Abs(PlayerController.Instance.rb.velocity.x));
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

    internal void CreateDashTrack()
    {
        if (PlayerController.Instance.rb.velocity.x > 0)
        {
            rightDashTrack.Play();
            rightDashParticles.Play();            
        }
        else if (PlayerController.Instance.rb.velocity.x < 0)
        {
            leftDashTrack.Play();
            leftDashParticles.Play();            
        }
    }
}
