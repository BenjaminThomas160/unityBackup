using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 moveDirection;
    GameObject player;
    public float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            this.gameObject.SetActive(false);
        }
    }
}
