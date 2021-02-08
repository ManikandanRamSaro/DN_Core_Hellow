using System.Collections.Generic;

namespace HellowWorld.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Damage { get; set; }
        public List<CharecterSkill> CharecterSkills { get; set; }
    }
}