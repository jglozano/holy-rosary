using System;

namespace HolyRosary.Models
{
    public class RosaryViewModel
    {
        public DateTime Today { get; set; }
        public DateTime Yesterday { get; set; }
        public DateTime Tomorrow { get; set; }

        public string Day { get; set; }
        public string Title { get; set; }

        public MysteryViewModel[] Mysteries { get; set; }
    }

    public class MysteryViewModel  
    {
        public string Name { get; set; }
        public string Event { get; set; }
        public string Lesson { get; set; }
    }
}
