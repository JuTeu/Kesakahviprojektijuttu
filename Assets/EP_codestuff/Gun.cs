using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // gun variables
    // change the bullet prefab to the one you want
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.5f;

    private float fireTimer;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        } else {
            fireTimer -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        }
    }





