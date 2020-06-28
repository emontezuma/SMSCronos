Imports System.ComponentModel
Imports System.Text
Imports System.Data
Imports System.Data.Odbc

Imports System.Net.Mail
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base

Public Class Form7
    Dim Cambiando As Boolean = False
    Dim MiSecuencia
    Public Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        InitializeComponent()
        AddHandler TextEdit1.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit2.GotFocus, AddressOf Sombrear_Texto
        AddHandler MemoEdit2.GotFocus, AddressOf Sombrear_Texto
        AddHandler MemoEdit1.GotFocus, AddressOf Sombrear_Texto
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

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RecuperarDatos()
    End Sub

    Sub RecuperarDatos()
        Me.Cursor = Cursors.WaitCursor
        Cambiando = False
        Try
            Dim MiTabla As New DataTable

            Dim CadSQL As String = "select z_nombre, z_movil, z_email from z_mensajes_perfiles"
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text

            Dim Registros As OdbcDataReader = Comando.ExecuteReader
            MiTabla.Load(Registros)
            GridControl1.DataSource = MiTabla
            GridControl1.MainView = GridView1
            GridView1.Columns(0).Caption = "Recipiente/Staff"
            GridView1.Columns(1).Caption = "Número de móvil"
            GridView1.Columns(2).Caption = "Correo electrónico"
            GridView1.Columns(0).Width = GridControl1.Width * 0.3
            GridView1.Columns(1).Width = GridControl1.Width * 0.2
            GridView1.Columns(2).Width = GridControl1.Width * 0.5
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
            Dim CadSQL As String = "select * from z_mensajes_perfiles where z_nombre = '" & MiSecuencia & "'"
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Dim Registros As OdbcDataReader = Comando.ExecuteReader
            If Registros.HasRows Then
                TextEdit1.Text = ValNull(Registros!z_nombre, "A")
                TextEdit2.Text = ValNull(Registros!z_movil, "A")
                TextEdit3.Text = ValNull(Registros!z_recipiente, "A")
                TextEdit9.Text = ValNull(Registros!z_segundos, "N")
                CheckEdit4.Checked = IIf(ValNull(Registros!z_demorado, "A") = "S", True, False)
                MemoEdit2.Text = ValNull(Registros!z_email, "A")
                MemoEdit1.Text = ValNull(Registros!z_prefijo_mensaje, "A")
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
        TextEdit1.Text = ""
        TextEdit2.Text = ""
        TextEdit3.Text = ""
        TextEdit9.Text = ""
        CheckEdit4.Checked = False
        MemoEdit2.Text = ""
        MemoEdit1.Text = ""
        TextEdit1.Focus()
        SimpleButton1.Enabled = True
        SimpleButton2.Enabled = True

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        BuscarMensaje()
        TextEdit1.Focus()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim Imagen As Bitmap = New Bitmap(My.Resources.Resource1.help)
        Dim Icono As Icon = Icon.FromHandle(Imagen.GetHicon)
        Dim args As New XtraMessageBoxArgs

        AddHandler args.Showing, AddressOf Me.args_Showing2
        args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
        args.Text = "Al eliminar este perfil ya no se le enviará correos ni mensajes SMS." & Environment.NewLine & "¿Desea continuar y eliminar el perfil?"
        args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
        args.Icon = Icono
        XtraMessageBox.SmartTextWrap = True
        Dim Respuesta As Integer = XtraMessageBox.Show(args)
        '. . . 
        If Respuesta = 2 Then Exit Sub

        Try
            Dim CadSQL As String = "delete from z_mensajes_perfiles where z_nombre = '" & TextEdit1.Text & "'"
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
        TextEdit1.Focus()

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

        If TextEdit1.Text.Trim.Length = 0 Then
            args.Text = "Especifique el nombre del recipiente"

            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)
            TextEdit1.Focus()
            Exit Sub
        End If

        '''
        If TextEdit2.Text.Trim.Length = 0 Then
            args.Text = "Especifique el número de móvil"

            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)
            TextEdit2.Focus()
            Exit Sub
            'ElseIf TextEdit2.Text.Trim.Length <> 10 Then
            '    args.Text = "Especifique un número de móvil a 10 dígitos"
            '
            '            XtraMessageBox.SmartTextWrap = True
            '            XtraMessageBox.Show(args)
            '            TextEdit2.Focus()
            '            Exit Sub
        End If
        If MemoEdit2.Text.Trim.Length = 0 Then
            args.Text = "Especifique al menos un correo electrónico para este recipiente"
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)
            MemoEdit2.Focus()
            Exit Sub
        End If



        CadSQL = "select name from staffs where name = '" & TextEdit1.Text & "'"
        Comando = New OdbcCommand(CadSQL)
            Comando.CommandText = CadSQL
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text

            Registros = Comando.ExecuteReader
            If Not Registros.HasRows Then
                Registros.Close()
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
            End If

        Me.Cursor = Cursors.WaitCursor

        Try
            CadSQL = "select z_nombre from z_mensajes_perfiles where z_nombre = '" & TextEdit1.Text & "'"
            Comando = New OdbcCommand(CadSQL)
            Comando.CommandText = CadSQL
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text

            Registros = Comando.ExecuteReader
            If Registros.HasRows Then

                CadSQL = "update z_mensajes_perfiles set z_movil = '" & TextEdit2.Text & "', z_recipiente = '" & TextEdit3.Text & "', z_segundos = " & Val(TextEdit9.Text) & ", z_demorado = '" & IIf(CheckEdit4.Checked, "S", "N") & "', z_email = '" & MemoEdit2.Text & "', z_prefijo_mensaje = '" & MemoEdit1.Text & "' where z_nombre = '" & TextEdit1.Text & "' "
            Else
                CadSQL = "insert into z_mensajes_perfiles (z_nombre, z_movil, z_email, z_prefijo_mensaje, z_recipiente, z_segundos, z_demorado) values('" & TextEdit1.Text & "', '" & TextEdit2.Text & "', '" & MemoEdit2.Text & "', '" & MemoEdit1.Text & "', '" & TextEdit3.Text & "', " & Val(TextEdit9.Text) & ", '" & IIf(CheckEdit4.Checked, "S", "N") & "')"
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
        TextEdit1.Focus()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit1.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit1_GotFocus(sender As Object, e As EventArgs) Handles TextEdit1.GotFocus
        Me.AcceptButton = SimpleButton1
        Me.CancelButton = SimpleButton2
    End Sub

    Private Sub GridControl1_GotFocus(sender As Object, e As EventArgs) Handles GridControl1.GotFocus
        Me.AcceptButton = SimpleButton4
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        BuscarMensaje()
        TextEdit1.Focus()
        SimpleButton1.Enabled = False
        SimpleButton2.Enabled = False

    End Sub

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        If e.KeyValue = Keys.Delete And SimpleButton3.Enabled Then
            'Presiono la tecla delete
            SimpleButton3_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick

    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        If SimpleButton4.Enabled Then
            'Presiono la tecla delete
            SimpleButton4_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit2.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub MemoEdit2_EditValueChanged(sender As Object, e As EventArgs)
        CambiarBotones(1)
    End Sub

    Private Sub MemoEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles MemoEdit1.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub LabelControl9_Click(sender As Object, e As EventArgs) Handles LabelControl9.Click

    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        XtraOpenFileDialog1.Filter = "Archivo separado por comas (*.csv)|*.csv|Todos los archivos (*.*)|*.*'"
        XtraOpenFileDialog1.ShowDialog()
        Dim Imagen As Bitmap = New Bitmap(My.Resources.Resource1.info)
        Dim Icono As Icon = Icon.FromHandle(Imagen.GetHicon)

        Dim args As New XtraMessageBoxArgs

        Dim Archivo As String = XtraOpenFileDialog1.FileName
        If My.Computer.FileSystem.FileExists(Archivo) Then
            Dim CadSQL As String
            Dim Comando As OdbcCommand


            Dim ConError As Integer = 0
            Dim Actualizados As Integer = 0
            Dim Nuevos As Integer = 0

            Dim Registros As OdbcDataReader

            Using MyReader As New Microsoft.VisualBasic.
                        FileIO.TextFieldParser(Archivo)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")
                Dim currentRow As String()
                Dim PrimeraLinea As Boolean = False
                While Not MyReader.EndOfData
                    currentRow = MyReader.ReadFields()
                    If PrimeraLinea Then
                        Try
                            CadSQL = "select name from staffs where name = '" & currentRow(0) & "'"
                            Comando = New OdbcCommand(CadSQL)
                            Comando.Connection = MiConexion
                            Comando.CommandType = CommandType.Text
                            Comando.CommandText = CadSQL

                            Registros = Comando.ExecuteReader
                            If Registros.HasRows Then
                                Registros.Close()
                                CadSQL = "select z_nombre from z_mensajes_perfiles where z_nombre = '" & currentRow(0) & "'"
                                Comando.CommandText = CadSQL

                                Registros = Comando.ExecuteReader
                                If Registros.HasRows Then

                                    CadSQL = "update z_mensajes_perfiles set z_movil = '" & currentRow(1) & "', z_email = '" & Replace(currentRow(2), ";", ",") & "', z_prefijo_mensaje = '" & currentRow(3) & "' where z_nombre = '" & currentRow(0) & "' "
                                    Actualizados = Actualizados + 1
                                Else
                                    CadSQL = "insert into z_mensajes_perfiles (z_nombre, z_movil, z_email, z_prefijo_mensaje) values('" & currentRow(0) & "', '" & currentRow(1) & "', '" & Replace(currentRow(2), ";", ",") & "', '" & currentRow(3) & "')"

                                    Nuevos = Nuevos + 1
                                End If
                                Comando = New OdbcCommand(CadSQL)
                                Comando.CommandText = CadSQL
                                Comando.Connection = MiConexion
                                Comando.CommandType = CommandType.Text
                                Comando.ExecuteReader()
                            Else
                                ConError = ConError + 1
                                Registros.Close()
                            End If
                        Catch ex As Exception
                            ConError = ConError + 1
                        End Try
                    Else
                        PrimeraLinea = True
                    End If
                End While
            End Using
            RecuperarDatos()
            AddHandler args.Showing, AddressOf Me.args_Showing
            args.Caption = "Importación masiva terinada"
            args.Buttons = New DialogResult() {DialogResult.OK}
            args.Icon = Icono

            args.Text = "Se actualizaron: " & Actualizados & vbCrLf & "Se agregaron: " & Nuevos & vbCrLf & "Registros con error o recipientes no válidos: " & ConError
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)
        End If

    End Sub

    Private Sub GroupControl2_Paint(sender As Object, e As PaintEventArgs) Handles GroupControl2.Paint

    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        Dim Forma As New Form10
        Forma.FormBorderStyle = FormBorderStyle.FixedDialog
        MMCRecas = ""
        Forma.ShowDialog()
        If MMCRecas.Trim.Length > 0 Then
            TextEdit1.Text = MMCRecas

        End If
        TextEdit1.Focus()
    End Sub

    Private Sub MemoEdit2_EditValueChanged_1(sender As Object, e As EventArgs) Handles MemoEdit2.EditValueChanged

    End Sub

    Private Sub CheckEdit4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit4.CheckedChanged
        LabelControl4.Enabled = CheckEdit4.Checked
        LabelControl11.Enabled = LabelControl4.Enabled
        TextEdit3.Enabled = LabelControl4.Enabled
        TextEdit9.Enabled = LabelControl4.Enabled
        SimpleButton7.Enabled = LabelControl4.Enabled
        CambiarBotones(1)
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Dim Forma As New Form10
        Forma.FormBorderStyle = FormBorderStyle.FixedDialog
        MMCRecas = ""
        Forma.ShowDialog()
        If MMCRecas.Trim.Length > 0 Then
            TextEdit3.Text = MMCRecas

        End If
        TextEdit3.Focus()
    End Sub

    Private Sub TextEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit3.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit9_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit9.EditValueChanged
        CambiarBotones(1)
    End Sub
End Class