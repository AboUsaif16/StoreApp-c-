using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;


namespace allN1
{
    class printReport
    {
        public static void FindAndReplace(Word.Application wordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref findText,
                        ref matchCase, ref matchWholeWord,
                        ref matchWildCards, ref matchSoundLike,
                        ref nmatchAllForms, ref forward,
                        ref wrap, ref format, ref replaceWithText,
                        ref replace, ref matchKashida,
                        ref matchDiactitics, ref matchAlefHamza,
                        ref matchControl);
        }
        public static void print(object filename, object savaAs , string date , string pay , string user,string mony)
        {
            foreach (var process in Process.GetProcessesByName("WINWORD"))
            {
                process.Kill();
            }
            object missing = Missing.Value;
            Word.Application wordApp = new Word.Application();

            Word.Document aDoc = null;

            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;

                wordApp.Visible = false;

                aDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing);
                FindAndReplace(wordApp, "<date>", date);
                FindAndReplace(wordApp, "<pay>", pay);
                FindAndReplace(wordApp, "<name>", user);
                FindAndReplace(wordApp, "<mony>", mony);




                aDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
                aDoc.Activate();

                //Find and replace:

                object copies = "1";
                object pages = "";
                object range = Word.WdPrintOutRange.wdPrintAllDocument;
                object items = Word.WdPrintOutItem.wdPrintDocumentContent;
                object pageType = Word.WdPrintOutPages.wdPrintAllPages;
                object oTrue = true;
                object oFalse = false;
                object oMissing = Missing.Value;
                aDoc.PrintOut(ref oTrue, ref oFalse, ref range, ref oMissing, ref oMissing, ref oMissing, ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue, ref oMissing, ref oFalse, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                //Close Document:
                MessageBox.Show("تمت الطباعة");
                aDoc.SaveAs2(savaAs);
                aDoc.Close(ref missing, ref missing, ref missing);
                foreach (var process in Process.GetProcessesByName("WINWORD"))
                {
                    process.Kill();
                }

            }
            else
            {
                MessageBox.Show("file dose not exist.");
                return;
            }
            

        }
    }
}
