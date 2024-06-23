using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum States
{
    Poor = 5,
    Base = 10,
    Middle = 15,
    Buisiness = 30,
    Cocktail = 40
}

public class BalanceService : MonoBehaviour
{
    [SerializeField] int _moneyCost;
    [SerializeField] int _bottleCost;
    [SerializeField] int _greenDoorCost;
    [SerializeField] int _redDoorCost;

    [SerializeField] private int _currentBalance;
    [SerializeField] private int _maxBalance;

    private PlayerAnimationController _playerAnimationController;

    private Dictionary<int,States> _data = new Dictionary<int, States>()
    {
        {5 , States.Poor},
        {10 , States.Base},
        {15 , States.Middle},
        {30 , States.Buisiness},
        {40 , States.Cocktail},
    };

    [SerializeField] private States _currentState;
    [SerializeField] private States _lastState;
    public int Balance => _currentBalance;
    public int MaxBalance => _maxBalance;

    public event Action<int> OnBalanceChanged;
    public event Action<States> OnStateChanged;

    [Inject]
    private void Construct(PlayerAnimationController playerAnimationController)
    {
        _playerAnimationController = playerAnimationController;
    }
    public void ChangeBalance(string PickUpType) 
    {
        switch (PickUpType)
        {
            case "Money":
                _currentBalance += _moneyCost;
                _playerAnimationController.EmitPositiveParticles();
                break;
            case "Bottle":
                _currentBalance -= _bottleCost;
                _playerAnimationController.EmitNegativeParticles();
                if (_currentBalance < 0)
                {
                    _currentBalance = 0;
                }
                break;
            case "RedDoor":
                _currentBalance -= _redDoorCost;
                _playerAnimationController.EmitNegativeParticles();
                if (_currentBalance < 0)
                {
                    _currentBalance = 0;
                }
                break;
            case "GreenDoor":
                _currentBalance += _greenDoorCost;
                _playerAnimationController.EmitPositiveParticles();
                break;
        }
        foreach (var state in _data)
        {
            if (_currentBalance >= state.Key)
            {
                _currentState = state.Value;
            }
            if (_currentBalance <= ((int)States.Poor))
            {
                _currentState = States.Poor;
            }
        }
        OnBalanceChanged?.Invoke(_currentBalance);
        if (_lastState == _currentState)
        {
            return;
        }
        OnStateChanged?.Invoke(_currentState);
        _lastState = _currentState;
    }

}
