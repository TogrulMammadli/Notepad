using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace NotePad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string FilePath = null;
        public MainWindow()
        {
            InitializeComponent();
            textbox.Focus();
            ButtonsUnvailable();
        }
        private void Status_Click(object sender, RoutedEventArgs e)
        {
            if (SttsButton.IsChecked == false)
            {
                SttsWindow.Visibility = Visibility.Collapsed;
            }
            else
            {
                SttsWindow.Visibility = Visibility.Visible;
            }
            StatusBar();

        }
        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            textbox.Undo();
        }
        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textbox.SelectedText);
        }
        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            textbox.SelectedText = Clipboard.GetText();
        }
        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textbox.SelectedText);
            textbox.SelectedText = "";
        }
        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            textbox.SelectAll();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int ind = textbox.CaretIndex;
            if (textbox.SelectedText.Length == 0)
            {
                if (textbox.Text.Length == textbox.CaretIndex)
                {
                    return;
                }
                textbox.Text = textbox.Text.Remove(textbox.CaretIndex, 1);
                textbox.CaretIndex = ind;
            }
            textbox.SelectedText = "";
        }
        private void textbox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            StatusBar();
            ButtonsUnvailable();

        }
        private void WordWrap_Click(object sender, RoutedEventArgs e)
        {
            if (wordwrapbutton.IsChecked == true)
            {
                scrll.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;

                textbox.TextWrapping = System.Windows.TextWrapping.Wrap;
                return;
            }
            textbox.TextWrapping = System.Windows.TextWrapping.NoWrap;
            scrll.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
        }
        private void Font_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FontDialog fontDialog = new System.Windows.Forms.FontDialog();
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textbox.FontFamily = new FontFamily(fontDialog.Font.Name);
                textbox.FontSize = fontDialog.Font.Size;


                textbox.FontWeight = (fontDialog.Font.Bold) ? FontWeights.Bold : FontWeights.Regular;
                textbox.FontStyle = (fontDialog.Font.Italic) ? FontStyles.Italic : FontStyles.Normal;

                TextDecorationCollection textDecorations = new TextDecorationCollection();
                if (fontDialog.Font.Underline)
                {
                    textDecorations.Add(TextDecorations.Underline);
                }
                if (fontDialog.Font.Strikeout)
                {
                    textDecorations.Add(TextDecorations.Strikethrough);
                }
                textbox.TextDecorations = textDecorations;

            }
        }
        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Copyrighted by Togrul Mammadli", "This is a copy of MS notepad",MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void SaveAsButton_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog SaveFiledialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };

            if (SaveFiledialog.ShowDialog() == true)
            {
                File.WriteAllText(SaveFiledialog.FileName, textbox.Text);
                App.Title = SaveFiledialog.SafeFileName;
                FilePath =  SaveFiledialog.FileName;
            }

        }
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            if (FilePath == null)
            {
                if (!string.IsNullOrWhiteSpace(textbox.Text))
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want save changes?", "Notepad", MessageBoxButton.YesNoCancel);
                    switch (result)
                    {
                        case MessageBoxResult.Cancel:

                            break;
                        case MessageBoxResult.Yes:
                            SaveButton_Click(sender, e);
                            break;
                        case MessageBoxResult.No:
                            OpenFile();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    OpenFile();
                }
            }
            else
            {
                if (textbox.Text != GetTextFromFile())
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want save changes?", "Notepad", MessageBoxButton.YesNoCancel);
                    switch (result)
                    {
                        case MessageBoxResult.Cancel:
                            break;
                        case MessageBoxResult.Yes:
                            SaveButton_Click(sender, e);
                            break;
                        case MessageBoxResult.No:
                            OpenFile();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    OpenFile();
                }
            }


        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FilePath == null)
            {
                this.SaveAsButton_Click(sender, e);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(File.Open(FilePath, FileMode.Open)))
                {
                    streamWriter.Write(textbox.Text);
                }
            }
        }
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            if (FilePath == null)
            {
                if (!string.IsNullOrWhiteSpace(textbox.Text))
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want save changes?", "Notepad", MessageBoxButton.YesNoCancel);
                    switch (result)
                    {
                        case MessageBoxResult.Cancel:
                            break;
                        case MessageBoxResult.Yes:
                            SaveButton_Click(sender, e);
                            ResetNotepad();

                            break;
                        case MessageBoxResult.No:
                            ResetNotepad();
                            break;
                        default:
                            break;
                    }
                    return;

                }

            }
            else
            {
                if (textbox.Text != GetTextFromFile())
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want save changes?", "Notepad", MessageBoxButton.YesNoCancel);
                    switch (result)
                    {
                        case MessageBoxResult.Cancel:
                            break;
                        case MessageBoxResult.Yes:
                            SaveButton_Click(sender, e);
                            ResetNotepad();

                            break;
                        case MessageBoxResult.No:
                            ResetNotepad();
                            break;
                        default:
                            break;
                    }
                    return;
                }
            }
            ResetNotepad();

        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (FilePath == null)
            {
                if (!string.IsNullOrWhiteSpace(textbox.Text))
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want save changes?", "Notepad", MessageBoxButton.YesNoCancel);
                    switch (result)
                    {
                        case MessageBoxResult.Cancel:

                            break;
                        case MessageBoxResult.Yes:
                            SaveButton_Click(sender, e);
                            App.Close();

                            break;
                        case MessageBoxResult.No:
                            App.Close();

                            break;
                        default:
                            break;
                    }
                    return;
                }
            }
            else
            {
                if (textbox.Text != GetTextFromFile())
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want save changes?", "Notepad", MessageBoxButton.YesNoCancel);
                    switch (result)
                    {
                        case MessageBoxResult.Cancel:
                            break;
                        case MessageBoxResult.Yes:
                            SaveButton_Click(sender, e);
                            App.Close();

                            break;
                        case MessageBoxResult.No:
                            App.Close();

                            break;
                        default:
                            break;
                    }
                    return;
                }
            }
            App.Close();
        }
        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };
            if (openFileDialog.ShowDialog() == true)
                textbox.Text = File.ReadAllText(openFileDialog.FileName);
            App.Title = openFileDialog.SafeFileName;
            FilePath = openFileDialog.FileName;
        }
        private void StatusBar()
        {
            int row = textbox.GetLineIndexFromCharacterIndex(textbox.CaretIndex);
            int col = textbox.CaretIndex - textbox.GetCharacterIndexFromLineIndex(row);
            SttsWindow.Text = $"Row: {row+1} Col: {col + 1}";
        }
        private void ButtonsUnvailable()
        {
            if (textbox.SelectedText.Length == 0)
            {
                CopyButton.IsEnabled = false;
                CutButton.IsEnabled = false;
            }
            else
            {
                CopyButton.IsEnabled = true;
                CutButton.IsEnabled = true;
            }
            if (Clipboard.GetText() == "")
            {
                PasteButton.IsEnabled = false;
            }
            else
            {
                PasteButton.IsEnabled = true;

            }
            if (textbox.Text.Length == textbox.CaretIndex)
            {
                DeleteButton.IsEnabled = false;
            }
            else
            {
                DeleteButton.IsEnabled = true;

            }
            if (textbox.CanUndo == false)
            {
                UndoButton.IsEnabled = false;
            }
            else
            {
                UndoButton.IsEnabled = true;

            }
        }
        private string GetTextFromFile()
        {
            using (StreamReader streamReader = new StreamReader(FilePath))
            {
                return streamReader.ReadToEnd();
            }

        }
        private void ResetNotepad()
        {
            textbox.Text = "";
            FilePath = null;

        }
        private void App_Closing(object sender, CancelEventArgs e)
        {

            if (FilePath == null)
            {
                if (!string.IsNullOrWhiteSpace(textbox.Text))
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want save changes?", "Notepad", MessageBoxButton.YesNoCancel);
                    switch (result)
                    {
                        case MessageBoxResult.Cancel:
                            e.Cancel = true;
                            break;
                        case MessageBoxResult.Yes:
                            SaveButton_Click(sender, new RoutedEventArgs());

                            break;
                        case MessageBoxResult.No:

                            break;
                        default:
                            break;
                    }
                    return;
                }
            }
            else
            {
                if (textbox.Text != GetTextFromFile())
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want save changes?", "Notepad", MessageBoxButton.YesNoCancel);
                    switch (result)
                    {
                        case MessageBoxResult.Cancel:
                            break;
                        case MessageBoxResult.Yes:
                            SaveButton_Click(sender, new RoutedEventArgs());

                            break;
                        case MessageBoxResult.No:

                            break;
                        default:
                            break;
                    }
                    return;
                }
            }
        }
        private void App_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.N))
            {
                NewButton_Click(sender, new RoutedEventArgs());
                Keyboard.ClearFocus();
            }
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.O))
            {
                OpenButton_Click(sender, new RoutedEventArgs());
                Keyboard.ClearFocus();

            }
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.S))
            {
                SaveButton_Click(sender, new RoutedEventArgs());
                Keyboard.ClearFocus();

            }



        }

    }
}




