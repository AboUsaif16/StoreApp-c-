using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Text;

namespace allN1
{
    public partial class bill_info : Form

    {
        public static string Cd ;
        public static string billN = "";
        public static string gName = "";
        public static string gID = "";
        public static string sDate = "";
        public static string price = "";
        public static string tot = "";
        public static string sAmount = "";
        public static string uid = "";
        readonly string connectionString;
        SqlConnection connection;
        public bill_info()
        {
            InitializeComponent();
            //connectionString = "Server=DESKTOP-O9G3AES;Data Source = CORTEX; Initial Catalog = AppDB; Persist Security Info = True; User ID = sa; Password = 12345";
            connectionString = ConfigurationManager.ConnectionStrings["allN1.Properties.Settings.DBConnectionString"].ConnectionString;
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void Bill_info_Load(object sender, EventArgs e)
        {
            txtid.Text = Form1.useridSelected;
            txtuser.Text = Form1.usernameSelected;
            this.Text = "سجل فواتير  : " + txtuser.Text;
            ViewOrdersIds();
        }

        private void BillList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StringBuilder Quary = new StringBuilder();
                Quary.Append("select total_price  , (CONVERT(VARCHAR(10),date , 103)) as date from orders where order_id = ");
                Quary.Append(billList.SelectedValue);
                
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(Quary.ToString(), connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable bill_info = new DataTable();
                    adapter.Fill(bill_info);
                    DataRow[] rows = bill_info.Select();
                    txttotal.Text = rows[0]["total_price"].ToString();
                    txtdate.Text = rows[0]["date"].ToString();
                }

                ViewOrderInfo();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void ViewOrderInfo()
        {
            String quary = "select Sells.Id as [#],goods.name as [إسم الصنف] , Sells.amount as [الكمية] , Sells.sell_price as [سعر الوحده] , total_price as [السعر الكلى] , goods.Id from  Sells join goods on Sells.good_id = goods.Id  where order_id = @order_id ";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@order_id", billList.SelectedValue);
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                dataGridView1.DataSource = goods_info;
            }
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("هل تريد حذف الفاتورة؟ يرجى العلم ان الأصناف لن يتم إرجاعها إلى المخزن", "تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                MessageBox.Show("تم الحذف");
                delete();
                clean();
            }
            if (res == DialogResult.Cancel)
            {


            }
        }
        private void delete()
        {
            String quary = "alter table Sells nocheck constraint all ;delete from  orders where order_id = @order_id ;alter table Sells check constraint all ";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@order_id", billList.SelectedValue);


                command.ExecuteNonQuery();
            }

            ViewOrdersIds();

            dataGridView1.DataSource = null;
        }

