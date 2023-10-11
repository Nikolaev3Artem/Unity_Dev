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
    /// <summary>
    /// Sets the health bar value
    /// </summary>
    /// <param name="value">should be between 0 to 1</param>
    public void SetXPBarValue(int value)
    {
        // ������� �����
        _player_data.exp += value;
        XPBar_Slider.value = _player_data.exp;
        // ���������, �� ����� ��������� ����������� ��������
        if (_player_data.exp >= XPBar_Slider.maxValue)
        {
            int excessExp = _player_data.exp - (int)XPBar_Slider.maxValue;

            // �������� ����� � ������� �����
            LevelUp(excessExp);
        }
    }


    private void LevelUp(int excessExp)
    {
        // �������� ����� �� 1
        _player_data.level += 1;

        // ������� ����� �� ������� ���� ����
        _player_data.exp = excessExp;

        // ������� ����������� ����
        PlayerLvlUI.text = _player_data.level.ToString();

        // ������� ������� � �������
        XPBar_Slider.value = _player_data.exp;
    }


    public static float GetXPBarValue()
    {
        return XPBar_Slider.value;
    }

    /// <summary>
    /// Initialize the variable
    /// </summary>
    /// 
    private void Start()
    {
        XPBar_Slider = GetComponent<Slider>();
        _player_data = Player.GetComponent<PlayerData>();
    }
}