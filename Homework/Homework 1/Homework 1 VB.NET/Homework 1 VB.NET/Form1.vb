Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ProgressBar1.Value <> 100 Then
            ProgressBar1.Value += 10
        End If
        If ProgressBar1.Value = 100 Then
            Button1.BackColor = Color.Black
            Label10.Hide()
        ElseIf ProgressBar1.Value = 10 Then
            Label1.Hide()
        ElseIf ProgressBar1.Value = 20 Then
            Label2.Hide()
        ElseIf ProgressBar1.Value = 30 Then
            Label3.Hide()
        ElseIf ProgressBar1.Value = 40 Then
            Label4.Hide()
        ElseIf ProgressBar1.Value = 50 Then
            Label5.Hide()
        ElseIf ProgressBar1.Value = 60 Then
            Label6.Hide()
        ElseIf ProgressBar1.Value = 70 Then
            Label7.Hide()
        ElseIf ProgressBar1.Value = 80 Then
            Label8.Hide()
        ElseIf ProgressBar1.Value = 90 Then
            Label9.Hide()
        End If
    End Sub
End Class
