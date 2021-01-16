using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject player;
    public GameObject projectilePrefab;
    public GameObject startPos;

    public float projectileSpeed;

    private Vector3 target;

    void Start()
    {
        projectileSpeed = 20.0f;
    }

    void Update()
    {
        //target = Camera.main.ScreenToWorldPoint;
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
            Input.mousePosition.y, 
            transform.position.z));

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            FireBullet(direction, rotationZ);
        }
    }

    void FireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(projectilePrefab) as GameObject;
        b.transform.position = startPos.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }

}
