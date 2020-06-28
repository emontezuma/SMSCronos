Imports System.ComponentModel
Imports System.Text
Imports System.Data
Imports System.Data.Odbc

Imports System.Net.Mail
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base

Public Class Form6
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Me.Close()
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RecuperarDatos()
    End Sub
    Sub RecuperarDatos()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim MiTabla As New DataTable

            Dim CadSQL As String = "select name from requesters order by name"
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text

            Dim Registros As OdbcDataReader = Comando.ExecuteReader
            MiTabla.Load(Registros)
            GridControl1.DataSource = MiTabla
            GridControl1.MainView = GridView1
            GridView1.Columns(1).Caption = "Nombre"
            SimpleButton1.Enabled = GridView1.DataRowCount > 0

        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        If SimpleButton1.Enabled Then
            'Presiono la tecla delete
            SimpleButton1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        MMCReqID = GridView1.GetRowCellValue(e.FocusedRowHandle, GridView1.Columns(0))
    End Sub
End Class