using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetection : AbstractPlayerGroundWallDetection
{   
    private void Start()
    {
        bc2d = PlayerController.Instance.bc;
        boxHeight = 0.12f;
        boxWidth = bc2d.size.x * 1.7f;
        boxSize = new Vector2(boxWidth, boxHeight);        
        distanceToDraw = 0.0f;
        isTouching = false;
        surfaceLayer = LayerMask.GetMask("Ground", "SlideGround", "SandGround", "MovingPlatform", "OneWayPlatform");
    }

    public override void CalculateBoxPosition()
    {
        boxOriginPosition = new Vector2(transform.position.x, transform.position.y - transform.lossyScale.y / 2);
    }
}
