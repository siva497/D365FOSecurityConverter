using D365FOSecurityConverter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private void ExportSecurityXMLFiles(string inputFilePath, string outputFolderPath)
        {
            List<SecurityLayer> securityLayerList = (List<SecurityLayer>)dgvSecurityLayers.DataSource;
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
            foreach (XmlNode role in roles)
            {
                string roleName = role["Name"]?.InnerText;
                if (roleName != null)
                {
                    SecurityLayer roleSecurityLayer = securityLayerList.FirstOrDefault(sl => sl.OldName == roleName && sl.Type == "Role");
                    if(roleSecurityLayer != null)
                    {
                        string fileName = roleFolderPath + @"\" + roleSecurityLayer.Name + @".xml";
                        string xml = ReplaceSecurityLayerParameters(role.OuterXml, roleSecurityLayer);
                        File.WriteAllText(fileName, xml);
                    }                
                }
            }
            XmlNodeList duties = xDoc.GetElementsByTagName("AxSecurityDuty");
            foreach (XmlNode duty in duties)
            {
                string dutyName = duty["Name"]?.InnerText;
                
                if (dutyName != null)
                {
                    SecurityLayer dutySecurityLayer = securityLayerList.FirstOrDefault(sl => sl.OldName == dutyName && sl.Type == "Duty");
                    if(dutySecurityLayer != null)
                    {
                        string fileName = dutyFolderPath + @"\" + dutySecurityLayer.Name + @".xml";
                        string xml = ReplaceSecurityLayerParameters(duty.OuterXml, dutySecurityLayer);
                        File.WriteAllText(fileName, xml);
                    }
                }

            }
            XmlNodeList privileges = xDoc.GetElementsByTagName("AxSecurityPrivilege");
            foreach (XmlNode privilege in privileges)
            {
                string privilegeName = privilege["Name"]?.InnerText;

                if (privilegeName != null)
                {
                    SecurityLayer privSecurityLayer = securityLayerList.FirstOrDefault(sl => sl.OldName == privilegeName && sl.Type == "Privilege");
                    if(privSecurityLayer != null)
                    {
                        string fileName = privFolderPath + @"\" + privSecurityLayer.Name + @".xml";
                        string xml = ReplaceSecurityLayerParameters(privilege.OuterXml, privSecurityLayer);
                        File.WriteAllText(fileName, xml);
                    }
                }
            }
        }

        private string ReplaceSecurityLayerParameters(string inputXml, SecurityLayer securityLayer)
        {
            string outputXml = inputXml;
            if(securityLayer.OldName != securityLayer.Name)
            {
                outputXml = outputXml.Replace("<Name>"+securityLayer.OldName+"</Name>", "<Name>" + securityLayer.Name + "</Name>");
            }
            if(securityLayer.OldLabel != securityLayer.Label)
            {
                outputXml = outputXml.Replace("<Label>" + securityLayer.OldLabel + "</Label>", "<Label>" + securityLayer.Label + "</Label>");
            }
            if(securityLayer.OldDescription != securityLayer.Description)
            {
                outputXml = outputXml.Replace("<Description>" + securityLayer.OldDescription + "</Description>", "<Description>" + securityLayer.Description + "</Description>");
            }
            return outputXml;
        }

        private List<SecurityLayer> ParseInputXML(string inputFilePath)
        {
            List<SecurityLayer> securityLayerList = new List<SecurityLayer>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(inputFilePath);
            XmlNodeList roles = xDoc.GetElementsByTagName("AxSecurityRole");
            foreach (XmlNode role in roles)
            {
                string roleName = role["Name"]?.InnerText;
                if (roleName != null)
                {
                    SecurityLayer sl = new SecurityLayer
                    {
                        OldName = roleName,
                        Name = roleName,
                        OldLabel = role["Label"]?.InnerText ?? "",
                        Label = role["Label"]?.InnerText ?? "",
                        OldDescription = role["Description"]?.InnerText ?? "",
                        Description = role["Description"]?.InnerText ?? "",
                        Type = "Role"
                    };
                    securityLayerList.Add(sl);
                }
            }

            XmlNodeList duties = xDoc.GetElementsByTagName("AxSecurityDuty");
            foreach (XmlNode duty in duties)
            {
                string dutyName = duty["Name"]?.InnerText;
                if(dutyName != null)
                {
                    SecurityLayer sl = new SecurityLayer
                    {
                        OldName = dutyName,
                        Name = dutyName,
                        OldLabel = duty["Label"]?.InnerText ?? "",
                        Label = duty["Label"]?.InnerText ?? "",
                        OldDescription = duty["Description"]?.InnerText ?? "",
                        Description = duty["Description"]?.InnerText ?? "",
                        Type = "Duty"
                    };
                    securityLayerList.Add(sl);
                }
            }

            XmlNodeList privileges = xDoc.GetElementsByTagName("AxSecurityPrivilege");
            foreach (XmlNode privilege in privileges)
            {
                string privilegeName = privilege["Name"]?.InnerText;
                if(privilegeName != null)
                {
                    SecurityLayer sl = new SecurityLayer
                    {
                        OldName = privilegeName,
                        Name = privilegeName,
                        OldLabel = privilege["Label"]?.InnerText ?? "",
                        Label = privilege["Label"]?.InnerText ?? "",
                        OldDescription = privilege["Description"]?.InnerText ?? "",
                        Description = privilege["Description"]?.InnerText ?? "",
                        Type = "Privilege"
                    };
                    securityLayerList.Add(sl);
                }
            }
            return securityLayerList;
        }

        private void btnExport_Click(object sender, EventArgs e)
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
                try
                {
                    ExportSecurityXMLFiles(inputFilePath, outputFolderPath);
                    MessageBox.Show("Processing of security has completed successfully!", "Security File Processed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Processing Security File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string inputFilePath = tb_inputFile.Text;

            if (!File.Exists(inputFilePath))
            {
                MessageBox.Show("Input file does not exist", "Error Processing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    dgvSecurityLayers.DataSource = ParseInputXML(inputFilePath);
                    dgvSecurityLayers.Columns["OldName"].Visible = false;
                    dgvSecurityLayers.Columns["OldLabel"].Visible = false;
                    dgvSecurityLayers.Columns["OldDescription"].Visible = false;
                    dgvSecurityLayers.Columns["Type"].ReadOnly = true;
                    dgvSecurityLayers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    if(tb_outputFolder.Text != "")
                        btn_Export.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Processing Security File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbInputFile_TextChanged(object sender, EventArgs e)
        {
            btn_Export.Enabled = false;
            if (tb_inputFile.Text == "")
                btn_Process.Enabled = false;
            else
                btn_Process.Enabled = true;

        }

        private void tbOutputFolder_TextChanged(object sender, EventArgs e)
        {
            if (tb_outputFolder.Text == "" || tb_inputFile.Text == "")
                btn_Export.Enabled = false;
            if (tb_outputFolder.Text != "" && dgvSecurityLayers.Rows.Count > 0)
                btn_Export.Enabled = true;
        }
    }
}
