using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public int projectileNumber = 5;

    public GameObject projectilePrefab;
    public List<GameObject> projectileList;

    public static PoolManager Instance;

    public float timeCounter;
    public float speed;
    public float size;
    public float x;
    public float y;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //speed = 2.5f;
        size = 1f;
    }

    void FixedUpdate()
    {
        if (projectileList.Count > 0)
        {            
            DanceOfSwords();
        }
    }

    public void AddProjectile(GameObject tempProjectile)
    {
        if (projectileList.Count < projectileNumber)
        {
            //GameObject tempProjectile = (GameObject)Instantiate(projectilePrefab) as GameObject;
            tempProjectile.transform.parent = this.transform;
            tempProjectile.transform.rotation = this.transform.rotation;
            tempProjectile.GetComponent<Rigidbody2D>().isKinematic = true;
            tempProjectile.GetComponent<BoxCollider2D>().enabled = false;
            projectileList.Add(tempProjectile);
        }
    }

    private void DanceOfSwords()
    {
        switch (projectileList.Count)
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
        projectileList[index].transform.localPosition = new Vector2(x, y);
    }

    /*private void Fire()
    {
        for (int i = 0; i < projectileList.Count; i++)
        {
            if (projectileList[i].activeInHierarchy == false)
            {
                projectileList[i].SetActive(true);
            }
            else
            {
                if (i == projectileList.Count - 1)
                {
                    GameObject tempProjectile = (GameObject)Instantiate(projectilePrefab) as GameObject;
                    tempProjectile.transform.parent = this.transform;
                    tempProjectile.SetActive(false);
                    projectileList.Add(tempProjectile);
                }
            }
        }
    }*/
}
