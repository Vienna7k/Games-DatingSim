using UnityEngine;
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour
{
    public Toggle fullscreenToggle; // Referência ao Toggle de tela cheia
    public Toggle resolution1920x1080Toggle; // Toggle para 1920x1080
    public Toggle resolution1280x720Toggle; // Toggle para 1280x720
    public Toggle resolution1024x768Toggle; // Toggle para 1024x768

    void Start()
    {
        // Define o estado inicial dos Toggles de resolução
        resolution1920x1080Toggle.isOn = false;
        resolution1280x720Toggle.isOn = false;
        resolution1024x768Toggle.isOn = false;

        // Adiciona listeners para detectar mudanças nos Toggles de resolução
        resolution1920x1080Toggle.onValueChanged.AddListener(delegate { OnResolutionToggleChanged(); });
        resolution1280x720Toggle.onValueChanged.AddListener(delegate { OnResolutionToggleChanged(); });
        resolution1024x768Toggle.onValueChanged.AddListener(delegate { OnResolutionToggleChanged(); });
    }

    void OnResolutionToggleChanged()
    {
        // Verifica se algum Toggle de resolução está selecionado
        if (resolution1920x1080Toggle.isOn || resolution1280x720Toggle.isOn || resolution1024x768Toggle.isOn)
        {
            // Desativa o Toggle de tela cheia
            fullscreenToggle.isOn = false;
            Screen.fullScreen = false;

            // Define a resolução baseada no Toggle selecionado
            if (resolution1920x1080Toggle.isOn)
            {
                Screen.SetResolution(1920, 1080, false);
            }
            else if (resolution1280x720Toggle.isOn)
            {
                Screen.SetResolution(1280, 720, false);
            }
            else if (resolution1024x768Toggle.isOn)
            {
                Screen.SetResolution(1024, 768, false);
            }
        }
        else
        {
            // Se nenhum Toggle de resolução estiver selecionado, ativa o modo tela cheia
            fullscreenToggle.isOn = true;
            Screen.fullScreen = true;
        }
    }
}
