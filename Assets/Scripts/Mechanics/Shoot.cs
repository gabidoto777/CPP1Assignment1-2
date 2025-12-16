using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Transform spawnPoint;

    public void Fire()
    {
        if (bombPrefab == null || spawnPoint == null)
        {
            Debug.LogError("Bomb prefab or spawn point not set!");
            return;
        }

        Instantiate(bombPrefab, spawnPoint.position, Quaternion.identity);
    }
}
