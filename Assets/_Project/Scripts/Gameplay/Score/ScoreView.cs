using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.Score
{
    public sealed class ScoreView : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField] private TMP_Text _scoreText;

        private ScoreCounter _model;

        [Inject]
        public void Construct(ScoreCounter model)
        {
            _model = model;
        }

        public void Initialize()
        {
            _model.OnScoreChanged += UpdateVisualScore;
            UpdateVisualScore(_model.Score);
        }

        public void Dispose()
        {
            _model.OnScoreChanged -= UpdateVisualScore;
        }

        private void UpdateVisualScore(int currentScore) => _scoreText.text = currentScore.ToString();
    }
}