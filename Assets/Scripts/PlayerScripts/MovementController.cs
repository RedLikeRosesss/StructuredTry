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
    private float maxSpeed = 10.0f;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Collider2D tempCollider;

    public void PlayerMove(Vector2 direction)
    {
        if (PlayerController.instance.PlayerGroundDetection.groundTag == "BaseGround")
        {
            MoveCharacterOnBaseGround(direction);
        }
        else if (PlayerController.instance.PlayerGroundDetection.groundTag == "SlideGround")
        {
            MoveCharacterOnSlideGround(direction);
        }
        else if (PlayerController.instance.PlayerGroundDetection.groundTag == "SandGround")
        {
            MoveCharacterOnSandGround(direction);
        }
        else
        {
            MoveCharacterOnBaseGround(direction);
        }

        if (Mathf.Abs(PlayerController.instance.rb.velocity.x) > maxSpeed)
        {
            PlayerController.instance.rb.velocity = new Vector2(Mathf.Sign(PlayerController.instance.rb.velocity.x) * maxSpeed, PlayerController.instance.rb.velocity.y);
        }
    }

    void MoveCharacterOnBaseGround(Vector2 direction)
    {
        PlayerController.instance.rb.velocity = new Vector2(direction.x * moveSpeedOnBaseGround, 
            PlayerController.instance.rb.velocity.y);
    }

    void MoveCharacterOnSlideGround(Vector2 direction)
    {
        PlayerController.instance.rb.AddForce(Vector2.right * PlayerController.instance.PlayerInputScript.direction.x * moveSpeedOnSlideGround);
    }

    void MoveCharacterOnSandGround(Vector2 direction)
    {
        PlayerController.instance.rb.velocity = new Vector2(direction.x * moveSpeedOnSandGround,
            PlayerController.instance.rb.velocity.y);
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
            if (PlayerController.instance.PlayerInputScript.WantDown())
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
        Physics2D.IgnoreCollision(tempCollider, PlayerController.instance.bc, true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(tempCollider, PlayerController.instance.bc, false);
    }
}
