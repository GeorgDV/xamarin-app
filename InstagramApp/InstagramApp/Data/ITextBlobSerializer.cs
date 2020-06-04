using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramApp.Data
{
    public interface ITextBlobSerializer
    {
        string Serialize(object element);
        object Deserialize(string text, Type type);
    }
}
