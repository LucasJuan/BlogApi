﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Dtos
{
    public class CommentCreateDto
    {
        public string Author { get; set; }
        public string Content { get; set; }
    }
}
