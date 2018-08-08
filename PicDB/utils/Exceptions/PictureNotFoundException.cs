using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicDB.utils.Exceptions
{
    class PictureNotFoundException : Exception
    {
        public PictureNotFoundException()
        {
        }

        public PictureNotFoundException(string message)
        : base(message)
        {
        }

        public PictureNotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
