using System;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public event Action OnLevelFinished;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnLevelFinished?.Invoke();
        }
    }
}
