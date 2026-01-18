using System.Diagnostics;
using System.Text;

namespace MKLinkHelper_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LogText.ScrollBars = ScrollBars.Both;
            SelectFolders_fn.Multiselect = true;
            SelectFiles_fn.Multiselect = true;
            // Enable drag and drop for IN_Folders TextBox
            InputFolders.DragEnter += (s, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            };
            InputFolders.DragDrop += (s, e) =>
            { // Drad and drop can't be nulled, so no need to check for null
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var droppedPaths = ((string[])e.Data.GetData(DataFormats.FileDrop))
                        .Where(Directory.Exists)
                        .ToArray();
                    InputFolders.Text = '"' + string.Join("\";\"", droppedPaths) + '"';
                }
            };
            InputFiles.DragEnter += (s, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            };
            InputFiles.DragDrop += (s, e) =>
            { // Drad and drop can't be nulled, so no need to check for null
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var droppedPaths = ((string[])e.Data.GetData(DataFormats.FileDrop))
                        .Where(File.Exists)
                        .ToArray();
                    InputFiles.Text = '"' + string.Join("\";\"", droppedPaths) + '"';
                }
            };
            OutputFolders.DragEnter += (s, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            };
            OutputFolders.DragDrop += (s, e) =>
            { // Drad and drop can't be nulled, so no need to check for null
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var droppedPaths = ((string[])e.Data.GetData(DataFormats.FileDrop))
                        .Where(Directory.Exists)
                        .ToArray();
                    OutputFolders.Text = '"' + string.Join("\";\"", droppedPaths) + '"';
                }
            };
        }

        private void SelectFolders_bt_Click(object sender, EventArgs e)
        {
            DialogResult result = SelectFolders_fn.ShowDialog();
            if (result == DialogResult.OK)
            {
                InputFolders.Text = '"' + string.Join("\";\"", SelectFolders_fn.SelectedPaths) + '"';
            }
        }

        private void SelectFiles_bt_Click(object sender, EventArgs e)
        {
            SelectFiles_fn.Title = "Select Files";

            DialogResult result = SelectFiles_fn.ShowDialog();
            if (result == DialogResult.OK)
            {
                InputFiles.Text = '"' + string.Join("\";\"", SelectFiles_fn.FileNames) + '"';
            }
        }

		private void SelectOutputs_bt_Click(object sender, EventArgs e)
		{
            DialogResult result = SelectFolders_fn.ShowDialog();
            if (result == DialogResult.OK)
            {
                OutputFolders.Text = '"' + string.Join("\";\"", SelectFolders_fn.SelectedPaths) + '"';
			}
		}

		private static void RunCMDandLog(List<string> list_of_commands_to_run, TextBox LogText)
        {
            // Build a single command string; use " & " to run each command sequentially regardless of previous exit codes.
            // Append "2>&1" so stderr is redirected into stdout and we only need to read one stream.
            string combinedCommands = string.Join(" & ", list_of_commands_to_run);
            string arguments = "/c " + combinedCommands + " 2>&1";

            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8
            };

            using var proc = new Process { StartInfo = psi };
            try
            {
                proc.Start();

                // Read merged stdout/stderr synchronously on the UI thread.
                string? line;
                while ((line = proc.StandardOutput.ReadLine()) != null)
                {
                    LogText.AppendText(line + Environment.NewLine);
                    // Keep UI responsive while remaining single-threaded.
                    Application.DoEvents();
                }

                // Ensure the process has exited before returning.
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                LogText.AppendText("[EX] " + ex.Message + Environment.NewLine);
            }
        }

        private void CreateFoldersSymlinks_Click(object sender, EventArgs e)
        {
            // making list of cmd commands to run
            var list_of_commands_to_run = new List<string>();

            foreach (string input_folder in InputFolders.Text.Split(";", StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (string output_folder in OutputFolders.Text.Split(";", StringSplitOptions.RemoveEmptyEntries))
                {
                    string trimmed_input_folder = input_folder.Trim().Trim('"');
                    string trimmed_output_folder = output_folder.Trim().Trim('"');
                    if (Directory.Exists(trimmed_input_folder) && Directory.Exists(trimmed_output_folder))
                    {
                        // Create the junction command
                        string output_junction = Path.Combine(trimmed_output_folder, Path.GetFileName(trimmed_input_folder));
                        string cmd = $"mklink /D \"{output_junction}\" \"{trimmed_input_folder}\"";
                        list_of_commands_to_run.Add(cmd);
                    }
                }
            }
            RunCMDandLog(list_of_commands_to_run, LogText);
        }

        private void CreateFolderJucntions_Click(object sender, EventArgs e)
        {
            // making list of cmd commands to run
            var list_of_commands_to_run = new List<string>();
            foreach (string input_folder in InputFolders.Text.Split(";", StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (string output_folder in OutputFolders.Text.Split(";", StringSplitOptions.RemoveEmptyEntries))
                {
                    string trimmed_input_folder = input_folder.Trim().Trim('"');
                    string trimmed_output_folder = output_folder.Trim().Trim('"');
                    if (Directory.Exists(trimmed_input_folder) && Directory.Exists(trimmed_output_folder))
                    {
                        // Create the junction command
                        string output_junction = Path.Combine(trimmed_output_folder, Path.GetFileName(trimmed_input_folder));
                        string cmd = $"mklink /J \"{output_junction}\" \"{trimmed_input_folder}\"";
                        list_of_commands_to_run.Add(cmd);
                    }
                }
            }
            RunCMDandLog(list_of_commands_to_run, LogText);
        }

        private void CreateFileSymlinks_Click(object sender, EventArgs e)
        {
            // making list of cmd commands to run
            var list_of_commands_to_run = new List<string>();
            foreach (string input_file in InputFiles.Text.Split(";", StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (string output_folder in OutputFolders.Text.Split(";", StringSplitOptions.RemoveEmptyEntries))
                {
                    string trimmed_input_file = input_file.Trim().Trim('"');
                    string trimmed_output_folder = output_folder.Trim().Trim('"');
                    if (File.Exists(trimmed_input_file) && Directory.Exists(trimmed_output_folder))
                    {
                        // Create the symlink command
                        string output_symlink = Path.Combine(trimmed_output_folder, Path.GetFileName(trimmed_input_file));
                        string cmd = $"mklink \"{output_symlink}\" \"{trimmed_input_file}\"";
                        list_of_commands_to_run.Add(cmd);
                    }
                }
            }
            RunCMDandLog(list_of_commands_to_run, LogText);
        }

        private void CreateFileHardlinks_Click(object sender, EventArgs e)
        {
            // making list of cmd commands to run
            var list_of_commands_to_run = new List<string>();
            foreach (string input_file in InputFiles.Text.Split(";", StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (string output_folder in OutputFolders.Text.Split(";", StringSplitOptions.RemoveEmptyEntries))
                {
                    string trimmed_input_file = input_file.Trim().Trim('"');
                    string trimmed_output_folder = output_folder.Trim().Trim('"');
                    if (File.Exists(trimmed_input_file) && Directory.Exists(trimmed_output_folder))
                    {
                        // Create the hardlink command
                        string output_hardlink = Path.Combine(trimmed_output_folder, Path.GetFileName(trimmed_input_file));
                        string cmd = $"mklink /H \"{output_hardlink}\" \"{trimmed_input_file}\"";
                        list_of_commands_to_run.Add(cmd);
                    }
                }
            }
            RunCMDandLog(list_of_commands_to_run, LogText);
        }

        private void OutputLogToText_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Title = "Save LOG to Text File",
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                DefaultExt = "txt"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, LogText.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
