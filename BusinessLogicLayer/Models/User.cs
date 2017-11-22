using System;
using System.Collections.Generic;
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
        public IEnumerable<Role> Roles { get; set; }

        public string Name
        {
            get
            {
                Debug.Assert(name != null);
                return name;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("name", "Valid name is mandatory!");

                string oldValue = name;
                try
                {
                    name = value;
                }
                catch
                {
                    name = oldValue;
                    throw;
                }
            }
        }
        public string Surname
        {
            get
            {
                Debug.Assert(surname != null);
                return surname;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("surname", "Valid surname is mandatory!");

                string oldValue = surname;
                try
                {
                    surname = value;
                }
                catch
                {
                    surname = oldValue;
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
                    throw new ArgumentNullException("username", "Valid username is mandatory!");

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
