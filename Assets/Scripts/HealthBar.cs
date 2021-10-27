using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    [SerializeField] private GameObject healthDivPrefab;
    [SerializeField] private GameObject healthDivLayout;
    private List<GameObject> healthDivList;
    private Coroutine flashRoutine;


    public void SetMaxHealth(int maxHealth) {

        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        fill.color = gradient.Evaluate(1f);

        healthDivList = new List<GameObject>();
        healthDivList.Clear();

        int health_divider = maxHealth / 100;

        for (int i = 0; i < health_divider; i = i + 1)
        {
            GameObject new_health = Instantiate(healthDivPrefab);
            new_health.transform.SetParent(healthDivLayout.transform, false);
            healthDivList.Add(new_health);
        }
    }

    public void SetCurrentHealth(int currentHealth) {

        if(slider.value > currentHealth)
        {
            Flash();
        }
        else
        {
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
        
        slider.value = currentHealth;
    }

    public void DecreaseMaxHealth(int currentHealth, int maxHealth) {

        slider.maxValue = maxHealth;

        SetCurrentHealth(currentHealth);

        GameObject toRemove = healthDivList[healthDivList.Count - 1];
        healthDivList.Remove(toRemove);
        Destroy(toRemove);
    }

    public void IncreaseMaxHealth(int currentHealth, int maxHealth) {

        slider.maxValue = maxHealth;

        SetCurrentHealth(maxHealth);
        
        GameObject healthDiv = Instantiate(healthDivPrefab);
        healthDiv.transform.SetParent(healthDivLayout.transform, false);
        healthDivList.Add(healthDiv);
    }

    public void Flash() {

        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
            
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine() {

        fill.color = Color.magenta;

        yield return new WaitForSeconds(0.1f);

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
