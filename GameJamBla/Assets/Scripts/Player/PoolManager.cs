using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    public int bulletPoolStartSize;
    public GameObject bulletPrefab;
    private readonly List<GameObject> _bulletPool = new List<GameObject>();

    public int SightPoolStartSize;
    public GameObject SightPrefab;
    private readonly List<GameObject> _SightPool = new List<GameObject>();



    private void Start()
    {
        for (var x = 0; x < bulletPoolStartSize; x++)
        {
            var newBullet = Instantiate(bulletPrefab);
            _bulletPool.Add(newBullet);
            newBullet.SetActive(false);
        }
        for (var x = 0; x < SightPoolStartSize; x++)
        {
            var newBullet = Instantiate(SightPrefab);
            _SightPool.Add(newBullet);
            newBullet.SetActive(false);
        }
    }

    public GameObject GetBullet()
    {
        for (var x = 0; x < _bulletPool.Count; x++)
            if (!_bulletPool[x].gameObject.activeInHierarchy)
                return _bulletPool[x];
        var newBullet = Instantiate(bulletPrefab);
        _bulletPool.Add(newBullet);
        return newBullet;
    }

    public GameObject GetSight()
    {
        for (var x = 0; x < _SightPool.Count; x++)
            if (!_SightPool[x].gameObject.activeInHierarchy)
                return _SightPool[x];
        var newSight = Instantiate(SightPrefab);
        _SightPool.Add(newSight);
        return newSight;
    }
}