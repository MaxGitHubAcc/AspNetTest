using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestProject2.Models
{
    public class MessagesViewModel
    {
        public IEnumerable<Message> Messages { get; set; }
        public SelectList Users { get; set; }
        
    }
}