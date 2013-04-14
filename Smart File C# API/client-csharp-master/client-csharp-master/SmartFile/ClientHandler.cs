
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SmartFile
{
    public class ClientHandler
    {
        private static string YodelKey = "MkWmIqdJNKrrUYzbDGIacXmtrLCr4b";
        private static string YodelPassword = "An4Qbqc6AxjruGHgv2w5HSENZqcqzL";
        private static BasicClient client = new BasicClient(YodelKey, YodelPassword);

        private string copiedPath = "";

        public ClientHandler()
        {
        }
        public static String[] getDirectory(String directory)
        {
            Stream r = client.Get("path/info", directory).GetResponseStream();

            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(r, encode);
            StringBuilder s = new StringBuilder();
            char[] read = new char[256];
            int count = readStream.Read(read, 0, 256);

            while (count > 0)
            {
                s.Append(read);
                count = readStream.Read(read, 0, 256);
            }

            string str = s.ToString();
            return null;
        }
        public Boolean newFolder(String directory, String folderName)
        {
            Hashtable h = new Hashtable();
            h.Add(directory, folderName);
            Stream r = client.Post("path/info", null, h).GetResponseStream();

            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(r, encode);
            StringBuilder s = new StringBuilder();
            char[] read = new char[256];
            int count = readStream.Read(read, 0, 256);
            while (count > 0)
            {
                s.Append(read);
                count = readStream.Read(read, 0, 256);
            }
            string str = s.ToString();
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
