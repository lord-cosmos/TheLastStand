using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 1000f;
    GameObject currentProjectilePrefab;
    public AudioClip playerShootSFX;
    public float shootingVolume = 0.8f;

    void Start()
    {
        currentProjectilePrefab = projectilePrefab;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play shooting sound at low volume
            AudioSource.PlayClipAtPoint(playerShootSFX, transform.position, shootingVolume);

            // Instantiate the projectile slightly in front of the player
            GameObject projectile = Instantiate(currentProjectilePrefab, transform.position + transform.forward, transform.rotation) as GameObject;
        }
    }

    private void FixedUpdate()
    {
    }

}
