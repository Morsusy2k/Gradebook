using System;
using System.Diagnostics;

namespace Gradebook.BusinessLogicLayer.Models
{
    public class User
    {
        private string name { get; set; }
        private string surname { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private string email { get; set; }


        public User() { }

        public User(string name, string surname, string username, string password, string email, byte[] version)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Email = email;
            Version = version;
        }

        public int Id { get; set; }
        public byte[] Version { get; set; }

        public string Name
        {
            get
            {
                Debug.Assert(Name != null);
                return Name;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Name", "Valid Name is mandatory!");

                string oldValue = Name;
                try
                {
                    Name = value;
                }
                catch
                {
                    Name = oldValue;
                    throw;
                }
            }
        }
        public string Surname
        {
            get
            {
                Debug.Assert(Surname != null);
                return Surname;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Surname", "Valid Surname is mandatory!");

                string oldValue = Surname;
                try
                {
                    Surname = value;
                }
                catch
                {
                    Surname = oldValue;
                    throw;
                }
            }
        }
        public string Username
        {
            get
            {
                Debug.Assert(username != null);
                return username;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Username", "Valid username is mandatory!");

                string oldValue = username;
                try
                {
                    username = value;
                }
                catch
                {
                    username = oldValue;
                    throw;
                }
            }
        }
        public string Password
        {
            get
            {
                Debug.Assert(password != null);
                return password;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Password", "Valid password is mandatory!");

                string oldValue = password;
                try
                {
                    password = value;
                }
                catch
                {
                    password = oldValue;
                    throw;
                }
            }
        }
        public string Email
        {
            get
            {
                Debug.Assert(email != null);
                return email;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Email", "Valid email is mandatory!");

                string oldValue = email;
                try
                {
                    email = value;
                }
                catch
                {
                    email = oldValue;
                    throw;
                }
            }
        }
    }
}
