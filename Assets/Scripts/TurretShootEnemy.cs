using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShootEnemy : MonoBehaviour
{
    Transform _Player;
    float dist;
    public float proximity;
    public Transform turret, barrel;
    public float fireRate, nextFire;
    public GameObject _projectile;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(_Player.position, transform.position);
        if(dist< proximity){
            turret.LookAt(_Player);
            turret.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            if(Time.time>=nextFire)
            {
                nextFire = Time.time + 1f / fireRate;
                shoot();
            }
        }
    }

    void shoot(){
        GameObject clone = Instantiate(_projectile, barrel.position, turret.rotation);
        clone.GetComponent<Rigidbody>().AddForce(-turret.right* 800);
        Destroy(clone, 1);
    }
}
