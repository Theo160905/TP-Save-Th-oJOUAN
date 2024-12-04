using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class Save : MonoBehaviour
{
    public void ToSave()
    {
        string savePath = Path.Combine(Application.persistentDataPath, "savefile.xml");
        Debug.Log(savePath);

        XmlWriterSettings xml = new XmlWriterSettings
        {
            NewLineOnAttributes = true,
            Indent = true,
        };

        XmlWriter xmlWriter = XmlWriter.Create(savePath, xml);

        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("Data");

                // xmlWriter.WriteElementString("playerScore", "100");

        xmlWriter.WriteEndElement();
        xmlWriter.WriteEndDocument();

    }
}
