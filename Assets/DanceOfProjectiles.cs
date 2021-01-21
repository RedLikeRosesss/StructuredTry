using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceOfProjectiles : MonoBehaviour
{
    public GameObject[] projectileSpriteObjects;

    private GameObject projectilePrefab;

    public int indexForActivation;
    private int ArraySize;
    private int activeSwords;

    public float timeCounter;
    public float speed;
    public float size;
    public float x;
    public float y;

    private void Start()
    {
        var projectile = Resources.Load("Projectiles/LegendarySwordSprite");
        projectilePrefab = projectile as GameObject;
        CreateArrayOfSwords();
        indexForActivation = 0;
        size = 1f;
        activeSwords = 0;
    }

    private void CreateArrayOfSwords()
    {
        ArraySize = ProjectilesPool.Instance.maxNumberOfProjectiles;
        projectileSpriteObjects = new GameObject[ArraySize];
        for (int i = 0; i < projectileSpriteObjects.Length; i++)
        {
            projectileSpriteObjects[i] = Instantiate(projectilePrefab, transform.position, transform.rotation);
            projectileSpriteObjects[i].transform.parent = gameObject.transform;
            projectileSpriteObjects[i].SetActive(false);
        }
    }

    private void Update()
    {
        DanceOff();
    }

    private void DanceOff()
    {
        //Debug.Log("DanceOff: " + ProjectilesPool.Instance.maxNumberOfProjectiles);
        switch (activeSwords)
        {
            case 1:
                CalculateSwordRotation(0, 0.0f, 2.6f);
                break;
            case 2:
                CalculateSwordRotation(0, 0.0f, 1.8f);
                CalculateSwordRotation(1, 9.3f, 1.8f);
                break;
            case 3:
                CalculateSwordRotation(0, 0.0f, 1.3f);
                CalculateSwordRotation(1, 8.1f, 1.3f);
                CalculateSwordRotation(2, 16.3f, 1.3f);
                break;
            case 4:
                CalculateSwordRotation(0, 0.8f, 1f);
                CalculateSwordRotation(1, 8.8f, 1f);
                CalculateSwordRotation(2, 10.2f, 1f);
                CalculateSwordRotation(3, 18.1f, 1f);
                break;
            case 5:
                CalculateSwordRotation(0, 0.0f, 0.7f);
                CalculateSwordRotation(1, 5f, 0.7f);
                CalculateSwordRotation(2, 10f, 0.7f);
                CalculateSwordRotation(3, 15f, 0.7f);
                CalculateSwordRotation(4, 20f, 0.7f);
                break;
            default:
                break;
        }
    }
    

    private void CalculateSwordRotation(int index, float timeChange, float speed)
    {
        timeCounter += Time.deltaTime * speed;
        x = -Mathf.Cos(timeCounter + timeChange) * size;
        y = Mathf.Sin(timeCounter + timeChange) * size;
        projectileSpriteObjects[index].transform.localPosition = new Vector2(x, y);
    }

    public void ActivateSword()
    {
        if (indexForActivation < 5)
        {
            projectileSpriteObjects[indexForActivation].SetActive(true);
            indexForActivation++;
            activeSwords++;
        }
        else
        {
            Debug.Log("Can't add more swords to danceOfSwords: limit is reached");
        }        
    }

    public void DeactivateSword()
    {        
        if (indexForActivation > 0)
        {
            projectileSpriteObjects[indexForActivation - 1].SetActive(false);
            indexForActivation--;
            activeSwords--;
        }
        else
        {
            Debug.Log("Can't remove sword from danceOfSwords: no swords");
        }
        
    }
}
