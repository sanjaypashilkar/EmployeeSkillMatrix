using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public Response()
        {
            Success = false;
            Message = string.Empty;
        }
    }
}
