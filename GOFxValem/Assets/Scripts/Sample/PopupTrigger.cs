using UnityEngine;

public class PopupTrigger : MonoBehaviour
{
    public TrashType trashType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            trashType = other.GetComponent<TrashGrabbable>().trashType;
            Destroy(other);
        }
    }
}