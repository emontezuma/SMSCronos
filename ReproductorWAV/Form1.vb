
Imports System.Deployment.Application
Imports System.Net.Mail
Imports System.Globalization
Imports System.ComponentModel
Imports System.Text
Imports System.Data
Imports System.IO
Imports System.Data.Odbc
Imports DevExpress.XtraEditors
Imports System.Media



Public Class Form1


    Dim Ruta As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    Dim Segundos As Integer = 10
    Dim Cargando As Boolean = False


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args As New XtraMessageBoxArgs
        PictureBox1.Width = Me.Width - 10
        PictureBox1.Height = 80
        LinkLabel1.Left = Me.Width / 2 - LinkLabel1.Width / 2
        LinkLabel1.Top = 85
        'Dim CadSQL0 As String = "select z_rea_ruta, z_rea_senso from z_mensajes_config"
        'Dim Comando0 As OdbcCommand = New OdbcCommand(CadSQL0)
        'Dim AccionConexion0 As String = Conexion()

        'Dim Imagen0 As Bitmap = New Bitmap(My.Resources.Resource1.close__2_)
        'Dim Icono0 As Icon = Icon.FromHandle(Imagen0.GetHicon)
        'Comando0.Connection = MiConexion
        '
        'Dim MisDatosClave As OdbcDataReader = Comando0.ExecuteReader

        'If MisDatosClave.HasRows Then
        ' MisDatosClave.Read()
        ' Ruta = Strings.Replace(ValNull(MisDatosClave!z_rea_ruta, "A"), "/", "\")
        ' Segundos = ValNull(MisDatosClave!z_rea_senso, "N")
        ' MisDatosClave.Close()
        ' Else
        ' MisDatosClave.Close()

        Try

            Dim fileReader As String
            fileReader = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\rutadeaudo.txt")
            Dim MICadena() As String = Split(fileReader, ",")
            Ruta = MICadena(0)
            Segundos = Val(MICadena(1))
            If Segundos = 0 Then Segundos = 10

        Catch ex As Exception

        End Try

        'Ruta = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        ' Segundos = 10
        ' End If
        If Ruta.Trim.Length = 0 Or Not My.Computer.FileSystem.DirectoryExists(Ruta) Then
            Ruta = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\rutadeaudo.txt", True)
            file.WriteLine(Ruta & "," & Segundos)
            file.Close()
        End If

        'Dim CadSQL As String = "update z_mensajes_config set z_rea_ruta = '" & Strings.Replace(Ruta, "\", "/") & "', z_rea_senso = " & Val(Segundos)
        'Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
        'Try
        'Comando.Connection = MiConexion
        'Comando.CommandType = CommandType.Text
        'Comando.ExecuteReader()
        'Catch ex As Exception
        'End Try
        NotifyIcon1.Text = "Esperando por audios..."
        TextEdit16.Text = Ruta
        TextEdit3.Text = Segundos
        Timer1.Interval = Segundos * 1000
        Timer1.Enabled = True
    End Sub

    Private Sub args_Showing(sender As Object, e As XtraMessageShowingArgs)
        e.Buttons(DialogResult.OK).Text = "&Aceptar"
        e.Buttons(DialogResult.OK).ImageOptions.Image = My.Resources.Resource1.close__2_

        e.Buttons(DialogResult.OK).ImageOptions.Location = ImageLocation.MiddleLeft
        e.Buttons(DialogResult.OK).Font = MiFuente
        e.Form.Appearance.Font = MiFuente
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Visible = True
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Visible = True
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Me.Close()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Visible = False
        NotifyIcon1.Visible = True

    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        Procesando = True
        XtraFolderBrowserDialog1.SelectedPath = TextEdit16.Text
        XtraFolderBrowserDialog1.ShowDialog()
        TextEdit16.Text = XtraFolderBrowserDialog1.SelectedPath
        TextEdit16.Focus()
        Procesando = False
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If TextEdit16.Text.Trim.Length = 0 Then
            TextEdit16.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        End If
        If Not My.Computer.FileSystem.DirectoryExists(TextEdit16.Text) Then
            TextEdit16.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        End If
        If Val(TextEdit3.Text.Trim) = 0 Then
            TextEdit3.Text = 10
        End If
        Ruta = TextEdit16.Text
        Segundos = Val(TextEdit3.Text)

        'Dim CadSQL As String = "update z_mensajes_config set z_rea_ruta = '" & Strings.Replace(Ruta, "\", "/") &' "', z_rea_senso = " & Val(Segundos)
        'Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
        'Try
        'Comando.Connection = MiConexion
        'Comando.CommandType = CommandType.Text
        'Comando.ExecuteReader()
        'Catch ex As Exception
        'End Try
        If Ruta.Trim.Length = 0 Then
            Ruta = My.Computer.FileSystem.SpecialDirectories.MyDocuments

        End If
        Try
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\rutadeaudo.txt", False)
            file.WriteLine(Ruta & "," & Segundos)
            file.Close()

        Catch ex As Exception

        End Try
        Timer1.Interval = Segundos * 1000
        Timer1.Enabled = False
        Timer1.Enabled = True
        Me.Visible = False
    End Sub




    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        NotifyIcon1.Text = "Reproduciendo..."
        ' Listen for the LoadCompleted event.
        Dim LaRuta As String

        Try
            If My.Computer.FileSystem.DirectoryExists(TextEdit16.Text) Then
                LaRuta = TextEdit16.Text
            Else
                LaRuta = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Cargando = True
        Catch ex As Exception
            Exit Sub
        End Try


        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
  LaRuta, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.wav")
            Try
                'My.Computer.Audio.Play(foundFile, AudioPlayMode.WaitToComplete)

                'Dim simpleSound As SoundPlayer = New SoundPlayer(foundFile)
                'simpleSound.PlaySync()


                Dim fs As FileStream = New FileStream(foundFile, FileMode.Open, FileAccess.Read)
                Dim sp As System.Media.SoundPlayer = New System.Media.SoundPlayer(fs)
                sp.PlaySync()
                fs.Close()
                File.Delete(foundFile)
                'Rename(foundFile, foundFile & ".old")
                'If File.Exists(foundFile & ".old") Then
                ' File.Delete(foundFile & ".old")
                ' End If

            Catch ex2 As Exception

            End Try

            'Se mueven los archivos a otra carpeta
        Next
        NotifyIcon1.Text = "Esperando por audios..."
        Cargando = False
    End Sub

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(LinkLabel1.Text)
    End Sub
End Class
