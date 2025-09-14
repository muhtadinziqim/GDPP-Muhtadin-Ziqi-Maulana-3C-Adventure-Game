using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;

    [SerializeField]
    private string _mainMenuSceneName;

    void Awake()
    {
        _inputManager.OnMainMenuInput += BackToMainMenu;
    }
    void OnDestroy()
    {
        _inputManager.OnMainMenuInput -= BackToMainMenu;
    }
    private void BackToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(_mainMenuSceneName);
    }
}
