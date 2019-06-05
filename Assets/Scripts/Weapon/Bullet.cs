using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float speed = 10f;
    public GameObject effectPrefab;
    public Transform line;

    private Rigidbody rigid;
   
    void Awake()
    {
        //getcomponent
        rigid = GetComponent<Rigidbody>();
    }

  
    void Update()
    {
        if (rigid.velocity.magnitude > 0)
        {
            //rotate line in direction of bullet travel
            line.transform.rotation = Quaternion.LookRotation(rigid.velocity);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        //get contact point
        ContactPoint contact = coll.contacts[0];
        //spawn effect
        //  Instantiate(effectPrefab, contact.point, Quaternion.LookRotation(contact.normal));
        //destroy bullet
        Enemy enemy = coll.collider.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    public void Fire(Vector3 lineOrigin, Vector3 direction)
    {
        //add instant force to bullet
        rigid.AddForce(direction * speed, ForceMode.Impulse);
        //set line origin
        line.transform.position = lineOrigin;
    }
}
