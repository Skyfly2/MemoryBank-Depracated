using System;

namespace MemoryBank
{
    public class Account
    {
        private static string username;
        private static string firstname;
        private static string lastname;
        private static string email;

        public Account()
        {
        }

        // Current Login Session
        public static void SetSession(string user, string first, string last, string em)
        {
            username = user;
            firstname = first;
            lastname = last;
            email = em;

        }

        // End Current Session
        public static void DestroySession()
        {
            username = null;
            firstname = null;
            lastname = null;
            email = null;
        }

        public static string First()
        {
            return firstname;
        }

        public static string Last()
        {
            return lastname;
        }

        public static string User()
        {
            return username;
        }

        public static string Email()
        {
            return email;
        }
    }
}