        private void clean()
        {
            String quary = "alter table Sells nocheck constraint all ;delete from  orders where total_price IS NULL ;alter table Sells check constraint all ";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            ViewOrdersIds();
        }
        private void ViewOrdersIds()
        {
            String quary = "select * from orders where userId = " + int.Parse(txtid.Text);
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable bills_info = new DataTable();
                adapter.Fill(bills_info);
                billList.DisplayMember = "order_id";
                billList.ValueMember = "order_id";
                billList.DataSource = bills_info;

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show(this,"هل تريد إسترداد الصنف؟", "تحذير", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)

            {
                    try
                    {
                    int x  = dataGridView1.CurrentCell.RowIndex;
                    Cd = dataGridView1[0, x].Value.ToString();
                    gName =  dataGridView1[1, x].Value.ToString();
                    sAmount = dataGridView1[2, x].Value.ToString();
                    price = dataGridView1[3, x].Value.ToString();
                    tot = dataGridView1[4, x].Value.ToString();
                    gID = dataGridView1[5, x].Value.ToString();
                    sDate = txtdate.Text;
                    billN = billList.SelectedValue.ToString();
                    uid = txtid.Text;
                    goodReturn gRet = new goodReturn();
                    gRet.ShowDialog(this);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
            clean();
            ViewOrdersIds();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            status.Text = "جارى إنشاء الفاتورة";
            string name_of_bill = "/bills/" + txtuser.Text + "_" + billList.SelectedValue+".docx";
            Print(Application.StartupPath + "/fatora.docx", Application.StartupPath + name_of_bill, dataGridView1);
            foreach (var process in Process.GetProcessesByName("WINWORD"))
            {
                process.Kill();
            }
            status.Text = "";
            this.Close();
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

        private void FindAndReplacekashf(Word.Range wordApp, object findText, object replaceWithText)
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

            wordApp.Find.Execute(ref findText,
                        ref matchCase, ref matchWholeWord,
                        ref matchWildCards, ref matchSoundLike,
                        ref nmatchAllForms, ref forward,
                        ref wrap, ref format, ref replaceWithText,
                        ref replace, ref matchKashida,
                        ref matchDiactitics, ref matchAlefHamza,
                        ref matchControl);
        }
        private void Print(object filename, object savaAs, DataGridView DGV)
        {
            foreach(var process in Process.GetProcessesByName("WINWORD"))
                {
                process.Kill();
                }
            int rowcount = 0;
            object missing = Missing.Value;
            Word.Application wordApp = new Word.Application();

            Word.Document aDoc = null;

            if (File.Exists((string)filename))
            {
                if (DGV.Rows.Count != 0)
                {
                    rowcount = DGV.Rows.Count;
                    DateTime today = DateTime.Now;

                    object readOnly = false; //default
                    object isVisible = false;

                    wordApp.Visible = false;

                    aDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing, ref missing);
                    FindAndReplace(wordApp, "<date>", txtdate.Text);
                    FindAndReplace(wordApp, "<fatora>", billList.SelectedValue);
                    FindAndReplace(wordApp, "<name>", txtuser.Text);
                    aDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
                    aDoc.Activate();

                    //Find and replace:

                    int RowCount = DGV.Rows.Count;
                    int ColumnCount = DGV.Columns.Count;
                    Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];
                    //add rows  
                    int r = 0;
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        for (r = 0; r <= RowCount - 1; r++)
                        {
                            DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                        }
                        //end row loop  
                    }


                    string oTemp = "";
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        for (int c = 0; c <= ColumnCount - 1; c++)
                        {
                            oTemp = oTemp + DataArray[r, c] + "\t";
                        }
                    }

                    /*
                        for (r = 0; r <= 35 - RowCount - 1; r++)
                        {
                            for (int c = 0; c <= ColumnCount - 1; c++)
                            {
                                oTemp = oTemp + "" + "\t";
                            }
                        }
                        */
                    oTemp += "عدد الأصنـــاف : " + (rowcount).ToString() + " صنف" + "\t" + "\t" + "الاجمالي\t" + txttotal.Text;
                    //table format  
                    object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                    object ApplyBorders = true;
                    object AutoFit = true;
                    object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;
                    aDoc.Application.ActiveDocument.Characters.Last.Select();
                    aDoc.Application.Selection.Collapse();
                    dynamic oRange = aDoc.Content.Application.Selection.Range;
                    oRange.Text = oTemp;
                    oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount, Type.Missing, Type.Missing, ref ApplyBorders, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);
                    oRange.Select();


                    aDoc.Application.Selection.Tables[1].Select();
                    aDoc.Application.Selection.Tables[1].Rows.Height = 4;
                    aDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                    aDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                    aDoc.Application.Selection.Tables[1].Rows[1].Select();
                    aDoc.Application.Selection.InsertRowsAbove(1);
                    aDoc.Application.Selection.Tables[1].Rows[1].Select();
                    aDoc.Application.Selection.Tables[1].Range.BoldBi = 1;
                    aDoc.Application.Selection.Tables[1].Range.Font.NameBi = "Arial";
                    aDoc.Application.Selection.Tables[1].Range.Font.SizeBi = 16;
                    aDoc.Application.Selection.Tables[1].Range.Bold = 1;
                    aDoc.Application.Selection.Tables[1].Range.Font.Name = "Arial";
                    aDoc.Application.Selection.Tables[1].Range.Font.Size = 16;
                    aDoc.Application.Selection.Tables[1].Rows[1].Range.BoldBi = 1;
                    aDoc.Application.Selection.Tables[1].Rows[1].Range.Font.NameBi = "Arial";
                    aDoc.Application.Selection.Tables[1].Rows[1].Range.Font.SizeBi = 16;
                    aDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                    aDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Arial";
                    aDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 16;



