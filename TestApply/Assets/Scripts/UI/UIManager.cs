using TMPro;
using UnityEngine;
using Zenject;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _balanceText;
    [SerializeField] private BalanceBar _balanceBar;
    [SerializeField] private GameObject _bottomUI;
    [SerializeField] private GameObject _looseScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _ingameUI;

    private BalanceService _balanceService;

    [Inject]
    private void Construct(BalanceService balanceService)
    {
        _balanceService = balanceService;
        _balanceService.OnBalanceChanged += ChangeBalanceText;
        _balanceService.OnBalanceChanged += ChangeBalanceBar;
    }

    private void Awake()
    {
        _balanceBar.SetInitialBalance(_balanceService.MaxBalance, _balanceService.Balance);
        _balanceText.gameObject.SetActive(false);
    }

    private void ChangeBalanceText(int balance) 
    {
        _balanceText.text = balance.ToString();
    }

    private void ChangeBalanceBar(int balance)
    {
        _balanceBar.ChangeBalanceBar(balance);
    }

    public void ShowWinScreen()
    {
        _winScreen.gameObject.SetActive(true);
    }

    public void ShowLooseScreen()
    {
        _looseScreen.SetActive(true);
        _balanceText.gameObject.SetActive(false);
        _balanceBar.gameObject.SetActive(false);
        _ingameUI.gameObject.SetActive(false);
    }

    public void HideBottomUI() 
    {
        _bottomUI.gameObject.SetActive(false);
    }

    public void ShowBalance()
    {
        _balanceText.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        _balanceService.OnBalanceChanged -= ChangeBalanceText;
        _balanceService.OnBalanceChanged -= ChangeBalanceBar;
    }
}

