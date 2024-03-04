using TMPro;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField] private TrashType trashType;

    private PopupTrigger popupTrigger;

    private TextMeshProUGUI tMP;

    private void Start()
    {
        popupTrigger = GetComponentInChildren<PopupTrigger>();
        tMP = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update() => tMP.text = popupTrigger.CollectedTrashType == trashType ? "BENAR!" : "SALAH!";
}