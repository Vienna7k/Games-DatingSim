using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameManagerQ : MonoBehaviour
{
    public static GameManagerQ Instance;

    public DragandDrop[] puzzlePieces;
    public Transform[] correctDropAreas;
    public Text timerText;  // Campo de texto para exibir o temporizador
    public GameObject winMessage;  // Objeto de mensagem de vit�ria
    public GameObject loseMessage;  // Objeto de mensagem de perda

    private float timeLimit = 10f;
    public bool gameEnded = false; // Vari�vel privada que indica se o jogo terminou


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(StartTimer());
    }

    public void CheckPuzzleCompletion()
    {
        bool isComplete = true;

        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (puzzlePieces[i].transform.parent != correctDropAreas[i])
            {
                isComplete = false;
                break;
            }
        }

        if (isComplete)
        {
            Debug.Log("Puzzle Complete!");
            ShowWinMessage();
        }
    }

    public bool IsCorrectDropArea(DragandDrop piece, Transform dropArea)
    {
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (puzzlePieces[i] == piece && correctDropAreas[i] == dropArea)
            {
                return true;
            }
        }
        return false;
    }

    private IEnumerator StartTimer()
    {
        float currentTime = timeLimit;

        while (currentTime > 0)
        {
            timerText.text = currentTime.ToString("0");
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        timerText.text = "0";
        CheckPuzzleCompletionOnTimeEnd();
    }

    private void CheckPuzzleCompletionOnTimeEnd()
    {
        bool isComplete = true;

        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (puzzlePieces[i].transform.parent != correctDropAreas[i])
            {
                isComplete = false;
                break;
            }
        }

        if (isComplete)
        {
            ShowWinMessage();
        }
        else
        {
            ShowLoseMessage();
            gameEnded = true; // Define o estado do jogo como terminado
        }
    }

    private void ShowWinMessage()
    {
        winMessage.SetActive(true);
        // Voc� pode adicionar mais l�gica aqui, como parar o jogo, etc.
    }

    private void ShowLoseMessage()
    {
        loseMessage.SetActive(true);
        // Voc� pode adicionar mais l�gica aqui, como parar o jogo, etc.
    }
}
