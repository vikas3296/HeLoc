using System.Text;

namespace Heloc.Models
{
    public class LogFileModel
    {
        public LogFileModel(string filePath, bool isAppend, Encoding encoding, string textMessage)
        {
            FilePath = filePath;
            IsAppend = isAppend;
            EncodingType = encoding;
            TextString = textMessage;
        }
        public string FilePath { get; set; }
        public bool IsAppend { get; set; }
        public Encoding EncodingType { get; set; }
        public string TextString { get; set; }
    }
}
