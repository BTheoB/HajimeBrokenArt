using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    Animator animator;
    public bool actif = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void Activer()
    {
        actif = true;
        animator.SetBool("isActive", true);
    }

    public void Deactiver()
    {
        actif = false;
        animator.SetBool("isActive", false);
    }

    public void Spawn(GameObject enemy)
    {
        Instantiate(enemy, this.transform.position, Quaternion.identity);
    } 
}
