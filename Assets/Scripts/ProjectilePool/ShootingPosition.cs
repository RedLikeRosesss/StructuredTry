using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPosition : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var tempProjectile = ProjectilePool.Instance.Get();
        tempProjectile.transform.rotation = transform.rotation;
        tempProjectile.transform.position = transform.position;
        tempProjectile.gameObject.SetActive(true);
    }
}
