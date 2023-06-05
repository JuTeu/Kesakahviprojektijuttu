using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
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
    [SerializeField] private float extraFallingSpeed = 3;
    [SerializeField] private bool variableJumpHeight = true;

    [SerializeField] private float playerCafeScalingModifier = 0.1f;
    private float coyoteTime = 0;
    private InputReader inputReader;
    private Rigidbody2D rb;
    private Collider2D col;
    [SerializeField] private SpriteRenderer sprite;
    private Transform spriteScale;
    [SerializeField] private Animator anim;
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
    bool walkMaterialChange = false;
    float velocityChange;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GameManager.SetGameMode(0);
    }
    private void Awake()
    {
        standStillMaterial = new PhysicsMaterial2D();
        standStillMaterial.friction = 10;
        walkMaterial = new PhysicsMaterial2D();
        walkMaterial.friction = 0;
        inputReader = GetComponent<InputReader>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        pos = GetComponent<Transform>();
        //sprite = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
        velocity = new Vector2();
        posOffset = new Vector3(0.45f, 0f, 0f);
        if (rb == null) {
            Debug.LogError($"{gameObject} is missing the RigidBody2D component!");
        }

        spriteScale = sprite.gameObject.GetComponent<Transform>();
    }
    private float playerScale;
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
        Vector2 moveInput = inputReader.GetMoveInput();
        velocity = rb.velocity;
        CafeMove(moveInput);
        rb.velocity = velocity;
    }

    private void PlatformerMode()
    {
        Vector2 moveInput = inputReader.GetMoveInput();
        bool jumpInput = inputReader.GetJumpInput();
        velocity = rb.velocity;
        CheckIfGrounded();
        PlatformerMove(moveInput);
        Jump(jumpInput);
        if (velocity.y < downwardVelocityCap)
        {
            velocity.y = downwardVelocityCap;
        }
        rb.velocity = velocity;
        if ((velocity.x > -0.2f && velocity.x < 0.2f))
        {
            col.sharedMaterial = standStillMaterial;
            walkMaterialChange = true;
        }
        else if (walkMaterialChange)
        {
            col.sharedMaterial = walkMaterial;
            walkMaterialChange = false;
        }
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
                Animate("Character_fall");
            }
            else
            {
                Animate("Character_jump");
            }
        }
        else
        {
            if (direction.x != 0)
            {
                Animate("Character_run");
            }
            else
            {
                Animate("Character_idle");
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
    void Animate(string newAnimation)
    {
        if (newAnimation != currentAnimation)
        {
            //anim.Play(newAnimation);
            currentAnimation = newAnimation;
        }
    }
}
