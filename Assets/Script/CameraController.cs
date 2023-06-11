using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        this.player = GameObject.Find("cat");
    }

    private void Update()
    {
        if (player.transform.position.y > 0 )
        {
            Vector3 playerPos = this.player.transform.position;
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
