﻿using Hermes.Identity.Dto;
using System;
using System.Collections.Generic;

namespace Hermes.Identity.Auth
{
    public interface IJwtProvider
    {
        AuthDto Create(Guid userId, string role, string audience = null,
            IDictionary<string, IEnumerable<string>> claims = null);
    }
}