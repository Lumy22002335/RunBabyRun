using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    public void DropItem ()
    {
        Vector3 playerPos = new Vector3 (player.position.x, player.position.y + 3, player.position.z);
        Instantiate (item, playerPos, Quaternion.identity);
    }
}
