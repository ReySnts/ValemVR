using System.Collections;
using UnityEngine;

public class RandomTrashSpawner : ObjectPool
{
    [SerializeField] private RandomSpawnPosition randomSpawnPosition;

    [SerializeField] private GameObject[] trashPrefabs;

    [SerializeField] private float maxDuration = 120f;

    [SerializeField] private float spawnDuration = 2.5f;

    protected override int MaximumSize => (int)(maxDuration / spawnDuration);

    private int RandomTrashIndex => Random.Range(minInclusive: 0, maxExclusive: trashPrefabs.Length);

    protected override void OnStart()
    {
        for (int i = 0; i < MaximumSize; i++)
        {
            var randomTrashPrefab = trashPrefabs[RandomTrashIndex];
            var trashGrabbable = randomTrashPrefab.GetComponent<TrashGrabbable>();
            var spawnedTrash = Instantiate(original: trashGrabbable, position: randomSpawnPosition.Value, rotation: Quaternion.identity, parent: transform);
            spawnedTrash.ObjectPool = this;
            Return(pooledObject: spawnedTrash);
        }
    }

    protected override void Start()
    {
        OnStart();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        Get();
        yield return new WaitForSeconds(spawnDuration);
        if (Time.time < maxDuration) StartCoroutine(Spawn());
    }
}