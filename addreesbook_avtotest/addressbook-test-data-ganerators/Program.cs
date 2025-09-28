using WebAdressbokkTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;



string type = args[0];
int count = Convert.ToInt32(args[1]);
StreamWriter writer = new StreamWriter(args[2]);
string format = args[3];

if (type == "group")
{
    List<GroupData> groups = new List<GroupData>();
    for (int i = 0; i < count; i++)
    {
        groups.Add(new GroupData(TestBase.GenerateRandomString(10))
        {
            Header = TestBase.GenerateRandomString(10),
            Footer = TestBase.GenerateRandomString(10),
        });
    }



    if (format == "csv")
    {
        writeGroupsToCsvFile(groups, writer);
    }
    else if (format == "xml")
    {
        writeGroupsToXmlFile(groups, writer);
    }
    else if (format == "json")
    {
        writeGroupsToJsonlFile(groups, writer);
    }
    else
    {
        Console.WriteLine("Unrecognized format" + format);


    }

}
else if (type == "contact")
{
    List<ContactData> contacts = new List<ContactData>();
    for (int i = 0; i < count; i++)
    {
        contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
        {
            SecondName = TestBase.GenerateRandomString(10),
        });
    }

     if (format == "xml")
    {
        writeContactsToXmlFile(contacts, writer);
    }
    else if (format == "json")
    {
        writeContactsToJsonlFile(contacts, writer);
    }
    else
    {
        Console.WriteLine("Unrecognized format" + format);
    }
}
else
{
    Console.WriteLine("invalid type");
}



writer.Close();


static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
{
    foreach (GroupData group in groups)
    {
        writer.WriteLine(String.Format("${0};${1};${2}",
            group.Name,
            group.Header,
            group.Footer
            ));

    }

}

static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
{
    new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
}

static void writeGroupsToJsonlFile(List<GroupData> groups, StreamWriter writer)
{
    writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
}


static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
{
    new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
}

static void writeContactsToJsonlFile(List<ContactData> contacts, StreamWriter writer)
{
    writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
}