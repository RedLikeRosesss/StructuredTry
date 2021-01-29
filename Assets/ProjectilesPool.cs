using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPool : MonoBehaviour
{
    internal int maxNumberOfProjectiles;

    List<GameObject> proprojectileList = new List<GameObject>();
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
        DanceOfProjectiles = FindObjectOfType<DanceOfProjectiles>();
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
            StartCoroutine(ChangeSwordTag(proprojectileList[0]));
            DanceOfProjectiles.DeactivateSword();
            proprojectileList.RemoveAt(0);            
        }       
    }

    public void AddProjectile(GameObject projectileToAdd)
    {
        if (proprojectileList.Count < maxNumberOfProjectiles)
        {
            projectileToAdd.tag = "CollectedSword";
            projectileToAdd.SetActive(false);
            proprojectileList.Add(projectileToAdd);
            DanceOfProjectiles.ActivateSword();
        }       
    }

    IEnumerator ChangeSwordTag(GameObject tmpProjectile)
    {        
        yield return new WaitForSeconds(0.5f);
        tmpProjectile.tag = "Sword";
    }
}
