using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeGenerator.Common;
using System.IO;

namespace CodeGenerator
{
    public partial class frmGenerator : Form
    {
        public frmGenerator()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        /// <summary>
        /// connnect and scan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Common.IDbInfo IDbIfo = (IDbInfo)new CodeGenerator.Common.MSSQLDbInfo();
            if (!IDbIfo.IsCanAccess())
            {
                MessageBox.Show("连接失败，请检查配置文件。", "提示");
                return;
            }

            IDbIfo = null;

            if (!string.IsNullOrEmpty(cboDbNames.SelectedItem + ""))
            {
                MSSQLDbInfo DbInfo = new CodeGenerator.Common.MSSQLDbInfo();
                string[] Tables = DbInfo.GetAllTableName(cboDbNames.SelectedItem + "");
                foreach (var item in Tables)
                {
                    ckListBoxTable.Items.Add(item);
                }
            }
        }

        private void frmGenerator_Load(object sender, EventArgs e)
        {
            //OutputDir
            string OutputDir = Common.ConfigOut.OutPutDirectory;
            if (!string.IsNullOrEmpty(OutputDir))
            {
                txtOutputPath.Text = OutputDir;
            }

            //Partial
            string Partial = Common.ConfigOut.Partial;
            if (Partial.ToLower().Contains("true"))
            {
                ckPrt.Checked = true;
            }

            //PropertyEvents
            string PropertyEvents = Common.ConfigOut.PropertyEvents;
            if (PropertyEvents.ToLower().Contains("true"))
            {
                ckPryEvt.Checked = true;
            }

            //Validation
            string Validation = Common.ConfigOut.Validation;
            if (Validation.ToLower().Contains("true"))
            {
                ckValida.Checked = true;
            }

            //NameSpace
            string NameSpace = Common.ConfigOut.NameSpace;
            if (!string.IsNullOrEmpty(NameSpace))
            {
                txtNameSpace.Text = NameSpace;
            }

            //combox
            Common.DBInfo DbInfo = new CodeGenerator.Common.MSSQLDbInfo();
            string[] DbNames = DbInfo.CanAccessDbName();
            foreach (var item in DbNames)
            {
                cboDbNames.Items.Add(item);
            }
            cboDbNames.SelectedItem = Common.ConfigOut.ConfigBase;

            //TemplateFile 
            List<string> list = Common.DBInfo.TemplateFiles;
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string FileName = list[i].Replace(DBInfo.CurreExcPath, "");
                    ckListBoxTpl.Items.Add(FileName);
                }
            }

        }

        //选择文件夹
        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath + "\\";
                txtOutputPath.Text = path;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ckListBoxTpl.Items.Count; i++)
            {
                if (checkBox1.Checked)
                {
                    ckListBoxTpl.SetItemChecked(i, true);
                }
                else
                {
                    ckListBoxTpl.SetItemChecked(i, false);
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ckListBoxTable.Items.Count; i++)
            {
                if (checkBox2.Checked)
                {
                    ckListBoxTable.SetItemChecked(i, true);
                }
                else
                {
                    ckListBoxTable.SetItemChecked(i, false);
                }
            }
        }

        //生成代码
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

    }
}
