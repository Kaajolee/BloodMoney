using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Button moveUp, moveDown, moveLeft, moveRight;

    private Rigidbody2D playerRB;

    [SerializeField]
    private float moveSpeed, rotationSpeed;

    [SerializeField]
    private bool isMobileEnabled;

    [SerializeField]
    private float horitontalInput, verticalInput;

    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInputs();
        MoveCharacter();
        RotateCharacter();
    }
    public void ReadInputs()
    {
        horitontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    public void MoveCharacter()
    {
        moveDirection = new Vector2(horitontalInput, verticalInput);
        moveDirection.Normalize();

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
    public void RotateCharacter()
    {
        //Debug.Log(moveDirection);
        if (moveDirection != Vector2.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);

        }
    }




    //--------------------MOBILE_CONTROLS--------------------------------------------
    public void MoveUp()
    {
        if (isMobileEnabled)
        {
            if (playerRB != null)
            {
                playerRB.velocity = new Vector2(0, 1) * moveSpeed;
                Debug.Log("Moving up");
            }
            else
                Debug.LogError("Player RigidBody component null");
        }
    }
    public void MoveDown()
    {
        if (isMobileEnabled)
        {
            if (playerRB != null)
            {
                playerRB.velocity = new Vector2(0, -1) * moveSpeed;
                Debug.Log("Moving down");
            }
            else
                Debug.LogError("Player RigidBody component null");
        }
    }
    public void MoveLeft()
    {
        if (isMobileEnabled)
        {
            if (playerRB != null)
            {
                playerRB.velocity = new Vector2(-1, 0) * moveSpeed;
                Debug.Log("Moving left");
            }
            else
                Debug.LogError("Player RigidBody component null");
        }
    }
    public void MoveRight()
    {
        if (isMobileEnabled)
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

}
