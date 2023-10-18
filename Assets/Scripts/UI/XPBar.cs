using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    private static Slider XPBar_Slider;
    public TextMeshProUGUI PlayerLvlUI;
    public GameObject Player;
    private Text _PlayerLvlText;
    private PlayerData _player_data;
    public TextMeshProUGUI XPUI;

    public void SetXPBarValue(int value)
    {
        // Оновити досвід
        _player_data.exp += value;
        // Міняємо данні слайдера відповідно до данних гравця
        XPBar_Slider.value = _player_data.exp;
        XPBar_Slider.maxValue = _player_data.expForLvl;
        XPUI.text = _player_data.exp + "/" + _player_data.expForLvl;
        // Перевірити, чи досвід перевищив максимальне значення
        if (_player_data.exp >= XPBar_Slider.maxValue)
        {
            // Дізнаємось залишок рівня після його підняття
            int excessExp = _player_data.exp - (int)XPBar_Slider.maxValue;

            // Збільшити рівень і оновити досвід
            LevelUp(excessExp);
        }
    }


    private void LevelUp(int excessExp)
    {
        // Збільшити рівень на 1
        _player_data.level += 1;

        // Оновити досвід на залишок після рівня
        _player_data.exp = excessExp;

        // Оновити відображення рівня
        PlayerLvlUI.text = _player_data.level.ToString();

        // Оновити слайдер з досвідом
        XPBar_Slider.value = _player_data.exp;
    }

    private void Start()
    {
        // Получаємо слайдер
        XPBar_Slider = GetComponent<Slider>();
        // Получаємо данні користувача
        _player_data = Player.GetComponent<PlayerData>();
    }
}