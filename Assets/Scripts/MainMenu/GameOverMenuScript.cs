using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOverMenuScript : ToogleableMenuesScript
{
    private Button RejouerButton;
    private Button _QuitterButton;
    private Label ScoreNumber;
    private TextField PlayerNameTextField;
    private Button ValidationRegistryScore;

    public event Action OnClickRejouer;
    public event Action OnClickQuitter;

    protected override void Awake()
    {
        base.Awake();
        RejouerButton = _UIDocument.rootVisualElement.Q<Button>("RejouerButton");
        _QuitterButton = _UIDocument.rootVisualElement.Q<Button>("QuitterButton");
        ScoreNumber = _UIDocument.rootVisualElement.Q<Label>("ScoreNumber");
        PlayerNameTextField = _UIDocument.rootVisualElement.Q<TextField>("PlayerNameTextField");
        ValidationRegistryScore = _UIDocument.rootVisualElement.Q<Button>("ValidationRegistryScore");


        RejouerButton.clicked += () => OnClickRejouer?.Invoke();
        _QuitterButton.clicked += () => OnClickQuitter?.Invoke();
        ValidationRegistryScore.clicked += () => SaveScore();
    }

    public override void ShowWithAnim(int delayMs = 1)
    {
        ScoreNumber.text = ScoreManager.Instance.Score.ToString();
        base.ShowWithAnim(delayMs);
    }

    private void SaveScore()
    {

        string playerName = PlayerNameTextField.value.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("Nom du joueur vide !");
            return;
        }
        Debug.Log("Save avec le nom : " + playerName);
        ScorePersistanceManager.Instance.AddScore(
            playerName,
            ScoreManager.Instance.Score
        );

        // Désactiver le bouton pour éviter le spam
        PlayerNameTextField.SetEnabled(false);
        ValidationRegistryScore.SetEnabled(false);
    }


}
