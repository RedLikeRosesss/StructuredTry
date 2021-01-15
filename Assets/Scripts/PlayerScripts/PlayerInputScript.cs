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

    public void SetWannaJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayerController.instance.PlayerJump.wannaJump = true;
            PlayerController.instance.PlayerJump.jumpTimer = Time.time + PlayerController.instance.PlayerJump.jumpDelay;
        }
    }

    public void SetWannaDash()
    {
        if (Time.time >= PlayerController.instance.PlayerDash.nextDashTime)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                PlayerController.instance.PlayerDash.DashPreparation();
            }
        }
    }

    internal bool WantDown()
    {
        return Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
    }

}
