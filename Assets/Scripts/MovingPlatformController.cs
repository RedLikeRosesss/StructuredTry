using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    [SerializeField]
    public Transform startPosition;
    [SerializeField]
    private float startPos;
    [SerializeField]
    private float nextPos;
    [SerializeField]
    public float speed;
    [SerializeField]
    private float leftEdge;
    [SerializeField]
    private float rightEdge;
    [SerializeField]
    public float movingRange;

    void Start()
    {
        startPos = GetComponent<Transform>().position.x;
        movingRange = 4;
        leftEdge = startPos - movingRange;
        rightEdge = startPos + movingRange;
        speed = 2;        
    }

    void FixedUpdate()
    {
        ChooseDirection();
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(nextPos, transform.position.y, transform.position.z), speed * Time.deltaTime);
    }

    private void ChooseDirection()
    {
        if (transform.position.x <= leftEdge)
        {
            nextPos = rightEdge;
        }
        else if (transform.position.x >= rightEdge)
        {
            nextPos = leftEdge;
        }
    }
}
