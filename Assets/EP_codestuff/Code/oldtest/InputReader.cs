using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EcoExplorer
{
	public class InputReader : MonoBehaviour
	{
		private Rigidbody2D rb2D;
		private SpriteRenderer sprite;
		private Animator anim;

		private float dirX;

        private void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
			anim = GetComponent<Animator>();

        }


        private void Update()
        {
			dirX = Input.GetAxisRaw("Horizontal");
			rb2D.velocity = new Vector2(dirX * 7f, rb2D.velocity.y);

			// ajetaan animaation päivitys metodi
			UpdateAnimationUpdate();
			
        }
		private void UpdateAnimationUpdate()
		{
            if (movementDirection.x > 0f)
            {
                anim.SetBool("runR", true);
                anim.SetBool("runL", false);
                anim.SetBool("idle", false);
            }
            else if (movementDirection.x < 0f)
            {
                anim.SetBool("runR", false);
                anim.SetBool("runL", true);
                anim.SetBool("idle", false);
            }
            else
            {
                anim.SetBool("runR", false);
                anim.SetBool("runL", false);
                anim.SetBool("idle", true);
            }
        }







        private Vector2 movementDirection = Vector2.zero;
		private bool isJumping = false;

		public void OnMove(InputAction.CallbackContext context)
		{
			this.movementDirection = context.ReadValue<Vector2>();
		}

		public void OnJump(InputAction.CallbackContext context)
		{
			isJumping = context.performed;
		}

		public Vector2 GetMovement()
		{
			return movementDirection;
		}

		public bool IsJumping()
		{
			return isJumping;
		}
	}
}