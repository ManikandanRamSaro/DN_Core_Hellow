using System.Collections.Generic;

namespace HellowWorld.Models
{
    public class Charecter
    {
        // prop -> variables short cut
        public int Id { get; set; }
        public string Name { get; set; }="Mani";
        public int HitPoints { get; set; } =100;
        public int Strength { get; set; } = 10;
        public int Defence { get; set; }=10;

        public int Intelligence { get; set; } =10;

        public RpgClass Class {get;set;}= RpgClass.Knight; 

        public User Users {get;set;}
        public Weapon Weapons { get; set; }
        public List<CharecterSkill> CharecterSkills { get; set; }
    }
}