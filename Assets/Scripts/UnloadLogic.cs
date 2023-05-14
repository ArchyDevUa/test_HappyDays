using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadLogic : MonoBehaviour
{
    [SerializeField] private GameObject dropPoint;
    private Vector3 offset = new Vector3(0, 0, 0);
    private int amoCount = 0;
    [SerializeField] private LoadUpLogic scriptLoadUpLogic;

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Player"))
        {
            Transform playerLoadPoint =  collisionInfo.gameObject.transform.Find("LoadPoint");
            if (playerLoadPoint.childCount > 0)
            {
                Transform amo = playerLoadPoint.GetChild(playerLoadPoint.childCount-1);
                amo.parent = transform;
                amo.position = dropPoint.transform.position + offset; 
                amo.rotation = dropPoint.transform.rotation;
                scriptLoadUpLogic.DecreseAmmoCount();
                amoCount++;
                offset += new Vector3(0.7f, 0, 0);
                if (amoCount % 6 == 0)
                {
                    offset = new Vector3(0, offset.y +0.51f , 0);
                }else if (amoCount % 3 == 0)
                {
                    offset = new Vector3(0, offset.y, offset.z -0.6f);
                }

            };
        }
    }
}
