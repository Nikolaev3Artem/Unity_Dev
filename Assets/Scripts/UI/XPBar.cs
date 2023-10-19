using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    private static Slider XPBar_Slider;
    public int MaxToLevelUp;
    public TextMeshProUGUI PlayerLvlUI;
    public GameObject Player;
    private Text _PlayerLvlText;
    private PlayerData _player_data;
    public TextMeshProUGUI XPUI;

    public void SetXPBarValue(int value)
    {
        // ������� �����
        _player_data.exp += value;
        // ̳����� ����� �������� �������� �� ������ ������
        XPBar_Slider.value = _player_data.exp;
        XPBar_Slider.maxValue = _player_data.expForLvl;
        XPUI.text = _player_data.exp + "/" + _player_data.expForLvl;
        // ���������, �� ����� ��������� ����������� ��������
        if (_player_data.exp >= XPBar_Slider.maxValue)
        {
            // ĳ������� ������� ���� ���� ���� �������
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

        // змінюється макс кількість досвіду для лвл апа
        _player_data.expForLvl += 1;



    }

    private void Start()
    {
        // �������� �������
        XPBar_Slider = GetComponent<Slider>();
        // �������� ����� �����������
        _player_data = Player.GetComponent<PlayerData>();
    }
}