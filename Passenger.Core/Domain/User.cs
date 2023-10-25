using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class User
    {
        private static readonly Regex _nameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string UserName { get; protected set; }
        public string FullName { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        protected User()
        {
            
        }
        public User(Guid userId, string email, string username, string password, string salt, string role)
        {
            Id = userId;
            Email = email.ToLowerInvariant();
            UserName = username;
            Password = password;
            Salt = salt;
            Role = role;
            CreatedAt = DateTime.UtcNow;
        }
        public void SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Email cannot be empty");
            }
            if (Email == email)
            {
                return;
            }
            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetUsername(string username)
        {
            if (!_nameRegex.IsMatch(username))
            {
                throw new Exception($"Username is invalid");
            }
            UserName = username;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Password cannot be empty");
            }
            if (password.Length < 4)
            {
                throw new Exception("Password is too short. It has to be at least 4 characters long.");
            }
            if (password.Length > 100)
            {
                throw new Exception("Password is too long. It has to be no longer than 100 characters.");
            }
            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
