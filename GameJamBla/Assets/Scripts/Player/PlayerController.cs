
using System;
using Unity.VisualScripting;
using UnityEngine;
namespace Player
{
    public class PlayerController : MonoBehaviour , IDamageable
    {
        [SerializeField] private AnimationPlayer AnimationPlayer;
        public float moveSpeed=6f;
        public float jumpForce=6f;
<<<<<<< Updated upstream
        private Rigidbody2D _rigB;
        public GameObject projetile;
        public float prjektileForce;
        private int _prjektilsFierd;
=======
        private float _input;
        private Rigidbody2D _rigB;        
        [SerializeField] private Attack bulletSpawner;
        private bool Attack;
        public bool Jumped;
        AudioSource bla;
        [Header("Ground check Ray")]
        public LayerMask groundCheckMask;
        public float checkLenght;

        //Buffer
        public float jumpBuffer = 0.1f, koyoteBuffer = 0.1f;
        private float jumpTimer = 1f, koyoteTimer = 1f;
        public int health = 1;
        public GameObject deathEffect, PlayObject;

        [Header("Sounds")]
        public AudioSource soundPlayer;
        public AudioClip jumpSFX, shootSFX, dieSFX;

>>>>>>> Stashed changes
        private void Start()
        {
            _rigB = GetComponent<Rigidbody2D>();
            Jumped = false;
        }

        private void Update()
        {
<<<<<<< Updated upstream
            var input = Input.GetAxisRaw("Horizontal");
            transform.position += new Vector3(input, 0, 0) * Time.deltaTime * moveSpeed;
            if (Input.GetKeyDown("space"))
                _rigB.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
            if (input != 0)
=======
            if (Input.GetKeyDown("r"))
            {
                Die();
            }

            _input = Input.GetAxisRaw("Horizontal");

            Timers();
            CheckGround();
            Move();
            Jump();
            Rotation();
           
            
            if(Input.GetKeyDown("w"))
            {
                PlaySound(shootSFX);
                Attack=true;
                if (bulletSpawner != null)
                {
                    bulletSpawner.Attacker(-transform.localScale.x); 
                }
            }
            if(Input.GetKeyUp("w"))
                Attack=false;
            AnimationPlayer.Animate(Attack,Jumped,_input);

        }

        public void Die()
        {
            if (deathEffect != null)
                Instantiate(deathEffect, transform.position, transform.rotation);

            PlayObject.SetActive(false);
        }

        public void TakeDamage()
        {
            PlaySound(dieSFX);
            health -= 1;

            if (health <= 0)
                Die(); //Die when health reaches, or surpasses, 0;
        }

        private void CheckGround()
        {
            var groundHit = Physics2D.Raycast(transform.position - transform.right * 0.1f, -transform.up, checkLenght, groundCheckMask);
            var groundHit2 = Physics2D.Raycast(transform.position + transform.right * 0.1f, -transform.up, checkLenght, groundCheckMask);

            if (groundHit.collider != null || groundHit2.collider != null)
                koyoteTimer = 0;
        }


        private void Move()
        {
            var wallCheck = Physics2D.Raycast(transform.position, -transform.right * transform.localScale.x, 0.2f, groundCheckMask);

            if (wallCheck.collider == null)
                transform.position += new Vector3(_input, 0, 0) * Time.deltaTime * moveSpeed;
        }

        private void Jump()
        {
            if (Input.GetKeyDown("space"))
            {
                jumpTimer = 0f;
            }

            if (jumpTimer < jumpBuffer)
            {
                if (koyoteTimer < koyoteBuffer)
                {
                    PlaySound(jumpSFX);
                    _rigB.velocity = Vector2.up * jumpForce;
                    jumpTimer = 1f;
                    Jumped=true;
                }else
                    Jumped=false;

            }
            else if(jumpTimer > jumpBuffer)
                Jumped = false;


            if (Input.GetKeyUp("space") && _rigB.velocity.y > 0)
            {
                _rigB.velocity = new Vector2(_rigB.velocity.x,_rigB.velocity.y / 2);
            }

        }

        private void Rotation()
        {
            if (_input != 0)
>>>>>>> Stashed changes
            {
                if (input > 0.1)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    
                }
                else if (input < 0.1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            if(Input.GetKeyDown("e"))
                Attack(input);
        }

        private void Attack(float input)
        {
            Instantiate(projetile, transform.position, transform.rotation).GameObject().GetComponent<ProjectilesScripts>().Fly(input);
            _prjektilsFierd++;
            if (_prjektilsFierd >= 10)
            {
                var _bullets = GameObject.FindGameObjectsWithTag("Bullet");
                foreach (var bullet in _bullets)
                {
                    Destroy(bullet);
                }

                _prjektilsFierd = 0;
            }
        }

        private void Timers()
        {
            jumpTimer += Time.deltaTime;
            koyoteTimer += Time.deltaTime;
        }
        void OnTriggerEnter2D(Collider2D other){


            if (other.CompareTag("Enemy"))
            {
                Die();
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawLine(transform.position,transform.position + (-transform.up * checkLenght));
        }

        private void PlaySound(AudioClip playThis)
        {
            soundPlayer.clip = playThis;
            soundPlayer.pitch = UnityEngine.Random.Range(0.9f,1.1f);
            soundPlayer.Play();
        }

        
    }
}
