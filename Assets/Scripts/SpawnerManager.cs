﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform[] swordSpawnPositions;


    private void Awake()
    {
        var sword = Resources.Load<ProjectileBehaviour>("Projectiles/LegendarySword");
        projectilePrefab = (sword as ProjectileBehaviour).gameObject;
        SpawnSword();
    }

    private void SpawnSword()
    {
        for (int i = 0; i < swordSpawnPositions.Length; i++)
        {
            Instantiate(projectilePrefab, swordSpawnPositions[i].position, transform.rotation);
        }
    }
}
