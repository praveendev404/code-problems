using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSample.Models
{
    public class UIProfilePic
    {
        public int ProfilePicId { get; set; }
        public byte[] ProfileImage { get; set; }
    }
}