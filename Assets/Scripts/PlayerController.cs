using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    

    Rigidbody player;
    GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float fwd = Input.GetAxis("Vertical");
        player.AddForce(focalPoint.transform.forward * speed * fwd);
    }
}
