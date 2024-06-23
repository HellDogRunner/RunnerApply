using UnityEngine;
using Zenject;

public class GameService : MonoBehaviour
{
    [SerializeField] private FinishLevel _finishLevel;

    private BalanceService _balanceSerivce;
    private UIManager _uiManager;
    private PlayerMovementController _playerMovementController;
    private PlayerAnimationController _playerAnimationController;

    private bool IsGameLive;
    [Inject]
    private void Construct(BalanceService balanceService, UIManager uIManager, PlayerMovementController playerMovementController, PlayerAnimationController playerAnimationController)
    {
        _balanceSerivce = balanceService;
        _uiManager = uIManager;
        _playerMovementController = playerMovementController;
        _playerAnimationController = playerAnimationController;
        _balanceSerivce.OnBalanceChanged += LooseGame;
        _finishLevel.OnLevelFinished += WinGame;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && IsGameLive == false)
        {
            IsGameLive = true;
            _playerMovementController.IsAbleToMove(true);
            _uiManager.ShowBalance();
            _uiManager.HideBottomUI();
            _playerAnimationController.WalkAnimation(true);
        }
    }

    private void LooseGame(int balance) 
    {
        if (balance <= 0)
        {
            _uiManager.ShowLooseScreen();
            IsGameLive = false;
            _playerMovementController.IsAbleToMove(false);
            _playerAnimationController.DeathAnimation(true);
        }
    }

    private void WinGame()
    {
        IsGameLive = false;
        _uiManager.ShowWinScreen();
        _playerMovementController.IsAbleToMove(false);
        _playerAnimationController.DanceWinAnimation(true);
    }

    private void OnDestroy()
    {
        _balanceSerivce.OnBalanceChanged -= LooseGame;
        _finishLevel.OnLevelFinished -= WinGame;
    }
}
