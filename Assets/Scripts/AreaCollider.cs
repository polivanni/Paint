﻿using System;
using PreFabs.Enemies;
using UnityEngine;

public class AreaCollider : MonoBehaviour
{
    public ChasePlayer[] enemies;
    private Collider2D col;
    private ContactFilter2D filter;
    void Start()
    {
        col = gameObject.GetComponent<Collider2D>();
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var enemy in enemies)
            {
                if (enemy != null)
                {
                    enemy.Chase(other.transform, ChasePlayer.State.Chase);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var enemy in enemies)
            {
                if (enemy != null)
                {
                    enemy.InvokeRetreat(3f);
                }
            }
        }
    }
}