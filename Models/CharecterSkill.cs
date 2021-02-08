namespace HellowWorld.Models
{
    public class CharecterSkill
    {
        public int CharecterId { get; set; }

        public Charecter charecters { get; set; }
        public int SkillId { get; set; }

        public Skill Skills { get; set; }
    }
}