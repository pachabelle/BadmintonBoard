using System;

namespace BadmintonBoard.Player
{
    public class Player
    {
        private string m_firstName;
        private string m_lastName;

        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        public string FirstName
        {
            get => m_firstName;
            set
            {
                m_firstName = value;
                UpdateDisplayName();}
        }

        public string LastName
        {
            get => m_lastName;
            set
            {
                m_lastName = value;
                UpdateDisplayName();
            }
            
        }
        public int Grade { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string DisplayName { get; set; }

        void UpdateDisplayName()
        {
            DisplayName = FirstName + " " + LastName;
        }
    }
}
