using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePasswdAsHash
{
    internal class User
    {
        private int id_;
        private string username_;
        private byte[] password_;
        private byte[] salt_;

        public User(int id_, string username_, byte[] password_, byte[] salt_)
        {
            this.id_ = id_;
            this.username_ = username_;
            this.password_ = password_;
            this.salt_ = salt_;
        }

        public int Id_ { get => id_; set => id_ = value; }
        public string Username_ { get => username_; set => username_ = value; }
        public string Password_ { get => Convert.ToBase64String(password_); }
        public string Salt_ { get => Convert.ToBase64String(salt_); }


        
    }
}
