using CSharpFramework.com.cSharpFramework.PageObjectPages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using winjitAssessment.Utilities;
using WinjitAssessment.com.winjitAssessment.PageObjectPages;

namespace WinjitAssessment.com.winjitAssessment.TestCases
{
        public class TestCase_01 : BaseClass
    {
        [Test]
        public void dragAndDropTest()
        {
            DragAndDropPagePO dragAndDropObj = new DragAndDropPagePO(GetDriver());

            dragAndDropObj.dragAndDropMethod();
            string expected= dragAndDropObj.getFirstImage().GetAttribute("src");
            string actual = dragAndDropObj.getTrashImage().GetAttribute("src");
            Console.WriteLine(expected);
            Console.WriteLine(actual);

            Assert.True(expected.Equals(actual));           

        }

        [Test]
        public void dropDownTest()
        {       

            DropDownPO productShoppingPOObj = new DropDownPO(GetDriver());
            productShoppingPOObj.dropDownMethod();
            //String se1 = dropDown.GetAttribute("value");
            String str = productShoppingPOObj.getdropDown().GetAttribute("value");
            Assert.True(str.Equals(BaseClass.getJsonData("country")));        

        }

        [Test]
        public void samplePageTest()
        {
            SamplePagePO SamplePagePOObj = new SamplePagePO(GetDriver());
            SamplePagePOObj.samplePageMethod();
            String cnfMessage = SamplePagePOObj.getcnfMsg().Text;
            Assert.True(cnfMessage.Equals(BaseClass.getJsonData("cnfmsg")));
        }   

    }
}
