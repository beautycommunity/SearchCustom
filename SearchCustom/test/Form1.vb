Imports ค้นหาข้อมูลสมาชิกลืมพกบัตร
Imports k.libary

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New Save_Log_CT.Save_Log("2558", "1020", "Data Source=ayud2.dyndns.info,1401;Initial Catalog=CMD-FX;User ID=sa;Password=0000", "Data Source=ayud2.dyndns.info,1401;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0000")

        frm.ShowDialog()

    End Sub
End Class
