using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PJII_projekt
{
    public partial class Form1 : Form
    {
        private AppSet h;
        private bool block = false;
        private int SIZE = 50;
        public Form1()
        {
            InitializeComponent();
            h = new AppSet(SIZE);
            refreshRows();
        }

        

        private void addButton_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            bool tmp;
            if (textOcc.Text == "YES")
            {
                tmp = true;
            }
            else tmp = false;

            int? p;
            if (textPrice.Text == "null" || textPrice.Text == "")
            {
                p = null;
            }
            else p = int.Parse(textPrice.Text);

            int? an;
            if (textNum.Text == "null" || textNum.Text == "")
            {
                an = null;
            }
            else an = int.Parse(textNum.Text);

            try
            {
            
                h.Add(new Appartment(an, p, textAddress.Text, tmp));
            }
            catch (System.FormatException)
            {
                label8.Visible = true;
            }
            refreshRows();
            clearTextBoxes();
            resetLabels();


        }



        public void refreshRows()
        {
            if (block)
            {
                return;
            }
            dataGridView1.Rows.Clear();
            foreach (Appartment a in h) {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = a.getAppNumber().ToString();
                
                dataGridView1.Rows[n].Cells[1].Value = a.getAddress();
                dataGridView1.Rows[n].Cells[2].Value = a.getPrice().ToString();
                dataGridView1.Rows[n].Cells[3].Value = a.getOccupied()? "YES":"NO";
            }
            if (dataGridView1.RowCount == SIZE)
            {
                label7.Visible = true;
                block = true;
            }
            else
            {
                label7.Visible = false;
                block = false;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0 || e.RowIndex >= dataGridView1.RowCount-1)
            {
                return;
            }
            int index = e.RowIndex;
            //Console.WriteLine(sender.ToString());
            textNum.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textAddress.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textPrice.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            textOcc.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            textNum.ReadOnly = true;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            int idx = -1;
            label8.Visible = false;
            try
            {
                idx = int.Parse(textNum.Text);
            }
            catch (System.FormatException) { }

            int a = -1;
            a = h.FindIndex(x => x.getAppNumber() == idx);
            if (a != -1 )
            {
                bool tmp;
                if (textOcc.Text == "YES")
                {
                    tmp = true;
                }
                else tmp = false;
                int? p;
                if (textPrice.Text == "null" || textPrice.Text == "")
                {
                    p = null;
                }
                else p = int.Parse(textPrice.Text);

                int? an;
                if (textNum.Text == "null" || textNum.Text == "")
                {
                    an = null;
                }
                else an = int.Parse(textNum.Text);
                try
                {

                    h[a] = new Appartment(an, p, textAddress.Text, tmp);
                }
                catch (System.FormatException)
                {
                    
                }
                
                
            }
            refreshRows();
            clearTextBoxes();
            resetLabels();
            textNum.ReadOnly = false;


        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            resetLabels();
            int idx = int.Parse(textNum.Text);

            h.Remove(h.Find(r => r.getAppNumber() == idx));
            refreshRows();
            clearTextBoxes();
        }
        public void clearTextBoxes()
        {
            resetLabels();
            textNum.Text = "";
            textAddress.Text = "";
            textPrice.Text = "";
            textOcc.Text = "";

        }


        public void exportXML(string path = "D:\\DATA\\data.xml")
        {
            resetLabels();
            DataSet data = new DataSet();

            DataTable table = new DataTable("ProjData");
            
            table.TableName = "Appartments";
            table.Columns.Add("AppNumber");
            table.Columns.Add("Address");
            table.Columns.Add("Price");
            table.Columns.Add("isOccupied");
            data.Tables.Add(table);

            foreach (Appartment a in h) {
                DataRow r = data.Tables[table.TableName].NewRow();
                if(a.getAppNumber() == null)
                {
                    r["AppNumber"] = "";
                }
                else r["AppNumber"] = a.getAppNumber().ToString();

                if (a.getPrice() == null)
                {
                    r["Price"] = "";
                }
                else r["Price"] = a.getPrice().ToString();
               
                r["Address"] = a.getAddress();
                r["isOccupied"] = a.occupiedTF();
                data.Tables[table.TableName].Rows.Add(r);
            }

            data.WriteXml(path);
           
        }

        public void importXML(string path = "D:\\DATA\\data.xml")
        {
            resetLabels();
            DataSet data = new DataSet("ProjData");
            data.ReadXml(path);
            Appartment a = null;
            bool tmp;
            try
            {
                foreach (DataRow r in data.Tables["Appartments"].Rows)
                {
                    if (r[3].ToString() == "true")
                    {
                        tmp = true;
                    }
                    else tmp = false;
                    int? p;
                    if (r[0].ToString() == "")
                    {
                        p = null;
                    }
                    else p = int.Parse(r[0].ToString());

                    int? an;
                    if (r[2].ToString() == "")
                    {
                        an = null;
                    }
                    else an = int.Parse(r[2].ToString());


                    a = new Appartment(p, an, r[1].ToString(), tmp);
                    h.Add(a);

                }
                refreshRows();
            }
            catch (System.NullReferenceException) { }
        }




        private void saveXML_Click(object sender, EventArgs e)
        {
            exportXML();
            label9.Visible = true;
        }

        private void loadXML_Click(object sender, EventArgs e)
        {
            importXML();
            label10.Visible = true;
        }


        public void resetLabels()
        {
            label9.Visible = false;
            label10.Visible = false;
        }
    }
}
