using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetection : MonoBehaviour
{
    [SerializeField]
    private bool onGround;  //delete in the future
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    internal string groundTag;
    [SerializeField]
    private float lossyScaleChange;
    [SerializeField]
    private float distance;
    [SerializeField]
    private Vector2 boxCastSize;

    private void Start()
    {
        lossyScaleChange = 0.1f;
        boxCastSize = new Vector2(gameObject.transform.lossyScale.x - lossyScaleChange, gameObject.transform.lossyScale.y - lossyScaleChange);
        distance = 0.1f;
        onGround = false;
        groundLayer = LayerMask.GetMask("Ground", "SlideGround", "SandGround", "MovingPlatform", "OneWayPlatform");
    }

    public bool isGrounded()
    {
        RaycastHit2D raycastHit = GetRaycastHit();
        onGround = raycastHit;
        return raycastHit.collider != null;
    }
    public void DetectTypeOfGround()
    {
        RaycastHit2D raycastHit = GetRaycastHit();
        if (raycastHit.collider != null)
        {
            groundTag = raycastHit.collider.tag;
        }
    }
    private RaycastHit2D GetRaycastHit()
    {
        return Physics2D.BoxCast(gameObject.transform.position,
            boxCastSize,
            0f,
            Vector2.down,
            distance,
            groundLayer);
    }    
}
