using UnityEngine;

public enum TrashType
{
    Organic,
    NonOrganic,
    Toxic
}

public class Trash : MonoBehaviour
{
    public TrashType trashType;
}