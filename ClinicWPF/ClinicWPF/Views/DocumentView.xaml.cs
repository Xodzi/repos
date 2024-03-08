using Aspose.Pdf;
using Aspose.Pdf.Text;
using ClinicWPF.Models;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;

namespace ClinicWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для DocumentView.xaml
    /// </summary>
    public partial class DocumentView : Window
    {
        public DocumentView(string pat_name, int doctor_id)
        {
            InitializeComponent();

            Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document("blank.pdf");

            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber("FIO PAT________________");
            pdfDocument.Pages.Accept(textFragmentAbsorber);
            TextFragmentCollection textFragmentCollection = textFragmentAbsorber.TextFragments;
            foreach (TextFragment textFragment in textFragmentCollection)
            {
                // Update text and other properties
                textFragment.Text = pat_name;
            }

            TextFragmentAbsorber textFragmentAbsorber1 = new TextFragmentAbsorber("число");
            pdfDocument.Pages.Accept(textFragmentAbsorber1);
            TextFragmentCollection textFragmentCollection1 = textFragmentAbsorber1.TextFragments;
            foreach (TextFragment textFragment1 in textFragmentCollection1)
            {
                // Update text and other properties
                textFragment1.Text = DateTime.Now.Date.Day.ToString();
            }

            TextFragmentAbsorber textFragmentAbsorber2 = new TextFragmentAbsorber("месяц");
            pdfDocument.Pages.Accept(textFragmentAbsorber2);
            TextFragmentCollection textFragmentCollection2 = textFragmentAbsorber2.TextFragments;
            foreach (TextFragment textFragment2 in textFragmentCollection2)
            {
                // Update text and other properties
                textFragment2.Text = DateTime.Now.Date.Month.ToString();
            }

            TextFragmentAbsorber textFragmentAbsorber3 = new TextFragmentAbsorber("год");
            pdfDocument.Pages.Accept(textFragmentAbsorber3);
            TextFragmentCollection textFragmentCollection3 = textFragmentAbsorber3.TextFragments;
            foreach (TextFragment textFragment3 in textFragmentCollection3)
            {
                // Update text and other properties
                textFragment3.Text = DateTime.Now.Date.Year.ToString();
            }

            TextFragmentAbsorber textFragmentAbsorber4 = new TextFragmentAbsorber("..................................................................");
            pdfDocument.Pages.Accept(textFragmentAbsorber4);
            TextFragmentCollection textFragmentCollection4 = textFragmentAbsorber4.TextFragments;
            foreach (TextFragment textFragment4 in textFragmentCollection4)
            {
                // Update text and other properties
                textFragment4.Text = "";
            }

            TextFragmentAbsorber textFragmentAbsorber5 = new TextFragmentAbsorber("FIO DOC______________");
            pdfDocument.Pages.Accept(textFragmentAbsorber5);
            TextFragmentCollection textFragmentCollection5 = textFragmentAbsorber5.TextFragments;
            using (ClinicSystemContext db = new ClinicSystemContext())
            {
                var temp = db.Doctors.Where(x => x.Id == doctor_id).FirstOrDefault();
                foreach (TextFragment textFragment5 in textFragmentCollection5)
                {
                    // Update text and other properties
                    textFragment5.Text = temp.Surname+ " " + temp.Name;
                }
            }
            TextFragmentAbsorber textFragmentAbsorber6 = new TextFragmentAbsorber("AGE PAG______");
            pdfDocument.Pages.Accept(textFragmentAbsorber6);
            TextFragmentCollection textFragmentCollection6 = textFragmentAbsorber6.TextFragments;
            using (ClinicSystemContext db = new ClinicSystemContext())
            {
                //var temp = db.Personals.Where();
                foreach (TextFragment textFragment6 in textFragmentCollection6)
                {
                    // Update text and other properties
                    textFragment6.Text = "22";
                }
            }



            pdfDocument.Save("new_blank.pdf");
            var document = new Document("new_blank.pdf");
            document.Save("temp.xps", Aspose.Pdf.SaveFormat.Xps);
            var doc = new XpsDocument("temp.xps",System.IO.FileAccess.ReadWrite);
            viewer.Document = doc.GetFixedDocumentSequence();
        }

    }
}
