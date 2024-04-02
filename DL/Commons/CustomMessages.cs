using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Commons
{
    public class ResponseMessages
    {
        public const string USER_ADDED = "User registered successfully";
        public const string USER_DELETED = "User deleted successfully";

        public const string CATEGORY_ADDED = "Category registered successfully";
        public const string CATEGORY_DELETED = "Category deleted successfully";
    }

    public class ExceptionMessages
    {
        public const string USER_DOESNOT_EXIST = "User does not exist.";
        public const string USER_ALREADY_EXIST = "User already exists.";
        public const string INVALID_CREDENTIALS = "Invalid credentials.";
    }
}
