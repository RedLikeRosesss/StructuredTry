using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : MonoBehaviour
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
        var tempProjectile = ProjectilesPool.Instance.GetProjectile();
        if (tempProjectile != null)
        {
            ProjectilesPool.Instance.RemoveProjectile();
            tempProjectile.transform.rotation = transform.rotation;
            tempProjectile.transform.position = transform.position;
            tempProjectile.gameObject.SetActive(true);
            tempProjectile.GetComponent<ProjectileBehaviour>().enabled = true;            
        }        
    }
}
