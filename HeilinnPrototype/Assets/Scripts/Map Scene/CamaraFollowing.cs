using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollowing : MonoBehaviour
{
    public Transform playerPosition;

    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Main Character").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -20f);
       
    }
}
