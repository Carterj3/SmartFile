using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartFile
{
    public class Permission
    {
        Boolean list;
        Boolean read;
        Boolean remove;
        Boolean write;

        public Permission(Boolean list, Boolean read, Boolean remove, Boolean write)
        {
            this.list = list;
            this.read = read;
            this.remove = remove;
            this.write = write;
        }

        public String listPermissions()
        {
            return null;
        }
    }
}
