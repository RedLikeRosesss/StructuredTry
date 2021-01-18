using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField]
    private LayerMask layersToCooperate;

    [SerializeField]
    private List<string> tagsToCooperate;

    [Header("Shooting")]
    public GameObject startPos;
    public float projectileSpeed;
    private Vector3 target;
    public bool isShooted;

    private void Start()
    {
        projectileSpeed = 20.0f;
        /*layersToCooperate = LayerMask.GetMask("Ground", "SlideGround", "SandGround", "MovingPlatform", "OneWayPlatform", "Enemy");
        tagsToCooperate.Add("BaseGround");
        tagsToCooperate.Add("SlideGround");
        tagsToCooperate.Add("SandGround");
        tagsToCooperate.Add("MovingPlatform");
        tagsToCooperate.Add("OneWayPlatform");*/
    }

    private void Update()
    {
        target = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,
            transform.position.z);

        Vector3 difference = target - startPos.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            Shoot(direction, rotationZ);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        this.gameObject.SetActive(false);
    }

    public void Shoot(Vector2 direction, float rotationZ)
    {
        this.gameObject.transform.position = startPos.transform.position;
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        this.gameObject.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }

}
