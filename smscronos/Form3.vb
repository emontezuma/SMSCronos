Imports System.ComponentModel
Imports System.Text
Imports System.Data
Imports System.Data.Odbc

Imports System.Net.Mail
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base

Public Class Form3
    Dim MiSecuencia
    Public Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        InitializeComponent()
    End Sub


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RecuperarDatos()
    End Sub

    Sub RecuperarDatos()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim MiTabla As New DataTable

            Dim CadSQL As String = "select z_secuencia, z_nombre, if(z_destino = 'S', 'Mensaje de Texto', if(z_destino = 'E', 'Correo electrónico', 'Ambos')) from z_mensajes_plantillas"
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text

            Dim Registros As OdbcDataReader = Comando.ExecuteReader
            MiTabla.Load(Registros)
            GridControl1.DataSource = MiTabla
            GridControl1.MainView = GridView1
            GridView1.Columns(0).Caption = "Secuencia"
            GridView1.Columns(1).Caption = "Nombre"
            GridView1.Columns(2).Caption = "Tipo de mensaje"
            GridView1.BestFitColumns()
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
        ComboBoxEdit1.SelectedIndex = 0
        ComboBoxEdit2.SelectedIndex = -1

        Me.Cursor = Cursors.Default


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
            Dim CadSQL As String = "select * from z_mensajes_plantillas where z_secuencia = " & MiSecuencia
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Dim Registros As OdbcDataReader = Comando.ExecuteReader
            If Registros.HasRows Then
                MemoEdit1.Text = ValNull(Registros!z_lista, "A")
                MemoEdit2.Text = ValNull(Registros!z_mensaje, "A")
                If ValNull(Registros!z_destino, "A") = "S" Then
                    ComboBoxEdit1.SelectedIndex = 0
                ElseIf ValNull(Registros!z_destino, "A") = "E" Then
                    ComboBoxEdit1.SelectedIndex = 1

                End If
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
        ComboBoxEdit1.SelectedIndex = 0
        ComboBoxEdit2.SelectedIndex = -1
        MemoEdit1.Text = ""
        MemoEdit2.Text = ""
        ComboBoxEdit1.Focus()

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        BuscarMensaje()
        ComboBoxEdit1.Focus()

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

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

    Private Sub GroupControl2_Paint(sender As Object, e As PaintEventArgs) Handles GroupControl2.Paint

    End Sub
End Class