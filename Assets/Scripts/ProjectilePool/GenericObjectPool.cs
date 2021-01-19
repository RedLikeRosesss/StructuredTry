using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private T prefab;

    public static GenericObjectPool<T> Instance { get; private set; }

    [SerializeField]
    private float counter = 0f;

    private Queue<T> projectiles = new Queue<T>();

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

    private void Update()
    {
        counter = projectiles.Count;
    }

    public T Get()
    {
        if (projectiles.Count == 0)
        {
            AddObjects(1);
        }          
        return projectiles.Dequeue();
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        projectiles.Enqueue(objectToReturn);
    }

    private void AddObjects(int count)
    {
        var newObject = GameObject.Instantiate(prefab);
        newObject.gameObject.SetActive(false);
        projectiles.Enqueue(newObject);
    }
}
