﻿namespace ErrorAPI.DTO
{
    public class ErrorDto
    {
        public int Id { get; set; }
        public string ErrorCode { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
