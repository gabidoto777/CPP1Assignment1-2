using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}

