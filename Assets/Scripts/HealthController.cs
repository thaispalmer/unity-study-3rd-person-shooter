using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public GameObject healthBarPrefab;
    public float healthBarYOffset = 2;
    public float currentHealth = 100;
    public float maxHealth = 100;

    GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        if (healthBarPrefab)
        {
            healthBar = Instantiate(healthBarPrefab);
            UpdateBar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarPrefab)
        {
            PositionHealthBar();
        }
    }

    // Update instantiated health bar position based on the current game object
    private void PositionHealthBar()
    {
        Vector3 currentPos = transform.position;

        healthBar.transform.position = new Vector3(
            currentPos.x,
            currentPos.y + healthBarYOffset,
            currentPos.z
        );

        healthBar.transform.LookAt(Camera.main.transform);
    }

    // Update slider value
    private void UpdateBar()
    {
        if (healthBarPrefab)
        {
            Transform panel = healthBar.transform.Find("Panel");
            Transform slider = panel.transform.Find("Slider");
            Slider sliderComponent = slider.GetComponent<Slider>();
            sliderComponent.value = currentHealth / maxHealth;
        }
    }

    // Destroy the instantiated health bar game object
    public void Destroy()
    {
        Destroy(healthBar);
    }

    // Reduce health points
    public void Damage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateBar();
    }

    // Increase health points
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateBar();
    }
}
