using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragandDrop dragAndDrop = eventData.pointerDrag.GetComponent<DragandDrop>();
            if (dragAndDrop != null)
            {
                dragAndDrop.SetParentToReturnTo(transform); // Atualiza o pai para a �rea de drop
                dragAndDrop.transform.SetParent(transform); // Move a pe�a para a �rea de drop
            }
        }
    }
}