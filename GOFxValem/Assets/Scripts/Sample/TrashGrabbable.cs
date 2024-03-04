using UnityEngine;

public class TrashGrabbable : PooledObject
{
    [field: SerializeField] public TrashType TrashType { get; private set; }
}