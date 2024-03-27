using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;

    public float groundSpeed;
    [Range(0f, 2f)] public float groundDecay;

    float xInput;

    public bool playerInput;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MoveWithInput();
        
    }

    private void FixedUpdate()
    {
        ApplyFriction();
        WalkAnimation();
        PlayerInput();
    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
    }

    void MoveWithInput()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            body.velocity = new Vector2(xInput * groundSpeed, 0);

            float direction = Mathf.Sign(xInput);
            transform.localScale = new Vector3(direction,1,1);
        }
    }

    void ApplyFriction()
    {
        if (xInput == 0)
        {
            body.velocity *= groundDecay;
        }
    }

    void WalkAnimation()
    {
        animator.SetFloat("xVelocity", Mathf.Abs(body.velocity.x));
        animator.SetBool("Input", playerInput);
    }

    void PlayerInput()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            playerInput = true;
        }
        else playerInput = false;
    }
}
