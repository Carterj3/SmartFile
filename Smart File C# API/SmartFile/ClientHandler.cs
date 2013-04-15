
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFile
{
    public class ClientHandler
    {
        BasicClient client;
        public static string YodelKey = "MkWmIqdJNKrrUYzbDGIacXmtrLCr4b";
        public static string YodelPassword = "An4Qbqc6AxjruGHgv2w5HSENZqcqzL";

        private string key;
        private string password;


        private string copiedPath = "";

        public ClientHandler(String key, String password)
        {
            this.key = key;
            this.password = password;

            client = new BasicClient(key, password);

        }
        public String[] getDirectory(String directory)
        {
            return null;
        }
        public Boolean newFolder(String directory, String folderName)
        {
            return false;
        }

        public Boolean rename(String oldPath, String newPath)
        {
            return false;
        }

        public Boolean move(String fromPath, String toPath)
        {
            return false;
        }

        public Boolean copy(String fromPath)
        {
            copiedPath = "fromPath";
            return true;
        }

        public Boolean paste(String toPath)
        {
            return move(copiedPath, toPath);
        }

        public Boolean remove(String path)
        {
            return false;
        }

        public Boolean info(String path)
        {
            return false;
        }

        public SmartFile.Task[] listTasks()
        {
            return null;
        }

        public Boolean modifyUser(String user, SmartFile.Permission permissions)
        {
            return false;
        }

        public Boolean modifyGroup(String user, SmartFile.Permission permissions)
        {
            return false;

        }

        public String tempLink(String path)
        {
            return null;
        }

    }
}
