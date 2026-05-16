using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.DTO;

public record AuthenticationResponse(Guid UserID, string? Email, string? PersonName, string? Gender,
        string? Token, bool success);

