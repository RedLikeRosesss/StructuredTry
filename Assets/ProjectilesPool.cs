using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPool : MonoBehaviour
{
    /*[SerializeField]
    private GameObject projectilePrefab;*/

    [SerializeField]
    private ArrayList projectiles;
    [SerializeField]
    private int maxNumberOfProjectiles;

    public int count;

    public static ProjectilesPool Instance { get; private set; }

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

        projectiles = new ArrayList();
        maxNumberOfProjectiles = 5;
    }

    private void Update()
    {
        count = projectiles.Count;
    }

    public GameObject GetProjectile()
    {
        return projectiles[0] as GameObject;
    }

    public void RemoveProjectile()
    {
        if (projectiles != null)
        {
            projectiles.RemoveAt(0);
        }
    }

    public void AddProjectile(GameObject projectileToAdd)
    {
        if (projectiles.Count < maxNumberOfProjectiles)
        {
            projectiles.Add(projectileToAdd);
        }
    }
}
