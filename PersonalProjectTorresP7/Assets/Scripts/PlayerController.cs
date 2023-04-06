using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float horizontal;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Rigidbody playerRb;
    public float gravityModifier;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontal * Time.deltaTime * speed);
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
                isOnGround = false;
            }
        }
    }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground") && !gameOver)
            {
                isOnGround = true;
            }
            else if (collision.gameObject.CompareTag("Enemy") && !gameOver)
            {
                gameOver = true;
                Debug.Log("Game Over!");
            }
            if (collision.gameObject.CompareTag("Win") && !gameOver)
            {
                Debug.Log("You Win!");
                gameOver = true;
            }
        }
}
