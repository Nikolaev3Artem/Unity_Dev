using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    private static Slider XPBar_Slider;

    /// <summary>
    /// Sets the health bar value
    /// </summary>
    /// <param name="value">should be between 0 to 1</param>
    public void SetXPBarValue(int value)
    {
        XPBar_Slider.value += value;
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
    }
}