using UnityEngine;

public class PopupTrigger : MonoBehaviour
{
    public TrashType CollectedTrashType { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        var trashGrabbable = other.GetComponent<TrashGrabbable>();
        if (trashGrabbable)
        {
            CollectedTrashType = trashGrabbable.TrashType;
            trashGrabbable.Release();
        }
    }
}