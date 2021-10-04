using System;
using UnityEngine;



    public class ProjectilesScripts : MonoBehaviour
    {
        public Rigidbody2D rigB;
<<<<<<< Updated upstream

=======
        private IDamageable damageable;
        private float _timer;
>>>>>>> Stashed changes
        private void Start()
        {
            if(rigB==null)
                rigB = GetComponent<Rigidbody2D>();
        }
        
        public void Fly(float input)
        {
            if (input > 0.1)
            {
                for (int i = 0; i < 10; i++)
                {
                    rigB.velocity += new Vector2(Vector2.right.x, Vector2.right.y);
                }
            }
            else if (input < 0.1)
            {
                for (int i = 0; i < 10; i++)
                {
                    rigB.velocity += new Vector2(Vector2.left.x, Vector2.right.y);
                }
            }
        }
        void OnTriggerEnter2D(Collider2D other){
            if (other.CompareTag("Enemy"))
            {
                damageable = other.GetComponent<IDamageable>();
                if (damageable == null) return;

                other.GetComponent<EnemyBase>().TakeDamage();

                gameObject.SetActive(false);
            }
        }
    }

