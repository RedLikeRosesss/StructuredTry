using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallDetection : AbstractPlayerGroundWallDetection
{
    private float multiplier = 2;

    private void Start()
    {
        bc2d = PlayerController.Instance.bc;

        boxHeight = bc2d.size.y * multiplier - 0.12f;
        boxWidth = bc2d.size.x * multiplier + 0.15f;
        boxSize = new Vector2(boxWidth, boxHeight);

        distanceToDraw = 0.0f;
        isTouching = false;
        surfaceLayer = LayerMask.GetMask("Ground", "SlideGround", "SandGround", "MovingPlatform", "OneWayPlatform");
    }

    public override void CalculateBoxPosition()
    {
        float xPosition = bc2d.transform.position.x + bc2d.offset.x;
        float yPosition = bc2d.transform.position.y + bc2d.offset.y * multiplier;
        boxOriginPosition = new Vector2(xPosition, yPosition);
    }
}
