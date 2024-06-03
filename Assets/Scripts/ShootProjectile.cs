using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 1000f;
    GameObject currentProjectilePrefab;

    void Start()
    {
        currentProjectilePrefab = projectilePrefab;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate(currentProjectilePrefab, transform.position + transform.forward, transform.rotation) as GameObject;
        }
    }

    private void FixedUpdate()
    {
    }

}
