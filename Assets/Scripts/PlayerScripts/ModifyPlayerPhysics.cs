using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyPlayerPhysics : MonoBehaviour
{
    [Header("Jumping")]
    [SerializeField]
    private float fallMultiplier = 3.5f;
    [SerializeField]
    private float lowJumpMultiplier = 3f;

    [Header("GravityScales")]
    [SerializeField]
    private float normalGravityScale = 2f;
    [SerializeField]
    private float dashGravityScale = 0f;

    [Header("WindZone")]
    [SerializeField]
    private float windMagnitudeOnTheGround = 300f;
    [SerializeField]
    private float windMagnitudeInTheAir = 600f;
    [SerializeField]
    private float windChangeDelay = 0.4f;
    [SerializeField]
    private float windChangeTime = 0f;
    [SerializeField]
    private float TowardsTheWindDashPower = 2f;
    [SerializeField]
    private float standartDashPower = 4f;

    internal void ModifyPh()
    {
        if (PlayerController.Instance.PlayerGroundDetection.IsTouchingSurface())
        {
            PlayerController.Instance.rb.gravityScale = normalGravityScale;
        }
        else
        {
            ChangeGravityScale();
        }
    }

    private void ChangeGravityScale()
    {
        if (PlayerController.Instance.PlayerDash.wannaDash && Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            PlayerController.Instance.rb.gravityScale = dashGravityScale;
        }
        else if (PlayerController.Instance.rb.velocity.y < 0)
        {
            PlayerController.Instance.rb.gravityScale = fallMultiplier;
        }
        else if (PlayerController.Instance.rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            PlayerController.Instance.rb.gravityScale = lowJumpMultiplier;
        }
        else
        {
            PlayerController.Instance.rb.gravityScale = normalGravityScale;
        }
    }

    #region OnTrigger...ForWindZone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WindZone"))
        {
            windChangeTime = Time.time + windChangeDelay;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("WindZone"))
        {
            AreaEffector2D windZone = collision.GetComponent<AreaEffector2D>();
            if (windZone != null)
            {
                PlayerController.Instance.PlayerDash.dashPower = TowardsTheWindDashPower;
                if (PlayerController.Instance.PlayerGroundDetection.IsTouchingSurface() == true)
                {
                    windZone.forceMagnitude = windMagnitudeOnTheGround;
                }
                else
                {
                    if (Time.time >= windChangeTime)
                    {
                        windZone.forceMagnitude = windMagnitudeInTheAir;
                        windChangeTime = 0;
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WindZone"))
        {
            AreaEffector2D windZone = collision.GetComponent<AreaEffector2D>();
            if (windZone != null)
            {
                PlayerController.Instance.PlayerDash.dashPower = standartDashPower;
                windZone.forceMagnitude = windMagnitudeOnTheGround;
            }
        }
    }
    #endregion
}
