using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeedOnBaseGround = 10.0f;
    [SerializeField]
    private float moveSpeedOnSlideGround = 7.0f;
    [SerializeField]
    private float moveSpeedOnSandGround = 2.0f;
    [SerializeField]
    private float maxSpeedForwardLook = 10.0f;
    [SerializeField]
    private float maxSpeedBackLook = 5.0f;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Collider2D tempCollider;

    public void PlayerMove(Vector2 direction)
    {
        MovementOnDifferentGround(direction);
        MaxSpeedLimitConditions();
    }

    private void MovementOnDifferentGround(Vector2 direction)
    {
        if (PlayerController.Instance.PlayerGroundDetection.surfaceTag == "BaseGround")
        {
            MoveCharacterOnBaseGround(direction);
        }
        else if (PlayerController.Instance.PlayerGroundDetection.surfaceTag == "SlideGround")
        {
            MoveCharacterOnSlideGround();
        }
        else if (PlayerController.Instance.PlayerGroundDetection.surfaceTag == "SandGround")
        {
            MoveCharacterOnSandGround(direction);
        }
        else
        {
            MoveCharacterOnBaseGround(direction);
        }
    }

    private void MaxSpeedLimitConditions()
    {
        if ((PlayerController.Instance.rb.velocity.x > 0 && PlayerController.Instance.PlayerAnimationContollerScript.facingRight) ||
            (PlayerController.Instance.rb.velocity.x < 0 && !PlayerController.Instance.PlayerAnimationContollerScript.facingRight))
        {
            MaxSpeedLimitation(maxSpeedForwardLook);
        }
        else if ((PlayerController.Instance.rb.velocity.x > 0 && !PlayerController.Instance.PlayerAnimationContollerScript.facingRight) ||
            (PlayerController.Instance.rb.velocity.x < 0 && PlayerController.Instance.PlayerAnimationContollerScript.facingRight))
        {
            MaxSpeedLimitation(maxSpeedBackLook);
        }
    }

    private void MaxSpeedLimitation(float speedLimit) 
    {
        if (Mathf.Abs(PlayerController.Instance.rb.velocity.x) > speedLimit)
        {
            PlayerController.Instance.rb.velocity = new Vector2(Mathf.Sign(PlayerController.Instance.rb.velocity.x) * speedLimit, PlayerController.Instance.rb.velocity.y);
        }
    }

    void MoveCharacterOnBaseGround(Vector2 direction)
    {
        PlayerController.Instance.rb.velocity = new Vector2(direction.x * moveSpeedOnBaseGround, 
            PlayerController.Instance.rb.velocity.y);
    }

    void MoveCharacterOnSlideGround()
    {
        PlayerController.Instance.rb.AddForce(Vector2.right * PlayerController.Instance.PlayerInputScript.direction.x * moveSpeedOnSlideGround);
    }

    void MoveCharacterOnSandGround(Vector2 direction)
    {
        PlayerController.Instance.rb.velocity = new Vector2(direction.x * moveSpeedOnSandGround,
            PlayerController.Instance.rb.velocity.y);
    }

    #region CollisionForMovingPlatformAndOneWayPlatform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            player.transform.parent = collision.transform;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            if (PlayerController.Instance.PlayerInputScript.WantDown())
            {
                tempCollider = collision.collider;
                StartCoroutine(FallTimer());
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            player.transform.parent = null;
        }
    }
    #endregion

    IEnumerator FallTimer()
    {
        Physics2D.IgnoreCollision(tempCollider, PlayerController.Instance.bc, true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(tempCollider, PlayerController.Instance.bc, false);
    }
}
