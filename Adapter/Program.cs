using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create XMLData.
            XMLData xmlData = new XMLData();
            xmlData.Data = "user_list";

            // Use the XMLData in the service.
            XMLService xmlService = new XMLService(xmlData);
            xmlService.UseData(); // Uses XMLData.

            // Convert that XMLData to JSONData via the adapter.
            XMLtoJSONAdapter xMLtoJSONAdapter = new XMLtoJSONAdapter(xmlData);

            // Use adapter as JSONData in a library that uses JSONData to work.
            AnalysticsLibrary analysticsLibrary = new AnalysticsLibrary(xMLtoJSONAdapter);
            analysticsLibrary.AnalyzeData(); // Uses JSON data.
        }
    }
    
    // A class replaces real XML data.
    class XMLData
    {
        public string Data { get; set; }
    }

    // A class replaces real JSON data.
    class JSONData
    {
        public string Data { get; set; }
    }

    // A service that uses XML to do work.
    class XMLService
    {
        private XMLData XMLData;
        public XMLService(XMLData xml)
        {
            XMLData = xml;
        }

        public void UseData()
        {
            // Use XMLData to do some work.
            Console.WriteLine("Using XML Data: {0}", XMLData.Data);
        }
    }

    // A library that uses JSONData to analyze.
    class AnalysticsLibrary
    {
        private JSONData JSONData;
        public AnalysticsLibrary(JSONData json)
        {
            JSONData = json;
        }

        public void AnalyzeData()
        {
            // Use JSONData and analyze.
            Console.WriteLine("Analyzing JSON Data: {0}", JSONData.Data);
        }
    }

    // An adapter that converts given XMLData to JSONData and is also a JSONData.
    class XMLtoJSONAdapter : JSONData
    {
        private XMLData XMLData;
        public XMLtoJSONAdapter(XMLData xml)
        {
            XMLData = xml;
            ConvertXMLtoJSON();
        }

        private void ConvertXMLtoJSON() 
        {
            // Convert XML to JSON
            this.Data = XMLData.Data;
        }
    }
}
