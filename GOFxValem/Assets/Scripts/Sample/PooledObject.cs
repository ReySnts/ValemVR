using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPool ObjectPool { get; set; }

    public void Release() => ObjectPool.Return(this);
}