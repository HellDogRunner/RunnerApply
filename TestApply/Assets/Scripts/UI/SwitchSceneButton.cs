using UnityEngine;
using UnityEngine.UI;

public class SwitchSceneButton : MonoBehaviour
{
    [SerializeField] SceneTransitionService _sceneTransitionService;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        _sceneTransitionService.SwichToScene("SecoundLevel");
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(HandleButtonClick);
    }
}
