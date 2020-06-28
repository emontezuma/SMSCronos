
Imports System.Deployment.Application
Imports System.Net.Mail
Imports System.Globalization
Imports System.ComponentModel
Imports System.Text
Imports System.Data
Imports System.Data.Odbc
Imports DevExpress.XtraCharts
Imports System.IO
Imports DevExpress.XtraEditors
Imports System.Speech.Synthesis
Imports System.IO.Ports

Public Class Form1


    Dim Ruta As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    Dim Segundos As Integer = 10
    Dim Puerto As String
    Dim Cargando As Boolean = False
    Dim MiArchivoEs As String
    Dim MensajeLlamada As String
    Dim TiempoInicial As DateTime
    Dim ProcesandoLlamada As Boolean
    Dim CadenaCOMM As String
    Dim Numero As String
    Dim email As String
    Dim veces As Integer = 3

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args As New XtraMessageBoxArgs
        ProcesandoLlamada = True
        PictureBox1.Width = Me.Width - 20 - PictureBox2.Width
        PictureBox1.Height = 80
        LinkLabel1.Left = Me.Width / 2 - LinkLabel1.Width / 2
        LinkLabel1.Top = 85
        ComboBoxEdit1.SelectedIndex = 0

        Dim CadSQL0 As String = "select * from z_repeticiones"
        Dim Comando0 As OdbcCommand = New OdbcCommand(CadSQL0)
        Dim AccionConexion0 As String = Conexion()
        Comando0.Connection = MiConexion

        Dim MisDatosClave As OdbcDataReader

        Try
            MisDatosClave = Comando0.ExecuteReader
            MisDatosClave.Close()
        Catch ex As Exception
            Dim Comando6 As OdbcCommand = New OdbcCommand("CREATE TABLE `z_repeticiones` (
  `telefono` varchar(20) DEFAULT NULL, `veces` int(3) DEFAULT NULL,  KEY `NewIndex1` (`telefono`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1")
            Comando6.Connection = MiConexion
            Comando6.CommandType = CommandType.Text
            Comando6.ExecuteReader()
        End Try



        Try

            Dim fileReader As String
            fileReader = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\rutallamada.txt")
            Dim MICadena() As String = Split(fileReader, ",")
            MemoEdit2.Text = MemoEdit2.Text & vbCrLf & fileReader
            Ruta = MICadena(0)
            Segundos = Val(MICadena(1))
            Puerto = MICadena(2)
            ComboBoxEdit1.SelectedIndex = Val(MICadena(3))
            TextEdit1.Text = Puerto
            If Segundos = 0 Then Segundos = 10


        Catch ex As Exception
            MemoEdit2.Text = MemoEdit2.Text & vbCrLf & "error: " & ex.Message

        End Try

        'Ruta = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        ' Segundos = 10
        ' End If
        If Ruta.Trim.Length = 0 Or Not My.Computer.FileSystem.DirectoryExists(Ruta) Then
            Ruta = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\rutallamada.txt", True)
            file.WriteLine(Ruta & "," & Segundos & "," & Puerto)
            file.Close()
        End If

        'Dim CadSQL As String = "update z_mensajes_config set z_rea_ruta = '" & Strings.Replace(Ruta, "\", "/") & "', z_rea_senso = " & Val(Segundos)
        'Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
        If Not ValPuerto() Then
            MsgBox("El puerto especificado no es válido. El programa no generará llamadas")
        End If
        NotifyIcon1.Text = "Esperando por audios..."
        TextEdit16.Text = Ruta
        TextEdit3.Text = Segundos
        Timer1.Interval = Segundos * 1000
        ProcesandoLlamada = False
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
        Try
            Me.Visible = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            Me.Visible = True
        Catch ex As Exception

        End Try
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
        If ComboBoxEdit1.SelectedIndex < 0 Then
            ComboBoxEdit1.SelectedIndex = 0
        End If
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

        If Ruta.Trim.Length = 0 Then
            Ruta = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        End If
        If Not ValPuerto() Then
            MsgBox("El puerto especificado no es válido")
        End If

        Try
            Dim file As System.IO.StreamWriter

            file = My.Computer.FileSystem.OpenTextFileWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\rutallamada.txt", False)
            file.WriteLine(Ruta & "," & Segundos & "," & TextEdit1.Text & "," & ComboBoxEdit1.SelectedIndex)
            file.Close()
            MemoEdit2.Text = Ruta & "," & Segundos & "," & TextEdit1.Text & "," & ComboBoxEdit1.SelectedIndex

        Catch ex As Exception
            MemoEdit2.Text = ex.Message
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
        ' Listen for the LoadCompleted event.
        If ProcesandoLlamada Then Exit Sub
        ProcesandoLlamada = True
        If ComboBoxEdit1.SelectedIndex < 0 Then
            ComboBoxEdit1.SelectedIndex = 0
        End If
        Dim LaRuta As String
        Me.Text = Timer1.Enabled

        Try
            If My.Computer.FileSystem.DirectoryExists(TextEdit16.Text) Then
                LaRuta = TextEdit16.Text
            Else
                LaRuta = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Cargando = True
        Catch ex As Exception
            ProcesandoLlamada = False
            Exit Sub
        End Try

        LlamadasPendientes = 0
        For Each FoundFile As String In My.Computer.FileSystem.GetFiles(
  LaRuta, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.wav")
            LlamadasPendientes = LlamadasPendientes + 1
        Next

        Me.Text = "Hay " & LlamadasPendientes & " mensaje(s) por enviar"

        For Each FoundFile As String In My.Computer.FileSystem.GetFiles(
  LaRuta, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.wav")
            Try
                MiArchivoEs = FoundFile
                TiempoInicial = DateTime.Now
                If File.Exists(FoundFile) Then HacerLlamada()


                'My.Computer.Audio.Play(foundFile, AudioPlayMode.WaitToComplete)

                'Dim simpleSound As SoundPlayer = New SoundPlayer(foundFile)
                'simpleSound.PlaySync()

                'Rename(foundFile, foundFile & ".old")
                'If File.Exists(foundFile & ".old") Then
                ' File.Delete(foundFile & ".old")
                ' End If

            Catch ex2 As Exception

            End Try

            'Se mueven los archivos a otra carpeta
        Next
        For Each FoundFile As String In My.Computer.FileSystem.GetFiles(
  LaRuta, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
            Try
                MiArchivoEs = FoundFile
                TiempoInicial = DateTime.Now
                If File.Exists(FoundFile) Then EnviarSMS(False)

            Catch ex2 As Exception

            End Try

            'Se mueven los archivos a otra carpeta
        Next
        ProcesandoLlamada = False
        NotifyIcon1.Text = "Esperando por audios..."
        Cargando = False
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(LinkLabel1.Text)
    End Sub


    Private Sub EnviarSMS(Tipo As Boolean)
        Dim LimiteTimeout As Integer = 10
        Dim Salir = False
        Dim TiempoInicial = DateTime.Now

        If Not SerialPort1.IsOpen Then
            SerialPort1.Open()
        End If
        Dim Contestada As Boolean = False
        'ReceiveSerialData()
        Numero = Strings.Left(Path.GetFileName(MiArchivoEs), 10)
        Dim elMensaje As String
        If IsNumeric(Numero) Then
            If Not Tipo Then
                Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(MiArchivoEs)

                elMensaje = reader.ReadLine
                elMensaje = UCase(elMensaje)
                elMensaje = Replace(elMensaje, "Á", "A")
                elMensaje = Replace(elMensaje, "É", "E")
                elMensaje = Replace(elMensaje, "Í", "I")
                elMensaje = Replace(elMensaje, "Ó", "O")
                elMensaje = Replace(elMensaje, "Ú", "U")
                elMensaje = Replace(elMensaje, "Ñ", "~")
                reader.Close()
            Else
                elMensaje = "Se le han efectuado 3 llamadas a su movil sin respuesta..."
            End If
            If ComboBoxEdit1.SelectedIndex = 0 Then
                Try
                    CadenaCOMM = "VB->VOID" & vbNewLine & CadenaCOMM
                    MemoEdit1.Text = CadenaCOMM
                    SerialPort1.Write("VOID" & vbNewLine)
                    Demora(1)
                    CadenaCOMM = "VB->SMS" & vbNewLine & CadenaCOMM
                    SerialPort1.Write("SMS" & vbNewLine)
                    TiempoInicial = DateTime.Now
                    Do While Not Salir
                        'Se cuentan hasta 30seg
                        Application.DoEvents()
                        Dim TiempoFinal = DateTime.Now
                        TotalSegundos = TiempoFinal - TiempoInicial
                        If TotalSegundos.Seconds > LimiteTimeout Then
                            SerialPort1.Write("VOID" & vbNewLine)
                            CadenaCOMM = "VB->" & "VOID" & LimiteTimeout & vbNewLine & CadenaCOMM
                            MensajeLlamada = "timeout"
                            Salir = True
                        ElseIf MensajeLlamada.Length > 0 Then
                            'CadenaCOMM = "ARDUINO (SMS)->" & MensajeLlamada & vbNewLine & CadenaCOMM
                            If InStr(MensajeLlamada, "NUMBER?") > 0 Then
                                Salir = True
                            End If
                        End If
                        MemoEdit1.Text = CadenaCOMM
                    Loop
                    If MensajeLlamada <> "timeout" Then
                        Salir = False
                        SerialPort1.Write("~" & Numero & vbNewLine)
                        CadenaCOMM = "VB->~" & Numero & vbNewLine & vbNewLine & CadenaCOMM
                        MemoEdit1.Text = CadenaCOMM
                        TiempoInicial = DateTime.Now
                        Do While Not Salir
                            'Se cuentan hasta 30seg
                            Application.DoEvents()
                            Dim TiempoFinal = DateTime.Now
                            TotalSegundos = TiempoFinal - TiempoInicial
                            If TotalSegundos.Seconds > LimiteTimeout Then
                                SerialPort1.Write("VOID" & vbNewLine)
                                CadenaCOMM = "->" & "VOID" & LimiteTimeout & vbNewLine & CadenaCOMM
                                MensajeLlamada = "timeout"
                                Salir = True
                            ElseIf MensajeLlamada.Length > 0 Then
                                'CadenaCOMM = "ARDUINO (NUMERO DE MOVIL)->" & MensajeLlamada & vbNewLine & CadenaCOMM
                                If InStr(MensajeLlamada, "MESSAGE?") > 0 Then
                                    Salir = True
                                End If
                            End If
                            MemoEdit1.Text = CadenaCOMM
                        Loop
                    End If
                    If MensajeLlamada <> "timeout" Then
                        SerialPort1.Write(elMensaje & vbNewLine)
                        CadenaCOMM = "VB->MENSAJE AL MOVIL: '" & elMensaje & "'" & vbNewLine & CadenaCOMM
                        MemoEdit1.Text = CadenaCOMM
                        TiempoInicial = DateTime.Now
                        Salir = False
                        Do While Not Salir
                            'Se cuentan hasta 30seg
                            Application.DoEvents()
                            Dim TiempoFinal = DateTime.Now
                            TotalSegundos = TiempoFinal - TiempoInicial
                            If MensajeLlamada.Length > 0 Then
                                If InStr(MensajeLlamada, "OK") > 0 Or InStr(MensajeLlamada, "ERROR") > 0 Then
                                    Salir = True
                                End If
                            End If
                            If TotalSegundos.Seconds > LimiteTimeout Then
                                Salir = True
                                MensajeLlamada = "timeout"
                            End If
                        Loop
                        If MensajeLlamada = "timeout" Then
                            CadenaCOMM = "->TIMEOUT VENCIDO" & vbNewLine & CadenaCOMM
                        Else
                            CadenaCOMM = "->RESPUESTA DE ARDUNIO: " & MensajeLlamada & vbNewLine & CadenaCOMM
                        End If
                        MemoEdit1.Text = CadenaCOMM
                    End If
                Catch ex As Exception
                    NotifyIcon1.Text = "Error en el puerto serial..."
                Finally

                End Try
            Else
                SerialPort1.Write("VOID" & vbNewLine)
                Demora(1)
                SerialPort1.Write("~SMS01" & Numero & elMensaje & vbNewLine)
                LimiteTimeout = 5
                Salir = False
                TiempoInicial = DateTime.Now
                MensajeLlamada = ""
                Do While Not Salir
                    'Se cuentan hasta 30seg
                    Application.DoEvents()
                    Dim TiempoFinal = DateTime.Now
                    TotalSegundos = TiempoFinal - TiempoInicial
                    If TotalSegundos.Seconds >= LimiteTimeout Then
                        MensajeLlamada = "timeout"
                        Salir = True
                    ElseIf MensajeLlamada.Length > 0 Then
                        If Microsoft.VisualBasic.Strings.InStr(MensajeLlamada, "OK") Or Microsoft.VisualBasic.Strings.InStr(MensajeLlamada, "finalizada") Then
                            Salir = True
                        Else
                            Salir = True
                            MensajeLlamada = "timeout"
                        End If
                    End If
                Loop
            End If

        End If
        If Not Tipo Then EliminarFile(MiArchivoEs)
        ProcesandoLlamada = False
    End Sub

    Private Sub HacerLlamada()
        Dim LimiteTimeout As Integer = 10
        If Not SerialPort1.IsOpen Then
            SerialPort1.Open()
        End If
        Dim TiempoInicial = DateTime.Now
        Dim TiempoFinal = DateTime.Now
        Dim Contestada As Boolean = False
        'ReceiveSerialData()
        Numero = Strings.Left(Path.GetFileName(MiArchivoEs), 10)
        If IsNumeric(Numero) Then
            If ComboBoxEdit1.SelectedIndex = 0 Then

                Try
                    SerialPort1.Write("VOID" & vbNewLine)
                    Demora(1)
                    SerialPort1.Write("CALL" & vbNewLine)

                    Salir = False
                    TiempoInicial = DateTime.Now

                    Do While Not Salir
                        'Se cuentan hasta 30seg
                        Application.DoEvents()
                        TiempoFinal = DateTime.Now
                        TotalSegundos = TiempoFinal - TiempoInicial
                        If TotalSegundos.Seconds > LimiteTimeout Then
                            SerialPort1.Write("VOID" & vbNewLine)
                            CadenaCOMM = "->" & "VOID" & LimiteTimeout & vbNewLine & CadenaCOMM
                            MensajeLlamada = "timeout"
                            Salir = True
                        ElseIf MensajeLlamada.Length > 0 Then
                            If InStr(MensajeLlamada, "CALL") > 0 Then
                                Salir = True
                            End If
                        End If
                        MemoEdit1.Text = CadenaCOMM
                    Loop
                    If MensajeLlamada <> "timeout" Then
                        SerialPort1.Write("~" & Numero & vbNewLine)
                        CadenaCOMM = "->" & Numero & vbNewLine & CadenaCOMM

                        'Primer timeout de 10Seg
                        MensajeLlamada = ""
                        TiempoInicial = DateTime.Now
                        NotifyIcon1.Text = "Llamando (Intento 15seg)"
                        Salir = False

                        Do While Not Salir
                            'Se cuentan hasta 30seg
                            Application.DoEvents()
                            TiempoFinal = DateTime.Now
                            TotalSegundos = TiempoFinal - TiempoInicial
                            If TotalSegundos.Seconds > LimiteTimeout Then
                                SerialPort1.Write("VOID" & vbNewLine)

                                CadenaCOMM = "->" & "VOID" & LimiteTimeout & vbNewLine & CadenaCOMM
                                MensajeLlamada = "timeout"
                                Salir = True
                            ElseIf MensajeLlamada.Length > 0 Then
                                NotifyIcon1.Text = "Llamando (Intento 20seg)"

                                'Se recibio un mensaje desde SIM900
                                If MensajeLlamada.Length > 0 Then
                                    LimiteTimeout = 35
                                    'Se recibio un mensaje desde SIM900
                                    If InStr(MensajeLlamada, "RING") > 0 Then
                                        'Hay ring por parte del telefono
                                    ElseIf InStr(MensajeLlamada, "CONNECTED") > 0 Then
                                        'Se contesto la llamada
                                        Dim lallamada = MensajeLlamada
                                        Contestada = True
                                        Salir = True
                                    ElseIf InStr(MensajeLlamada, "CANCEL") > 0 Then
                                        'Se CANCELÓ LA LLAMADA
                                        Salir = True
                                    ElseIf InStr(MensajeLlamada, "NO CARRIER") > 0 Then
                                        'Llamada cancelada
                                        Salir = True
                                    End If
                                End If
                            End If
                            MemoEdit1.Text = CadenaCOMM
                        Loop
                    End If
                    If Contestada Then
                        ReproducirAudio()
                    Else
                        Dim EnviarSMSVeces As Boolean
                        EnviarSMSVeces = True
                        veces = 3
                        Dim CadSQL0 As String = "Select z_lla_smsvencer, z_lla_veces, z_lla_mail from z_mensajes_config"
                        Dim Comando0 As OdbcCommand = New OdbcCommand(CadSQL0)
                        Dim MisDatosClave As OdbcDataReader
                        Comando0.Connection = MiConexion
                        MisDatosClave = Comando0.ExecuteReader
                        If MisDatosClave.HasRows Then
                            MisDatosClave.Read()
                            If MisDatosClave!z_lla_veces.Equals(System.DBNull.Value) Then
                                veces = 3
                            Else
                                veces = Val(MisDatosClave!z_lla_veces)
                                If veces = 0 Then veces = 3
                            End If
                            If MisDatosClave!z_lla_smsvencer.Equals(System.DBNull.Value) Then
                                EnviarSMSVeces = True
                            Else
                                EnviarSMSVeces = MisDatosClave!z_lla_smsvencer = "S"
                            End If
                        End If
                        MisDatosClave.Close()
                        'Se contabilizan hasta 3 llamadas y luego se elimina
                        CadSQL0 = "Select * from z_repeticiones where telefono = '" & Numero & "'"
                        Dim Comando10 As OdbcCommand = New OdbcCommand(CadSQL0)
                        Comando10.Connection = MiConexion
                        MisDatosClave = Comando10.ExecuteReader
                        If Not MisDatosClave.HasRows Then
                            MisDatosClave.Close()
                            Comando10.CommandText = "insert into z_repeticiones values ('" & Numero & "', 1)"
                            Comando10.ExecuteReader()
                            SerialPort1.Write("VOID" & vbNewLine)
                            Demora(1)
                        Else
                            MisDatosClave.Read()
                            If MisDatosClave!veces > veces Then
                                MisDatosClave.Close()
                                Comando10.CommandText = "delete from z_repeticiones where telefono = '" & Numero & "'"
                                Comando10.ExecuteReader()
                                'EnviarMail()
                                EliminarFile(MiArchivoEs)
                                SerialPort1.Write("VOID" & vbNewLine)
                                'Enviar SMS
                                If EnviarSMSVeces Then EnviarSMS(True)
                                Demora(2)
                            Else
                                MisDatosClave.Close()
                                Comando10.CommandText = "update z_repeticiones set veces = veces + 1 where telefono = '" & Numero & "'"
                                Comando10.ExecuteReader()
                                SerialPort1.Write("VOID" & vbNewLine)
                                Demora(1)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    NotifyIcon1.Text = "Error en el puerto serial..."
                Finally

                End Try
            Else
                Try
                    SerialPort1.Write("VOID" & vbNewLine)
                    Demora(1)
                    SerialPort1.Write("~CALL" & Numero & vbNewLine)
                    Salir = False
                    TiempoInicial = DateTime.Now
                    MensajeLlamada = ""
                    Do While Not Salir
                        'Se cuentan hasta 30seg
                        Application.DoEvents()
                        TiempoFinal = DateTime.Now
                        TotalSegundos = TiempoFinal - TiempoInicial
                        If TotalSegundos.Seconds >= LimiteTimeout Then
                            MensajeLlamada = "timeout"
                            Salir = True
                        ElseIf MensajeLlamada.Length > 0 Then
                            If Microsoft.VisualBasic.Strings.InStr(MensajeLlamada, "CONNECTED") > 0 Then
                                Contestada = True
                                Salir = True
                            End If
                        End If
                    Loop
                    If Contestada Then
                        ReproducirAudio()
                    Else
                        Dim EnviarSMSVeces As Boolean
                        EnviarSMSVeces = True
                        veces = 3
                        Dim CadSQL0 As String = "Select z_lla_smsvencer, z_lla_veces, z_lla_mail from z_mensajes_config"
                        Dim Comando0 As OdbcCommand = New OdbcCommand(CadSQL0)
                        Dim MisDatosClave As OdbcDataReader
                        Comando0.Connection = MiConexion
                        MisDatosClave = Comando0.ExecuteReader
                        If MisDatosClave.HasRows Then
                            MisDatosClave.Read()
                            If MisDatosClave!z_lla_veces.Equals(System.DBNull.Value) Then
                                veces = 3
                            Else
                                veces = Val(MisDatosClave!z_lla_veces)
                                If veces = 0 Then veces = 3
                            End If
                            If MisDatosClave!z_lla_smsvencer.Equals(System.DBNull.Value) Then
                                EnviarSMSVeces = True
                            Else
                                EnviarSMSVeces = MisDatosClave!z_lla_smsvencer = "S"
                            End If
                        End If
                        MisDatosClave.Close()
                        'Se contabilizan hasta 3 llamadas y luego se elimina
                        CadSQL0 = "Select * from z_repeticiones where telefono = '" & Numero & "'"
                        Dim Comando10 As OdbcCommand = New OdbcCommand(CadSQL0)
                        Comando10.Connection = MiConexion
                        MisDatosClave = Comando10.ExecuteReader
                        If Not MisDatosClave.HasRows Then
                            MisDatosClave.Close()
                            Comando10.CommandText = "insert into z_repeticiones values ('" & Numero & "', 1)"
                            Comando10.ExecuteReader()
                            SerialPort1.Write("VOID" & vbNewLine)
                            Demora(1)
                        Else
                            MisDatosClave.Read()
                            If MisDatosClave!veces > veces Then
                                MisDatosClave.Close()
                                Comando10.CommandText = "delete from z_repeticiones where telefono = '" & Numero & "'"
                                Comando10.ExecuteReader()
                                'EnviarMail()
                                EliminarFile(MiArchivoEs)
                                SerialPort1.Write("VOID" & vbNewLine)
                                'Enviar SMS
                                If EnviarSMSVeces Then EnviarSMS(True)
                                Demora(2)
                            Else
                                MisDatosClave.Close()
                                Comando10.CommandText = "update z_repeticiones set veces = veces + 1 where telefono = '" & Numero & "'"
                                Comando10.ExecuteReader()
                                SerialPort1.Write("VOID" & vbNewLine)
                                Demora(1)
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try
            End If
        Else
            EliminarFile(MiArchivoEs)
        End If
        ProcesandoLlamada = False
    End Sub

    Function EnviarMail() As Boolean

        Dim MMRecipiente As String
        Dim MMCuenta As String, MMPrefijo As String, MMUsuario As String, MMPass As String, MMSSL As Boolean, MMHost As String, MMPort As Integer, MMMensaje As String, IDR As Double, IDM As Double
        ErrorMail = ""
        EnviarMail = True
        Dim smtpServer As New SmtpClient()
        Dim mail As New MailMessage
        Try
            smtpServer.Credentials = New Net.NetworkCredential(MMUsuario, MMPass)
            smtpServer.Port = MMPort
            smtpServer.Host = MMHost
            smtpServer.EnableSsl = MMSSL
            mail.From = New MailAddress(MMUsuario)
            mail.To.Add(MMCuenta)
            mail.Subject = MMMensaje
            mail.Body = "Se ha excedido el número de llamadas para el número de teléfono: " & Numero & ". Se eliminó el mensaje de voz destinado para este recipiente"
            smtpServer.Send(mail)
            smtpServer.Dispose()
            mail.Dispose()

        Catch ex As Exception

        End Try



    End Function


    Sub ReproducirAudio()
        CadenaCOMM = "->" & "Entro a leer el audio " & MiArchivoEs & vbNewLine & CadenaCOMM
        Dim fs As FileStream = New FileStream(MiArchivoEs, FileMode.Open, FileAccess.Read)
        MemoEdit2.Text = CadenaCOMM
        Try
            Dim sp As System.Media.SoundPlayer = New System.Media.SoundPlayer(fs)
            For i = 0 To 1
                sp.PlaySync()
            Next i
            fs.Close()
            EliminarFile(MiArchivoEs)
        Catch ex As Exception
            fs.Close()
            EliminarFile(MiArchivoEs)
            SerialPort1.Write("VOID" & vbNewLine)
            Demora(2)
            MemoEdit2.Text = MemoEdit2.Text & vbCrLf & ex.Message
        Finally
            fs.Close()
            Demora(1)
            EliminarFile(MiArchivoEs)
            SerialPort1.Write("VOID" & vbNewLine)
            Demora(2)
        End Try


    End Sub

    Sub EliminarFile(MiArchivoEs As String)
        Dim Salir = False
        Dim TInicial = DateTime.Now
        Dim TotalSegundos As TimeSpan
        Dim Segundos = 2
        Do While Not Salir
            If File.Exists(MiArchivoEs) Then
                My.Computer.FileSystem.DeleteFile(MiArchivoEs)
                File.Delete(MiArchivoEs)
            Else
                CadenaCOMM = "<-Se eliminó el archivo " + MiArchivoEs & vbNewLine & CadenaCOMM

                Salir = True
            End If
            Dim TiempoFinal = DateTime.Now
            TotalSegundos = TiempoFinal - TInicial
            If TotalSegundos.Seconds > Segundos Then
                Salir = True
                CadenaCOMM = "<-Se intentó eliminar el archivo y se salió por timeout " + MiArchivoEs & vbNewLine & CadenaCOMM
            End If
        Loop
        Dim Comando10 As OdbcCommand = New OdbcCommand(CadSQL0)
        Comando10.Connection = MiConexion
        Comando10.CommandText = "delete from z_repeticiones where telefono = '" & Strings.Left(Path.GetFileName(MiArchivoEs), 10) & "'"
        Comando10.ExecuteReader()

    End Sub
    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        MensajeLlamada = SerialPort1.ReadLine
        CadenaCOMM = "<-" & MensajeLlamada & vbCrLf & CadenaCOMM
    End Sub

    Private Sub SerialPort1_ErrorReceived(sender As Object, e As SerialErrorReceivedEventArgs) Handles SerialPort1.ErrorReceived
        MensajeLlamada = SerialPort1.ReadExisting()
    End Sub

    Function ValPuerto() As Boolean

        ValPuerto = True

        Try
            SerialPort1.Close()
        Catch ex As Exception

        End Try



        Try
            SerialPort1.PortName = TextEdit1.Text.Trim

            SerialPort1.BaudRate = 19200
            SerialPort1.DataBits = 8
            SerialPort1.Parity = Parity.None


            SerialPort1.StopBits = StopBits.One


            SerialPort1.Handshake = Handshake.RequestToSend
            SerialPort1.RtsEnable = True

            SerialPort1.Open()
        Catch ex As Exception
            ValPuerto = False
        End Try


    End Function

    Sub Demora(Segundos As Integer)
        Salir = False
        Dim TInicial = DateTime.Now
        Dim TotalSegundos As TimeSpan
        Do While Not Salir
            Dim TiempoFinal = DateTime.Now
            TotalSegundos = TiempoFinal - TInicial
            If TotalSegundos.Seconds > Segundos Then
                Salir = True
            End If
        Loop
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

        Dim args As New XtraMessageBoxArgs
        args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
        args.Text = "Esta acción eliminará los mensajes pendientes." & Environment.NewLine & "¿Desea eliminarlos?"
        args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
        XtraMessageBox.SmartTextWrap = True
        Dim Respuesta As Integer = XtraMessageBox.Show(args)
        '. . . 
        If Respuesta <> 2 Then
            Dim LaRuta As String
            Try
                If My.Computer.FileSystem.DirectoryExists(TextEdit16.Text) Then
                    LaRuta = TextEdit16.Text
                Else
                    LaRuta = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                End If
                Cargando = True
            Catch ex As Exception
                ProcesandoLlamada = False
                Exit Sub
            End Try


            LlamadasEliminadas = 0
            For Each FoundFile As String In My.Computer.FileSystem.GetFiles(
LaRuta, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.wav")
                Try
                    EliminarFile(FoundFile)
                    LlamadasEliminadas = LlamadasEliminadas + 1
                Catch ex2 As Exception

                End Try
            Next

            HayLlamadas = 0
            For Each FoundFile As String In My.Computer.FileSystem.GetFiles(
LaRuta, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.wav")
                HayLlamadas = HayLlamadas + 1

                'Se mueven los archivos a otra carpeta
            Next
            If LlamadasEliminadas > 0 Then
                MsgBox("Se eliminaron satisfactoriamente " & LlamadasEliminadas & " llamada(s) pendiente(s) ")
            Else
                MsgBox("No hay llamadas pendientes a eliminar...")
            End If
            If HayLlamadas > 0 Then
                MsgBox(HayLlamadas & " llamada(s) no se eliminaron, vaya a la carpeta: '" & LaRuta & "' y eliminelas manualmente. Es posible que tenga que terminar esta aplicación")
            End If
            ProcesandoLlamada = False
            NotifyIcon1.Text = "Esperando por audios..."
            Cargando = False

        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit1.EditValueChanged
        uno = 1
    End Sub
End Class

