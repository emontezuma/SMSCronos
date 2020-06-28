Imports System.ComponentModel
Imports System.Text
Imports System.Data
Imports System.Data.Odbc

Imports System.Net.Mail
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports System.Speech.Synthesis

Public Class Form8
    Dim Cambiando As Boolean = False
    Dim MiSecuencia
    Public Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        InitializeComponent()
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

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxEdit9.Properties.Items.Clear()
        Dim synthesizer As New SpeechSynthesizer()
        For Each voice In synthesizer.GetInstalledVoices
            Dim info As VoiceInfo
            info = voice.VoiceInfo
            ComboBoxEdit9.Properties.Items.Add(info.Name)
            ComboBoxEdit1.Properties.Items.Add(info.Name)
        Next
        If ComboBoxEdit9.Properties.Items.Count > 0 Then
            ComboBoxEdit9.SelectedIndex = 0
            ComboBoxEdit1.SelectedIndex = 0
        End If

        RecuperarDatos()
    End Sub

    Sub RecuperarDatos()
        Me.Cursor = Cursors.WaitCursor
        Cambiando = False
        Try
            Dim MiTabla As New DataTable

            Dim CadSQL As String = "select id, mensaje, traduccion from z_mensajes_traduccion order by mensaje"
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text

            Dim Registros As OdbcDataReader = Comando.ExecuteReader
            MiTabla.Load(Registros)
            GridControl1.DataSource = MiTabla
            GridControl1.MainView = GridView1
            GridView1.Columns(0).Caption = "ID"
            GridView1.Columns(1).Caption = "Mensaje"
            GridView1.Columns(2).Caption = "Traducción"
            GridView1.Columns(0).Width = GridControl1.Width * 0.1
            GridView1.Columns(1).Width = GridControl1.Width * 0.45
            GridView1.Columns(2).Width = GridControl1.Width * 0.45
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
            Dim CadSQL As String = "select * from z_mensajes_traduccion where id = " & Val(MiSecuencia)
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Dim Registros As OdbcDataReader = Comando.ExecuteReader
            If Registros.HasRows Then
                LabelControl1.Text = MiSecuencia
                MemoEdit2.Text = ValNull(Registros!mensaje, "A")
                MemoEdit1.Text = ValNull(Registros!traduccion, "A")
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
        MemoEdit2.Text = ""
        MemoEdit1.Text = ""
        MemoEdit2.Focus()
        SimpleButton1.Enabled = True
        SimpleButton2.Enabled = True

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        BuscarMensaje()
        MemoEdit2.Focus()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim Imagen As Bitmap = New Bitmap(My.Resources.Resource1.help)
        Dim Icono As Icon = Icon.FromHandle(Imagen.GetHicon)
        Dim args As New XtraMessageBoxArgs

        AddHandler args.Showing, AddressOf Me.args_Showing2
        args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
        args.Text = "Al eliminar este traducción ya no estará disponible al momento de generar el mensaje por voz." & Environment.NewLine & "¿Desea continuar y eliminar a traducción?"
        args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
        args.Icon = Icono
        XtraMessageBox.SmartTextWrap = True
        Dim Respuesta As Integer = XtraMessageBox.Show(args)
        '. . . 
        If Respuesta = 2 Then Exit Sub

        Try
            Dim CadSQL As String = "delete from z_mensajes_traduccion where id = " & Val(LabelControl1.Text)
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
        MemoEdit2.Focus()

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

        If MemoEdit2.Text.Trim.Length = 0 Then
            args.Text = "Especifique el mensaje a leer y traducir"

            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)
            MemoEdit2.Focus()
            Exit Sub
        End If

        '''

        Me.Cursor = Cursors.WaitCursor

        Try
            CadSQL = "select id from z_mensajes_traduccion where id = '" & LabelControl1.Text & "'"
            Comando = New OdbcCommand(CadSQL)
            Comando.CommandText = CadSQL
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text

            Registros = Comando.ExecuteReader
            If Registros.HasRows Then

                CadSQL = "update z_mensajes_traduccion set mensaje = '" & MemoEdit2.Text & "', traduccion = '" & MemoEdit1.Text & "' where id = " & Val(LabelControl1.Text)
            Else
                CadSQL = "insert into z_mensajes_traduccion (mensaje, traduccion) values('" & MemoEdit2.Text.ToUpper & "', '" & MemoEdit1.Text.ToUpper & "')"
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
        MemoEdit2.Focus()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_GotFocus(sender As Object, e As EventArgs) Handles GridControl1.GotFocus
        Me.AcceptButton = SimpleButton4
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        BuscarMensaje()
        MemoEdit2.Focus()
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



    Private Sub MemoEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles MemoEdit1.EditValueChanged
        CambiarBotones(1)
        SimpleButton6.Enabled = MemoEdit1.Text.Length > 0
    End Sub

    Private Sub MemoEdit2_EditValueChanged_1(sender As Object, e As EventArgs) Handles MemoEdit2.EditValueChanged
        CambiarBotones(1)
        SimpleButton7.Enabled = MemoEdit2.Text.Length > 0
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Dim synthesizer As New SpeechSynthesizer()
        If ComboBoxEdit1.Properties.Items.Count = 0 Then Exit Sub
        synthesizer.SelectVoice(ComboBoxEdit1.Text)
        synthesizer.Volume = 100 '  // 0...100
        synthesizer.Rate = 0 '     // -10...10
        Dim builder As New PromptBuilder()
        builder.AppendText(MemoEdit2.Text)
        builder.Culture = synthesizer.Voice.Culture
        synthesizer.Speak(builder)
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Dim synthesizer As New SpeechSynthesizer()
        If ComboBoxEdit9.Properties.Items.Count = 0 Then Exit Sub
        synthesizer.SelectVoice(ComboBoxEdit9.Text)
        synthesizer.Volume = 100 '  // 0...100
        synthesizer.Rate = 0 '     // -10...10
        Dim builder As New PromptBuilder()
        builder.AppendText(MemoEdit1.Text)
        builder.Culture = synthesizer.Voice.Culture
        synthesizer.Speak(builder)
    End Sub

    Private Sub GroupControl1_Paint(sender As Object, e As PaintEventArgs) Handles GroupControl1.Paint

    End Sub
End Class