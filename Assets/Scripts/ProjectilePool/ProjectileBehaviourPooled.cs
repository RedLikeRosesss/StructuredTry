using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviourPooled : MonoBehaviour
{
    public float moveSpeed = 30f;

    public float lifeTime;
    public float maxLifeTime = 5f;

    private void OnEnable()
    {
        lifeTime = 0f;
    }
    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime) 
        {
            ProjectilePool.Instance.ReturnToPool(this);
        }
    }
}
