
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
        private BasicClient client;
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
        // Returns the name of every file and directory within a given path (directory)
        // Append F to the name if its a file
        // Append D to the file if its a directory
        public String[] getDirectory(String directory)
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

        // Creates a new folder in the given directory with the given foldername
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

        // Renames the given directory located at the oldPath to the newPath
        // From my understanding files count as directory so doing this on say /home/Text.txt would have the same effect on /home/Folder
        public Boolean rename(String oldPath, String newPath)
        {
            return false;
        }

        // Moves the given directory/file to the new path
        // This does the instant move
        public Boolean move(String fromPath, String toPath)
        {
            return false;
        }

        // Just stores the given path
        public Boolean copy(String fromPath)
        {
            copiedPath = "fromPath";
            return true;
        }

        // "Copies" the stored path to the new location
        // May need to check that it still exists
        public Boolean paste(String toPath)
        {
            return move(copiedPath, toPath);
        }

        // Deletes given folder/file
        public Boolean remove(String path)
        {
            return false;
        }

        // ? Returns all of the info about a given path/folder
        public String[] info(String path)
        {
            return null;
        }

        #region Last stuff
        // These stuff aren't currently accepting good parameters for what they do


        // Returns a task[] for all of the tasks that are ongoing
        // Purpose is so that under the task tab you can see what is happening 'under-the-hood'
        public SmartFile.Task[] listTasks()
        {
            return null;
        }

        // I'm hoping this can be used to add, modify, delete user
        // Permissions will currently have to be adjusted given how much can be specified
        public Boolean modifyUser(String user, SmartFile.Permission permissions)
        {
            return false;
        }

        
        public Boolean modifyGroup(String user, SmartFile.Permission permissions)
        {
            return false;

        }
        #endregion

        // Returns a temp link for the given path
        // Mainly meant to be used in co-junction with google document viewer
        public String tempLink(String path)
        {
            return null;
        }

    }
}
