using UnityEngine;
using Zenject;

public class SimplePickup : MonoBehaviour
{
    private BalanceService _balanceService;
    private PlayerAnimationController _playerAnimationController;

    [Inject]
    private void Construct(BalanceService balanceService, PlayerAnimationController playerAnimationController)
    {
        _balanceService = balanceService;
        _playerAnimationController = playerAnimationController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Pickup(this.tag);
            Destroy(transform.parent.gameObject);
        }
    }

    private void Pickup(string PickUpType)
    {
        _balanceService.ChangeBalance(PickUpType);
    }
}
