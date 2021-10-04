using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    public float moveSpeed = 5f, moveChangeInterval = 2f, jumpForce = 1f, jumpInterval = 2f , 
        sightRange = 0.5f, groundCheckRange = 0.5f, verticalVelocity = 0f, sinusWobbleStrenght = 1f, sinusWobbleSpeed = 1f;
    protected float JumpTimer = 0f, MoveChangeTimer = 0f, JustTime = 0f, hurtTime = 0f;
    public LayerMask sightMask;
    public int health = 1;
    private Vector3 _myPosition, _offsetPosition;
    /// <summary>
    /// death Effect gets Instantiated when the Enemy dies, Used for on Death Particles or new enemy spawns on Death;
    /// </summary>
    public GameObject deathEffect = null;
    protected delegate void EnemyBehaviour();
    protected EnemyBehaviour Behaviour;
    private SpriteRenderer SPR;
    public bool IsCrystal = true; 

    [Header("Sound")]
    public AudioSource soundPlayer;
    public AudioClip hurtSFX;


    private void Start()
    {
        if (IsCrystal)
            GameManager.Instance.Crystals.Add(this.gameObject);
        SPR = GetComponent<SpriteRenderer>();
        SPR.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        _myPosition = transform.position;
    }

    

    public virtual void Update()
    {
        if (Behaviour != null)
            Behaviour();
        else
            Debug.Log(this.gameObject + " is not Subbed to any behaviours");

        transform.position = _myPosition + _offsetPosition;

        if (hurtTime < 0.1f)
        {
            SPR.color = Color.red;
        }
        else
            SPR.color = Color.white;
    }

    public void LateUpdate()
    {
        hurtTime += Time.deltaTime;
        JumpTimer += Time.deltaTime;
        MoveChangeTimer += Time.deltaTime;
        JustTime += Time.deltaTime;
    }

    private void PlaySound(AudioClip playThis)
    {
        soundPlayer.clip = playThis;
        soundPlayer.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        soundPlayer.Play();
    }

    public void Die()
    {
        if(deathEffect != null)
            Instantiate(deathEffect,transform.position,transform.rotation);

        Destroy(this.gameObject);
    }

    public void TakeDamage()
    {
        PlaySound(hurtSFX);
        health -= 1;
        hurtTime = 0;
        if (health <= 0)
            Die(); //Die when health reaches, or surpasses, 0;
    }

    protected void SimpleMove()
    {
        _myPosition += -transform.right * moveSpeed * Time.deltaTime;

        if(Physics2D.Raycast(transform.position, -transform.right, sightRange,sightMask).collider != null)
        {
            //Enemy saw wall, Change direction
            transform.Rotate(0,180,0);
        }
    }

    protected void VerticalMovement()
    {
        _myPosition += transform.up * verticalVelocity * Time.deltaTime;
    }

    protected void FallToGravity()
    {
        if (Physics2D.Raycast(transform.position, -transform.up, groundCheckRange,sightMask).collider == null)
        {
            verticalVelocity -= 10f * Time.deltaTime;
            //No ground found, Fall down
        }
        else
        {
            if(verticalVelocity < 0)
                verticalVelocity = 0;
        }

    }

    protected void Jump()
    {
        if(JumpTimer > jumpInterval)
        {
            JumpTimer = 0f;
            verticalVelocity = jumpForce;
        }
    }

    protected void ChangeMoveDir()
    {
        if(MoveChangeTimer > moveChangeInterval)
        {
            MoveChangeTimer = 0;
            transform.Rotate(0, 180, 0);
        }
    }

    protected void SinusVerticalWobble()
    {
        _offsetPosition.y = Mathf.Sin(JustTime * sinusWobbleSpeed) * sinusWobbleStrenght;
    }
    protected void SinusHorizontalWobble()
    {
        _offsetPosition.x = Mathf.Cos(JustTime * sinusWobbleSpeed) * sinusWobbleStrenght;
    }
    
    protected void StickToGround()
    {
        if (Physics2D.Raycast(transform.position, -transform.up, groundCheckRange - 0.1f, sightMask).collider != null)
        {
            //Enemy Clipped into ground to far, go up
            _myPosition += transform.up * 0.1f;
        }
        if (Physics2D.Raycast(transform.position, transform.up, groundCheckRange - 0.1f, sightMask).collider != null)
        {
            //Enemy Clipped into ground to far, go up
            if(verticalVelocity > 0)
                verticalVelocity = 0.0f;
        }
    }
}
