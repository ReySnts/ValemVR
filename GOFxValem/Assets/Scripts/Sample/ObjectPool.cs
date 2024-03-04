using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    private readonly Stack<PooledObject> objectStack = new();

    protected abstract int MaximumSize { get; }

    protected abstract void OnStart();

    protected abstract void Start();

    protected PooledObject Get()
    {
        if (objectStack.Count > 0)
        {
            var lastObjectInStack = objectStack.Pop();
            lastObjectInStack.gameObject.SetActive(true);
            return lastObjectInStack;
        }
        return null;
    }

    public void Return(PooledObject pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        objectStack.Push(pooledObject);
    }
}