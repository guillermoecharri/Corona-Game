using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerHealth.GetHealth() / playerHealth.GetHealthMax();
    }
}
