using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloxmod.ApiLibrary.Models
{
    public class TrelloList
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool closed { get; set; }
        public string idBoard { get; set; }
        public int pos { get; set; }
        public bool subscribed { get; set; }
        public object softLimit { get; set; }
    }

    public class TrelloCard
    {
        public string id { get; set; }
        public bool closed { get; set; }
        public bool dueComplete { get; set; }
        public DateTime dateLastActivity { get; set; }
        public string desc { get; set; }
        public object due { get; set; }
        public object dueReminder { get; set; }
        public object email { get; set; }
        public string idBoard { get; set; }
        public List<object> idChecklists { get; set; }
        public string idList { get; set; }
        public int idShort { get; set; }
        public object idAttachmentCover { get; set; }
        public List<string> idLabels { get; set; }
        public bool manualCoverAttachment { get; set; }
        public string name { get; set; }
        public string pos { get; set; }
        public string shortLink { get; set; }
        public string shortUrl { get; set; }
        public object start { get; set; }
        public bool subscribed { get; set; }
        public string url { get; set; }
        public Cover cover { get; set; }
        public bool isTemplate { get; set; }
        public object cardRole { get; set; }
    }

    public class Cover
    {
        public object idAttachment { get; set; }
        public string color { get; set; }
        public object idUploadedBackground { get; set; }
        public string size { get; set; }
        public string brightness { get; set; }
        public object idPlugin { get; set; }
    }
}
