using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    private Vector3 RandomizeIntensity = new Vector3(0.3f, 0, 0);


    void Start()
    {
        Destroy(gameObject, _destroyTime);

        transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x,RandomizeIntensity.x),
            Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y),
            Random.Range(-RandomizeIntensity.z, RandomizeIntensity.z));
    }
}
