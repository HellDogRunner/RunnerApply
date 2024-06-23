using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    public void SetInitialBalance(int maxBalance, int startBalance)
    {
        _slider.maxValue = maxBalance;
        _slider.value = startBalance;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }

    public void ChangeBalanceBar(int balance)
    {
        _slider.value = balance;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}
