using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TMPro;
using UnityEngine;

public class Save : MonoBehaviour
{
    [SerializeField] 
    private string _playerName;

    [SerializeField] 
    private Timer Timer;

    [SerializeField] 
    private TextMeshProUGUI _playerNameDisplay;

    [SerializeField] 
    private TextMeshProUGUI _numOfSaveDisplay;

    XmlWriter xmlWriter;
    XmlWriterSettings xml = new XmlWriterSettings
    {
        NewLineOnAttributes = true,
        Indent = true,
    };

    private int _numberOfSave = 1;

    public void ToSave()
    {
        string savePath = Path.Combine(Application.persistentDataPath, "savefile.xml");

        xmlWriter = XmlWriter.Create(savePath, xml);

        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("Data");
        WriteXML(xmlWriter, "PlayerName", _playerName);
        _playerNameDisplay.text = _playerName.ToString();
        WriteXML(xmlWriter, "GameTime", Timer.CurrentTime.ToString());
        WriteXML(xmlWriter, "SaveNumber", _numberOfSave.ToString());
        _numOfSaveDisplay.text = _numberOfSave.ToString();
        Timer.Load();
        xmlWriter.Close();
        _numberOfSave++;
    }

    private void Start()
    {
        XmlDocument saveFile = new XmlDocument();

        if (!System.IO.File.Exists(Application.persistentDataPath + "savefile.xml"))
        {
            string savePath = Path.Combine(Application.persistentDataPath, "savefile.xml");
            xmlWriter = xmlWriter = XmlWriter.Create(savePath, xml); ;
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteStartElement("PlayerName");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("GameTime");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("SaveNumber");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        LoadSave();
    }

    //Elouann m'a aidé pour cette partie (j'ai eu du mal)
    public void LoadSave()
    {
        XmlDocument saveFile = new XmlDocument();
        if (!System.IO.File.Exists(Application.dataPath + "/" + "ARGH" + ".xml")) return;
        saveFile.LoadXml(System.IO.File.ReadAllText(Application.dataPath + "/" + "ARGH" + ".xml"));

        string key;
        string value;

        foreach (XmlNode node in saveFile.ChildNodes[1])
        {
            key = node.Name;
            value = node.InnerText;
            switch (key)
            {
                case "PlayerName":
                    _playerNameDisplay.text = value;
                    break;

                case "GameTime":
                    Timer.PreviousTime = float.Parse(value);
                    break;

                case "SaveNumber":
                    _numOfSaveDisplay.text = value;
                    break;
            }
        }
    }

    static void WriteXML(XmlWriter writer, string key, string value)
    {
        writer.WriteStartElement(key);
        writer.WriteString(value);
        writer.WriteEndElement();
    }
}
