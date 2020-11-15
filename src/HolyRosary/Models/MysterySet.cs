namespace HolyRosary.Models
{
    public class MysterySet 
    {
        public string Name { get; set; }
        public string[] Days { get; set; }

        public Mystery[] Mysteries { get; set; }
    }
}
