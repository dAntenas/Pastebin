﻿namespace Pastebin.Application.Interfaces.Authentication
{
    public interface IPasswordHasher
    {
        public string Generate(string password);

        public bool Verify(string password, string hashedPassword);
    }
}
