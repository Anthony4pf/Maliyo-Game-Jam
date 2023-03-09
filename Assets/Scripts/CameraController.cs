using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        if (!(player.position.y < -4))
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }    
    }
}
