using UnityEngine;
using UnityEngine.UI;
using TMPro; // Certifique-se de que esta linha está aqui

public class PlayerNameManager : MonoBehaviour
{
    public TMP_InputField nameInputField; // Use TMP_InputField em vez de InputField
    public Button confirmButton;

    private string playerName;

    void Start()
    {
        // Atribuir manualmente se não estiverem no Inspetor
        if (nameInputField == null)
        {
            nameInputField = GameObject.Find("BarraDeDigitacao").GetComponent<TMP_InputField>();
        }

        if (confirmButton == null)
        {
            confirmButton = GameObject.Find("BotaoConfirmar").GetComponent<Button>();
        }

        confirmButton.onClick.AddListener(OnConfirmButtonClick);
    }

    void OnConfirmButtonClick()
    {
        playerName = nameInputField.text;
        Debug.Log("Player Name: " + playerName);

        // Armazenando o nome usando PlayerPrefs
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
    }

    public string GetPlayerName()
    {
        return playerName;
    }
}
