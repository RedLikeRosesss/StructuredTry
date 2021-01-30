using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    float projectileSpeed = 35.0f;
    public string[] TagList = { "BaseGround", "SlideGround",  "SandGround"};
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ProjectileShooting(Vector3 mousePosition, Vector3 startPos)
    {
        Vector3 difference = mousePosition - startPos;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();

        transform.position = startPos;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        rb.velocity = direction * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        Debug.Log(collision.gameObject.transform.position);
        foreach (string TagToTest in TagList)
        {
            if (collision.gameObject.tag == TagToTest)
            {                
                StartCoroutine(DelayForGroundPenetration());
            }
        }
    }

    IEnumerator DelayForGroundPenetration()
    {
        yield return new WaitForSeconds(0f);
        rb.velocity = Vector2.zero;
    }
}
