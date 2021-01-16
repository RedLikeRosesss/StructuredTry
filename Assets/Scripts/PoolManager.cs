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

    void Start()
    {

    }
        

    void Update()
    {

    }

    public void AddProjectile()
    {
        if (projectileList.Count < projectileNumber)
        {
            GameObject tempProjectile = (GameObject)Instantiate(projectilePrefab) as GameObject;
            tempProjectile.transform.parent = this.transform;
            tempProjectile.SetActive(false);
            projectileList.Add(tempProjectile);
        }
    }

    private void Fire()
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
    }
}
