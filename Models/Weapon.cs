namespace HellowWorld.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Damage { get; set; }
        public Charecter charecter {get;set;}
        public int CharecterId { get; set; }
    }
}