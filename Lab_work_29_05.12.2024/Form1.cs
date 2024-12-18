namespace Lab_work_29_05._12._2024
{
    public partial class Form1 : Form
    {
        private string defaultSavePath = ""; 

        public Form1()
        {
            InitializeComponent();
            richTextBox1.Dock = DockStyle.Fill;
            defaultSavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 

        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "��������� ��������� (*.txt)|*.txt|����� � ������� rtf (*.rtf)|*.rtf|��� ����� (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName);
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ ��� �������� �����: " + ex.Message);
                }
            }
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "��������� ��������� (*.txt)|*.txt|����� � ������� rtf (*.rtf)|*.rtf";
            saveFileDialog.InitialDirectory = defaultSavePath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (saveFileDialog.FileName.EndsWith(".rtf"))
                    {
                        richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ ��� ���������� �����: " + ex.Message);
                }
            }
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog.Color;
            }
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog.Font;
            }
        }

        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                defaultSavePath = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
