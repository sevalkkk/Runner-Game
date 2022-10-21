using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    bool canJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canJump)
        {
            //jump
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "platform")
        {
            canJump = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag =="platform")
        {
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("trap"))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
