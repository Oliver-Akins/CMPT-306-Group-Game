using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour {
    
    // health bar slider
    public Slider slider;

    // health bar color gradient
    public Gradient gradient;

    public Image fill;

    // health divider prefab sprite
    public GameObject healthDivPrefab;

    // health divider horizontal group layout
    public GameObject healthDivLayout;

    // health bar divider prefabs container
    private List<GameObject> healthDivList;

    // flash routine for health bar damage effect
    private Coroutine flashRoutine;

    // health value per divider
    [SerializeField]
    private float valuePerDivider;

    public void SetMaxHealth(int maxHealth) {

        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        // fill health bar slider with gradient
        fill.color = gradient.Evaluate(1f);

        // initialize health divider prefabs container
        healthDivList = new List<GameObject>();
        healthDivList.Clear();

        // division currently set to 50
        float healthDivider = Mathf.Round(maxHealth / valuePerDivider);

        for (int i = 0; i < healthDivider; i++) {
            GameObject new_health = Instantiate(healthDivPrefab);
            new_health.transform.SetParent(healthDivLayout.transform, false);
            healthDivList.Add(new_health);
        }
    }

    public void SetCurrentHealth(int currentHealth) {
        // call Flash() effect when taking damage
        if(slider.value > currentHealth)
            Flash();
        
        fill.color = gradient.Evaluate(slider.normalizedValue);
        
        slider.value = currentHealth;
    }

    public void DecreaseMaxHealth(int currentHealth, int maxHealth) {
        slider.maxValue = maxHealth;

        SetCurrentHealth(currentHealth);

        UpdateDivider(maxHealth);
    }

    public void IncreaseMaxHealth(int currentHealth, int maxHealth) {
        slider.maxValue = maxHealth;

        SetCurrentHealth(currentHealth);
        
        UpdateDivider(maxHealth);
    }

    // flash effect for 0.1f seconds when taking damage
    public void Flash() {
        if (flashRoutine != null)
            StopCoroutine(flashRoutine);
            
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine() {
        fill.color = Color.magenta;

        yield return new WaitForSeconds(0.1f);

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void UpdateDivider(int maxHealth) {

        foreach(GameObject div in healthDivList) {
            Destroy(div);
        }

        healthDivList.Clear();

        // division currently set to 50
        float healthDivider = Mathf.Round(maxHealth / valuePerDivider);

        // initialize health dividers according to new max health value
        for (int i = 0; i < healthDivider; i++) {
            GameObject new_health = Instantiate(healthDivPrefab);
            new_health.transform.SetParent(healthDivLayout.transform, false);
            healthDivList.Add(new_health);
        }
    }
}
