Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Public r As New Random
    Public sum As Double = 0
    Public count As Int32 = 0
    Public val1 As Int32 = 0
    Public val2 As Int32 = 0
    Public val3 As Int32 = 0
    Public val4 As Int32 = 0
    Public val5 As Int32 = 0
    Public val6 As Int32 = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim franco As Double = r.NextDouble
        count += 1
        sum += franco
        Me.RichTextBox1.AppendText(franco & vbCrLf)
        Me.TextBox1.Clear()
        Me.TextBox1.AppendText(vbCrLf & sum / count & vbCrLf)
        ProgressBar1.Maximum = count
        ProgressBar2.Maximum = count
        ProgressBar3.Maximum = count
        ProgressBar4.Maximum = count
        ProgressBar5.Maximum = count
        If franco >= 0.0 And franco <= 0.2 Then
            val1 += 1
            ProgressBar1.Increment(1)
        ElseIf franco > 0.2 And franco <= 0.4 Then
            val2 += 1
            ProgressBar2.Increment(1)
        ElseIf franco > 0.4 And franco <= 0.6 Then
            val3 += 1
            ProgressBar3.Increment(1)
        ElseIf franco > 0.6 And franco <= 0.8 Then
            val4 += 1
            ProgressBar4.Increment(1)
        ElseIf franco > 0.8 And franco <= 1.0 Then
            val5 += 1
            ProgressBar5.Increment(1)
        End If
        val6 = count
        PictureBox2.Height = 142 - (142 * (ProgressBar1.Value / ProgressBar1.Maximum))
        PictureBox3.Height = 142 - (142 * (ProgressBar2.Value / ProgressBar2.Maximum))
        PictureBox5.Height = 142 - (142 * (ProgressBar3.Value / ProgressBar3.Maximum))
        PictureBox7.Height = 142 - (142 * (ProgressBar4.Value / ProgressBar4.Maximum))
        PictureBox9.Height = 142 - (142 * (ProgressBar5.Value / ProgressBar5.Maximum))
        Label7.Text = val1
        Label8.Text = val2
        Label9.Text = val3
        Label10.Text = val4
        Label11.Text = val5
        Label13.Text = val6

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Timer1.Stop()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        count = 0
        sum = 0
        TextBox1.Clear()
        RichTextBox1.Clear()
        Label7.Text = 0
        Label8.Text = 0
        Label9.Text = 0
        Label10.Text = 0
        Label11.Text = 0
        Label13.Text = 0
        val1 = 0
        val2 = 0
        val3 = 0
        val4 = 0
        val5 = 0
        val6 = 0
        PictureBox2.Height = 142
        PictureBox3.Height = 142
        PictureBox5.Height = 142
        PictureBox7.Height = 142
        PictureBox9.Height = 142
        ProgressBar1.Value = 0
        ProgressBar2.Value = 0
        ProgressBar3.Value = 0
        ProgressBar4.Value = 0
        ProgressBar5.Value = 0

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            Timer1.Interval = 1000
        ElseIf ComboBox1.SelectedIndex = 1 Then
            Timer1.Interval = 300
        Else
            Timer1.Interval = 1
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub
End Class
