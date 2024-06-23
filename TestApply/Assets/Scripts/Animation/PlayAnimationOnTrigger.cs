using UnityEngine;

public class PlayAnimationOnTrigger : MonoBehaviour
{
    [SerializeField] private Animation _animation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _animation.Play();
        }
    }
}
