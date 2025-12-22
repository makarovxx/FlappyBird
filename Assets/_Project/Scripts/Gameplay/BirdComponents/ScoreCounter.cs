namespace _Project.Scripts.Gameplay.BirdComponents
{
    public class ScoreCounter
    {
        public int Score { get; private set; }

        private void IncreaseScore() => Score++;
        
        private void ResetScore() => Score = 0;
    }
}