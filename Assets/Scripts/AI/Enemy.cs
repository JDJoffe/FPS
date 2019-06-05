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
    public Renderer rend;
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

        //get component from this gameobject
        rend = GetComponent<Renderer>();
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
        if (rend.isVisible)
        {
            healthSlider.gameObject.SetActive(true);

            Vector3 screenPosition = Camera.main.WorldToScreenPoint(healthbarPoint.position);
            healthSlider.transform.position = screenPosition;
        }
        else
        {
            healthSlider.gameObject.SetActive(false);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        //update slider
        //convert to percentage
        healthSlider.value = (float)health / (float)maxHealth;
        //health == 0
        if (health < 0)
        {
            //deatroy gameobject
            Destroy(gameObject);
        }
    }
}
