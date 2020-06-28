Imports System.ComponentModel
Imports System.Text
Imports System.Data
Imports System.Data.Odbc

Imports System.Net.Mail
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base

Public Class Form4
    Public Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        InitializeComponent()
        AddHandler TextEdit7.GotFocus, AddressOf Sombrear_Texto
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim Imagen As Bitmap = New Bitmap(My.Resources.Resource1.close__2_)
        Dim Icono As Icon = Icon.FromHandle(Imagen.GetHicon)
        Dim CadSQL As String
        Dim Comando As OdbcCommand
        Dim Registros As OdbcDataReader

        Dim args As New XtraMessageBoxArgs
        AddHandler args.Showing, AddressOf Me.args_Showing
        args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
        args.Buttons = New DialogResult() {DialogResult.OK}
        args.Icon = Icono

        If TextEdit7.Text.Trim.Length = 0 Then
            args.Text = "Especifique la cantidad de mensajes que se recargarán"

            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)
            TextEdit7.Focus()
            Exit Sub
        End If
        CadSQL = "insert into z_mensajes_recargas (z_fecha, z_mensajes, z_reiniciar) values('" & Format(DateEdit1.EditValue, "yyyy/MM/dd") & "', " & TextEdit7.EditValue & ", '" & IIf(CheckEdit1.Checked, "S", "N") & "')"
        Comando = New OdbcCommand(CadSQL)
        Comando.CommandText = CadSQL
        Comando.Connection = MiConexion
        Comando.CommandType = CommandType.Text
        Comando.ExecuteReader()
        If CheckEdit1.Checked Then
            CadSQL = "update z_mensajes_config set z_sms_restan = " & TextEdit7.EditValue & ", z_sms_fecha = '" & Format(DateEdit1.EditValue, "yyyy/MM/dd") & "'"
        Else
            CadSQL = "update z_mensajes_config set z_sms_restan = z_sms_restan + " & TextEdit7.EditValue & ", z_sms_fecha = '" & Format(DateEdit1.EditValue, "yyyy/MM/dd") & "'"
        End If
        Comando = New OdbcCommand(CadSQL)
        Comando.CommandText = CadSQL
        Comando.Connection = MiConexion
        Comando.CommandType = CommandType.Text
        Comando.ExecuteReader()

        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateEdit1.DateTime = Now.Date
        Me.AcceptButton = SimpleButton1
        Me.CancelButton = SimpleButton2
        RecuperarDatos()
    End Sub

    Sub RecuperarDatos()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim MiTabla As New DataTable

            Dim CadSQL As String = "select z_fecha, z_mensajes, if(z_reiniciar = 'S', 'Sí', 'No') from z_mensajes_recargas"
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text

            Dim Registros As OdbcDataReader = Comando.ExecuteReader
            MiTabla.Load(Registros)
            GridControl1.DataSource = MiTabla
            GridControl1.MainView = GridView1
            GridView1.Columns(0).Caption = "Fecha"
            GridView1.Columns(1).Caption = "Mensajes"
            GridView1.Columns(2).Caption = "Reinicio"
            GridView1.BestFitColumns()
            SimpleButton3.Enabled = GridView1.DataRowCount > 0

        Catch ex As Exception
            Dim Imagen As Bitmap = New Bitmap(My.Resources.Resource1.close__2_)
            Dim Icono As Icon = Icon.FromHandle(Imagen.GetHicon)

            Dim args As New XtraMessageBoxArgs
            AddHandler args.Showing, AddressOf Me.args_Showing
            args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
            args.Text = ex.Message
            args.Buttons = New DialogResult() {DialogResult.OK}
            args.Icon = Icono
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)

        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub args_Showing(sender As Object, e As XtraMessageShowingArgs)
        e.Buttons(DialogResult.OK).Text = "&Aceptar"
        e.Buttons(DialogResult.OK).ImageOptions.Image = My.Resources.Resource1.symbol_check_icon
        e.Buttons(DialogResult.OK).ImageOptions.Location = ImageLocation.MiddleLeft
        e.Buttons(DialogResult.OK).Font = MiFuente
        e.Form.Appearance.Font = MiFuente
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged

    End Sub

    Private Sub TextEdit7_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit7.EditValueChanged

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim Imagen As Bitmap = New Bitmap(My.Resources.Resource1.help)
        Dim Icono As Icon = Icon.FromHandle(Imagen.GetHicon)
        Dim args As New XtraMessageBoxArgs
        Dim args2 As New XtraMessageBoxArgs

        AddHandler args.Showing, AddressOf Me.args_Showing2
        args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
        args.Text = "Esta acción dejará 30 días de transacciones, el resto se eliminarán." & Environment.NewLine & "¿Desea continuar y eliminar el histórico?"
        args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
        args.Icon = Icono
        XtraMessageBox.SmartTextWrap = True
        Dim Respuesta As Integer = XtraMessageBox.Show(args)
        '. . . 
        If Respuesta = 2 Then Exit Sub

        Dim CadSQL As String = "delete from z_mensajes_recargas where z_registro <= '" & Format(DateAdd("M", -1, Now), "yyyy/MM/dd HH:mm:ss") & "'"
        Dim Comando2 As OdbcCommand = New OdbcCommand(CadSQL)
        Comando2.CommandType = CommandType.Text
        Comando2.Connection = MiConexion
        Comando2.ExecuteReader()

        RecuperarDatos()

    End Sub

    Private Sub args_Showing2(sender As Object, e As XtraMessageShowingArgs)
        e.Buttons(DialogResult.OK).Text = "&Si"
        e.Buttons(DialogResult.OK).ImageOptions.Image = My.Resources.Resource1.symbol_check_icon
        e.Buttons(DialogResult.OK).ImageOptions.Location = ImageLocation.MiddleLeft
        e.Buttons(DialogResult.OK).Font = MiFuente
        e.Buttons(DialogResult.Cancel).Text = "&Cancelar"
        e.Buttons(DialogResult.Cancel).ImageOptions.Image = My.Resources.Resource1.Undo_icon
        e.Buttons(DialogResult.Cancel).ImageOptions.Location = ImageLocation.MiddleLeft
        e.Buttons(DialogResult.Cancel).Font = MiFuente
        e.Form.Appearance.Font = MiFuente
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Me.Height = 409
        SimpleButton5.Visible = True
        GridControl1.Visible = True

    End Sub
End Class