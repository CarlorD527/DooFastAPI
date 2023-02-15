﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Application.Commons.Bases
{
    public class BaseResponse<T>
    {
            public bool isSucces { get; set; }

            public T? Data { get; set; }
        
            public string? Message { get; set; }
            public IEnumerable<ValidationFailure>? Errors { get; set; }

    }
}
