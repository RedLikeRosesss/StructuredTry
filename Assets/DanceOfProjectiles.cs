using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceOfProjectiles : MonoBehaviour
{
    public GameObject[] projectileSpriteObjects;

    private GameObject projectilePrefab;

    public float timeCounter;
    public float speed;
    public float size;
    public float x;
    public float y;

    private void Awake()
    {
        var projectile = Resources.Load("Projectiles/LegendarySwordSprite");
        projectilePrefab = (projectile as ProjectileBehaviour).gameObject;
    }

    private void OnEnable()
    {
        projectileSpriteObjects = new GameObject[] { };
    }

    public void RecreateDoS(int size)
    {
        projectileSpriteObjects = new GameObject[size];
        for (int i = 0; i < projectileSpriteObjects.Length; i++)
        {
            projectileSpriteObjects[i] = Instantiate(projectilePrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }

    private void Update()
    {
        DanceOff();
    }

    private void DanceOff()
    {
        switch (projectileSpriteObjects.Length)
        {
            case 1:
                CalculatePosition(0, 0.0f, 2.6f);
                break;
            case 2:
                CalculatePosition(0, 0.0f, 1.8f);
                CalculatePosition(1, 9.3f, 1.8f);
                break;
            case 3:
                CalculatePosition(0, 0.0f, 1.3f);
                CalculatePosition(1, 8.1f, 1.3f);
                CalculatePosition(2, 16.3f, 1.3f);
                break;
            case 4:
                CalculatePosition(0, 0.8f, 1f);
                CalculatePosition(1, 8.8f, 1f);
                CalculatePosition(2, 10.2f, 1f);
                CalculatePosition(3, 18.1f, 1f);
                break;
            case 5:
                CalculatePosition(0, 0.0f, 0.7f);
                CalculatePosition(1, 5f, 0.7f);
                CalculatePosition(2, 10f, 0.7f);
                CalculatePosition(3, 15f, 0.7f);
                CalculatePosition(4, 20f, 0.7f);
                break;
            default:
                break;
        }
    }
    

    private void CalculatePosition(int index, float timeChange, float speed)
    {
        timeCounter += Time.deltaTime * speed;
        x = -Mathf.Cos(timeCounter + timeChange) * size;
        y = Mathf.Sin(timeCounter + timeChange) * size;
        projectileSpriteObjects[index].transform.localPosition = new Vector2(x, y);
    }
}
