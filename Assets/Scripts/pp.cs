using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pp : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject reductoPrefab;
    public float projectileSpeed = 100;
    public AudioClip spellSFX;
    public Image reticleImage;
    public Color reticleDementorColor;
    public Color reductoColor;
    Color originalReticleColor;

    GameObject currentProjectilePrefab;
    void Start()
    {
        //originalReticleColor = reticleImage.color;
        currentProjectilePrefab = projectilePrefab;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = Instantiate(projectilePrefab,
                transform.position + transform.forward, transform.rotation) as GameObject;

            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * projectileSpeed, ForceMode.VelocityChange);

            projectile.transform.SetParent(GameObject.FindGameObjectWithTag("ProjectileParent").transform);

            AudioSource.PlayClipAtPoint(spellSFX, transform.position);
        }
    }


    private void FixedUpdate()
    {
        ReticleEffect();
    }


    void ReticleEffect()
    {
        if (reticleImage != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Dementor"))
                {
                    currentProjectilePrefab = projectilePrefab;

                    reticleImage.color = Color.Lerp(reticleImage.color, reticleDementorColor, Time.deltaTime * 2);
                    reticleImage.transform.localScale = Vector3.Lerp(
                         reticleImage.transform.localScale, new Vector3(0.7f, 0.7f, 1),
                         Time.deltaTime * 2);
                }
                else if (hit.collider.CompareTag("Reducto"))
                {
                    currentProjectilePrefab = reductoPrefab;

                    reticleImage.color = Color.Lerp(reticleImage.color, reductoColor, Time.deltaTime * 2);
                    reticleImage.transform.localScale = Vector3.Lerp(
                         reticleImage.transform.localScale, new Vector3(0.7f, 0.7f, 1),
                         Time.deltaTime * 2);
                }
                else
                {
                    currentProjectilePrefab = projectilePrefab;

                    reticleImage.color = Color.Lerp(reticleImage.color, originalReticleColor, Time.deltaTime * 2);
                    reticleImage.transform.localScale = Vector3.Lerp(
                         reticleImage.transform.localScale, new Vector3(1f, 1f, 1),
                         Time.deltaTime * 2);
                }
            }
            else
            {
                reticleImage.color = Color.Lerp(reticleImage.color, originalReticleColor, Time.deltaTime * 2);
                reticleImage.transform.localScale = Vector3.Lerp(
                     reticleImage.transform.localScale, new Vector3(1f, 1f, 1),
                     Time.deltaTime * 2);
            }
        }
    }
}