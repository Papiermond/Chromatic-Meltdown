
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed=6f;
        public float jumpForce=6f;
        public PlayerAnimation playerAnimation;
        private float _input;
        private Rigidbody2D _rigB;
        public bool Moveabale;
        [SerializeField] private GroundCheck groundCheck;
        [SerializeField] private Attack bulletSpawner;
        private void Start()
        {
            _rigB = GetComponent<Rigidbody2D>();
            Moveabale = true;
        }

        private void Update()
        {
            _input = Input.GetAxisRaw("Horizontal");
            
            Move();
            Jump();
            Rotation();
            
            if(Input.GetKeyDown("e"))
                if (bulletSpawner != null)
                {
                    Moveabale = false;
                    playerAnimation.attacked = true;
                    bulletSpawner.Attacker(_input);
                    Moveabale = true;

                }
                else
                    playerAnimation.attacked = false;

            if (_rigB.velocity.y < 1.5)
                playerAnimation.Grounded = true;
            else
                playerAnimation.Grounded = false;
            playerAnimation.aniSpeed = _input;
        }

        

        private void Move()
        {   if(Moveabale)
                transform.position += new Vector3(_input, 0, 0) * Time.deltaTime * moveSpeed;
        }

        private void Jump()
        {
            if (Input.GetKeyDown("space"))
            {

                if (_rigB.velocity.y < 1.5)
                {
                    playerAnimation.jumped = true;
                    _rigB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
                else
                    playerAnimation.jumped = false;

            }
               
                    
        }

        private void Rotation()
        {
            if (_input != 0)
            {
                if (_input > 0.1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    
                }
                else if (_input < 0.1)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
        }
    }
}
