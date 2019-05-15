using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 10, maxReserve = 500, maxClip = 30;
    public float spread = 2f, recoil = 1f, range = 10f, shootRate = .34f;
    public Transform shootOrigin;
    public GameObject bulletPrefab;
    public bool canShoot = false;

    private int currentReserve = 0, currentClip = 0;
    private float shootTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Reload();
    }

    // Update is called once per frame
    void Update()
    {
        //increase shoot timer
        shootTimer += Time.deltaTime;
        //check shoottimer reach rate
        if (shootTimer >= shootRate)
        {
            //can shoot
            canShoot = true;
        }

    }
    void Reload()
    {

    }

    void Shoot()
    {
        //reduce clip size
        //reset shoottimer
        //reset canshoot
        //get origin + direction of fire
        //shootbullet
    }
}
