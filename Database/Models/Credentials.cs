using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace Database.Models
{
    public class Credentials
    {
        private volatile int disposed;

        private SecureString password;

        public string UserName { get; set; }

        public string Password
        {
            get
            {
                if (password == null)
                {
                    return String.Empty;
                }

                var unmanagedString = IntPtr.Zero;
                try
                {
                    unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(password);
                    return Marshal.PtrToStringUni(unmanagedString);
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    password = new SecureString();
                }

                var secureString = new SecureString();
                foreach (char ch in value)
                {
                    secureString.AppendChar(ch);
                }
                secureString.MakeReadOnly();
                password = secureString;
            }
        }

        public Credentials() { }

        public Credentials(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        ~Credentials()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref disposed, 1) != 0)
            {
                return;
            }

            if (disposing)
            {
                password.Dispose();
            }
        }
    }
}
