using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcoExplorer
{
	// vaaditaan Rigidbody2D toimiakseen
	[RequireComponent(typeof(Rigidbody2D))]
	public class PhysicsMover : MonoBehaviour
	{
		// kaksi s��dett�v�� arvoa UnityHubissa, nopeus ja hyppyvoima
		[SerializeField]
		private float speed = 1;


        private float speedModifier = 1;

		[SerializeField]
		private float jumpForce = 1;

		private Rigidbody2D rb2D;
		public InputReader inputReader;

		private bool isJumping = false;
		private Vector2 direction = Vector2.zero;
		private float jumpRate = 0.5f;
		private float jumpTimer = 0;
		private float modifierTimer = 0;
		// private bool isGrounded = false;
		private GroundCheck groundCheck;
		

		private void Awake()
		{
			this.rb2D = GetComponent<Rigidbody2D>();
			this.inputReader = GetComponent<InputReader>();

			// haetaan referenssi komponentistä lapsiobjektin sisältä
			groundCheck = GetComponentInChildren<GroundCheck>();
		}

		private void Update()
		{
			this.direction = inputReader.GetMovement();

			bool isJumping = inputReader.IsJumping();
			if (!this.isJumping && isJumping)
			{
				this.isJumping = true;
			}

			UpdateJumpTimer(Time.deltaTime);

			UpdateModifierTimer();
		}

		private void UpdateModifierTimer()
		{
			if (modifierTimer > 0)
			{
				modifierTimer -= Time.deltaTime;

				if (modifierTimer <= 0)
				{
					speedModifier = 1;
				}
			}
		}

		private void FixedUpdate()
		{
			Move(this.direction);
			if (this.isJumping)
			{
				Jump();

				// Jump input consumed
				this.isJumping = false;
			}
		}

		// ctrl e c
        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    this.isGrounded = collision.gameObject.layer == LayerMask.NameToLayer("Ground");
        //}

        //private void OnCollisionExit2D(Collision2D collision)
        //{
        //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        //    {
        //        this.isGrounded = false;
        //    }
        //}

        private void UpdateJumpTimer(float deltaTime)
		{
			if (this.jumpTimer > 0)
			{
				this.jumpTimer -= deltaTime;
			}
		}

		private void Jump()
		{
			if (this.jumpTimer > 0)
			{
				// Jump on cooldown, can't jump again just yet.
				return;
			}

			Debug.Log("Jumping");
			if (groundCheck.IsGrounded)
			{
				this.rb2D.AddForce(Vector2.up * this.jumpForce, ForceMode2D.Impulse);
				this.jumpTimer = this.jumpRate;
			}
		}

		private void Move(Vector2 direction)
		{
			Vector2 velocity = this.rb2D.velocity;
			velocity.x = this.direction.x * this.speed * this.speedModifier;
			this.rb2D.velocity = velocity;
		}

		public void ApplySpeedModifier(float modifier, float time)
		{
			this.speedModifier = modifier;
			this.modifierTimer = time;
		}
	}
}