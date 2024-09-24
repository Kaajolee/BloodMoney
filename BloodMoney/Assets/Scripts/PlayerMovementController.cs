using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Button moveUp, moveDown, moveLeft, moveRight;

    private Rigidbody2D playerRB;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private bool isMobileEnabled;

    [SerializeField]
    private float horitontalInput, verticalInput;

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
        //RotateCharacter();
    }
    public void ReadInputs()
    {
        horitontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    public void MoveCharacter()
    {
        Vector2 moveDirection = new Vector2(horitontalInput, verticalInput) * moveSpeed * Time.deltaTime;

        transform.Translate(moveDirection);
    }
    public void RotateCharacter()
    {
        if (horitontalInput != 0 || verticalInput != 0)
        {
            Vector2 moveDirection = new Vector2(horitontalInput, verticalInput);

            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);
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
