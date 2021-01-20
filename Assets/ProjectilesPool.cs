using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPool : MonoBehaviour
{
    [SerializeField]
    private int maxNumberOfProjectiles;    

    [Header("List")]
    List<GameObject> proprojectileList = new List<GameObject>();
    public int count;

    [Header("Scripts")]
    [SerializeField]
    internal DanceOfProjectiles DanceOfProjectiles;

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
        maxNumberOfProjectiles = 5;
    }

    private void Start()
    {
        DanceOfProjectiles = gameObject.GetComponent<DanceOfProjectiles>();
    }

    private void Update()
    {
        count = proprojectileList.Count;
        /*if (Input.GetMouseButtonDown(0))
        {
            RemoveProjectile();
        }*/
    }

    public GameObject GetProjectile()
    {
        if (proprojectileList.Count > 0) {
            return proprojectileList[0] as GameObject;
        }
        return null;
    }

    public void RemoveProjectile()
    {
        if (proprojectileList != null)
        {
            proprojectileList.RemoveAt(0);
        }
    }

    public void AddProjectile(GameObject projectileToAdd)
    {
        if (proprojectileList.Count < maxNumberOfProjectiles)
        {
            AddToDance();
            projectileToAdd.SetActive(false);
            proprojectileList.Add(projectileToAdd);
        }
    }

    private void AddToDance()
    {
        if (DanceOfProjectiles.gameObject.activeSelf == false)
        {
            DanceOfProjectiles.gameObject.SetActive(true);
        }
    }
}
