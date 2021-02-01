using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetection : MonoBehaviour   //ChangeName
{
    [SerializeField]
    private bool onGround;  //delete in the future
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    internal string groundTag;
    [SerializeField]
    private float boxHeight;
    [SerializeField]
    private float distanceToDraw;
    [SerializeField]
    private Vector2 groundBoxSize;
    [SerializeField]
    private Vector2 groundBoxOriginPosition;

    private void Start()
    {
        boxHeight = 0.12f;
        groundBoxSize = new Vector2(transform.lossyScale.x / 2, boxHeight);        
        distanceToDraw = 0.0f;
        onGround = false;
        groundLayer = LayerMask.GetMask("Ground", "SlideGround", "SandGround", "MovingPlatform", "OneWayPlatform");
    }

    public bool IsGrounded()
    {
        groundBoxOriginPosition = new Vector2(transform.position.x, transform.position.y - transform.lossyScale.y / 2);

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
        return Physics2D.BoxCast(groundBoxOriginPosition, groundBoxSize, 0f, Vector2.down, distanceToDraw, groundLayer);
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - transform.lossyScale.y / 2),
            new Vector2(gameObject.transform.lossyScale.x / 2, 0.12f));
    }*/
}
