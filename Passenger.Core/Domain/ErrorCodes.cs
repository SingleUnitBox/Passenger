﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public static class ErrorCodes
    {
        public static string InvalidUsername => "invalid_username";
        public static string InvalidEmail => "invalid_email";
        public static string InvalidRole => "invalid_role";
        public static string InvalidPassword => "invalid_password";
    }
}
