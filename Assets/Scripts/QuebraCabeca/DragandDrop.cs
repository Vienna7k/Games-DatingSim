using UnityEngine;
using UnityEngine.EventSystems;

public class DragandDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 startPosition;
    public Transform parentToReturnTo = null;
    public CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!GameManagerQ.Instance.gameEnded) // Verifica se o jogo não terminou
        {
            startPosition = transform.position;
            parentToReturnTo = transform.parent;
            canvasGroup.blocksRaycasts = false; // Desabilita o recebimento de raycasts enquanto arrasta
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!GameManagerQ.Instance.gameEnded) // Verifica se o jogo não terminou
        {
            transform.position = Input.mousePosition; // Atualiza a posição do objeto para a posição do mouse
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // Reabilita o recebimento de raycasts ao soltar

        if (!GameManagerQ.Instance.gameEnded) // Verifica se o jogo não terminou
        {
            if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("DropArea"))
            {
                if (GameManagerQ.Instance.IsCorrectDropArea(this, eventData.pointerEnter.transform))
                {
                    transform.SetParent(eventData.pointerEnter.transform); // Ajuste para setar o pai
                    transform.position = eventData.pointerEnter.transform.position; // Posiciona no centro da área de drop
                }
                else
                {
                    transform.position = startPosition; // Retorna à posição inicial se não estiver sobre uma área correta
                }
            }
            else
            {
                transform.position = startPosition; // Retorna à posição inicial se não estiver sobre uma área de drop
            }

            // Notifica o GameManagerQ sobre a alteração na posição da peça
            GameManagerQ.Instance.CheckPuzzleCompletion();
        }
    }

    public void SetParentToReturnTo(Transform newParent)
    {
        parentToReturnTo = newParent;
    }
}
