using SQLite;

namespace Playza.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string SelectedOptionsJson { get; set; } // checkboxes

        public string IconPath { get; set; } = "icon1.png";
    }
}