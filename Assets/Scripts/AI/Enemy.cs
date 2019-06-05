using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for UI
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Slider healthSlider;
    public Transform HealthBarParent;
    public Transform healthbarPoint;
    public GameObject healthBarUIPrefab;
    public int maxHealth = 100;
    private int health = 0;


    // Start is called before the first frame update
    void Start()
    {
        //health = maxhealth
        health = maxHealth;
        //spawn healthbarUI into parent
        GameObject Clone = Instantiate(healthBarUIPrefab, HealthBarParent);
        healthSlider = Clone.GetComponent<Slider>();
    }

    void OnDestroy()
    {
        if (healthSlider == null) { Debug.Log("oof"); }
        else { Destroy(healthSlider.gameObject); }

    }
    // Update is called once per frame
    private void LateUpdate()
    {
        //update position of healthbar
        // + offset
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(healthbarPoint.position);
        healthSlider.transform.position = screenPosition;

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        //update slider
        //convert to percentage
        healthSlider.value = health / maxHealth;
        //health == 0
        if (health <= 0)
        {
            //deatroy gameobject
            Destroy(gameObject);
        }
    }
}
