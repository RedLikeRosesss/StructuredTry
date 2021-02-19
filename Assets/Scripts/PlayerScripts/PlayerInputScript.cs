using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    [SerializeField]
    internal Vector2 direction;

    public Vector2 GetHorizontalInput()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return direction;
    }

    public void JumpPreparation()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayerController.Instance.PlayerJump.wannaJump = true;
            PlayerController.Instance.PlayerJump.jumpTimer = Time.time + PlayerController.Instance.PlayerJump.jumpDelay;
        }
    }

    public void DashPeparation()
    {
        if (Time.time >= PlayerController.Instance.PlayerDash.nextDashTime)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                PlayerController.Instance.PlayerDash.DashPreparation();
            }
        }
    }

    internal bool WantDown()
    {
        return Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
    }
}
