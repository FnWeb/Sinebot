using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public Vector3 playerVelocity;
    public bool isGrounded;
    public float playerSpeed = GlobalConstants.playerSpeed;
    public float jumpHeight = GlobalConstants.playerJumpHeight;
    public float gravityValue = -9.81f;

    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    private RaycastHit hit;
    private Vector3 screenCenter;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        screenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0);
        controller.enableOverlapRecovery = true;
    }

    void Update()
    {
        //controller.Move(playerMovement());
        playerMovement();
        raycasting();
    }
    void playerMovement()
    {
        //isGrounded = controller.isGrounded;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        playerSpeed = Input.GetKey(KeyCode.LeftShift) ? GlobalConstants.playerSpeedSprinting : GlobalConstants.playerSpeed;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -.1f;
        }
        else
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        /*if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }*/

        //return (move * playerSpeed + playerVelocity * Time.deltaTime) * Time.deltaTime;
        controller.Move(move * playerSpeed * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void raycasting()
    {//Target selection works in a cylinder r=grabD, height < playerY+grabD
        if (Physics.Raycast(Camera.main.ScreenPointToRay(screenCenter), out hit) && hit.collider != null && Mathf.Sqrt(Mathf.Pow(hit.point.x - transform.position.x, 2) + Mathf.Pow(hit.point.z - transform.position.z, 2)) <= GlobalConstants.playerGrabDistance && hit.point.y - transform.position.y <= GlobalConstants.playerGrabDistance)
        {
            PlayerTarget.set(hit.collider);
        }
        else
        {
            PlayerTarget.clear();
        }
    }
}