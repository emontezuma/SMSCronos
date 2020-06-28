Imports System.Data
Imports System.Data.Odbc
Imports DevExpress.XtraCharts
Imports System.IO
Imports DevExpress.XtraEditors

Public Class Form5

    Public Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        InitializeComponent()
        AddHandler TextEdit1.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit2.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit3.GotFocus, AddressOf Sombrear_Texto
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        End

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        TextEdit2.Text = ""
        TextEdit3.Text = ""
        TextEdit2.Focus()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim CadSQL As String
        Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
        Dim AccionConexion0 As String = Conexion()
        Dim args As New XtraMessageBoxArgs

        Dim Imagen0 As Bitmap = New Bitmap(My.Resources.Resource1.info)
        Dim Icono0 As Icon = Icon.FromHandle(Imagen0.GetHicon)
        If Not AplicarXOR() Then
            AddHandler args.Showing, AddressOf Me.args_Showing
            args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
            args.Text = "La licencia introducida no es correcta. La aplicación no podr[a continuar hata que introduzca una licencia correcta"
            args.Buttons = New DialogResult() {DialogResult.OK}
            args.Icon = Icono0
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)
            TextEdit2.Focus()
            Exit Sub
        Else
            CadSQL = "select * from z_licencia_audio"
            Comando = New OdbcCommand(CadSQL)
            Comando.CommandText = CadSQL
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Dim Registros As OdbcDataReader = Comando.ExecuteReader
            If Registros.HasRows Then

                CadSQL = "update z_licencia_audio set z_llave = '" & TextEdit3.Text & "', z_frase = '" & TextEdit2.Text & "'"
            Else
                CadSQL = "insert into z_licencia_audio (z_llave, z_frase) values('" & TextEdit3.Text & "', '" & TextEdit2.Text & "')"
            End If
            Comando = New OdbcCommand(CadSQL)
            Comando.CommandText = CadSQL
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Comando.ExecuteReader()
        End If
        Me.Close()
    End Sub

    Private Sub TextEdit3_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextEdit2_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub LabelControl1_Click(sender As Object, e As EventArgs) Handles LabelControl1.Click

    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim CadSQL0 As String = "select key_number from locations"
        Dim Comando0 As OdbcCommand = New OdbcCommand(CadSQL0)
        Dim AccionConexion0 As String = Conexion()
        Dim args As New XtraMessageBoxArgs

        Dim Imagen0 As Bitmap = New Bitmap(My.Resources.Resource1.info)
        Dim Icono0 As Icon = Icon.FromHandle(Imagen0.GetHicon)

        Comando0.CommandText = "select key_number from locations"
        Comando0.Connection = MiConexion
        Dim MisDatosClave As OdbcDataReader = Comando0.ExecuteReader

        If MisDatosClave.HasRows Then
            MisDatosClave.Read()
            TextEdit1.Text = ValNull(MisDatosClave!key_number, "A")
            MisDatosClave.Close()
        Else
            MisDatosClave.Close()
            AddHandler args.Showing, AddressOf Me.args_Showing
            args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
            args.Text = "No se hallaron los datos de la licencia de MMCall, comuníquese con su proveedor de MMCall. La aplicación se cerrará"
            args.Buttons = New DialogResult() {DialogResult.OK}
            args.Icon = Icono0
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)
            End
        End If


        CadSQL0 = "select * from z_licencia_audio"
        Comando0 = New OdbcCommand(CadSQL0)

        Comando0.Connection = MiConexion

        MisDatosClave = Comando0.ExecuteReader


        If MisDatosClave.HasRows Then
            MisDatosClave.Read()
            TextEdit2.Text = ValNull(MisDatosClave!z_frase, "A")
            TextEdit3.Text = ValNull(MisDatosClave!z_llave, "A")
        End If
        MisDatosClave.Close()

    End Sub

    Function AplicarXOR() As Boolean
        Dim i As Integer
        AplicarXOR = True
        For i = 1 To TextEdit1.Text.Length
            If Microsoft.VisualBasic.Strings.Left(Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Mid(TextEdit1.Text, i, 1)) + 33 Xor Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Mid(TextEdit2.Text, i, 1)) + 33, 1) <> Microsoft.VisualBasic.Strings.Mid(TextEdit3.Text, i, 1) Then
                AplicarXOR = False
                Exit Function
            End If
        Next
    End Function

    Private Sub args_Showing(sender As Object, e As XtraMessageShowingArgs)
        e.Buttons(DialogResult.OK).Text = "&Aceptar"
        e.Buttons(DialogResult.OK).ImageOptions.Image = My.Resources.Resource1.symbol_check_icon
        e.Buttons(DialogResult.OK).ImageOptions.Location = ImageLocation.MiddleLeft
        e.Buttons(DialogResult.OK).Font = MiFuente
        e.Form.Appearance.Font = MiFuente
    End Sub

End Class