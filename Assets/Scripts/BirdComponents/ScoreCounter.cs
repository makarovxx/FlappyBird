namespace BirdComponents
{
    public class ScoreCounter
    {
        public int Score { get; private set; } = 0;

        private void IncreaseScore() => Score++;
        
        private void ResetScore() => Score = 0;
    }
}