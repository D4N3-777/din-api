﻿namespace Din.Domain.Models.Dtos
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public string ErrorMessage { get; set; }
    }
}
