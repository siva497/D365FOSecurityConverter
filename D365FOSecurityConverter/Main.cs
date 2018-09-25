using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace D365FOSecurityConverter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnInputFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = inputFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tb_inputFile.Text = inputFileDialog.FileName;
            }
        }

        private void btnOutputFolderBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = outputFolderDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                tb_outputFolder.Text = outputFolderDialog.SelectedPath;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string inputFilePath = tb_inputFile.Text;
            string outputFolderPath = tb_outputFolder.Text;

            if (!File.Exists(inputFilePath))
            {
                MessageBox.Show("Input file does not exist", "Error Processing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Directory.Exists(outputFolderPath))
            {
                MessageBox.Show("Output folder path does not exist", "Error Processing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string rootFolderPath = outputFolderPath + @"\D365FOCustomizedSecurity";
                string roleFolderPath = rootFolderPath + @"\AxSecurityRole";
                string dutyFolderPath = rootFolderPath + @"\AxSecurityDuty";
                string privFolderPath = rootFolderPath + @"\AxSecurityPrivilege";

                Directory.CreateDirectory(rootFolderPath);
                Directory.CreateDirectory(roleFolderPath);
                Directory.CreateDirectory(dutyFolderPath);
                Directory.CreateDirectory(privFolderPath);

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(inputFilePath);
                XmlNodeList roles = xDoc.GetElementsByTagName("AxSecurityRole");
                foreach(XmlNode role in roles)
                {
                    string roleName = role["Name"]?.InnerText;
                    if (roleName != null)
                    {
                        string fileName = roleFolderPath + @"\" + roleName + @".xml";
                        File.WriteAllText(fileName, role.OuterXml);
                    }
                }
                XmlNodeList duties = xDoc.GetElementsByTagName("AxSecurityDuty");
                foreach(XmlNode duty in duties)
                {
                    string dutyName = duty["Name"]?.InnerText;
                    if(dutyName != null)
                    {
                        string fileName = dutyFolderPath + @"\" + dutyName + @".xml";
                        File.WriteAllText(fileName, duty.OuterXml);
                    }
                    
                }
                XmlNodeList privileges = xDoc.GetElementsByTagName("AxSecurityPrivilege");
                foreach(XmlNode privilege in privileges)
                {
                    string privilegeName = privilege["Name"]?.InnerText;
                    if(privilegeName != null)
                    {
                        string fileName = privFolderPath + @"\" + privilegeName + @".xml";
                        File.WriteAllText(fileName, privilege.OuterXml);
                    }
                    
                }
                MessageBox.Show("Processing of security has completed successfully!", "Security Processed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
