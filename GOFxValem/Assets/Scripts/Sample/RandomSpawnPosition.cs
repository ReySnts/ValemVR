using UnityEngine;

public class RandomSpawnPosition : MonoBehaviour
{
    [SerializeField] private float minRandomX = -1.17f;

    [SerializeField] private float maxRandomX = 0.64f;

    [SerializeField] private float randomY = -0.29f;

    [SerializeField] private float minRandomZ = -0.63f;

    [SerializeField] private float maxRandomZ = 0.86f;

    private float RandomX => Random.Range(minInclusive: minRandomX, maxInclusive: maxRandomX);

    private float RandomZ => Random.Range(minInclusive: minRandomZ, maxInclusive: maxRandomZ);

    public Vector3 Value => new(RandomX, randomY, RandomZ);
}