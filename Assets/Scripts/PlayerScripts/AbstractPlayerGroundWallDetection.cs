using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayerGroundWallDetection : MonoBehaviour
{
    [SerializeField]
    internal bool isTouching;  //delete in the future
    [SerializeField]
    internal LayerMask surfaceLayer;
    [SerializeField]
    internal string surfaceTag;

    [SerializeField]
    internal BoxCollider2D bc2d;

    [SerializeField]
    internal float boxHeight;
    [SerializeField]
    internal float boxWidth;
    [SerializeField]
    internal float distanceToDraw;
    [SerializeField]
    internal Vector2 boxSize;
    [SerializeField]
    internal Vector2 boxOriginPosition;

    public abstract void CalculateBoxPosition();

    public virtual bool IsTouchingSurface()
    {
        CalculateBoxPosition();
        RaycastHit2D raycastHit = GetRaycastHit();
        isTouching = raycastHit;
        return raycastHit.collider != null;
    }

    public void DetectTypeOfSurface()
    {
        RaycastHit2D raycastHit = GetRaycastHit();
        if (raycastHit.collider != null)
        {
            surfaceTag = raycastHit.collider.tag;
        }
    }

    private RaycastHit2D GetRaycastHit()
    {
        return Physics2D.BoxCast(boxOriginPosition, boxSize, 0f, Vector2.zero, distanceToDraw, surfaceLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(boxOriginPosition, boxSize);
    }
}
