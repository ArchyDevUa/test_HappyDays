using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LoadUpLogic : MonoBehaviour
{
    [SerializeField] private GameObject loadPoint;
    private float amoOffset = 0;
    private int ammoCount = 0;
   
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("LoadZone") && collision.transform.childCount > 0 && ammoCount < 8)
        {
            Transform amo = collision.transform.GetChild(0);
            amo.position = loadPoint.transform.position + new Vector3(0,amoOffset,0);
            // amo.rotation = loadPoint.transform.rotation;
            //amo.transform.eulerAngles = new Vector3(0f, -90f, 0f);
            //amo.transform.Rotate(new Vector3(0f, -90f, 0f));
            amo.parent = loadPoint.transform;
            amoOffset += 0.6f;
            ammoCount++;
        }
        
        
    }

    public void DecreseAmmoCount()
    {
        ammoCount -= 1;
        amoOffset -= 0.6f;
    }

    public int actualAmmoCount()
    {
        return ammoCount;
    }

    
}
