using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Player{
public class Attack : MonoBehaviour
{

    public GameObject projetile;
    private int _projektilsFierd;
    public PoolManager bulletPool;
    public PlayerController player;
    public void Attacker(float input)
    {
        var Bullet = bulletPool.GetBullet();
        Bullet.transform.position = transform.position;
        Bullet.SetActive(true);
        if (Bullet.GetComponent<ProjectilesScripts>() != null)
        {
            Bullet.GetComponent<ProjectilesScripts>().Fly(input);
 
        }
        

    }
}
}