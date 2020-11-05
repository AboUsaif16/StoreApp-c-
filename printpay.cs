using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace allN1
{
    public partial class printpay : Form
    {
        readonly string connectionString;
        SqlConnection connection;
        public printpay()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["allN1.Properties.Settings.DBConnectionString"].ConnectionString;
        }

        private void Printpay_Load(object sender, EventArgs e)
        {

        }
        private void FindAndReplace(Word.Application wordApp, object findText, object replaceWithText)
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
        private void printmotalba(object filename, object savaAs)
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
                FindAndReplace(wordApp, "<date>", date.Text);
                FindAndReplace(wordApp, "<pay>", pay.Text);
                FindAndReplace(wordApp, "<name>", user.Text);
                



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
                time_now.Text = "الحالة : "+"جارى طباعة الإيصال";
                aDoc.PrintOut(ref oTrue, ref oFalse, ref range, ref oMissing, ref oMissing, ref oMissing, ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue, ref oMissing, ref oFalse, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                //Close Document:
                time_now.Text = "الحالة : " + "تمت الطباعة";
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
            time_now.Text = "الحالة : " + "متصل";

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                String quary = "select payment , CONVERT (varchar(10), date, 103) as d ,name from logs_info join users on user_id = users.Id where logs_info.Id =" + int.Parse(id.Text);
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable payinfo = new DataTable();
                    adapter.Fill(payinfo);
                    DataRow[] rows = payinfo.Select();
                    user.Text = rows[0]["name"].ToString();
                    pay.Text = rows[0]["payment"].ToString();
                    date.Text = rows[0]["d"].ToString();



                }
                button1.Visible = true;
            }
            catch
            {
                MessageBox.Show("تأكد من رقم الإيصال");
                id.SelectAll();
                id.Focus();
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            time_now.Text = "جارى إنشاء الإيصال";
            string dd = date.Text.Replace("/", "-");
            string name_of_payment = "/payments/" + dd + "/" + user.Text + ".docx";
            // Specify the directory you want to manipulate.
            string path = Application.StartupPath + "/payments/" + dd;
            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
            }
            catch
            {
                time_now.ForeColor = Color.Red;
                time_now.Text = e.ToString();
            }
            printmotalba(Application.StartupPath + "/payment2.docx", Application.StartupPath + name_of_payment);
            button1.Visible = false;
            user.Text = pay.Text = date.Text = id.Text = "";
        }
        
    }
}
