using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetection : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    internal string groundTag;
    [SerializeField]
    private float lossyScaleChange = 0.02f;    
    private float detectionOffsetLeft = -0.5f;    
    private float detectionOffsetRight = 0.5f;    
    private float detectionOffsetMiddle = 0f;

    private void Start()
    { 
        groundLayer = LayerMask.GetMask("Ground", "SlideGround", "SandGround", "MovingPlatform", "OneWayPlatform");
    }

    public bool isGrounded()
    {
        RaycastHit2D raycastHitLeft = GetRaycastHit(detectionOffsetLeft);
        RaycastHit2D raycastHitRight = GetRaycastHit(detectionOffsetRight);
        return (raycastHitLeft.collider != null) || (raycastHitRight.collider != null);
    }

    public void DetectTypeOfGround()
    {
        RaycastHit2D raycastHit = GetRaycastHit(detectionOffsetMiddle);
        if (raycastHit.collider != null)
        {
            groundTag = raycastHit.collider.tag;
        }
    }

    private RaycastHit2D GetRaycastHit(float detectionOffset)
    {
        return Physics2D.Raycast(new Vector2(transform.position.x + detectionOffset, transform.position.y + 0.02f - transform.lossyScale.x / 2),
            Vector2.down,
            0.05f,
            groundLayer);
    }
}
