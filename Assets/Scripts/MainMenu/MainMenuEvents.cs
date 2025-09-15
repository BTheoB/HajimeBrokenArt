using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private UIDocument _UIDocument;
    private Button _button;


    private void Awake()
    {
        _UIDocument = GetComponent<UIDocument>();
        _button = _UIDocument.rootVisualElement.Q("StartButton") as Button;
    }

    private void OnEnable()
    {
        _button.clicked += OnClickPlay;
    }

    private void OnDisable()
    {
        _button.clicked -= OnClickPlay;
    }


    private void OnClickPlay() {
        Debug.Log("yay go play");
        SceneManager.LoadScene("Stage1");
    }
}
