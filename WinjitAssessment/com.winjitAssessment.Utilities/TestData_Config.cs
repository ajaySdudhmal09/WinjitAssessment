using AventStack.ExtentReports.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Interfaces;
using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinjitAssessment.com.winjitAssessment.Utilities
{
     public class TestData_Config
    {

        public string extractJsonData(String tokenName) {

            //String allJsonData= System.IO.File.ReadAllText(@"C:\Users\Ajay-PC\source\repos\WinjitAssessment\WinjitAssessment\TestData\TestDataFile.json");
            //var xy = File.ReadAllText(@"../../../TestData/TestDataFile.json", Encoding.Default); ;
            String allJsonData =File.ReadAllText(@"../../../TestData/TestDataFile.json", Encoding.Default);
            //= File.ReadAllText(@"C:\Users\Ajay-PC\source\repos\WinjitAssessment\WinjitAssessment\TestData\TestDataFile.json");
            // C: \Users\Ajay - PC\source\repos\WinjitAssessment\WinjitAssessment\TestData\TestDataFile.json
            //var obj=JToken.Parse(allJsonData);
            //return obj.SelectToken(tokenName).Value<string>();
            //return JToken.Parse(allJsonData)[tokenName].Value<string>();
            /*string deserialized = JsonConvert.DeserializeObject<string>(tokenName);
            string temp = deserialized.tokenname;*/
            //String allJsonData = File.ReadAllText("TestDataFile.json");
            var jsonObject= JToken.Parse(allJsonData);
            var xyz= jsonObject.SelectToken(tokenName).Value<string>();
            return jsonObject.SelectToken(tokenName).Value<string>();



        }
    }
}
