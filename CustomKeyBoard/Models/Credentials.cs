using SQLite;

namespace CustomKeyBoard.Models
{

    public class Credentials
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Domain { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}