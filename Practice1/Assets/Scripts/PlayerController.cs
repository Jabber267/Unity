using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    public float jumpForce;
    public AudioSource coinSound;

    Rigidbody rb;
    Collider col;
    bool jumpPressed = false;
    Vector3 playerSize;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        playerSize = col.bounds.size;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovementHandler();
        JumpHandler();
    }

    private void MovementHandler()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xAxis * walkSpeed * Time.deltaTime, 0, zAxis * walkSpeed * Time.deltaTime);
        Vector3 newPos = transform.position + movement;
        rb.MovePosition(newPos);
    }

    private void JumpHandler()
    {
        float jAxis = Input.GetAxis("Jump");
        bool isGrounded = CheckGrounded();
        if (jAxis > 0)
        {
            if (!jumpPressed && isGrounded)
            {
                jumpPressed = true;
                Vector3 jumpVector = new Vector3(0, jAxis * jumpForce, 0);
                rb.AddForce(jumpVector, ForceMode.VelocityChange);
            }
        }
        else
        {
            jumpPressed = false;
        }
    }

    private bool CheckGrounded()
    {
        Vector3 corner1 = transform.position + new Vector3(playerSize.x / 2, -playerSize.y / 2 + 0.01f, playerSize.z / 2);
        Vector3 corner2 = transform.position + new Vector3(-playerSize.x / 2, -playerSize.y / 2 + 0.01f, playerSize.z / 2);
        Vector3 corner3 = transform.position + new Vector3(playerSize.x / 2, -playerSize.y / 2 + 0.01f, -playerSize.z / 2);
        Vector3 corner4 = transform.position + new Vector3(-playerSize.x / 2, -playerSize.y / 2 + 0.01f, -playerSize.z / 2);

        bool grounded1 = Physics.Raycast(corner1, -Vector3.up, 0.02f);
        bool grounded2 = Physics.Raycast(corner2, -Vector3.up, 0.02f);
        bool grounded3 = Physics.Raycast(corner3, -Vector3.up, 0.02f);
        bool grounded4 = Physics.Raycast(corner4, -Vector3.up, 0.02f);

        return (grounded1 || grounded2 || grounded3 || grounded4);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinSound.Play();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {

        }
        else if (other.CompareTag("Portal"))
        {

        }
    }
}
