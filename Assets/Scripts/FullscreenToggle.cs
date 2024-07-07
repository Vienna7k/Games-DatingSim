using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    private Toggle fullscreenToggle;

    void Start()
    {
        fullscreenToggle = GetComponent<Toggle>();

        // Configura o estado inicial do Toggle como ativo (modo tela cheia)
        fullscreenToggle.isOn = true;

        // Adiciona um listener para detectar mudanças no estado do Toggle
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
    }

    void OnFullscreenToggle()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
    }
}


