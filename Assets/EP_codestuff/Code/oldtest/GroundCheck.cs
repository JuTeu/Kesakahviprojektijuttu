using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcoExplorer
{
    public class GroundCheck : MonoBehaviour
    {
        private bool isGrounded;
        public bool IsGrounded
        {
            get
            {
                return isGrounded;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            this.isGrounded = collision.gameObject.layer == LayerMask.NameToLayer("Ground");

        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                this.isGrounded = false;
            }
        }
    }
}