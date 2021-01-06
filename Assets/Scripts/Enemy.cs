using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.2f;
    Rigidbody body;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce((player.transform.position - transform.position).normalized * speed);

        if (transform.position.y < -10)
            Destroy(gameObject);


    }
}
