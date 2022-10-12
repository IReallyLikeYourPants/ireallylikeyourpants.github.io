Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Title = "Please Select a File"
        OpenFileDialog1.InitialDirectory = "C:temp"
        OpenFileDialog1.ShowDialog()

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim strm As System.IO.Stream
        strm = OpenFileDialog1.OpenFile()
        Dim franco = OpenFileDialog1.FileName.ToString()
        Dim File1 As String = File.ReadAllText(franco)
        RichTextBox1.Text = File1

    End Sub
End Class
