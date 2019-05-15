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
   public void Reload()
    {
        //if bullets in reserve
        if (currentReserve > 0)
        {
            //if enough bullets
            if (currentReserve >= maxClip)
            {
                //reduce clip size by offset from current clip to max clip
                int offset = maxClip - currentClip;
                currentReserve -= offset;
            }
            //if clip under max clip
            if (currentClip < maxClip)
            {

            }
        }
    }

   public void Shoot()
    {
        //reduce clip size
        currentClip--;
        //reset shoottimer
        shootTimer = 0f;
        //reset canshoot
        canShoot = false;
        //get origin + direction of fire
        Camera attachedCamera = Camera.main;
        Transform camTransform = attachedCamera.transform;
        Vector3 lineOrigin = shootOrigin.position;
        Vector3 direction = camTransform.forward;
        //shootbullet
        GameObject clone = Instantiate(bulletPrefab, camTransform.position, camTransform.rotation);
        Bullet bullet = clone.GetComponent<Bullet>();
        bullet.Fire(lineOrigin, direction);

    }
}
