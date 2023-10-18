using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private static Slider HPBar_Slider;
    public GameObject Player;
    private PlayerData _player_data;
    public TextMeshProUGUI HPUI;

    private void Start()
    {
        // Получаємо слайдер
        HPBar_Slider = GetComponent<Slider>();
        // Получаємо данні користувача
        _player_data = Player.GetComponent<PlayerData>();
        HPBar_Slider.value = _player_data.health;
        HPBar_Slider.maxValue = _player_data.maxHealth;
        HPUI.text = _player_data.health + "/" + _player_data.maxHealth;
    }
}
