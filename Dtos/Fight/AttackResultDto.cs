namespace HellowWorld.Dtos.Fight
{
    public class AttackResultDto
    {
        public string Attacker { get; set; }
        public string Opponent { get; set; } 
        public string AttackerHP { get; set; }
        public string OpponentHP { get; set; }
        public int Damage { get; set; }
    }
}