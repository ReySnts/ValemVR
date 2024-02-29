using System.Collections;
using UnityEngine;

public class RandomTrashSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] trashPrefabs;

    private readonly float duration = 20f;

    private int TrashIndex => Random.Range(0, trashPrefabs.Length);

    private float RandomX => Random.Range(-1.17f, 0.64f);

    private float RandomZ => Random.Range(-0.63f, 0.86f);

    private Vector3 SpawnPosition => new(RandomX, -0.29f, RandomZ);

    private IEnumerator Spawn()
    {
        Instantiate(original: trashPrefabs[TrashIndex], position: SpawnPosition, rotation: Quaternion.identity, parent: transform);
        yield return new WaitForSeconds(2.5f);
        if (Time.time < duration) StartCoroutine(Spawn());
    }

    private void Start() => StartCoroutine(Spawn());
}