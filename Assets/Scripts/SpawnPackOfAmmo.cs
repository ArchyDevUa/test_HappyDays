using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPackOfAmmo : MonoBehaviour
{
    [SerializeField] private GameObject amo;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private GameObject loadZone;


    private void Start()
    {
        for (float i = 0; i < 2; i+= 0.6f)
        {
            for (float j = 0; j < 1; j+=0.7f)
            {
              
              GameObject amo1 =  Instantiate(amo, spawnPosition + new Vector3(-j,0,-i), Quaternion.identity);
              GameObject amo2 =   Instantiate(amo, spawnPosition + new Vector3(-j,0.55f,-i), Quaternion.identity);
              amo1.transform.parent = loadZone.transform;
              amo2.transform.parent = loadZone.transform;
            }
            
        }
    }
}
