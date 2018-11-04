using System.IO;
using System.Xml.Serialization;

namespace SPGunLocker
{
    // https://stackoverflow.com/questions/2434534/serialize-an-object-to-string
    public static class XmlUtil
    {
        public static T Deserialize<T>(this string toDeserialize)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader textReader = new StringReader(toDeserialize))
            {
                return (T)serializer.Deserialize(textReader);
            }
        }

        public static string Serialize<T>(this T toSerialize)
        {
            XmlSerializer serializer = new XmlSerializer(toSerialize.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }
}