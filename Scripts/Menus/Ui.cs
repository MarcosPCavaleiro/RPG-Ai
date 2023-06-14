using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{

    public TextMeshProUGUI Text;
    public PlayerStats stats;

    void Start()
    {
        Text = FindAnyObjectByType<TextMeshProUGUI>();
    }


    public virtual void Update()
    {
        Text.text = "Vida atual: " + stats.currentHealth + "\nDano atual: " + stats.damage.baseValue;
    }
}
