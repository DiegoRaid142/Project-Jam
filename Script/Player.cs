using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] float speed;
    [SerializeField] float Gravity;
    [SerializeField] float JumpForce;
    [Header("Ground Y")]
    [SerializeField] float BlockDown;
    float JumpStrengh;
    bool IsGrounded;
    Vector2 velocity;
    Vector2 Jump;
    float horizontalMove;
    float VerticalMove;

    void Update()
    {
        Movement();
        velocity.y = speed * VerticalMove;
        velocity.x = speed * horizontalMove;
        Jump.y = VerticalMove * JumpForce;
        SetJump();


    }

    void FixedUpdate()
    {

        if (!IsGrounded)
        {
            JumpForce = JumpStrengh * Time.deltaTime;
        }

        UpdatePosition();
    }

    void SetJump()
    {
        if (IsGrounded && Keyboard.current.spaceKey.isPressed)
        {
            velocity.y = JumpStrengh;
            IsGrounded = false;
        }

        if (!IsGrounded && velocity.y > 0.00f && Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            velocity.y = 0;
        }
    }

    void Movement()
    {
        horizontalMove = 0.0f;
        VerticalMove = 0.0f;

        if (Keyboard.current.aKey.isPressed)
        {
            horizontalMove = -1;

        }

        if (Keyboard.current.dKey.isPressed)
        {
            horizontalMove = 1;

        }

        if (Keyboard.current.wKey.isPressed)
        {
            VerticalMove = 1;

        }

        if (Keyboard.current.sKey.isPressed)
        {
            VerticalMove = -1;

        }


    }

    void UpdatePosition()
    {  Vector2 Position = transform.position;
    Position += velocity* Time.deltaTime;

    //  if (transform.position.y >= BlockDown)
    //  {
    //   Position.y = BlockDown;
    //   Position = 0.0f;
    //   //   IsGrounded = true;
    //  }
    //   else
    //   {
    //     Position != BlockDown;
    //      IsGrounded = false;
    //    }
    

    transform.position = Position;
     }
       
    
}

