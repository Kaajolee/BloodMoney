using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Button moveUp, moveDown, moveLeft, moveRight;

    private Rigidbody2D playerRB;

    [SerializeField]
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void MoveUp()
    {
        if (playerRB != null)
        {
            playerRB.velocity = new Vector2(0,1) * moveSpeed;
            Debug.Log("Moving up");
        }
        else
            Debug.LogError("Player RigidBody component null");
    }
    public void MoveDown()
    {
        if (playerRB != null)
        {
            playerRB.velocity = new Vector2(0, -1) * moveSpeed;
            Debug.Log("Moving down");
        }
        else
            Debug.LogError("Player RigidBody component null");
    }
    public void MoveLeft()
    {
        if (playerRB != null)
        {
            playerRB.velocity = new Vector2(-1, 0) * moveSpeed;
            Debug.Log("Moving left");
        }
        else
            Debug.LogError("Player RigidBody component null");
    }
    public void MoveRight()
    {
        if (playerRB != null)
        {
            playerRB.velocity = new Vector2(1, 0) * moveSpeed;
            Debug.Log("Moving right");
        }
        else
            Debug.LogError("Player RigidBody component null");
    }

}
