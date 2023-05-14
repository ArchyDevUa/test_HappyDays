using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 offset = new Vector3(0, 0, -7);
    
    void Update()
    {
        transform.position =
            new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) + offset;
    }
}
