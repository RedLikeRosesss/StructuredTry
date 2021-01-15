using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceOfSwordsController : MonoBehaviour
{
    public List<GameObject> children = new List<GameObject>();
    public float timeCounter;
    public float speed;
    public float size;
    public float x;
    public float y;
    public int activeSwords;


    void Start()
    {
        activeSwords = 0;
        speed = 0.5f;
        size = 2f;
        foreach (Transform child in this.gameObject.transform)
        {
            children.Add(child.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (activeSwords > 0)
        {
            SwordRotation();
        }            
    }

    private void SwordRotation()
    {
        switch (activeSwords)
        {
            case 1:
                CalculatePosition(0, 0.0f);
                break;
            case 2:
                CalculatePosition(0, 0.0f);
                CalculatePosition(1, 9.3f);
                break;
            case 3:
                CalculatePosition(0, 0.0f);
                CalculatePosition(1, 8.5f);
                CalculatePosition(2, 16.2f);
                break;
            case 4:
                CalculatePosition(0, 0.6f);
                CalculatePosition(1, 8.8f);
                CalculatePosition(2, 10f);
                CalculatePosition(3, 18.3f);
                break;
            case 5:
                CalculatePosition(0, 0.0f);
                CalculatePosition(1, 5f);
                CalculatePosition(2, 10f);
                CalculatePosition(3, 15f);
                CalculatePosition(4, 20f);
                break;
            default:
                break;
        }
    }

    private void CalculatePosition(int index, float timeChange)
    {
        timeCounter += Time.deltaTime * speed;
        x = -Mathf.Cos(timeCounter + timeChange) * size;
        y = Mathf.Sin(timeCounter + timeChange) * size;
        children[index].transform.localPosition = new Vector2(x, y);
    }

    public void SetActiveSword(int index)
    {
        children[index].SetActive(true);
    }
}
