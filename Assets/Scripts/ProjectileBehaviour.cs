using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField]
    private LayerMask layersToCooperate;

    [SerializeField]
    private List<string> tagsToCooperate;

    private void Start()
    {
        layersToCooperate = LayerMask.GetMask("Ground", "SlideGround", "SandGround", "MovingPlatform", "OneWayPlatform", "Enemy");
        tagsToCooperate.Add("BaseGround");
        tagsToCooperate.Add("SlideGround");
        tagsToCooperate.Add("SandGround");
        tagsToCooperate.Add("MovingPlatform");
        tagsToCooperate.Add("OneWayPlatform");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
    }

    //easy way to check collisions for projectile
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        Destroy(gameObject);
    }*/
}
