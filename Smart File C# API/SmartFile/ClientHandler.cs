
using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace SmartFile
{
    public class ClientHandler
    {
        private BasicClient client;
        private WebClient c;
        public static string YodelKey = "MkWmIqdJNKrrUYzbDGIacXmtrLCr4b";
        public static string YodelPassword = "An4Qbqc6AxjruGHgv2w5HSENZqcqzL";

        private string address = "app.smartfile.com/api/2/";
        private string key;
        private string password;


        private string copiedPath = "";

        public ClientHandler(String key, String password)
        {
            this.key = key;
            this.password = password;

            client = new BasicClient(key, password);
            c = new WebClient();
            c.Headers["Authorization"] = "Basic " + 
                Convert.ToBase64String(Encoding.Default.GetBytes(this.key + ":" + this.password));
        }

        // Returns the name of every file and directory within a given path (directory)
        // Append F to the name if its a file
        // Append D to the file if its a directory

        public ArrayList getDirectory(String directory)
        {
            string s = address + "path/info/" + directory + "?children=on&format=xml";
            string res = c.DownloadString("https://" + s.Replace("//", "/"));
            XDocument doc = XDocument.Parse(res);
            var paths = from p in doc.Descendants("path")
                       select p.Value;
            ArrayList result = new ArrayList();
            foreach (string path in paths)
            {   
                if (!path.Equals(directory))
                {
                    result.Add(path);
                }
            }
            foreach (string path in paths)
            {   
                foreach (string el in getDirectory(path))
                    result.Add(el);
            }

            return result;
        }

        // Creates a new folder in the given directory with the given foldername
        public Boolean newFolder(String newPath)
        {
            try
            {
                var data = new NameValueCollection();
                data["path"] = newPath;
                string s = address + "path/oper/mkdir/" + newPath + "/";
                c.UploadValues("https://" + s.Replace("//", "/"), "POST", data);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        // Renames the given directory located at the oldPath to the newPath
        // From my understanding files count as directory so doing this on say /home/Text.txt would have the same effect on /home/Folder
        public Boolean rename(String from, String to)
        {
            try
            {
                var data = new NameValueCollection();
                data["src"] = from.Replace("//", "/");
                data["dst"] = to.Replace("//", "/");
                string s = address + "path/oper/rename/";
                c.UploadValues("https://" + s, "POST", data);

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        // Moves the given directory/file to the new path
        // This does the instant move
        public Boolean move(String from, String to)
        {
            var data = new NameValueCollection();
            data["src"] = from.Replace("//", "/");
            data["dst"] = to.Replace("//", "/");
            string s = address + "path/oper/move/";
            c.UploadValues("https://" + s, "POST", data);
            return false;
        }

        // Just stores the given path
        public Boolean copy(String fromPath)
        {
            copiedPath = fromPath;
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
            try
            {
                var data = new System.Collections.Specialized.NameValueCollection();
                data["path"] = path.Replace("//", "/");
                string s = address + "path/oper/remove/";
                c.UploadValues("https://" + s, "POST", data);
            }
            catch (Exception e)
            {

            }

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
