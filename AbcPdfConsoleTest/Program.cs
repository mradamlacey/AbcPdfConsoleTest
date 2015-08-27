using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebSupergoo.ABCpdf10;

namespace AbcPdfConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter the name of the output pdf file:");

            var fileName = System.Console.ReadLine();
            fileName = fileName.Replace(".pdf", "");
            fileName = fileName.Replace(".PDF", "");

            Doc theDoc = new Doc();
            theDoc.Rect.Inset(72, 144);
            theDoc.HtmlOptions.AddLinks = true;

            int theID;
            theID = theDoc.AddImageUrl("http://www.yahoo.com/");

            while (true)
            {
                theDoc.FrameRect();
                if (!theDoc.Chainable(theID))
                    break;
                theDoc.Page = theDoc.AddPage();
                theID = theDoc.AddImageToChain(theID);
            }

            for (int i = 1; i <= theDoc.PageCount; i++)
            {
                theDoc.PageNumber = i;
                theDoc.Flatten();
            }

            theDoc.Save(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), fileName + ".pdf"));
            theDoc.Clear();

        }
    }
}
