using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    [SerializeField]
    internal bool wannaDash;
    [SerializeField]
    internal float dashTimer;
    [SerializeField]
    internal float dashDuration;
    [SerializeField]
    internal float dashRate;
    [SerializeField]
    internal float nextDashTime;
    [SerializeField]
    internal float dashPower;
    [SerializeField]
    internal float yVelocityFix = 0;

    private void Start()
    {
        wannaDash = false;
        dashDuration = 0.25f;
        dashRate = 1f;
        nextDashTime = 0f;
        dashPower = 4f;
    }

    public void Dash()
    {
        if (wannaDash)
        {
            if (dashTimer > Time.time)
            {
                PlayerController.Instance.PlayerAnimationContollerScript.CreateDashTrack();
                PlayerController.Instance.rb.velocity = new Vector2(PlayerController.Instance.rb.velocity.x * dashPower, yVelocityFix);
            }
            else
            {
                wannaDash = false;
                dashTimer = 0f;
            }
        }
    }

    internal void DashPreparation()
    {
        wannaDash = true;
        dashTimer = Time.time + dashDuration;
        nextDashTime = Time.time + 1f / dashRate;
        yVelocityFix = PlayerController.Instance.rb.velocity.y;
    }
}
