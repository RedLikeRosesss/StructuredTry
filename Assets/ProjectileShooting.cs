using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : MonoBehaviour
{
    private Vector3 targetPosition;
    private Vector3 worldPosition;

    private void FixedUpdate()
    {
        worldPosition = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                transform.position.z));
            Shoot(targetPosition, worldPosition);
        }
    }

    private void Shoot(Vector3 targetPos, Vector3 startPos)
    {
        var tempProjectile = ProjectilesPool.Instance.GetProjectile();
        if (tempProjectile != null)
        {
            ProjectilesPool.Instance.RemoveProjectile();
            tempProjectile.transform.rotation = transform.rotation;
            tempProjectile.transform.position = transform.position;
            tempProjectile.gameObject.SetActive(true);
            tempProjectile.GetComponent<ProjectileBehaviour>().ProjectileShooting(targetPos, startPos);
        }        
    }
}
