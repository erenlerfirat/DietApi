﻿using Entity.Abstract;

namespace Entity.Dtos
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
