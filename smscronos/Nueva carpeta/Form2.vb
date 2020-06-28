Imports System.ComponentModel
Imports System.Text
Imports System.Data
Imports System.Data.Odbc

Imports System.Net.Mail
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports System.Speech.Synthesis

Public Class Form2
    Dim Cambiando As Boolean = False
    Dim MiSecuencia
    Public Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        InitializeComponent()
        AddHandler TextEdit3.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit18.GotFocus, AddressOf Sombrear_Texto
    End Sub

    Sub CambiarBotones(Accion As Integer)
        If Cambiando Then
            If Accion = 1 And Not SimpleButton1.Enabled Then
                SimpleButton1.Enabled = True
                SimpleButton2.Enabled = True
            ElseIf Accion = 2 And SimpleButton1.Enabled Then
                SimpleButton1.Enabled = False
                SimpleButton2.Enabled = False
            End If
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RecuperarDatos()
    End Sub

    Sub RecuperarDatos()
        Me.Cursor = Cursors.WaitCursor
        Cambiando = False
        Try
            Dim MiTabla As New DataTable

            Dim CadSQL As String = "select id, area, carpeta from z_mensajes_carpetas order by area"
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text

            Dim Registros As OdbcDataReader = Comando.ExecuteReader
            MiTabla.Load(Registros)
            GridControl1.DataSource = MiTabla
            GridControl1.MainView = GridView1
            GridView1.Columns(0).Caption = "ID"
            GridView1.Columns(1).Caption = "Área"
            GridView1.Columns(2).Caption = "Carpeta"
            GridView1.Columns(0).Width = 5
            GridView1.Columns(1).Width = 30
            GridView1.Columns(2).Width = 50
            SimpleButton3.Enabled = GridView1.DataRowCount > 0
            SimpleButton4.Enabled = GridView1.DataRowCount > 0

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
        Cambiando = True

    End Sub

    Private Sub args_Showing(sender As Object, e As XtraMessageShowingArgs)
        e.Buttons(DialogResult.OK).Text = "&Aceptar"
        e.Buttons(DialogResult.OK).ImageOptions.Image = My.Resources.Resource1.symbol_check_icon
        e.Buttons(DialogResult.OK).ImageOptions.Location = ImageLocation.MiddleLeft
        e.Buttons(DialogResult.OK).Font = MiFuente
        e.Form.Appearance.Font = MiFuente
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If view Is Nothing Then
            Return
        End If
        MiSecuencia = GridView1.GetRowCellValue(e.FocusedRowHandle, GridView1.Columns(0))
        BuscarMensaje()
    End Sub

    Sub BuscarMensaje()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim CadSQL As String = "select * from z_mensajes_carpetas where id = " & Val(MiSecuencia)
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Dim Registros As OdbcDataReader = Comando.ExecuteReader
            If Registros.HasRows Then
                LabelControl1.Text = MiSecuencia
                TextEdit3.Text = ValNull(Registros!area, "A")
                TextEdit18.Text = Strings.Replace(Registros!carpeta, "/", "\")
            End If

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

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        LabelControl1.Text = ""
        TextEdit3.Text = ""
        TextEdit18.Text = ""
        TextEdit3.Focus()
        SimpleButton1.Enabled = True
        SimpleButton2.Enabled = True

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        BuscarMensaje()
        TextEdit3.Focus()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim Imagen As Bitmap = New Bitmap(My.Resources.Resource1.help)
        Dim Icono As Icon = Icon.FromHandle(Imagen.GetHicon)
        Dim args As New XtraMessageBoxArgs

        AddHandler args.Showing, AddressOf Me.args_Showing2
        args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
        args.Text = "Al eliminar este carpeta ya se considerará al momento de generar el mensaje por voz." & Environment.NewLine & "¿Desea continuar y eliminar a traducción?"
        args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
        args.Icon = Icono
        XtraMessageBox.SmartTextWrap = True
        Dim Respuesta As Integer = XtraMessageBox.Show(args)
        '. . . 
        If Respuesta = 2 Then Exit Sub

        Try
            Dim CadSQL As String = "delete from z_mensajes_carpetas where id = " & Val(LabelControl1.Text)
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.CommandText = CadSQL
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text

            Dim LineasAfectadas As Integer = Comando.ExecuteReader.RecordsAffected

        Catch ex As Exception
            AddHandler args.Showing, AddressOf Me.args_Showing
            args.Text = ex.Message
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)
        End Try
        RecuperarDatos()
        TextEdit3.Focus()

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

        If TextEdit3.Text.Trim.Length = 0 Then
            args.Text = "Especifique el área que desea monitorear"

            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)
            TextEdit3.Focus()
            Exit Sub
        End If
        If TextEdit18.Text.Trim.Length = 0 Then
            args.Text = "Especifique a carpeta dónde se guardará el audio"

            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)
            TextEdit18.Focus()
            Exit Sub
        End If

        CadSQL = "select name from staffs where name = '" & TextEdit3.Text & "'"
        Comando = New OdbcCommand(CadSQL)
        Comando.CommandText = CadSQL
        Comando.Connection = MiConexion
        Comando.CommandType = CommandType.Text

        Registros = Comando.ExecuteReader
        If Not Registros.HasRows Then
            Imagen = New Bitmap(My.Resources.Resource1.help)
            Icono = Icon.FromHandle(Imagen.GetHicon)

            AddHandler args.Showing, AddressOf Me.args_Showing2
            args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
            args.Text = "El recipiente especificado NO existe en la aplicación MMCall." & Environment.NewLine & "¿Desea agregarlo de igual forma?"
            args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
            args.Icon = Icono
            XtraMessageBox.SmartTextWrap = True
            Dim Respuesta As Integer = XtraMessageBox.Show(args)
            '. . . 
            If Respuesta = 2 Then
                TextEdit3.Focus()
                Exit Sub
            End If


            'args.Text = "El nombre del recipiente debe existir en la tabla Staffs de la aplicación MMCall"
            'XtraMessageBox.SmartTextWrap = True
            'XtraMessageBox.Show(args)
            'TextEdit1.Focus()
            'Exit Sub
        End If
        '''

        Me.Cursor = Cursors.WaitCursor

        Try
            CadSQL = "select id from z_mensajes_carpetas where id = '" & LabelControl1.Text & "'"
            Comando = New OdbcCommand(CadSQL)
            Comando.CommandText = CadSQL
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text

            Registros = Comando.ExecuteReader
            If Registros.HasRows Then

                CadSQL = "update z_mensajes_carpetas set area = '" & TextEdit3.Text & "', carpeta = '" & Strings.Replace(TextEdit18.EditValue, "\", "/") & "' where id = " & Val(LabelControl1.Text)
            Else
                CadSQL = "insert into z_mensajes_carpetas (area, carpeta) values('" & TextEdit3.Text & "', '" & Strings.Replace(TextEdit18.EditValue, "\", "/") & "')"
            End If
            Comando = New OdbcCommand(CadSQL)
            Comando.CommandText = CadSQL
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Comando.ExecuteReader()
        Catch ex As Exception
            AddHandler args.Showing, AddressOf Me.args_Showing
            args.Text = ex.Message
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)

        End Try
        RecuperarDatos()
        SimpleButton1.Enabled = False
        SimpleButton2.Enabled = False
        TextEdit3.Focus()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_GotFocus(sender As Object, e As EventArgs) Handles GridControl1.GotFocus
        Me.AcceptButton = SimpleButton4
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        BuscarMensaje()
        TextEdit3.Focus()
        SimpleButton1.Enabled = False
        SimpleButton2.Enabled = False

    End Sub

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        If e.KeyValue = Keys.Delete And SimpleButton3.Enabled Then
            'Presiono la tecla delete
            SimpleButton3_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        If SimpleButton4.Enabled Then
            'Presiono la tecla delete
            SimpleButton4_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TextEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit3.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit18_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit18.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        XtraFolderBrowserDialog1.SelectedPath = TextEdit18.Text
        XtraFolderBrowserDialog1.ShowDialog()
        TextEdit18.Text = XtraFolderBrowserDialog1.SelectedPath
        TextEdit18.Focus()
        CambiarBotones(1)
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Dim Forma As New Form10
        MMCRecas = ""
        Forma.ShowDialog()
        If MMCRecas.Trim.Length > 0 Then
            TextEdit3.Text = MMCRecas

        End If
        TextEdit3.Focus()
    End Sub
End Class