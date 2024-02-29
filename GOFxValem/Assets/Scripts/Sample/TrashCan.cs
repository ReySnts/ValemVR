using TMPro;

public class TrashCan : Trash
{
    private PopupTrigger popupTrigger;

    private TextMeshProUGUI tMP;

    private void Start()
    {
        popupTrigger = GetComponentInChildren<PopupTrigger>();
        tMP = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update() => tMP.text = popupTrigger.trashType == trashType ? "BENAR!" : "SALAH!";
}