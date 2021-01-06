using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public bool hasPowerUp = false;
    public GameObject PUIndicator;


    Rigidbody player;
    GameObject focalPoint;
    
    float powerUpStrength = 15;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        PUIndicator.transform.position = transform.position + new Vector3(0,2,0);
        float fwd = Input.GetAxis("Vertical");
        player.AddForce(focalPoint.transform.forward * speed * fwd);

      

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            PUIndicator.SetActive(true);
            StartCoroutine(PowerUpCountdown());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        PUIndicator.SetActive(false);
    }
}
