using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollecting : MonoBehaviour
{
    //public GameObject DanceOfSwords;
    public DanceOfSwordsController dance;

    private void Start()
    {
        dance = gameObject.GetComponentInChildren(typeof(DanceOfSwordsController)) as DanceOfSwordsController;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            AddSword();
            collision.gameObject.SetActive(false);
        }
    }
    private void AddSword()
    {
        if (dance.activeSwords < 5)
        {
            dance.SetActiveSword(dance.activeSwords);
            dance.activeSwords++;
        }
    }
}
