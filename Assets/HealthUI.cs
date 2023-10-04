using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    private TMP_Text healthText;
    [SerializeField] Health playerHealth;

    // Start is called before the first frame update
    void Awake()
    {
        healthText = GetComponent<TMP_Text>();
        playerHealth.onGainHealth.AddListener(UpdateUI);
        playerHealth.onTakeDamage.AddListener(UpdateUI);
    }

    public void UpdateUI(int amount)
    {
        healthText.text = amount.ToString();
    }

}
 