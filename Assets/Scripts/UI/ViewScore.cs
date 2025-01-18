using TMPro;
using UnityEngine;

public class ViewScore : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] TMP_Text _text;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += DisplayScore;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= DisplayScore;
    }

    private void DisplayScore(int score)
    {
        _text.text = score.ToString();
    }
}