using UnityEngine;
using System.Xml.Serialization;
using System.IO;


public static class ReadWriteDataHelper
{    
    public static string ReadSingle(string path)
    {        
        XmlSerializer xmlser = new XmlSerializer(typeof(string));
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            try
            {
                return (string)xmlser.Deserialize(fs);
            }
            catch (System.Exception)
            {
                return "0";
            }
        }
    }
    //public static string[] Read(string path)
    //{
    //    XmlSerializer xmlser = new XmlSerializer(typeof(string));

    //    return null;
    //}
    public static void Write(string path, string data)
    {
        Debug.Log("Write");
        XmlSerializer xmlser = new XmlSerializer(typeof(string));
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            xmlser.Serialize(fs, data);
        }
    }
}
