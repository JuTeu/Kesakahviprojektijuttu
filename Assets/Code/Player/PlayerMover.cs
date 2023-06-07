using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private float acceleration = 100;
    [SerializeField] private float airAcceleration = 100;
    [SerializeField] private float deceleration = 50;
    [SerializeField] private float airDeceleration = 25;
    [SerializeField] private float turning = 50;
    [SerializeField] private float airTurning = 50;
    [SerializeField] private float jumpVelocity = 5;
    [SerializeField] private float shortestJump = 2;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxCoyoteTime = 0.2f;
    [SerializeField] private float maxJumpBuffer = 0.2f;
    [SerializeField] private float downwardVelocityCap = -8;
    [SerializeField] private float upwardVelocityCap = 20;
    [SerializeField] private float extraFallingSpeed = 3;
    [SerializeField] private bool variableJumpHeight = true;

    [SerializeField] private float playerCafeScalingModifier = 0.1f;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator anim;
    [SerializeField] private Collider2D meleeCollider;


    private float coyoteTime = 0;
    private InputReader inputReader;
    private Rigidbody2D rb;
    private Collider2D col;
    private Transform spriteScale;
    private string currentAnimation;
    private Transform pos;
    private Vector3 posOffset;
    private Vector2 velocity;
    private bool onGround = false;
    private bool alreadyJumped = false;
    private float timeSinceJump = 0;
    private float jumpBuffer = 0;
    private PhysicsMaterial2D standStillMaterial;
    private PhysicsMaterial2D walkMaterial;
    float velocityChange;
    

    float playerScale;
    
    void Start()
    {
        GameManager.SetGameMode(0);
    }
    private void Awake()
    {
        inputReader = GetComponent<InputReader>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        pos = GetComponent<Transform>();
        velocity = new Vector2();
        posOffset = new Vector3(0.45f, 0f, 0f);
        if (rb == null) {
            Debug.LogError($"{gameObject} is missing the RigidBody2D component!");
        }

        spriteScale = sprite.gameObject.GetComponent<Transform>();

    }
    private void Update()
    {
        if (coyoteTime > 0)
        {
            coyoteTime = coyoteTime - Time.deltaTime;
        }
        if (timeSinceJump > 0)
        {
            timeSinceJump = timeSinceJump - Time.deltaTime;
        }
        if (jumpBuffer > 0)
        {
            jumpBuffer = jumpBuffer - Time.deltaTime;
        }

    }

    void LateUpdate()
    {
        if (GameManager.gameMode == 0)
        {
            playerScale = 1 - spriteScale.position.y * playerCafeScalingModifier;
            spriteScale.localScale = new Vector2(playerScale, playerScale);
            spriteScale.position = new Vector3(spriteScale.position.x, spriteScale.position.y, transform.position.y);

        }
    }
    private void FixedUpdate()
    {
        if (GameManager.gameMode == 0) CafeMode();
        else if (GameManager.gameMode == 1) PlatformerMode();
    }
    private void CafeMode()
    {
        if (!GameManager.playerIsInControl) return;
        Vector2 moveInput = inputReader.GetMoveInput();
        velocity = rb.velocity;
        CafeMove(moveInput);
        rb.velocity = velocity;
    }

    private void PlatformerMode()
    {
        if (!GameManager.playerIsInControl) return;
        Vector2 moveInput = inputReader.GetMoveInput();
        bool jumpInput = inputReader.GetJumpInput();
        bool action2Input = inputReader.GetAction2Input();
        velocity = rb.velocity;
        CheckIfGrounded();
        PlatformerMove(moveInput);
        Jump(jumpInput);
        Attack(action2Input);
        if (velocity.y < downwardVelocityCap)
        {
            velocity.y = downwardVelocityCap;
        }
        else if (velocity.y > upwardVelocityCap)
        {
            velocity.y = upwardVelocityCap;
        }
        rb.velocity = velocity;
    }
    private void CheckIfGrounded()
    {
        onGround = Physics2D.Raycast(
            pos.position + posOffset, Vector2.down, 0.6f, groundLayer) ||
            Physics2D.Raycast(pos.position, Vector2.down, 0.6f, groundLayer) ||
            Physics2D.Raycast(pos.position - posOffset, Vector2.down, 0.6f, groundLayer);
        if (onGround) 
        {
            coyoteTime = maxCoyoteTime;
        }

    }
    private void CafeMove(Vector2 input)
    {
        Vector2 direction = input.normalized;
        if (direction.x != 0) sprite.flipX = direction.x < 0f;
        velocity = direction * 6;
    }
    private void PlatformerMove(Vector2 input)
    {
        Vector2 direction = new Vector2(input.x, 0);
        direction = direction.normalized;
        float dec = onGround ? deceleration : airDeceleration;
        float acc = onGround ? acceleration : airAcceleration;
        float tur = onGround ? turning : airTurning;
        if (direction.x != 0f) {
            if ((direction.x == -1f && velocity.x > 0) || (direction.x == 1f && velocity.x < 0)) {
                velocityChange = tur * Time.fixedDeltaTime;
            } else {
                velocityChange = acc * Time.fixedDeltaTime;
            }
        } else {
            velocityChange = dec * Time.fixedDeltaTime;
        }
        velocity.x = Mathf.MoveTowards(velocity.x, direction.x * speed, velocityChange);
        if (direction.x != 0) {
            
            if (direction.x == 1f)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
        if (!onGround)
        {
            if (velocity.y < 0)
            {
                Animate("Fall");
            }
            else
            {
                Animate("PlatformerJump");
            }
        }
        else
        {
            if (direction.x != 0)
            {
                Animate("PlatformerRun");
            }
            else
            {
                Animate("PlatformerIdle");
            }
        }
    }
    private void Jump(bool input)
    {
        if (input && !alreadyJumped) {
            jumpBuffer = maxJumpBuffer;
            alreadyJumped = true;
        }
        if (jumpBuffer > 0 && coyoteTime > 0) {
            velocity.y =+ jumpVelocity;
            coyoteTime = 0;
            jumpBuffer = 0;
            timeSinceJump = shortestJump * 0.1f;
        }
        if (!input && velocity.y > 0 && variableJumpHeight && !(timeSinceJump > 0)) {
            velocity.y = velocity.y / 1.3f;
        }
        if (!(coyoteTime > 0) && velocity.y < -0.1f) {
            velocity.y = Mathf.MoveTowards(velocity.y, downwardVelocityCap, extraFallingSpeed * 0.1f);
        }
        if (!input && alreadyJumped) {
            alreadyJumped = false;
        }
    }
    public bool attackFinished = true;
    bool alreadyAttacked = false;
    private void Attack(bool input)
    {
        if (input && attackFinished && !alreadyAttacked)
        {
            Animate("SpinAttack");
            velocity = new Vector2(Mathf.Clamp(velocity.x * 5, -30, 30), velocity.y * 0.6f);
            attackFinished = false;
            alreadyAttacked = true;
        }
        else if (!input && alreadyAttacked)
        {
            alreadyAttacked = false;
        }
    }

    void Animate(string newAnimation)
    {
        if (newAnimation != currentAnimation && attackFinished)
        {
            anim.Play(newAnimation);
            currentAnimation = newAnimation;
        }
    }
}
