using Scripts.Skins;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BalanceBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private float _currentVelocity;

    private int _balance;
    public TMP_Text UpperBarText;
    public void SetInitialBalance(int maxBalance, int startBalance)
    {
        _slider.maxValue = maxBalance;
        _slider.value = startBalance;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);

    }

    private void Update()
    {
       var currentBalance = Mathf.SmoothDamp(_slider.value, _balance, ref _currentVelocity, 100 * Time.deltaTime);
        _slider.value = currentBalance;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
        UpperBarText.color = _gradient.Evaluate(_slider.normalizedValue);
    }

    public void ChangeBalanceBar(int balance)
    {
        _balance = balance;
    }
}
