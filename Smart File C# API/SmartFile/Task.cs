using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartFile
{
    public class Task
    {
        SmartFile.ClientHandler client;
        String APIendPoint;
        DateTime created;
        int status;
        string type;

        public Task(SmartFile.ClientHandler client, String APIendPoint, DateTime created, int status, string type)
        {
            this.client = client;
            this.APIendPoint = APIendPoint;
            this.created = created;
            this.status = status;
            this.type = type;
        }
    }
}
