using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileProduction : MonoBehaviour
{   
    
    [SerializeField] float moveSpeed = 1f;

    private bool hasMoved = false;
    private Transform target;
    [SerializeField] private GameObject rocket;
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private Vector3 rocketInstallPoint;
    [SerializeField] private Vector3 offset = new Vector3(0,0,0);
    [SerializeField] private GameObject loadZone;
    private int rocketCount = 0;
    private GameObject movebleRocket;
    private void Update()
    {
        if (!hasMoved)
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Ammo") )
                {
                    target = child;
                    hasMoved = true;
                    break;
                }
            }
        }

        if (hasMoved && target != null)
        {
            Vector3 newPosition = target.position + Vector3.right;
            target.transform.position = Vector3.MoveTowards(target.transform.position, newPosition, moveSpeed * Time.deltaTime);
            if (target.position.x > -102)
            {
                Destroy(target.gameObject);
                target = null;
                hasMoved = false;
                GameObject newRocket = Instantiate(rocket, spawnPoint, Quaternion.identity);
                newRocket.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                movebleRocket = newRocket;
            }
        }
        if (movebleRocket != null)
        {
            Vector3 newRocketPosition = movebleRocket.transform.position + Vector3.right;
            movebleRocket.transform.position = Vector3.MoveTowards(movebleRocket.transform.position, newRocketPosition, moveSpeed* 5 * Time.deltaTime);
            if (movebleRocket.transform.position.x > -98)
            {
                
                movebleRocket.transform.eulerAngles = new Vector3(90,0 , 0);
                if (rocketCount % 3 == 0)
                {
                    offset = new Vector3(0.5f,0 , offset.z -0.5f);
                }
                else
                {
                    offset += new Vector3(0.8f, 0, 0);
                }
                
                rocketInstallPoint = new Vector3(rocketInstallPoint.x, rocketInstallPoint.y, rocketInstallPoint.z);
                movebleRocket.transform.position = rocketInstallPoint + offset;;
                movebleRocket.transform.parent = loadZone.transform;
                movebleRocket = null;
                rocketCount++;
            }
        }

    }

   
}
