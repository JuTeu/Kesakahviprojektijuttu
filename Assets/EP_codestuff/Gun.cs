using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // gun variables
    // change the bullet prefab to the one you want
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 1f)] 
    [SerializeField] private float firingRate = 0.5f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        }
    }


