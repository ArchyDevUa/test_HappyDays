using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashZoneLogic : MonoBehaviour
{
    [SerializeField] private LoadUpLogic script;
    private void OnCollisionStay(Collision collisionInfo)
    {
       
        if (collisionInfo.gameObject.CompareTag("Player"))
        {
            foreach (Transform child in collisionInfo.gameObject.transform.Find("LoadPoint"))
            {
                if (child.CompareTag("Ammo"))
                {
                    Destroy(child.gameObject);
                    script.DecreseAmmoCount();
                }
                
            }
            
        }
    }
}