                    //add header row manually  
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        aDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                    }





                    //table style  
                    aDoc.Application.Selection.Tables[1].set_Style("Table Grid");
                    aDoc.Application.Selection.Tables[1].Columns[2].Width = 60;
                    aDoc.Application.Selection.Tables[1].Columns[1].Width = 280;
                    aDoc.Application.Selection.Tables[1].Columns[3].Width = 110;
                    aDoc.Application.Selection.Tables[1].Columns[4].Width = 80;
                    aDoc.Application.Selection.Tables[1].Borders[Word.WdBorderType.wdBorderLeft].LineWidth = Word.WdLineWidth.wdLineWidth225pt;
                    aDoc.Application.Selection.Tables[1].Borders[Word.WdBorderType.wdBorderRight].LineWidth = Word.WdLineWidth.wdLineWidth225pt;
                    aDoc.Application.Selection.Tables[1].Borders[Word.WdBorderType.wdBorderTop].LineWidth = Word.WdLineWidth.wdLineWidth225pt;
                    aDoc.Application.Selection.Tables[1].Borders[Word.WdBorderType.wdBorderBottom].LineWidth = Word.WdLineWidth.wdLineWidth225pt;
                    aDoc.Application.Selection.Tables[1].Rows[1].Borders[Word.WdBorderType.wdBorderBottom].LineWidth = Word.WdLineWidth.wdLineWidth225pt;
                    aDoc.Application.Selection.Tables[1].Rows[rowcount + 2].Shading.BackgroundPatternColor = Word.WdColor.wdColorGray50;
                    aDoc.Application.Selection.Tables[1].Rows[rowcount + 2].Cells[2].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    aDoc.Application.Selection.Tables[1].Rows[1].Select();
                    aDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    foreach (Word.Section section in aDoc.Sections)
                    {

                        aDoc.TrackRevisions = false; //Disable Tracking for the Field replacement operation

                        //Get all Headers
                        Microsoft.Office.Interop.Word.HeadersFooters footers = section.Footers;

                        //Section headerfooter loop for all types enum WdHeaderFooterIndex. wdHeaderFooterEvenPages/wdHeaderFooterFirstPage/wdHeaderFooterPrimary;                          
                        //foreach (Microsoft.Office.Interop.Word.HeaderFooter footer in footers)
                        //{
                        //    var fields = footer.Range;

                        //    FindAndReplacekashf(fields, "<total>", label3.Text);


                        //}
                    }


                    object copies = "1";
                    object pages = "1";
                    object range = Word.WdPrintOutRange.wdPrintAllDocument;
                    object items = Word.WdPrintOutItem.wdPrintDocumentContent;
                    object pageType = Word.WdPrintOutPages.wdPrintAllPages;
                    object oTrue = true;
                    object oFalse = false;
                    object oMissing = Missing.Value;
                    status.Text = "جارى طباعة الفاتورة";
                    aDoc.PrintOut(ref oTrue, ref oFalse, ref range, ref oMissing, ref oMissing, ref oMissing, ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue, ref oMissing, ref oFalse, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                    status.Text = "تمت الطباعة";//Close Document:
                    aDoc.SaveAs2(savaAs);
                    aDoc.Close(ref missing, ref missing, ref missing);




                }
            }
            else
            {
                MessageBox.Show("file dose not exist.");
                return;
            }

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (NumChk(txt_search))
            {
                try
                {
                    String quary = "select * from orders where userId = " + int.Parse(txtid.Text) + " and order_id = " + int.Parse(txt_search.Text);
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(quary, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable bills_info = new DataTable();
                        adapter.Fill(bills_info);
                        billList.DisplayMember = "order_id";
                        billList.ValueMember = "order_id";
                        billList.DataSource = bills_info;

                    }
                }
                catch
                {
                    ViewOrdersIds();
                }
            }
            else
            {
                ViewOrdersIds();
            }
        }


        private bool NumChk(TextBox t)
        {
            if (!(Regex.IsMatch(t.Text, "^[0-9]+$")))
            {
                t.Text = "";
                t.SelectAll();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            txt_search.Clear();
            txt_search.Focus();
            txt_search.ForeColor = Color.DarkRed;
        }
    }
}


