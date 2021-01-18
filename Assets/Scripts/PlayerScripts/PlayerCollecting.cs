using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollecting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            //Debug.Log("Collision");
            PoolManager.Instance.AddProjectile(collision.gameObject);
        }
    }
}
