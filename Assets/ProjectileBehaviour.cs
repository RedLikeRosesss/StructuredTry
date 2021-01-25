using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public GameObject startPos;
    public float projectileSpeed = 20.0f;
    private Vector3 target;

    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,
            transform.position.z));
        /*target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,
            transform.position.z));*/

        Vector3 difference = target - startPos.transform.position;
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
        transform.position = startPos.transform.position;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }
}
