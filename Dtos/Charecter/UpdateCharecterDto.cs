using HellowWorld.Models;

namespace HellowWorld.Dtos.Charecter
{
    public class UpdateCharecterDto
    {
          public int Id { get; set; }
        public string Name { get; set; }="Mani";
        public int HitPoints { get; set; } =100;
        public int Strength { get; set; } = 10;
        public int Defence { get; set; }=10;

        public int Intelligence { get; set; } =10;

        public RpgClass Class {get;set;}= RpgClass.Knight; 
    }
}