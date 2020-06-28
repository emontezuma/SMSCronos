
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

Partial Public Class Form1
    Dim Cambiando As Boolean = False
    Dim Procesando As Boolean = False
    Dim ErrorMail As String
    Dim ErrorSMS As String
    Dim CancelarOperacion As Boolean = False
    Dim NGrafica01 As String
    Dim NGrafica02 As String
    Dim NGrafica03 As String
    Dim NGrafica04 As String
    Dim RutaAudio As String
    Dim RutaAudio2 As String
    Dim RutaAudio3 As String
    Dim MiClave As String = ""
    Dim MiSerial As String = ""
    Dim MiFrase As String = ""

    Public Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        InitializeComponent()
        AddHandler TextEdit1.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit2.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit3.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit4.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit5.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit6.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit7.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit8.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit9.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit10.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit11.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit12.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit13.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit14.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit15.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit16.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit17.GotFocus, AddressOf Sombrear_Texto
        AddHandler TextEdit18.GotFocus, AddressOf Sombrear_Texto
    End Sub

    Sub CambiarBotones(Accion As Integer)
        If Cambiando Then
            If Accion = 1 And Not SimpleButton1.Enabled Then
                SimpleButton1.Enabled = True
                SimpleButton2.Enabled = True
                SimpleButton2.Text = "&Cancelar"
            ElseIf Accion = 2 And SimpleButton1.Enabled Then
                SimpleButton1.Enabled = False
                SimpleButton2.Enabled = False
            End If
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args As New XtraMessageBoxArgs
        Dim CadSQL0 As String = "select key_number from locations"
        Dim Comando0 As OdbcCommand = New OdbcCommand(CadSQL0)
        Dim AccionConexion0 As String = Conexion()

        Dim Imagen0 As Bitmap = New Bitmap(My.Resources.Resource1.info)
        Dim Icono0 As Icon = Icon.FromHandle(Imagen0.GetHicon)

        ComboBoxEdit9.Properties.Items.Clear()
        Dim synthesizer As New SpeechSynthesizer()
        For Each voice In synthesizer.GetInstalledVoices
            Dim info As VoiceInfo
            info = voice.VoiceInfo
            ComboBoxEdit9.Properties.Items.Add(info.Name)

        Next
        PictureBox1.Width = Me.Width - 10
        PictureBox1.Height = 100
        LinkLabel1.Left = Me.Width / 2 - LinkLabel1.Width / 2
        LinkLabel1.Top = 105
        Comando0.CommandText = "select key_number from locations"
        Comando0.Connection = MiConexion
        Dim MisDatosClave As OdbcDataReader = Comando0.ExecuteReader

        If MisDatosClave.HasRows Then
            MisDatosClave.Read()
            MiSerial = ValNull(MisDatosClave!key_number, "A")
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

        Try
            CadSQL0 = "select * from z_licencia"
            Comando0 = New OdbcCommand(CadSQL0)

            Comando0.Connection = MiConexion

            MisDatosClave = Comando0.ExecuteReader


            If MisDatosClave.HasRows Then
                MisDatosClave.Read()
                MiFrase = ValNull(MisDatosClave!z_frase, "A")
                MiClave = ValNull(MisDatosClave!z_llave, "A")
                MisDatosClave.Close()
            Else
                MisDatosClave.Close()
                AddHandler args.Showing, AddressOf Me.args_Showing
                args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
                args.Text = "No se hallaron los datos de la licencia de los reportes de MMCall de Cronos, si los desea comuníquese con su proveedor de MMCall. La aplicación desactivará el módulo de reportes hasta que active esta funcionalidad"
                args.Buttons = New DialogResult() {DialogResult.OK}
                args.Icon = Icono0
                XtraMessageBox.SmartTextWrap = True
                XtraMessageBox.Show(args)
                CheckEdit9.Checked = False
                CheckEdit9.Enabled = False
                LabelControl30.Visible = True


            End If
            If Not AplicarXOR() Then
                MisDatosClave.Close()
                AddHandler args.Showing, AddressOf Me.args_Showing
                args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
                args.Text = "La licencia para los reportes de MMCall de Cronos no es la correcta, si los desea comuníquese con su proveedor de MMCall. La aplicación desactivará el módulo de reportes hasta que active esta funcionalidad"
                args.Buttons = New DialogResult() {DialogResult.OK}
                args.Icon = Icono0
                XtraMessageBox.SmartTextWrap = True
                XtraMessageBox.Show(args)
                CheckEdit9.Checked = False
                CheckEdit9.Enabled = False
                LabelControl30.Visible = True
            End If
            MisDatosClave.Close()

        Catch ex As Exception
            LabelControl30.Visible = True
            CheckEdit9.Checked = False
            CheckEdit9.Enabled = False
        End Try

        Me.Text = "Cronos:Envio de mensajes (ver: " & Version() & ")"
        ComboBoxEdit1.SelectedItem = 0
        Me.CancelButton = SimpleButton2
        Me.AcceptButton = SimpleButton1
        Dim AccionConexion As String = Conexion()
        Dim Imagen As Bitmap = New Bitmap(My.Resources.Resource1.close__2_)
        Dim Imagen2 As Bitmap = New Bitmap(My.Resources.Resource1.info)
        Dim Icono As Icon = Icon.FromHandle(Imagen.GetHicon)
        Dim Icono2 As Icon = Icon.FromHandle(Imagen2.GetHicon)


        If AccionConexion <> "" Then
            AddHandler args.Showing, AddressOf Me.args_Showing
            args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
            args.Text = AccionConexion
            args.Buttons = New DialogResult() {DialogResult.OK}
            args.Icon = Icono
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args)

            '. . . 

            'Dim Ventana As XtraMessageBoxArgs
            'Ventana.Icon = Icon
            'Ventana.MessageBeepSound = MessageBeepSound.None
            'Ventana.Text = AccionConexion
            'Ventana.Caption = "SMS Creonos:."
            'Ventana.Buttons = CaptionButton.Close
            'Ventana.Buttons =
            'DevExpress.XtraEditors.XtraMessageBox.Show(AccionConexion, "SMS Creonos:.", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
            End
        End If
        Dim CadSQL As String = "update z_mensajes_config set z_iniciado = '" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "'"
        Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
        Dim CadSQL2 As String = "CREATE TABLE `z_mensajes_config` (
  `z_activar` char(1) DEFAULT NULL COMMENT 'Activar envio de mensajes (S/N)',
  `z_sms_activar` char(1) DEFAULT NULL COMMENT 'Activar envio de mensajes SMS (S/N)',
  `z_mail_activar` char(1) DEFAULT NULL COMMENT 'Activar envio de mensajes mail (S/N)',
  `z_sms_usuario` varchar(100) DEFAULT NULL COMMENT 'Usuario para uso de SMS',
  `z_sms_contrasena` varchar(100) DEFAULT NULL COMMENT 'Contraseña para uso de SMS',
  `z_sms_puerto` varchar(100) DEFAULT NULL COMMENT 'Puerto para mails',
  `z_sms_host` varchar(100) DEFAULT NULL COMMENT 'Host para mails',
  `z_sms_ssl` char(1) DEFAULT NULL COMMENT 'Usar SSL (S) (N)',
  `z_sms_manejador` char(1) DEFAULT NULL COMMENT 'Manejador para SMSs',
  `z_sms_restan` decimal(10,0) DEFAULT NULL COMMENT 'Mensajes que restan',
  `z_sms_enviados` decimal(10,0) DEFAULT NULL COMMENT 'SMS enviados',
  `z_sms_fecha` date DEFAULT NULL COMMENT 'Fecha de reinicio de los mensajes',
  `z_mail_usuario` varchar(100) DEFAULT NULL COMMENT 'Usuario para mails',
  `z_mail_contrasena` varchar(100) DEFAULT NULL COMMENT 'Contraseña para mails',
  `z_mail_puerto` varchar(100) DEFAULT NULL COMMENT 'Puerto para mails',
  `z_mail_host` varchar(100) DEFAULT NULL COMMENT 'Host para mails',
  `z_usar_ssl` char(1) DEFAULT NULL COMMENT 'Usar SSL (S) (N)',
  `z_iniciado` datetime DEFAULT NULL COMMENT 'Fecha y hora de iniciado',
  `z_finalizado` datetime DEFAULT NULL COMMENT 'Fecha y hora de última ejecución',
  `z_segundos_censo` decimal(4,0) DEFAULT '0' COMMENT 'Cada cuantos segundos se censa',
  `z_ultimo_id` datetime DEFAULT '0000-00-00 00:00:00' COMMENT 'Fceha de la última revisión',
  `z_envio` char(1) DEFAULT NULL COMMENT 'Solo envíos (S)i (No',
  `z_reenvio` char(1) DEFAULT NULL COMMENT 'Solo reenvíos (S)i (No',
  `z_cancela` char(1) DEFAULT NULL COMMENT 'Solo cncelación (S)i (No',
  `z_rep_activar` char(1) DEFAULT NULL COMMENT 'Activar envio de reportes por mail (S/N)',
  `z_rep_usuario` varchar(100) DEFAULT NULL,
  `z_rep_contrasena` varchar(100) DEFAULT NULL,
  `z_rep_puerto` varchar(100) DEFAULT NULL,
  `z_rep_host` varchar(100) DEFAULT NULL,
  `z_rep_ssl` char(1) DEFAULT NULL,
  `z_rep_periodo` int(2) DEFAULT NULL,
  `z_rep_subject` varchar(100) DEFAULT NULL,
  `z_rep_cuerpo` varchar(500) DEFAULT NULL,
  `z_rep_para` varchar(500) DEFAULT NULL,
  `z_rep_enviar` int(2) DEFAULT NULL,
  `z_aud_activar` char(1) DEFAULT NULL,
  `z_aud_genero` int(2) DEFAULT NULL,
  `z_aud_edad` int(2) DEFAULT NULL,
  `z_aud_velocidad` int(2) DEFAULT NULL,
  `z_aud_pausa` int(2) DEFAULT NULL,
  `z_aud_guardar` char(1) DEFAULT NULL,
  `z_aud_reproducir` char(1) DEFAULT NULL,
  `z_aud_ruta` varchar(500) DEFAULT NULL,
  `z_rea_ruta` varchar(500) DEFAULT NULL,
  `z_rea_senso` decimal(4,0) DEFAULT '0' ,
  `z_aud_ruta2` varchar(500) DEFAULT NULL,
  `z_aud_ruta3` varchar(500) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Tabla de configuración de mensajes';"
        Dim Comando2 As OdbcCommand = New OdbcCommand(CadSQL2)

        Dim CrearScript As Boolean = False
        Try
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Comando.ExecuteReader()
            LabelControl10.Text = "Ejecutándose desde el día: " & Format(Now, "dddd dd-MMM-yyyy hh:mm:ss tt")
            RecuperarDatos()
        Catch ex As Exception
            If Strings.InStr(ex.Message, "'mmcall.z_mensajes_config' doesn't exist") > 0 Then
                CrearScript = True
            End If
        End Try
        If CrearScript Then
            Try
                Comando2.Connection = MiConexion
                Comando2.CommandType = CommandType.Text
                Comando2.ExecuteReader()
                Dim Comando3 As OdbcCommand = New OdbcCommand("CREATE TABLE `z_mensajes_log` (  `z_fecha` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Fecha y hora del registro',  `z_recipiente` VARCHAR(30) DEFAULT NULL COMMENT 'Recipiente',  `z_tipo_mensaje` CHAR(1) DEFAULT NULL COMMENT '(S)MS, (E)mail (A)mbos',  `z_estatus` CHAR(1) DEFAULT NULL COMMENT 'Mensaje enviado (1), No enviado (2)',  `z_causa` CHAR(1) DEFAULT NULL COMMENT '(1) Recipiente no existe, (2) No hay saldo, (3) Error de autenticación de email (4) Otro error',  `z_texto` VARCHAR(100) DEFAULT NULL COMMENT 'Texto adicional del error',  `z_mansaje_enviado` VARCHAR(100) DEFAULT NULL COMMENT 'Mensaje enviado',  `z_record` DECIMAL(15,0) DEFAULT NULL COMMENT 'ID del registro en mmcall.records',  `z_message` DECIMAL(15,0) DEFAULT NULL COMMENT 'ID del registro en mmcall.messages') ENGINE=MYISAM DEFAULT CHARSET=latin1 COMMENT='log de mensajes';")
                Comando3.Connection = MiConexion
                Comando3.CommandType = CommandType.Text

                Comando3.ExecuteReader()
                Dim Comando4 As OdbcCommand = New OdbcCommand("CREATE TABLE `z_mensajes_perfiles` (
  `z_nombre` varchar(50) DEFAULT NULL COMMENT 'Nombre de la secuencia',
  `z_movil` varchar(20) DEFAULT NULL COMMENT 'Número de móvil',
  `z_email` varchar(500) DEFAULT NULL COMMENT 'Correo electrónico',
  `z_prefijo_mensaje` varchar(50) DEFAULT NULL COMMENT 'Prefijo en mensaje',
  `z_demorado` char(1) DEFAULT NULL COMMENT 'Es demorado (S/N)',
  `z_recipiente` varchar(50) DEFAULT NULL COMMENT 'A que recipiente va?',
  `z_segundos` decimal(6,0) DEFAULT NULL COMMENT 'En cuantos segundos',
  KEY `NewIndex1` (`z_nombre`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Maestro de recipientes';")
                Comando4.Connection = MiConexion
                Comando4.CommandType = CommandType.Text

                Comando4.ExecuteReader()
                Dim Comando5 As OdbcCommand = New OdbcCommand("CREATE TABLE `z_mensajes_recargas` (  `z_registro` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha y hora del registro',  `z_fecha` DATE DEFAULT NULL COMMENT 'Fecha de la recarga',  `z_mensajes` DECIMAL(10,0) DEFAULT NULL COMMENT 'Número de mensajes a recargar',  `z_reiniciar` CHAR(1) DEFAULT NULL COMMENT 'Reiniciar saldo (S)i (N)o') ENGINE=MYISAM DEFAULT CHARSET=latin1 COMMENT='Hostórico de recargas';")
                Comando5.Connection = MiConexion
                Comando5.CommandType = CommandType.Text

                Comando5.ExecuteReader()

                Dim Comando6 As OdbcCommand = New OdbcCommand("CREATE TABLE `z_envio_reportes` (
                  `z_ufecha` datetime DEFAULT NULL,
                    KEY `NewIndex1` (`z_ufecha`)
                    ) ENGINE=MyISAM DEFAULT CHARSET=latin1;")
                Comando6.Connection = MiConexion
                Comando6.CommandType = CommandType.Text

                Comando6.ExecuteReader()

                Dim Comando7 As OdbcCommand = New OdbcCommand("CREATE TABLE `z_delays` (
  `message` int(11) DEFAULT NULL,  `time` timestamp NULL DEFAULT NULL,  `record` int(11) DEFAULT NULL,
  `recipiente` varchar(50) DEFAULT NULL,  `segundos` int(6) DEFAULT NULL,  `mensaje` varchar(50) DEFAULT NULL,
  KEY `NewIndex1` (`message`),  KEY `NewIndex2` (`message`,`record`)) ENGINE=MyISAM DEFAULT CHARSET=latin1;")
                Comando7.Connection = MiConexion
                Comando7.CommandType = CommandType.Text

                Comando7.ExecuteReader()

                Dim Comando8 As OdbcCommand = New OdbcCommand("ALTER TABLE `messages` CHANGE `message` `message` VARCHAR(100)
  ")
                Comando8.Connection = MiConexion
                Comando8.CommandType = CommandType.Text

                Comando8.ExecuteReader()

                Dim Comando9 As OdbcCommand = New OdbcCommand("CREATE TABLE `z_licencia_audio` (
  `z_llave` varchar(30) DEFAULT NULL COMMENT 'Llave',
  `z_frase` varchar(30) DEFAULT NULL COMMENT 'Frase dada por Cronos'
) ENGINE=MyISAM DEFAULT CHARSET=latin1")
                Comando9.Connection = MiConexion
                Comando9.CommandType = CommandType.Text

                Comando9.ExecuteReader()


            Catch ex As Exception
                AddHandler args.Showing, AddressOf Me.args_Showing
                args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
                args.Text = ex.Message & Environment.NewLine & "Error al intentar ejecutar los Scripts. La aplicación se cerrará"
                args.Buttons = New DialogResult() {DialogResult.OK}
                args.Icon = Icono
                XtraMessageBox.SmartTextWrap = True
                XtraMessageBox.Show(args)
                End
            End Try

        End If

        If CrearScript Then
            Try
                Comando.ExecuteReader()
                AddHandler args.Showing, AddressOf Me.args_Showing
                args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
                args.Text = "Los Scripts se ejecutaron satisfactoriamente. No es necesario crear las tablas de forma manual"
                args.Buttons = New DialogResult() {DialogResult.OK}
                args.Icon = Icono2
                XtraMessageBox.SmartTextWrap = True
                XtraMessageBox.Show(args)

            Catch ex As Exception
                AddHandler args.Showing, AddressOf Me.args_Showing
                args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
                args.Text = ex.Message & Environment.NewLine & "No se pudieron crear las tablas, deberá crearlas de forma manual, la aplicación se cerrará"
                args.Buttons = New DialogResult() {DialogResult.OK}
                args.Icon = Icono
                XtraMessageBox.SmartTextWrap = True
                XtraMessageBox.Show(args)
                End
            End Try
        End If

        Try
            CadSQL0 = "select * from z_licencia_audio"

            Comando0 = New OdbcCommand(CadSQL0)

            Comando0.Connection = MiConexion

            MisDatosClave = Comando0.ExecuteReader

        Catch ex As Exception
            Dim Comando9 As OdbcCommand = New OdbcCommand("CREATE TABLE `z_licencia_audio` (
  `z_llave` varchar(30) DEFAULT NULL COMMENT 'Llave',
  `z_frase` varchar(30) DEFAULT NULL COMMENT 'Frase dada por Cronos'
) ENGINE=MyISAM DEFAULT CHARSET=latin1")
            Comando9.Connection = MiConexion
            Comando9.CommandType = CommandType.Text

            Comando9.ExecuteReader()

        End Try
        CadSQL0 = "select * from z_licencia_audio"
        Comando0 = New OdbcCommand(CadSQL0)

        Comando0.Connection = MiConexion

        MisDatosClave = Comando0.ExecuteReader

        MiFrase = ""
        MiClave = ""
        Dim AbrirVentana As Boolean = False
        If MisDatosClave.HasRows Then
            MisDatosClave.Read()
            MiFrase = ValNull(MisDatosClave!z_frase, "A")
            MiClave = ValNull(MisDatosClave!z_llave, "A")
            MisDatosClave.Close()
        Else
            AbrirVentana = True
        End If
        MisDatosClave.Close()
        If MiFrase.Length > 0 And MiClave.Length > 0 Then
            AbrirVentana = Not AplicarXOR2()
        Else
            AbrirVentana = True
        End If
        Do While AbrirVentana
                Dim Forma As New Form5
                Forma.ShowDialog()
                MisDatosClave = Comando0.ExecuteReader
                If MisDatosClave.HasRows Then
                    MisDatosClave.Read()
                    MiFrase = ValNull(MisDatosClave!z_frase, "A")
                    MiClave = ValNull(MisDatosClave!z_llave, "A")
                    MisDatosClave.Close()
                End If
            AbrirVentana = Not AplicarXOR2() And MiFrase.Length > 0 And MiClave.Length > 0
        Loop
        Cambiando = True
    End Sub

    Sub RecuperarDatos()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim CadSQL As String = "select * from z_mensajes_config"
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Dim Registros As OdbcDataReader = Comando.ExecuteReader
            If Registros.HasRows Then
                CheckEdit1.Checked = ValNull(Registros!z_sms_activar, "A") = "S"
                CheckEdit2.Checked = ValNull(Registros!z_mail_activar, "A") = "S"
                CheckEdit3.Checked = ValNull(Registros!z_usar_ssl, "A") = "S"
                CheckEdit4.Checked = ValNull(Registros!z_envio, "A") = "S"
                CheckEdit5.Checked = ValNull(Registros!z_reenvio, "A") = "S"
                CheckEdit6.Checked = ValNull(Registros!z_cancela, "A") = "S"
                CheckEdit7.Checked = ValNull(Registros!z_sms_ssl, "A") = "S"
                CheckEdit8.Checked = ValNull(Registros!z_rep_ssl, "A") = "S"
                CheckEdit9.Checked = ValNull(Registros!z_rep_activar, "A") = "S"
                CheckEdit11.Checked = ValNull(Registros!z_aud_activar, "A") = "S"
                TextEdit1.Text = ValNull(Registros!z_sms_usuario, "A")
                TextEdit2.Text = ValNull(Registros!z_sms_contrasena, "A")
                TextEdit11.Text = ValNull(Registros!z_sms_puerto, "A")
                TextEdit10.Text = ValNull(Registros!z_sms_host, "A")
                TextEdit12.Text = ValNull(Registros!z_rep_usuario, "A")
                TextEdit13.Text = ValNull(Registros!z_rep_contrasena, "A")
                TextEdit14.Text = ValNull(Registros!z_rep_host, "A")
                TextEdit15.Text = ValNull(Registros!z_rep_puerto, "A")
                ComboBoxEdit1.SelectedIndex = ValNull(Registros!z_sms_manejador, "N")
                ComboBoxEdit2.SelectedIndex = ValNull(Registros!z_rep_periodo, "N")
                ComboBoxEdit3.SelectedIndex = ValNull(Registros!z_rep_enviar, "N")
                ComboBoxEdit8.SelectedIndex = ValNull(Registros!z_aud_genero, "N")
                ComboBoxEdit9.SelectedIndex = ValNull(Registros!z_aud_edad, "N")
                ComboBoxEdit7.SelectedIndex = ValNull(Registros!z_aud_pausa, "N")
                ComboBoxEdit6.SelectedIndex = IIf(ValNull(Registros!z_aud_guardar, "A") = "S", 0, 1)
                ComboBoxEdit5.SelectedIndex = IIf(ValNull(Registros!z_aud_reproducir, "A") = "S", 0, 1)
                TrackBarControl1.Value = ValNull(Registros!z_aud_velocidad, "N")
                TextEdit3.Text = ValNull(Registros!z_sms_restan, "A")
                If Not Registros!z_sms_fecha.Equals(System.DBNull.Value) Then
                    TextEdit4.Text = Format(Registros!z_sms_fecha, "dd/MM/yyyy")
                Else
                    TextEdit4.Text = ""
                End If
                TextEdit8.Text = ValNull(Registros!z_mail_usuario, "A")
                TextEdit9.Text = ValNull(Registros!z_segundos_censo, "N")
                TextEdit7.Text = ValNull(Registros!z_mail_contrasena, "A")
                TextEdit5.Text = ValNull(Registros!z_mail_puerto, "A")
                TextEdit6.Text = ValNull(Registros!z_mail_host, "A")
                TextEdit16.Text = Strings.Replace(ValNull(Registros!z_aud_ruta, "A"), "/", "\")
                TextEdit17.Text = Strings.Replace(ValNull(Registros!z_aud_ruta2, "A"), "/", "\")
                TextEdit18.Text = Strings.Replace(ValNull(Registros!z_aud_ruta3, "A"), "/", "\")
                If Val(TextEdit9.EditValue) > 0 Then
                    Timer1.Enabled = False
                    Timer1.Interval = Val(TextEdit9.EditValue) * 1000
                    Timer1.Enabled = True
                End If
                Memo1 = ValNull(Registros!z_rep_subject, "A")
                Memo2 = ValNull(Registros!z_rep_cuerpo, "A")
                Memo3 = ValNull(Registros!z_rep_para, "A")
                SimpleButton3.Enabled = True
            Else
                SimpleButton3.Enabled = False
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


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If SimpleButton2.Text = "&Cancelar" Then
            RecuperarDatos()
            CheckEdit1.Focus()
            SimpleButton2.Text = "&Cerrar"
            SimpleButton1.Enabled = False
        Else
            Me.Visible = False
        End If
    End Sub

    Private Sub args_Showing(sender As Object, e As XtraMessageShowingArgs)
        e.Buttons(DialogResult.OK).Text = "&Aceptar"
        e.Buttons(DialogResult.OK).ImageOptions.Image = My.Resources.Resource1.symbol_check_icon
        e.Buttons(DialogResult.OK).ImageOptions.Location = ImageLocation.MiddleLeft
        e.Buttons(DialogResult.OK).Font = MiFuente
        e.Form.Appearance.Font = MiFuente
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
    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Visible = True
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Visible = True
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Me.Close()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim Imagen As Bitmap = New Bitmap(My.Resources.Resource1.help)
        Dim Icono As Icon = Icon.FromHandle(Imagen.GetHicon)

        Dim args As New XtraMessageBoxArgs
        AddHandler args.Showing, AddressOf Me.args_Showing2
        args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
        args.Text = "Esta acción finalizará la aplicación y no se monitrorearán los mensajes." & Environment.NewLine & "¿Desea cerrar la aplicación?"
        args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
        args.Icon = Icono
        XtraMessageBox.SmartTextWrap = True
        Dim Respuesta As Integer = XtraMessageBox.Show(args)
        '. . . 
        If Respuesta = 2 Then
            e.Cancel = True
        Else
            Dim CadSQL As String = "update z_mensajes_config set z_finalizado = '" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "'"
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Comando.ExecuteReader()
        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim Imagen As Bitmap = New Bitmap(My.Resources.Resource1.help)
        Dim Icono As Icon = Icon.FromHandle(Imagen.GetHicon)
        Dim args As New XtraMessageBoxArgs
        Dim args2 As New XtraMessageBoxArgs
        Procesando = True
        AddHandler args.Showing, AddressOf Me.args_Showing2
        args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
        args.Text = "Al cambiar los parámetros la aplicación puede resultar inestable." & Environment.NewLine & "¿Desea continuar y guardar los cambios?"
        args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
        args.Icon = Icono
        XtraMessageBox.SmartTextWrap = True
        Dim Respuesta As Integer = XtraMessageBox.Show(args)
        '. . . 
        If Respuesta = 2 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        TextEdit17.Text = ""
        TextEdit18.Text = ""
        Try
            If TextEdit9.EditValue = 0 Then TextEdit9.EditValue = 1
            Dim CadSQL As String = "update z_mensajes_config set z_activar = 'S', z_sms_activar = '" & IIf(CheckEdit1.Checked, "S", "N") & "', z_mail_activar  = '" & IIf(CheckEdit2.Checked, "S", "N") & "', z_usar_ssl = '" & IIf(CheckEdit3.Checked, "S", "N") & "', z_rep_activar = '" & IIf(CheckEdit9.Checked, "S", "N") & "', z_aud_activar = '" & IIf(CheckEdit11.Checked, "S", "N") & "', z_rep_ssl = '" & IIf(CheckEdit8.Checked, "S", "N") & "', z_rep_usuario = '" & TextEdit12.Text & "', z_rep_contrasena = '" & TextEdit13.Text & "', z_rep_puerto = '" & TextEdit15.Text & "', z_rep_host = '" & TextEdit14.Text & "', z_sms_usuario = '" & TextEdit1.Text & "', z_sms_contrasena = '" & TextEdit2.Text & "', z_sms_manejador = '" & ComboBoxEdit1.SelectedIndex & "', z_aud_genero = " & Val(ComboBoxEdit8.SelectedIndex) & ", z_aud_edad = " & Val(ComboBoxEdit9.SelectedIndex) & ", z_aud_velocidad = " & TrackBarControl1.Value & ", z_aud_pausa = " & Val(ComboBoxEdit7.SelectedIndex) & ", z_aud_guardar = '" & IIf(ComboBoxEdit6.SelectedIndex = 0, "S", "N") & "', z_aud_reproducir = '" & IIf(ComboBoxEdit5.SelectedIndex = 0, "S", "N") & "', z_rep_periodo = '" & ComboBoxEdit2.SelectedIndex & "', z_rep_enviar = '" & ComboBoxEdit3.SelectedIndex & "', z_mail_usuario = '" & TextEdit8.Text & "', z_mail_contrasena = '" & TextEdit7.Text & "', z_mail_puerto = '" & TextEdit5.Text & "', z_mail_host = '" & TextEdit6.Text & "', z_segundos_censo = " & TextEdit9.EditValue & ", z_envio = '" & IIf(CheckEdit4.Checked, "S", "N") & "', z_reenvio = '" & IIf(CheckEdit5.Checked, "S", "N") & "', z_cancela = '" & IIf(CheckEdit6.Checked, "S", "N") & "', z_sms_ssl = '" & IIf(CheckEdit7.Checked, "S", "N") & "', z_sms_host = '" & TextEdit10.EditValue & "', z_rep_subject = '" & Memo1 & "', z_rep_cuerpo = '" & Memo2 & "', z_rep_para = '" & Memo3 & "', z_sms_puerto = '" & TextEdit11.EditValue & "', z_aud_ruta = '" & Strings.Replace(TextEdit16.EditValue, "\", "/") & "', z_aud_ruta2 = '" & Strings.Replace(TextEdit17.EditValue, "\", "/") & "', z_aud_ruta3 = '" & Strings.Replace(TextEdit18.EditValue, "\", "/") & "', z_iniciado = '" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "'"
            Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Dim LineasAfectadas As Integer = Comando.ExecuteReader().RecordsAffected
            If LineasAfectadas = 0 Then

                'Se arega el registro
                CadSQL = "insert into z_mensajes_config (z_activar, z_sms_activar, z_mail_activar, z_sms_usuario, z_sms_contrasena, z_sms_manejador, z_sms_restan, z_sms_enviados, z_sms_fecha, z_mail_usuario, z_mail_contrasena, z_mail_puerto, z_mail_host, z_segundos_censo, z_usar_ssl, z_envio, z_reenvio, z_cancela, z_sms_host, z_sms_puerto, z_sms_ssl, z_rep_activar, z_rep_usuario, z_rep_contrasena, z_rep_puerto, z_rep_host, z_rep_ssl, z_rep_periodo, z_rep_subject, z_rep_cuerpo, z_rep_para, z_rep_enviar, z_aud_activar, z_aud_genero, z_aud_edad, z_aud_velocidad, z_aud_pausa, z_aud_guardar, z_aud_reproducir, z_aud_ruta, z_aud_ruta2, z_aud_ruta3) values ('S', '" & IIf(CheckEdit1.Checked, "S", "N") & "', '" & IIf(CheckEdit2.Checked, "S", "N") & "', '" & TextEdit1.Text & "', '" & TextEdit2.Text & "', '" & ComboBoxEdit1.SelectedIndex & "', 0, 0, '" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "', '" & TextEdit8.Text & "', '" & TextEdit7.Text & "', '" & TextEdit5.Text & "', '" & TextEdit6.Text & "', " & TextEdit9.EditValue & ", '" & IIf(CheckEdit3.Checked, "S", "N") & "', '" & IIf(CheckEdit4.Checked, "S", "N") & "', '" & IIf(CheckEdit5.Checked, "S", "N") & "', '" & IIf(CheckEdit6.Checked, "S", "N") & "', '" & TextEdit10.Text & "', '" & TextEdit11.Text & "', '" & IIf(CheckEdit7.Checked, "S", "N") & "', '" & IIf(CheckEdit9.Checked, "S", "N") & "', '" & TextEdit12.Text & "', '" & TextEdit13.Text & "', '" & TextEdit15.Text & "', '" & TextEdit14.Text & "', '" & IIf(CheckEdit8.Checked, "S", "N") & "', " & ComboBoxEdit2.SelectedIndex & ", '" & Memo1 & "', '" & Memo2 & "', '" & Memo3 & "', " & ComboBoxEdit3.SelectedIndex & ", '" & IIf(CheckEdit11.Checked, "S", "N") & "', " & Val(ComboBoxEdit8.SelectedIndex) & ", " & Val(ComboBoxEdit9.SelectedIndex) & ", " & TrackBarControl1.Value & ", " & Val(ComboBoxEdit7.SelectedIndex) & ", '" & IIf(ComboBoxEdit6.SelectedIndex = 0, "S", "N") & "', '" & IIf(ComboBoxEdit5.SelectedIndex = 0, "S", "N") & "', '" & Strings.Replace(TextEdit16.EditValue, "\", "/") & "', '" & Strings.Replace(TextEdit17.EditValue, "\", "/") & "', '" & Strings.Replace(TextEdit18.EditValue, "\", "/") & "')"
                Comando = New OdbcCommand(CadSQL)
                Comando.Connection = MiConexion
                Comando.CommandType = CommandType.Text
                Comando.ExecuteReader()
            End If
            Timer1.Interval = Val(TextEdit9.EditValue) * 1000
            Timer1.Enabled = False
            Timer1.Enabled = True
            ToolStripMenuItem5_Click(sender, e)
            SimpleButton3.Enabled = True
        Catch ex As Exception
            AddHandler args2.Showing, AddressOf Me.args_Showing
            args2.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
            args2.Text = ex.Message
            args2.Buttons = New DialogResult() {DialogResult.OK}
            args2.Icon = Icono
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(args2)

        End Try
        CheckEdit1.Focus()
        CambiarBotones(2)
        SimpleButton2.Text = "&Cerrar"
        SimpleButton2.Enabled = True
        Procesando = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Procesando = True
        Dim Forma As New Form7
        Forma.Show()
        Procesando = False
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Visible = False
        NotifyIcon1.Visible = True

    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Procesando Then Exit Sub
        If Not ToolStripMenuItem4.Visible Then ToolStripMenuItem4.Visible = True
        NotifyIcon1.Text = "Trabajando..."
        Dim UltimoID As String
        Procesando = True
        Dim CadSQL As String
        CancelarOperacion = False
        Dim Registros As OdbcDataReader
        Dim AppConfig As OdbcDataReader

        Dim Recipiente As OdbcDataReader

        Dim ESMS As Boolean = False
        Dim EEMA As Boolean = False
        Dim EREP As Boolean = False
        Dim EAUD As Boolean = False
        Dim AASMSCuenta As String
        Dim AASMSPass As String
        Dim AASMSManejador As String
        Dim AASPuerto As Integer
        Dim AASHost As String
        Dim AASSSL As Boolean

        Dim AAMCuenta As String
        Dim AAMPass As String
        Dim AAMPuerto As Integer
        Dim AAMHost As String
        Dim AAMSSL As Boolean
        Dim MEnv As Boolean
        Dim MRee As Boolean
        Dim MCan As Boolean

        Dim AARCuenta As String
        Dim AARPass As String
        Dim AARPuerto As Integer
        Dim AARHost As String
        Dim AARSSL As Boolean
        Dim AARTit As String
        Dim AARPara As String
        Dim AARCpo As String
        Dim AAREnv As Integer
        Dim AARPer As Integer
        Dim NoError As Boolean = False
        Dim Velocidad As Integer

        'Se toman los datos activos de la configuración
        CadSQL = "select * from z_mensajes_config"
        Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
        Comando.Connection = MiConexion
        Comando.CommandType = CommandType.Text
        AppConfig = Comando.ExecuteReader
        If Not AppConfig.HasRows Then
            AppConfig.Close()
            Comando.CommandText = "insert into z_mensajes_log (z_estatus, z_causa, z_texto) values ('2', '4', 'No existe configuración')"
            Comando.ExecuteReader()
            Procesando = False
            NotifyIcon1.Text = "Cronos::. Envío de SMS y emails"
            Exit Sub
        Else
            ESMS = ValNull(AppConfig!z_sms_activar, "A").ToString = "S"
            EEMA = ValNull(AppConfig!z_mail_activar, "A").ToString = "S"
            EREP = ValNull(AppConfig!z_rep_activar, "A").ToString = "S" And CheckEdit9.Enabled 
            EAUD = ValNull(AppConfig!z_aud_activar, "A").ToString = "S"
            MEnv = ValNull(AppConfig!z_envio, "A").ToString = "S"
            MRee = ValNull(AppConfig!z_reenvio, "A").ToString = "S"
            MCan = ValNull(AppConfig!z_cancela, "A").ToString = "S"
            AASMSCuenta = ValNull(AppConfig!z_sms_usuario, "A").ToString
            AASMSPass = ValNull(AppConfig!z_sms_contrasena, "A").ToString
            AASMSManejador = ValNull(AppConfig!z_sms_manejador, "A").ToString
            AAMCuenta = ValNull(AppConfig!z_mail_usuario, "A").ToString
            AAMPass = ValNull(AppConfig!z_mail_contrasena, "A").ToString
            AAMPuerto = Val(ValNull(AppConfig!z_mail_puerto, "A").ToString)
            AAMHost = ValNull(AppConfig!z_mail_host, "A")
            AAMSSL = ValNull(AppConfig!z_usar_ssl, "A").ToString = "S"
            AASPuerto = Val(ValNull(AppConfig!z_sms_puerto, "A").ToString)
            AASHost = ValNull(AppConfig!z_sms_host, "A")
            AASSSL = ValNull(AppConfig!z_sms_ssl, "A").ToString = "S"

            AARCuenta = ValNull(AppConfig!z_rep_usuario, "A")
            AARPass = ValNull(AppConfig!z_rep_contrasena, "A")
            AARPuerto = Val(ValNull(AppConfig!z_rep_puerto, "A"))
            AARHost = ValNull(AppConfig!z_rep_host, "A")
            AARSSL = ValNull(AppConfig!z_rep_ssl, "A").ToString = "S"
            AARTit = ValNull(AppConfig!z_rep_subject, "A")
            AARPara = ValNull(AppConfig!z_rep_para, "A")
            AARCpo = ValNull(AppConfig!z_rep_cuerpo, "A")
            AAREnv = Val(ValNull(AppConfig!z_rep_enviar, "N"))
            AARPer = Val(ValNull(AppConfig!z_rep_periodo, "N"))
            Velocidad = Val(ValNull(AppConfig!z_aud_velocidad, "N"))

            If Not ESMS And Not EEMA And Not EREP And Not EAUD Then
                Dim Comando4 As OdbcCommand = New OdbcCommand("insert into z_mensajes_log (z_estatus, z_causa, z_texto) values ('2', '4', 'La configuración indica que no se envién SMS, emails, reportes ni audios')")
                Comando4.Connection = MiConexion
                Comando4.CommandType = CommandType.Text
                Comando4.ExecuteReader()
                Procesando = False
                NotifyIcon1.Text = "Cronos::. Envío de SMS y emails"
                Exit Sub
            End If
            If Not MEnv And Not MRee And Not MCan And Not EREP Then
                Dim Comando5 As OdbcCommand = New OdbcCommand("insert into z_mensajes_log (z_estatus, z_causa, z_texto) values ('2', '4', 'La configuración indica que no se envién mensajes (Envio, Reenvio, Cancelacion)')")
                Comando5.Connection = MiConexion
                Comando5.CommandType = CommandType.Text
                Comando5.ExecuteReader()
                Procesando = False
                NotifyIcon1.Text = "Cronos::. Envío de SMS y emails"
                Exit Sub
            End If
        End If
        AppConfig.Close()
        If (MEnv Or MRee Or MCan) And (ESMS Or EEMA Or EAUD) Then
            Comando.CommandText = "select z_ultimo_id from z_mensajes_config"
            Registros = Comando.ExecuteReader
            If Registros.HasRows Then
                If Not Registros!z_ultimo_id.Equals(System.DBNull.Value) Then
                    UltimoID = Format(Registros!z_ultimo_id, "yyyy/MM/dd HH:mm:ss")
                Else
                    UltimoID = Format(Now, "yyyy/MM/dd HH:mm:ss")
                End If
                'Censo de la tabla de mensajes
            Else
                UltimoID = Format(Now, "yyyy/MM/dd HH:mm:ss")
            End If
            Registros.Close()
            Dim TipoMSG As String = IIf(EEMA And ESMS, "A", IIf(ESMS, "S", "E"))
            Dim CadStaff As String = ""
            Dim ArregloStaff() As String
            Dim UStaff As String
            Dim CadWhere As String = ""
            CadWhere = " and type in ("
            If MEnv Then
                CadWhere = CadWhere & "'send_message', "
            End If
            If MRee Then
                CadWhere = CadWhere & "'repeat_message', "
            End If
            If MCan Then
                CadWhere = CadWhere & "'cancel_record', "
            End If
            CadWhere = Strings.Left(CadWhere, Len(CadWhere) - 2) & ") "

            CadSQL = "Select messages.*, records.requester_name from messages left join records on messages.record_id = records.id where messages.datetime > '" & UltimoID & "' " & CadWhere & " order by messages.datetime"
            Comando.CommandText = CadSQL
            Registros = Comando.ExecuteReader
            Dim MMovil As String
            Dim MMail As String
            Dim MPrefijo As String
            Dim MMensaje As String
            Dim UMensaje As DateTime
            Dim MMIDR As Double
            Dim HuboUnMensaje As Boolean = False
            Dim Separador As String = CultureInfo.CurrentCulture.TextInfo.ListSeparator
            If Registros.HasRows Then
                Do While Registros.Read
                    Application.DoEvents()
                    If CancelarOperacion Then
                        NotifyIcon1.Text = "Cronos::. Envío de SMS y emails"
                        CancelarOperacion = False
                        Exit Sub
                    End If
                    'Se agrega el log
                    'Se separan los recipientes
                    Dim Escalar As Boolean = False
                    Dim RCPT As String = ""
                    Dim MsgEscalar As String = ""
                    Dim TTLSegundos As Integer = 0
                    CadStaff = ValNull(Registros!received_by, "A").ToString
                    ArregloStaff = CadStaff.Split(New Char() {","c})
                    Dim CadTo As String = ""
                    Dim CadToSMS As String = ""
                    Dim EliminaEscalar As Boolean = False
                    For Each UStaff In ArregloStaff
                        'Se busca el recipiente
                        If UStaff.Trim.Length > 0 Then
                            Dim Comando2 As OdbcCommand = New OdbcCommand("Select * from z_mensajes_perfiles where z_nombre = '" & UStaff.Trim & "'")
                            Comando2.Connection = MiConexion
                            Comando2.CommandType = CommandType.Text
                            MMensaje = ValNull(Registros!message, "A").ToString.Trim

                            Recipiente = Comando2.ExecuteReader
                            If Recipiente.HasRows Then
                                If ValNull(Registros!type, "A") <> "cancel_record" Then
                                    Escalar = IIf(ValNull(Recipiente!z_demorado, "A") = "S", True, False)
                                    RCPT = ValNull(Recipiente!z_recipiente, "A")
                                    MsgEscalar = ValNull(Registros!message, "A")
                                    Escalar = Escalar And RCPT.Trim.Length > 0
                                    TTLSegundos = ValNull(Recipiente!z_segundos, "N")
                                Else
                                    EliminaEscalar = True
                                End If
                                MMovil = ValNull(Recipiente!z_movil, "A").ToString.Trim
                                MMail = ValNull(Recipiente!z_email, "A").ToString.Trim
                                MPrefijo = ValNull(Recipiente!z_prefijo_mensaje, "A").ToString.Trim
                                If TipoMSG = "A" Or TipoMSG = "E" And MMail.Length > 0 Then
                                    CadTo = CadTo & MMail & Separador & " "
                                End If
                                If TipoMSG = "A" Or TipoMSG = "S" And MMovil.Length > 0 Then
                                    CadToSMS = CadToSMS & MMovil & "@masmensajes.com.mx, "
                                    'NoError = EnviarSMS(UStaff, MMovil, MPrefijo, AASMSCuenta, AASMSPass, MMensaje, Registros!record_id, Registros!id, AASMSManejador)
                                End If
                            Else
                                Dim Comando3 As OdbcCommand = New OdbcCommand("insert into z_mensajes_log (z_recipiente, z_tipo_mensaje, z_estatus, z_causa, z_texto) values ('" & UStaff & "', '" & TipoMSG & "', '2', '1', 'Recipiente no registrado en Cronos:Mensajes')")
                                Comando3.Connection = MiConexion
                                Comando3.CommandType = CommandType.Text
                                Comando3.ExecuteReader()
                            End If
                            Recipiente.Close()
                        End If
                    Next
                    Dim SeEnvio As Boolean = False
                    If CadTo.Length > 0 And EEMA Then
                        CadTo = Strings.Left(CadTo, CadTo.Length - 2)
                        NoError = EnviarMail(CadStaff, CadTo, MPrefijo, AAMCuenta, AAMPass, AAMSSL, AAMHost, AAMPuerto, MMensaje, Registros!record_id, Registros!id)
                        SeEnvio = True
                    End If
                    If CadToSMS.Length > 0 And ESMS Then
                        CadToSMS = Strings.Left(CadToSMS, CadToSMS.Length - 2)
                        NoError = EnviarSMSMail(CadStaff, CadToSMS, MPrefijo, AASMSCuenta, AASMSPass, AASSSL, AASHost, AASPuerto, MMensaje, Registros!record_id, Registros!id)
                        SeEnvio = True
                    End If
                    If EEMA Or ESMS Then
                        If EliminaEscalar Then
                            Dim Comando91 As OdbcCommand = New OdbcCommand("delete from z_delays where message = " & Registros!id & " and record = " & Registros!record_id)
                            Comando91.Connection = MiConexion
                            Comando91.CommandType = CommandType.Text
                            Comando91.ExecuteReader()
                        ElseIf SeEnvio And Escalar Then
                            'Se guarda el mensaje para escalarlo
                            Dim Comando92 As OdbcCommand = New OdbcCommand("Select message from z_delays where message = " & Registros!id & " and record = " & Registros!record_id)
                            Comando92.Connection = MiConexion
                            Comando92.CommandType = CommandType.Text
                            Recipiente = Comando92.ExecuteReader
                            If Not Recipiente.HasRows Then
                                Dim Comando93 As OdbcCommand = New OdbcCommand("insert into z_delays (message, record, recipiente, segundos, mensaje, time) values (" & Registros!id & ", " & Registros!record_id & ", '" & RCPT & "', " & TTLSegundos & ", '" & MsgEscalar & "', '" & Format(DateTime.Now, "yyyy/MM/dd HH:mm:ss") & "')")
                                Comando93.Connection = MiConexion
                                Comando93.CommandType = CommandType.Text
                                Comando93.ExecuteReader()
                            End If
                        End If
                    End If
                    If EAUD Then
                        Try
                            'Dim oFileStream, oVoice
                            Dim LaRuta As String
                            If My.Computer.FileSystem.DirectoryExists(TextEdit16.Text) Then
                                LaRuta = TextEdit16.Text
                            Else
                                LaRuta = Application.StartupPath
                            End If

                            RutaAudio2 = ""
                            If TextEdit17.Text.Length > 0 Then
                                Dim LaRuta2 As String
                                If My.Computer.FileSystem.DirectoryExists(TextEdit17.Text) Then
                                    LaRuta2 = TextEdit17.Text
                                Else
                                    LaRuta2 = Application.StartupPath
                                End If
                                RutaAudio2 = LaRuta2 & "\Audio" & Format(DateAndTime.Now, "yyyyMMddHHmmss") & ".wav"
                            End If
                            RutaAudio3 = ""
                            If TextEdit18.Text.Length > 0 Then
                                Dim LaRuta3 As String
                                If My.Computer.FileSystem.DirectoryExists(TextEdit18.Text) Then
                                    LaRuta3 = TextEdit18.Text
                                Else
                                    LaRuta3 = Application.StartupPath
                                End If
                                RutaAudio3 = LaRuta3 & "\Audio" & Format(DateAndTime.Now, "yyyyMMddHHmmss") & ".wav"
                            End If
                            Dim MiMensaje As String = MPrefijo & " " & MMensaje
                            Dim MensajeMaster As String = ""
                            Dim Comando999 As OdbcCommand = New OdbcCommand

                            Comando999.CommandText = "select traduccion from z_mensajes_traduccion where mensaje = '" & MiMensaje.Trim.ToUpper & "'"
                            Comando999.Connection = MiConexion
                            Dim Traduccion As OdbcDataReader = Comando999.ExecuteReader
                            If Traduccion.HasRows Then
                                MensajeMaster = ValNull(Traduccion!traduccion, "A")
                                Traduccion.Close()
                            Else
                                MensajeMaster = ""
                                Dim CadMensajes As String() = Split(MiMensaje, " ")
                                Dim MiTraducccion As String
                                Traduccion.Close()
                                If CadMensajes.Length > 0 Then
                                    For i = 0 To CadMensajes.Length - 1
                                        Comando999.CommandText = "select traduccion from z_mensajes_traduccion where mensaje ='" & Strings.Trim(CadMensajes(i)).ToUpper & "'"
                                        Comando999.Connection = MiConexion
                                        Traduccion = Comando999.ExecuteReader
                                        If Traduccion.HasRows Then
                                            MiTraducccion = ValNull(Traduccion!traduccion, "A")
                                        Else
                                            MiTraducccion = CadMensajes(i)
                                        End If
                                        MiTraducccion = Strings.Trim(MiTraducccion)
                                        If i = 0 Then
                                            MensajeMaster = MiTraducccion
                                        Else
                                            MensajeMaster = MensajeMaster & " " & Strings.Trim(MiTraducccion)
                                        End If
                                        Traduccion.Close()
                                    Next
                                Else
                                    MensajeMaster = MiMensaje
                                End If
                            End If
                            'Se busca si hay una ruta adicional

                            Dim RutaAdicional As String
                            Dim SinCarpeta As Boolean = False
                            For Each UStaff In ArregloStaff
                                'Se busca el recipiente
                                If UStaff.Trim.Length > 0 Then
                                    RutaAdicional = ""
                                    Comando999.CommandText = "select carpeta from z_mensajes_carpetas where area = '" & UStaff.Trim & "'"
                                    Comando999.Connection = MiConexion
                                    Traduccion = Comando999.ExecuteReader
                                    If Traduccion.HasRows Then
                                        RutaAdicional = ValNull(Traduccion!carpeta, "A")
                                        RutaAdicional = Strings.Replace(RutaAdicional, "/", "\")
                                    End If
                                    If RutaAdicional.Length > 0 Then
                                        RutaAudio = RutaAdicional & "\Audio" & Format(DateAndTime.Now, "yyyyMMddHHmmss") & ".wav"
                                        Dim synthesizer0 As New SpeechSynthesizer()
                                        synthesizer0.SetOutputToWaveFile(RutaAudio)
                                        synthesizer0.SelectVoice(ComboBoxEdit9.Text)
                                        synthesizer0.Volume = 100 '  // 0...100
                                        synthesizer0.Rate = TrackBarControl1.Value - 5 '     // -10...10
                                        Dim builder2 As New PromptBuilder()
                                        builder2.AppendText(MensajeMaster)
                                        builder2.Culture = synthesizer0.Voice.Culture
                                        synthesizer0.Speak(builder2)
                                        synthesizer0.SetOutputToDefaultAudioDevice()
                                    Else
                                        SinCarpeta = True
                                    End If
                                    Traduccion.Close()
                                End If
                            Next
                            'If SinCarpeta Then
                            If RutaAudio = RutaAudio2 Then RutaAudio2 = ""
                            If RutaAudio = RutaAudio3 Then RutaAudio3 = ""
                            If RutaAudio2 = RutaAudio3 Then RutaAudio3 = ""
                            RutaAudio = LaRuta & "\Audio" & Format(DateAndTime.Now, "yyyyMMddHHmmss") & ".wav"
                            Dim synthesizer As New SpeechSynthesizer()
                            synthesizer.SetOutputToWaveFile(RutaAudio)
                            synthesizer.SelectVoice(ComboBoxEdit9.Text)
                            synthesizer.Volume = 100 '  // 0...100
                            synthesizer.Rate = TrackBarControl1.Value - 5 '     // -10...10
                            Dim builder As New PromptBuilder()
                            builder.AppendText(MensajeMaster)
                            builder.Culture = synthesizer.Voice.Culture
                            synthesizer.Speak(builder)
                            synthesizer.SetOutputToDefaultAudioDevice()
                            'If RutaAudio2.Length > 0 Then
                            ' Dim synthesizer2 As New SpeechSynthesizer()
                            ' synthesizer2.SetOutputToWaveFile(RutaAudio2)
                            ' synthesizer2.SelectVoice(ComboBoxEdit9.Text)
                            ' synthesizer2.Volume = 100 '  // 0...100
                            ' synthesizer2.Rate = TrackBarControl1.Value - 5 '     // -10...10
                            ' Dim builder2 As New PromptBuilder()
                            ' builder2.AppendText(MensajeMaster)
                            ' builder2.Culture = synthesizer2.Voice.Culture
                            ' synthesizer2.Speak(builder2)
                            ' synthesizer2.SetOutputToDefaultAudioDevice()
                            ' End If
                            '         If RutaAudio3.Length > 0 Then
                            '         Dim synthesizer3 As New SpeechSynthesizer()
                            '         synthesizer3.SetOutputToWaveFile(RutaAudio3)
                            '         synthesizer3.SelectVoice(ComboBoxEdit9.Text)
                            '         synthesizer3.Volume = 100 '  // 0...100
                            '         synthesizer3.Rate = TrackBarControl1.Value - 5 '     // -10...10
                            '         Dim builder3 As New PromptBuilder()
                            '         builder3.AppendText(MensajeMaster)
                            '         builder3.Culture = synthesizer3.Voice.Culture
                            '         synthesizer3.Speak(builder3)
                            '         synthesizer3.SetOutputToDefaultAudioDevice()
                            ' End If
                            'End If
                            '''
                        Catch ex As Exception
                            Dim Comando99 As OdbcCommand = New OdbcCommand("insert into z_mensajes_log (z_recipiente, z_tipo_mensaje, z_estatus, z_causa, z_texto) values ('Audios', 'A', '2', '1', 'No se pudo generar el audio')")
                            Comando99.Connection = MiConexion
                            Comando99.CommandType = CommandType.Text
                            Comando99.ExecuteReader()
                        End Try

                    End If
                    HuboUnMensaje = True
                    UMensaje = Registros!datetime
                    Dim Comando1000 As OdbcCommand = New OdbcCommand("update z_mensajes_config set z_ultimo_id = '" & Format(UMensaje, "yyyy/MM/dd HH:mm:ss") & "'")
                    Comando1000.Connection = MiConexion

                    Comando1000.CommandType = CommandType.Text
                    Comando1000.ExecuteReader()

                Loop

            End If

            'Se busca si hay mensajes a escalar
            CadSQL = "Select * from z_delays order by time"
            Dim Comando100 As OdbcCommand = New OdbcCommand(CadSQL)
            Comando100.Connection = MiConexion
            Comando100.CommandText = CadSQL
            Registros = Comando100.ExecuteReader
            If Registros.HasRows Then
                Do While Registros.Read
                    Application.DoEvents()
                    If CancelarOperacion Then
                        NotifyIcon1.Text = "Cronos::. Envío de SMS y emails"
                        CancelarOperacion = False
                        Exit Sub
                    End If
                    'Se valida si está cancelado

                    CadSQL = "Select * from messages where type = 'cancel_record' and messages.id = " & Registros!record
                    Dim Comando101 As OdbcCommand = New OdbcCommand(CadSQL)
                    Comando101.Connection = MiConexion
                    Comando101.CommandText = CadSQL
                    Recipiente = Comando101.ExecuteReader
                    If Not Recipiente.HasRows Then
                        Dim Comando111 As OdbcCommand = New OdbcCommand("delete from z_delays where message = " & Registros!message & " and record = " & Registros!record)
                        Comando111.Connection = MiConexion
                        Comando111.CommandType = CommandType.Text
                        Comando111.ExecuteReader()
                    Else

                        Dim ParaQuien As String = ValNull(Registros!recipiente, "A").ToString
                        Dim MiTiempo As Integer = ValNull(Registros!segundos, "N")
                        Dim MiMensaje As String = ValNull(Registros!mensaje, "A")
                        Dim DesdeHora As String = Format(Registros!time, "yyyy/MM/dd HH:mm:ss")
                        If DateAdd("s", MiTiempo, DateTime.Parse(DesdeHora)) <= Now Then
                            Dim Comando112 As OdbcCommand = New OdbcCommand("Select * from z_mensajes_perfiles where z_nombre = '" & ParaQuien.Trim & "'")
                            Comando112.Connection = MiConexion
                            Comando112.CommandType = CommandType.Text
                            Recipiente = Comando112.ExecuteReader
                            If Recipiente.HasRows Then
                                MMovil = ValNull(Recipiente!z_movil, "A").ToString.Trim
                                MMail = ValNull(Recipiente!z_email, "A").ToString.Trim
                                MPrefijo = ValNull(Recipiente!z_prefijo_mensaje, "A").ToString.Trim
                                Recipiente.Close()
                                Dim SeEnvio As Boolean = False
                                If MMail.Length > 0 Then
                                    NoError = EnviarMail(ParaQuien, MMail, MPrefijo, AAMCuenta, AAMPass, AAMSSL, AAMHost, AAMPuerto, MiMensaje, Registros!record, Registros!message)
                                    SeEnvio = NoError
                                End If
                                If MMovil.Length > 0 Then
                                    NoError = EnviarSMSMail(CadStaff, MMovil, MPrefijo, AASMSCuenta, AASMSPass, AASSSL, AASHost, AASPuerto, MiMensaje, Registros!record, Registros!message)
                                    SeEnvio = NoError
                                End If
                                If SeEnvio Then
                                    'Se elimina el mensaje escalado
                                    Dim Comando110 As OdbcCommand = New OdbcCommand("delete from z_delays where message = " & Registros!message & " and record = " & Registros!record)
                                    Comando110.Connection = MiConexion
                                    Comando110.CommandType = CommandType.Text
                                    Comando110.ExecuteReader()
                                End If
                            End If
                        End If
                    End If
                Loop
            End If

            If Not HuboUnMensaje Then
                Dim Comando11 As OdbcCommand = New OdbcCommand("update z_mensajes_config set z_ultimo_id = '" & UltimoID & "'")
                Comando11.Connection = MiConexion
                Comando11.CommandType = CommandType.Text
                Comando11.ExecuteReader()
            End If
        End If


        If EREP Then
            Dim LaHora As DateTime = DateTime.Now
            Dim MiDia As String = Format(LaHora, "yyyy/MM/dd")
            'Se verifica si es feha/hora para enviar
            Dim Avanzar As Boolean = False
            Dim SiEnviar As Boolean = False
            If AAREnv = 0 And DateAndTime.Weekday(LaHora.Date) = 2 And LaHora.ToString("HH") = "00" Then
                Avanzar = True
            ElseIf AAREnv = 1 And DateAndTime.Weekday(LaHora.Date) = 3 And LaHora.ToString("HH") = "00" Then
                Avanzar = True
            ElseIf AAREnv = 2 And DateAndTime.Weekday(LaHora.Date) = 4 And LaHora.ToString("HH") = "00" Then
                Avanzar = True
            ElseIf AAREnv = 3 And DateAndTime.Weekday(LaHora.Date) = 5 And LaHora.ToString("HH") = "00" Then
                Avanzar = True
            ElseIf AAREnv = 4 And DateAndTime.Weekday(LaHora.Date) = 6 And LaHora.ToString("HH") = "00" Then
                Avanzar = True
            ElseIf AAREnv = 5 And DateAndTime.Weekday(LaHora.Date) = 7 And LaHora.ToString("HH") = "00" Then
                Avanzar = True
            ElseIf AAREnv = 6 And DateAndTime.Weekday(LaHora.Date) = 1 And LaHora.ToString("HH") = "00" Then
                Avanzar = True
            ElseIf AAREnv = 7 And LaHora.ToString("HH") = "00" Then
                Avanzar = True
            ElseIf AAREnv = 8 And LaHora.ToString("HH") = "01" Then
                Avanzar = True
            ElseIf AAREnv = 9 And LaHora.ToString("HH") = "03" Then
                Avanzar = True
            ElseIf AAREnv = 10 And LaHora.ToString("HH") = "05" Then
                Avanzar = True
            ElseIf AAREnv = 11 And LaHora.ToString("HH") = "07" Then
                Avanzar = True
            ElseIf AAREnv = 12 And LaHora.ToString("HH") = "09" Then
                Avanzar = True
            ElseIf AAREnv = 13 And LaHora.ToString("HH") = "12" Then
                Avanzar = True
            ElseIf AAREnv = 14 And LaHora.ToString("HH") = "13" Then
                Avanzar = True
            ElseIf AAREnv = 15 And LaHora.ToString("HH") = "15" Then
                Avanzar = True
            ElseIf AAREnv = 16 And LaHora.ToString("HH") = "18" Then
                Avanzar = True
            ElseIf AAREnv = 17 And LaHora.ToString("HH") = "20" Then
                Avanzar = True
            ElseIf AAREnv = 18 And LaHora.ToString("HH") = "22" Then
                Avanzar = True
            End If
            If Avanzar Then
                'Validar si ya se envió
                Dim Comando12 As OdbcCommand = New OdbcCommand("select z_ufecha from z_envio_reportes order by z_ufecha desc limit 1")
                Comando12.Connection = MiConexion
                Registros = Comando12.ExecuteReader
                If Not Registros.HasRows Then
                    SiEnviar = True
                Else
                    Registros.Read()
                    If Format(Registros!z_ufecha, "yyyy/MM/dd") <> MiDia Then
                        SiEnviar = True
                    End If
                End If
                Registros.Close()
                If SiEnviar Then
                    Dim Eti1 As String = ""
                    Dim Eti2 As String = ""
                    Dim Eti3 As String = ""
                    Dim Comando13 As OdbcCommand = New OdbcCommand("select * from z_graficos where z_tipo = 1")
                    Comando13.Connection = MiConexion
                    Registros = Comando13.ExecuteReader
                    If Registros.HasRows Then
                        If Registros.Read Then
                            Eti1 = ValNull(Registros!z_texto1, "A")
                            Eti2 = ValNull(Registros!z_texto2, "A")
                            Eti3 = ValNull(Registros!z_texto3, "A")
                        End If
                    End If
                    Registros.Close()
                    Dim MiMensaje As String = ""
                    Dim FechaDesde As String
                    Dim FechaHasta As String
                    'Se envia el reporte
                    'Se calcula el período
                    If AARPer = 0 Then
                        FechaDesde = Format(DateAdd("d", -7, DateTime.Now.Date), "yyyy/MM/dd") & " 00:00:00"
                        FechaHasta = Format(DateTime.Now.Date, "yyyy/MM/dd 23:58:59")
                    ElseIf AARPer = 1 Then
                        FechaDesde = Format(DateAdd("d", -14, DateTime.Now.Date), "yyyy/MM/dd") & " 00:00:00"
                        FechaHasta = Format(DateTime.Now.Date, "yyyy/MM/dd") & " 23:59:59"
                    ElseIf AARPer = 2 Then
                        FechaDesde = Format(DateAdd("d", -21, DateTime.Now.Date), "yyyy/MM/dd") & " 00:00:00"
                        FechaHasta = Format(DateTime.Now.Date, "yyyy/MM/dd") & " 23:59:59"
                    ElseIf AARPer = 3 Then
                        FechaDesde = Format(DateAdd("d", -30, DateTime.Now.Date), "yyyy/MM/dd") & " 00:00:00"
                        FechaHasta = Format(DateTime.Now.Date, "yyyy/MM/dd") & " 23:59:59"
                    ElseIf AARPer = 4 Then
                        FechaDesde = Format(DateTime.Now.Date, "yyyy/MM") & "/01 00:00:00"
                        FechaHasta = Format(DateTime.Now.Date, "yyyy/MM/dd") & " 23:59:59"
                    ElseIf AARPer = 5 Then
                        If DateAndTime.Weekday(DateTime.Now.Date) = 2 Then
                            FechaDesde = Format(DateTime.Now.Date, "yyyy/MM/dd") & " 00:00:00"
                        ElseIf DateAndTime.Weekday(DateTime.Now.Date) = 3 Then
                            FechaDesde = Format(DateAdd("d", -1, DateTime.Now.Date), "yyyy/MM/dd") & " 00:00:00"
                        ElseIf DateAndTime.Weekday(DateTime.Now.Date) = 4 Then
                            FechaDesde = Format(DateAdd("d", -2, DateTime.Now.Date), "yyyy/MM/dd") & " 00:00:00"
                        ElseIf DateAndTime.Weekday(DateTime.Now.Date) = 5 Then
                            FechaDesde = Format(DateAdd("d", -3, DateTime.Now.Date), "yyyy/MM/dd") & " 00:00:00"
                        ElseIf DateAndTime.Weekday(DateTime.Now.Date) = 6 Then
                            FechaDesde = Format(DateAdd("d", -4, DateTime.Now.Date), "yyyy/MM/dd") & " 00:00:00"
                        ElseIf DateAndTime.Weekday(DateTime.Now.Date) = 7 Then
                            FechaDesde = Format(DateAdd("d", -5, DateTime.Now.Date), "yyyy/MM/dd") & " 00:00:00"
                        ElseIf DateAndTime.Weekday(DateTime.Now.Date) = 1 Then
                            FechaDesde = Format(DateAdd("d", -6, DateTime.Now.Date), "yyyy/MM/dd") & " 00:00:00"
                        End If
                        FechaHasta = Format(DateTime.Now.Date, "yyyy/MM/dd") & " 23:59:59"
                    ElseIf AARPer = 6 Then
                        FechaDesde = Format(DateTime.Now.Date, "yyyy/MM/dd") & " 00:00:00"
                        FechaHasta = Format(DateTime.Now.Date, "yyyy/MM/dd") & " 23:59:59"
                    ElseIf AARPer = 6 Then
                        FechaDesde = Format(DateAdd("d", -1, DateTime.Now.Date), "yyyy/MM/dd") & " 00:00:00"
                        FechaHasta = Format(DateTime.Now.Date, "yyyy/MM/dd") & " 23:59:59"
                    End If
                    'Se genara el archivo de datos

                    Dim Cadena As String = ""
                    Dim LineaError As Integer = 0


                    Dim Comando14 As OdbcCommand = New OdbcCommand("select id, key_name, requester_name, staff, start_time, end_time, total_time, status, active, z_reason_user, z_timestamp, z_reason, z_nombre , z_text from records left join z_causas on z_reason = z_causas.z_id where start_time >= '" & FechaDesde & "' and start_time <= '" & FechaHasta & "' order by id desc")
                        Comando14.Connection = MiConexion
                        Comando14.CommandType = CommandType.Text
                        Registros = Comando14.ExecuteReader
                    Dim Mfecha As String
                    Dim Mfecha2 As String
                    Dim Separador As String = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator
                        If Registros.HasRows Then
                            Dim Cabecera As Boolean = False

                            Do While Registros.Read()
                                If Not Cabecera Then
                                    Cabecera = True
                                    Cadena = "ID" & Separador & " Solicitado a" & Separador & "Solicitado por" & Separador & "Repositorio (beeper)" & Separador & "Fecha y hora de inicio" & Separador & "Fecha y hora de fin" & Separador & "Tiempo total en segundos" & Separador & "Estatus" & Separador & "Estado/LLamada" & Separador & "Usuario que clasifico" & Separador & "Fecha y hora de clasificacion" & Separador & "Causa/Falla" & Separador & "Descripcion Causa/Falla" & Separador & "Texto descriptivo" & Chr(13) & Chr(10)
                                Else
                                    LineaError = LineaError + 1
                                If Registros!z_timestamp.Equals(System.DBNull.Value) Then
                                    Mfecha = ""
                                Else
                                    Mfecha = Format(Registros!z_timestamp, "dd/MM/yyyy HH:mm:ss")
                                End If
                                If Registros!end_time.Equals(System.DBNull.Value) Then
                                    Mfecha2 = ""
                                Else
                                    Mfecha2 = Format(Registros!end_time, "dd/MM/yyyy HH:mm:ss")
                                End If
                                Cadena = Cadena & Chr(34) & Registros!id & Chr(34) & Separador & Chr(34) & Registros!key_name & Chr(34) & Separador & Chr(34) & Registros!requester_name & Chr(34) & Separador & Chr(34) & Registros!staff & Chr(34) & Separador & Chr(34) & Format(Registros!start_time, "dd/MM/yyyy HH:mm:ss") & Chr(34) & Separador & Chr(34) & Mfecha2 & Chr(34) & Separador & Chr(34) & Registros!total_time & Chr(34) & Separador & Chr(34) & IIf(Registros!status = 1, Eti1 & " (" & Registros!status & ")", IIf(Registros!status = 2, Eti2 & " (" & Registros!status & ")", Eti3 & " (" & Registros!status & ")")) & Chr(34) & Separador & Chr(34) & IIf(Registros!active, "Activa", "Cerrada") & Chr(34) & Separador & Chr(34) & ValNull(Registros!z_reason_user, "A") & Chr(34) & Separador & Chr(34) & Mfecha & Chr(34) & Separador & Chr(34) & ValNull(Registros!z_reason, "A") & Chr(34) & Separador & Chr(34) & ValNull(Registros!z_nombre, "A") & Chr(34) & Separador & Chr(34) & ValNull(Registros!z_text, "A") & Chr(34) & Chr(13) & Chr(10)
                            End If
                            Loop
                        Else
                            MiMensaje = "No hay datos para el período especificado (" & FechaDesde & " - " & FechaHasta & ")"
                        End If

                    Graficas(FechaDesde, FechaHasta)
                    Graficas2(FechaDesde, FechaHasta)
                    Graficas3(FechaDesde, FechaHasta)
                    Graficas4(FechaDesde, FechaHasta)

                    NoError = EnviarReporte("", AARPara, "", AARCuenta, AARPass, AARSSL, AARHost, AARPuerto, AARCpo, 0, 0, AARTit, Cadena, MiMensaje, LaHora.ToString("yyyy/MM/dd HH:mm:ss"))
                End If
            End If
        End If
        Procesando = False
        NotifyIcon1.Text = "Cronos::. Envío de SMS y emails"
    End Sub


    Function EnviarMail(MMRecipiente As String, MMCuenta As String, MMPrefijo As String, MMUsuario As String, MMPass As String, MMSSL As Boolean, MMHost As String, MMPort As Integer, MMMensaje As String, IDR As Double, IDM As Double) As Boolean
        ErrorMail = ""
        EnviarMail = True
        Dim smtpServer As New SmtpClient()
        Dim mail As New MailMessage
        Try
            smtpServer.Credentials = New Net.NetworkCredential(MMUsuario, MMPass)
            smtpServer.Port = MMPort
            smtpServer.Host = MMHost '"smtp.gmail.com"
            smtpServer.EnableSsl = MMSSL 'True
            mail.From = New MailAddress(MMUsuario) 'TextBox1.Text & "@gmail.com")
            mail.To.Add(MMCuenta)
            mail.Subject = MMMensaje
            mail.Body = MMPrefijo & " " & MMMensaje
            smtpServer.Send(mail)
            smtpServer.Dispose()
            mail.Dispose()
        Catch ex As Exception
            EnviarMail = False
            Dim Comando As OdbcCommand = New OdbcCommand("insert into z_mensajes_log (z_recipiente, z_tipo_mensaje, z_estatus, z_causa, z_texto, z_mansaje_enviado, z_record, z_message) values ('" & MMRecipiente & "', 'E', '2', '3', '" & Strings.Replace(Strings.Left(ex.Message, 100).Trim, "'", "") & "', '" & MMMensaje & "', " & IDR & ", " & IDM & ")")
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Comando.ExecuteReader()
        End Try


    End Function

    Function EnviarReporte(MMRecipiente As String, MMCuenta As String, MMPrefijo As String, MMUsuario As String, MMPass As String, MMSSL As Boolean, MMHost As String, MMPort As Integer, MMMensaje As String, IDR As Double, IDM As Double, MMSubject As String, FileCSV As String, ElMensaje As String, Hora As String) As Boolean
        ErrorMail = ""
        EnviarReporte = True
        Dim smtpServer As New SmtpClient()
        Dim mail As New MailMessage
        Try
            smtpServer.Credentials = New Net.NetworkCredential(MMUsuario, MMPass)
            smtpServer.Port = MMPort '587
            smtpServer.Host = MMHost '"smtp.gmail.com"
            smtpServer.EnableSsl = MMSSL 'True
            mail.From = New MailAddress(MMUsuario) 'TextBox1.Text & "@gmail.com")
            mail.To.Add(MMCuenta)
            mail.Subject = MMSubject
            mail.Body = MMMensaje

            Dim Archivo As System.IO.StreamWriter = New System.IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\reportemmcall.csv", False)
            Archivo.WriteLine(FileCSV)
            Archivo.Close()

            Dim at As New Attachment(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\reportemmcall.csv")
            mail.Attachments.Add(at)
            Dim at2 As New Attachment(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NGrafica01)
            mail.Attachments.Add(at2)
            Dim at3 As New Attachment(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NGrafica02)
            mail.Attachments.Add(at3)
            Dim at4 As New Attachment(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NGrafica03)
            mail.Attachments.Add(at4)
            Dim at5 As New Attachment(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NGrafica04)
            mail.Attachments.Add(at5)
            mail.Priority = MailPriority.High
            mail.IsBodyHtml = True

            smtpServer.Send(mail)
            smtpServer.Dispose()
            mail.Dispose()
            'Se eliminan las imagebes

            File.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NGrafica01)
            File.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NGrafica02)
            File.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NGrafica03)
            File.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NGrafica04)
            File.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\reportemmcall.csv")

            Dim Comando As OdbcCommand = New OdbcCommand("insert into z_envio_reportes (z_ufecha) values ('" & Hora & "')")
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Comando.ExecuteReader()
        Catch ex As Exception
            EnviarReporte = False
            Dim Comando As OdbcCommand = New OdbcCommand("insert into z_mensajes_log (z_recipiente, z_tipo_mensaje, z_estatus, z_causa, z_texto, z_mansaje_enviado, z_record, z_message) values ('" & MMRecipiente & "', 'E', '2', '3', '" & Strings.Replace(Strings.Left(ex.Message, 100).Trim, "'", "") & "', '" & Strings.Left(MMMensaje, 100) & "', " & IDR & ", " & IDM & ")")
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Comando.ExecuteReader()
        End Try


    End Function

    Function EnviarSMSMail(MMRecipiente As String, MMCuenta As String, MMPrefijo As String, MMUsuario As String, MMPass As String, MMSSL As Boolean, MMHost As String, MMPort As Integer, MMMensaje As String, IDR As Double, IDM As Double) As Boolean
        ErrorMail = ""
        EnviarSMSMail = True
        Dim smtpServer As New SmtpClient()
        Dim mail As New MailMessage
        Try
            smtpServer.Credentials = New Net.NetworkCredential(MMUsuario, MMPass)
            smtpServer.Port = MMPort '587
            smtpServer.Host = MMHost '"smtp.gmail.com"
            smtpServer.EnableSsl = MMSSL 'True
            mail.From = New MailAddress(MMUsuario) 'TextBox1.Text & "@gmail.com")
            mail.To.Add(MMCuenta)
            mail.Subject = MMMensaje
            mail.Body = MMPrefijo & " " & MMMensaje
            smtpServer.Send(mail)
            smtpServer.Dispose()
            mail.Dispose()
            Dim TotalSMS As Integer = 1
            'Se calculan cuantos son
            If Strings.InStr(MMRecipiente, ",") > 0 Then
                TotalSMS = Strings.Split(MMRecipiente, ",").Length
            End If
            Dim Comando2 As OdbcCommand = New OdbcCommand("update z_mensajes_config set z_sms_restan = z_sms_restan - " & TotalSMS & ", z_sms_enviados = z_sms_enviados + " & TotalSMS)
            Comando2.Connection = MiConexion
            Comando2.CommandType = CommandType.Text
            Comando2.ExecuteReader()
        Catch ex As Exception
            EnviarSMSMail = False
            Dim Comando As OdbcCommand = New OdbcCommand("insert into z_mensajes_log (z_recipiente, z_tipo_mensaje, z_estatus, z_causa, z_texto, z_mansaje_enviado, z_record, z_message) values ('" & MMRecipiente & "', 'E', '2', '3', '" & Strings.Replace(Strings.Left(ex.Message, 100).Trim, "'", "") & "', '" & MMMensaje & "', " & IDR & ", " & IDM & ")")
            Comando.Connection = MiConexion
            Comando.CommandType = CommandType.Text
            Comando.ExecuteReader()
        End Try


    End Function
    Function EnviarSMS(MMRecipiente As String, MMNumero As String, MMPrefijo As String, MMUsuario As String, MMPass As String, MMMensaje As String, IDR As Double, IDM As Double, MMManejador As String) As Boolean
        ErrorMail = ""
        EnviarSMS = True
        Dim Comando As OdbcCommand
        Dim Comando2 As OdbcCommand
        Dim CadSQL As String
        Try
            If MMManejador = "-1" Then
                'Mas mensajes México
                Dim webClient As New System.Net.WebClient
                Dim CadGet As String = ""
                CadGet = "https://www.masmensajes.com.mx/wss/smsapi11.php?usuario=" & MMUsuario & "&password=" & MMPass & "&celular=+52" & MMNumero & "&mensaje=" & MMMensaje
                Dim result As String = webClient.DownloadString(CadGet)
                If Strings.InStr(result, "ERROR") > 0 Then
                    EnviarSMS = False
                    CadSQL = "insert into z_mensajes_log (z_recipiente, z_tipo_mensaje, z_estatus, z_causa, z_texto, z_mansaje_enviado, z_record, z_message) values ('" & MMRecipiente & "', 'S', '2', '2', '" & Strings.Replace(Strings.Mid(result, 2, 100).Trim, "'", "") & "', '" & MMMensaje & "', " & IDR & ", " & IDM & ")"
                    Comando = New OdbcCommand(CadSQL)
                    Comando.Connection = MiConexion
                    Comando.CommandType = CommandType.Text
                    Comando.ExecuteReader()
                Else
                    CadSQL = "update z_mensajes_config set z_sms_restan = z_sms_restan - 1, z_sms_enviados = z_sms_enviados + 1"
                    Comando = New OdbcCommand(CadSQL)
                    Comando.Connection = MiConexion
                    Comando.CommandType = CommandType.Text
                    Comando.ExecuteReader()
                End If
            End If
        Catch ex As Exception
            EnviarSMS = False
            CadSQL = "insert into z_mensajes_log (z_recipiente, z_tipo_mensaje, z_estatus, z_causa, z_texto, z_mansaje_enviado, z_record, z_message) values ('" & MMRecipiente & "', 'S', '2', '2', '" & Strings.Replace(Strings.Left(ex.Message, 100).Trim, "'", "") & "', '" & MMMensaje & "', " & IDR & ", " & IDM & ")"
            Comando2 = New OdbcCommand(CadSQL)
            Comando2.Connection = MiConexion
            Comando2.CommandType = CommandType.Text
            Comando2.ExecuteReader()
        End Try
    End Function
    Private Sub CheckEdit2_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckEdit2.CheckedChanged
        LabelControl5.Enabled = CheckEdit2.Checked
        CheckEdit3.Enabled = LabelControl5.Enabled
        LabelControl6.Enabled = LabelControl5.Enabled
        LabelControl7.Enabled = LabelControl5.Enabled
        LabelControl8.Enabled = LabelControl5.Enabled
        TextEdit5.Enabled = LabelControl5.Enabled
        TextEdit6.Enabled = LabelControl5.Enabled
        TextEdit7.Enabled = LabelControl5.Enabled
        TextEdit8.Enabled = LabelControl5.Enabled
        CambiarBotones(1)
    End Sub

    Private Sub CheckEdit4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit4.CheckedChanged
        CambiarBotones(1)
    End Sub

    Private Sub CheckEdit5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit5.CheckedChanged
        CambiarBotones(1)
    End Sub

    Private Sub CheckEdit6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit6.CheckedChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit8_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit8.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit1.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit2.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit3.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit4_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit4.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub ComboBoxEdit1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit1.SelectedIndexChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit6_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit6.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit5_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit5.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit7_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit7.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit9_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit9.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Procesando = True
        Dim Forma As New Form4
        Forma.ShowDialog()
        CambiarBotones(1)
        Procesando = False
    End Sub


    Private Sub CheckEdit3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit3.CheckedChanged
        CambiarBotones(1)
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        LabelControl1.Enabled = CheckEdit1.Checked
        LabelControl2.Enabled = LabelControl1.Enabled
        LabelControl3.Enabled = LabelControl1.Enabled
        LabelControl4.Enabled = LabelControl1.Enabled
        LabelControl9.Enabled = LabelControl1.Enabled
        LabelControl12.Enabled = LabelControl1.Enabled
        LabelControl13.Enabled = LabelControl1.Enabled
        TextEdit1.Enabled = LabelControl1.Enabled
        TextEdit2.Enabled = LabelControl1.Enabled
        TextEdit10.Enabled = LabelControl1.Enabled
        TextEdit11.Enabled = LabelControl1.Enabled
        CheckEdit7.Enabled = LabelControl1.Enabled
        ComboBoxEdit1.Enabled = LabelControl1.Enabled
        CambiarBotones(1)
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        ToolStripMenuItem4_Click(sender, e)
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Procesando = True
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
        Dim CadSQL As String = "delete from z_mensajes_log where z_fecha <= '" & Format(DateAdd("M", -1, Now), "yyyy/MM/dd HH:mm:ss") & "'"
        Dim Comando As OdbcCommand = New OdbcCommand(CadSQL)
        Comando.Connection = MiConexion
        Comando.CommandType = CommandType.Text
        Comando.ExecuteReader()
        Imagen = New Bitmap(My.Resources.Resource1.info)
        Icono = Icon.FromHandle(Imagen.GetHicon)

        AddHandler args2.Showing, AddressOf Me.args_Showing
        args2.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
        args2.Text = "La depuración se ejecutó satisfactoriamente"
        args2.Buttons = New DialogResult() {DialogResult.OK}
        args2.Icon = Icono
        XtraMessageBox.SmartTextWrap = True
        XtraMessageBox.Show(args2)
        Procesando = True
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Dim Imagen As Bitmap = New Bitmap(My.Resources.Resource1.help)
        Dim Icono As Icon = Icon.FromHandle(Imagen.GetHicon)
        Dim args As New XtraMessageBoxArgs
        Dim args2 As New XtraMessageBoxArgs

        AddHandler args.Showing, AddressOf Me.args_Showing2
        args.Caption = "Cronos::. Configuración de SMS/Email para MMCall"
        args.Text = "Esta acción detendrá la revisión de los mensajes." & Environment.NewLine & "¿Desea continuar y detener la aplicación?"
        args.Buttons = New DialogResult() {DialogResult.OK, DialogResult.Cancel}
        args.Icon = Icono
        XtraMessageBox.SmartTextWrap = True
        Dim Respuesta As Integer = XtraMessageBox.Show(args)
        '. . . 
        If Respuesta = 2 Then Exit Sub

        CancelarOperacion = True
        Timer1.Enabled = False
        ToolStripMenuItem4.Visible = False
        ToolStripMenuItem5.Visible = True
        SimpleButton4.Visible = False
        SimpleButton6.Visible = True
        LabelControl10.Visible = False
        LabelControl14.Visible = True
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        CancelarOperacion = False
        Timer1.Enabled = True
        ToolStripMenuItem4.Visible = True
        ToolStripMenuItem5.Visible = False
        ToolStripMenuItem5.Visible = False
        SimpleButton4.Visible = True
        SimpleButton6.Visible = False
        LabelControl10.Visible = True
        LabelControl14.Visible = False
    End Sub

    Private Sub TextEdit11_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit11.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit10_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit10.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub CheckEdit7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit7.CheckedChanged
        CambiarBotones(1)
    End Sub


    Public Function Version() As String

        Dim ver As String

        Version = Application.ProductVersion & " Built: " & Format(FileDateTime(Application.ExecutablePath), "yyyy/MM/dd HH:mm")

    End Function

    Private Sub LabelControl1_Click(sender As Object, e As EventArgs) Handles LabelControl1.Click

    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        ToolStripMenuItem5_Click(sender, e)
    End Sub

    Private Sub TextEdit14_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit14.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit12_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit12.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit13_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit13.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit15_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit15.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Dim Forma As New Form11
        Forma.Show()
        CambiarBotones(1)
    End Sub

    Private Sub CheckEdit9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit9.CheckedChanged
        LabelControl15.Enabled = CheckEdit9.Checked
        LabelControl16.Enabled = LabelControl15.Enabled
        LabelControl17.Enabled = LabelControl15.Enabled
        LabelControl18.Enabled = LabelControl15.Enabled
        LabelControl19.Enabled = LabelControl15.Enabled
        LabelControl20.Enabled = LabelControl15.Enabled
        LabelControl13.Enabled = LabelControl15.Enabled
        TextEdit12.Enabled = LabelControl15.Enabled
        TextEdit13.Enabled = LabelControl15.Enabled
        TextEdit14.Enabled = LabelControl15.Enabled
        TextEdit15.Enabled = LabelControl15.Enabled
        CheckEdit8.Enabled = LabelControl15.Enabled
        ComboBoxEdit2.Enabled = LabelControl15.Enabled
        ComboBoxEdit3.Enabled = LabelControl15.Enabled
        SimpleButton7.Enabled = LabelControl15.Enabled
        CambiarBotones(1)
    End Sub

    Private Sub CheckEdit8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit8.CheckedChanged
        CambiarBotones(1)
    End Sub

    Private Sub ComboBoxEdit2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit2.SelectedIndexChanged
        CambiarBotones(1)
    End Sub

    Private Sub ComboBoxEdit3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit3.SelectedIndexChanged
        CambiarBotones(1)
    End Sub

    Sub Graficas(FechaDesde As String, FechaHasta As String)
        'Se generan las 3 gráficos
        'Grafica1
        Dim Comando As OdbcCommand = New OdbcCommand("select * from z_graficos where z_tipo = 3")
        Comando.Connection = MiConexion
        Dim MisGraficos As OdbcDataReader

        MisGraficos = Comando.ExecuteReader

        Dim ElTitulo As String

        Dim ApliTol As Boolean
        Dim VerLeyenda As Boolean
        Dim Tol1 As Double
        Dim Color1 As String
        Dim Eti1 As String
        Dim Tol2 As Double
        Dim Color2 As String
        Dim Eti2 As String
        Dim Tol3 As Double
        Dim Color3 As String
        Dim Eti3 As String
        Dim TLl1 As Integer
        Dim TLl2 As Integer
        Dim TLl3 As Integer
        Dim EjeX As String
        Dim Ejey As String
        Dim Limites As Integer = 0
        Dim Otros As String = ""
        Dim GDuracion As Integer
        Dim Agrupado As Integer = 0
        Dim MisDatosClave As OdbcDataReader
        Dim Limite As Integer = 10
        Dim Col0 As Integer, Col1 As Integer, Col2 As Integer, Col3 As Integer, Col4 As Integer


        Dim PrimerGrafico = False
        If MisGraficos.HasRows Then
            If MisGraficos.Read Then
                ElTitulo = ValNull(MisGraficos!z_titulo, "A")
                '''''
                ApliTol = ValNull(MisGraficos!z_aplicar_tol, "A") = "S"
                VerLeyenda = ValNull(MisGraficos!z_ver_leyenda, "A") = "S"
                Tol1 = ValNull(MisGraficos!z_tolerancia1, "N")
                If ValNull(MisGraficos!z_color1, "A") = "" Then
                    Color1 = "R"
                Else
                    Color1 = ValNull(MisGraficos!z_color1, "A")
                End If
                Eti1 = ValNull(MisGraficos!z_texto1, "A")
                Tol2 = ValNull(MisGraficos!z_tolerancia2, "N")
                If ValNull(MisGraficos!z_color2, "A") = "" Then
                    Color2 = "R"
                Else
                    Color2 = ValNull(MisGraficos!z_color2, "A")
                End If
                Eti2 = ValNull(MisGraficos!z_texto2, "A")
                Tol3 = ValNull(MisGraficos!z_tolerancia3, "N")
                If ValNull(MisGraficos!z_color3, "A") = "" Then
                    Color3 = "R"
                Else
                    Color3 = ValNull(MisGraficos!z_color3, "A")
                End If
                Eti3 = ValNull(MisGraficos!z_texto3, "A")
                EjeX = ValNull(MisGraficos!z_ejex, "A")
                Ejey = ValNull(MisGraficos!z_ejey, "A")
                Limites = ValNull(MisGraficos!z_maximo, "N")
                Otros = Strings.Trim(ValNull(MisGraficos!z_otros, "A"))
                MisGraficos.Close()

            End If
        End If
        'Label3.Text = Cache("restan") & " seg."

        Comando.CommandText = "select requester_name, count(*) as cuenta from records where start_time >= '" & FechaDesde & "' and start_time <= '" & FechaHasta & "' group by requester_name order by 2 desc"
        Comando.Connection = MiConexion
        Dim MisDatos As OdbcDataReader
        MisDatos = Comando.ExecuteReader
        Dim Punto As Integer = 0
        Dim GrafOtras As Double = 0
        If Limites = 0 Then Limites = 999999
        Dim dstData As DataTable = New DataTable("Table1")
        dstData.Columns.Add("Tipo", GetType(String))
        dstData.Columns.Add("Valor", GetType(System.Int32))
        Dim TOtros As Integer = 0
        If MisDatos.HasRows Then
            Do While MisDatos.Read
                If MisDatos!cuenta <> 0 Then
                    If Punto + 1 <= Limites Then
                        dstData.Rows.Add(MisDatos!requester_name, MisDatos!cuenta)
                        Punto = Punto + 1
                    ElseIf Otros.Length > 0 Then
                        TOtros = TOtros + 1
                        GrafOtras = GrafOtras + MisDatos!cuenta
                    End If
                End If
            Loop
            If GrafOtras > 0 Then
                dstData.Rows.Add(Otros & " (" & TOtros & ")", GrafOtras)
            End If
        End If
        MisDatos.Close()
        ChartControl1.Series.Clear()
        ChartControl1.Titles.Clear()
        Dim bcsSeries As Series = New Series("Series 1", ViewType.Bar)
        ChartControl1.Width = 1200
        ChartControl1.Height = 760

        bcsSeries.DataSource = dstData
        bcsSeries.ArgumentScaleType = ScaleType.Qualitative
        bcsSeries.ArgumentDataMember = "Tipo"
        bcsSeries.ValueScaleType = ScaleType.Numerical
        bcsSeries.ValueDataMembers.AddRange(New String() {"Valor"})
        ChartControl1.Series.Add(bcsSeries)
        bcsSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True

        Dim chartTitle1 As New ChartTitle()

        ' Define the text for the titles.
        chartTitle1.Text = ElTitulo & " desde: " & FechaDesde & " hasta: " & FechaHasta

        ' Define the alignment of the titles.
        chartTitle1.Alignment = StringAlignment.Center

        ' Place the titles where it's required.
        chartTitle1.Dock = ChartTitleDockStyle.Top

        ' Customize a title's appearance.
        chartTitle1.Antialiasing = True
        chartTitle1.Font = New Font("Tahoma", 12, FontStyle.Bold)
        chartTitle1.TextColor = Color.Black
        chartTitle1.Indent = 10

        ChartControl1.Titles.AddRange(New ChartTitle() {chartTitle1})

        Dim diagram As XYDiagram = CType(ChartControl1.Diagram, XYDiagram)

        ' Customize the appearance of the X-axis title.
        diagram.AxisX.Title.Visible = True
        diagram.AxisX.Title.Alignment = StringAlignment.Center
        diagram.AxisX.Title.Text = "REQUISITORES DEL SISTEMA"
        diagram.AxisX.Title.TextColor = Color.Tomato
        diagram.AxisX.Title.Antialiasing = True
        diagram.AxisX.Title.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisX.Label.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisX.Label.TextColor = Color.Tomato

        ' Customize the appearance of the Y-axis title.
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Center
        diagram.AxisY.Title.Text = "NÚMERO DE LLAMADAS EN EL PERÍODO"
        diagram.AxisY.Title.TextColor = Color.DodgerBlue
        diagram.AxisY.Title.Antialiasing = True
        diagram.AxisY.Title.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisY.Label.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisY.Label.TextColor = Color.DodgerBlue


        Dim label As SideBySideBarSeriesLabel = TryCast(ChartControl1.Series(0).Label, SideBySideBarSeriesLabel)
        If label IsNot Nothing Then
            label.Position = BarSeriesLabelPosition.Top
            label.Font = New Font("Tahoma", 12, FontStyle.Bold)
        End If

        CType(bcsSeries.View, SideBySideBarSeriesView).ColorEach = True
        ChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
        ChartControl1.Dock = DockStyle.Fill
        NGrafica01 = "grafico01 (" & Format(DateAndTime.Now, "yyyyMMddHHmmss") & ").png"
        Try
            ChartControl1.ExportToImage(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NGrafica01, Imaging.ImageFormat.Png)
        Catch ex As Exception

        End Try


    End Sub



    Sub Graficas2(FechaDesde As String, FechaHasta As String)
        'Se generan las 3 gráficos
        'Grafica1
        Dim Comando As OdbcCommand = New OdbcCommand("Select * from z_graficos where z_tipo = 4")
        Comando.Connection = MiConexion
        Dim MisGraficos As OdbcDataReader

        MisGraficos = Comando.ExecuteReader

        Dim ElTitulo As String

        Dim ApliTol As Boolean
        Dim VerLeyenda As Boolean
        Dim Tol1 As Double
        Dim Color1 As String
        Dim Eti1 As String
        Dim Tol2 As Double
        Dim Color2 As String
        Dim Eti2 As String
        Dim Tol3 As Double
        Dim Color3 As String
        Dim Eti3 As String
        Dim TLl1 As Integer
        Dim TLl2 As Integer
        Dim TLl3 As Integer
        Dim EjeX As String
        Dim Ejey As String
        Dim Limites As Integer = 0
        Dim Otros As String = ""
        Dim GDuracion As Integer
        Dim Agrupado As Integer = 0
        Dim MisDatosClave As OdbcDataReader
        Dim MiClave As String = ""
        Dim Limite As Integer = 10
        Dim Col0 As Integer, Col1 As Integer, Col2 As Integer, Col3 As Integer, Col4 As Integer


        Dim PrimerGrafico = False
        If MisGraficos.HasRows Then
            If MisGraficos.Read Then
                ElTitulo = ValNull(MisGraficos!z_titulo, "A")
                '''''
                ApliTol = ValNull(MisGraficos!z_aplicar_tol, "A") = "S"
                VerLeyenda = ValNull(MisGraficos!z_ver_leyenda, "A") = "S"
                Tol1 = ValNull(MisGraficos!z_tolerancia1, "N")
                If ValNull(MisGraficos!z_color1, "A") = "" Then
                    Color1 = "R"
                Else
                    Color1 = ValNull(MisGraficos!z_color1, "A")
                End If
                Eti1 = ValNull(MisGraficos!z_texto1, "A")
                Tol2 = ValNull(MisGraficos!z_tolerancia2, "N")
                If ValNull(MisGraficos!z_color2, "A") = "" Then
                    Color2 = "R"
                Else
                    Color2 = ValNull(MisGraficos!z_color2, "A")
                End If
                Eti2 = ValNull(MisGraficos!z_texto2, "A")
                Tol3 = ValNull(MisGraficos!z_tolerancia3, "N")
                If ValNull(MisGraficos!z_color3, "A") = "" Then
                    Color3 = "R"
                Else
                    Color3 = ValNull(MisGraficos!z_color3, "A")
                End If
                Eti3 = ValNull(MisGraficos!z_texto3, "A")
                EjeX = ValNull(MisGraficos!z_ejex, "A")
                Ejey = ValNull(MisGraficos!z_ejey, "A")
                Limites = ValNull(MisGraficos!z_maximo, "N")
                Otros = Strings.Trim(ValNull(MisGraficos!z_otros, "A"))
                MisGraficos.Close()

            End If
        End If
        'Label3.Text = Cache("restan") & " seg."

        Comando.CommandText = "Select count(*) As total, avg(total_time) As prome, (Select COUNT(*) FROM records WHERE status = 1 And start_time >= '" & FechaDesde & "' and start_time <= '" & FechaHasta & "') as totalbuenas, (SELECT COUNT(*) FROM records WHERE status = 2 and start_time >= '" & FechaDesde & "' and start_time <= '" & FechaHasta & "') as totalaceptables, (SELECT COUNT(*) FROM records WHERE status > 2 and start_time >= '" & FechaDesde & "' and start_time <= '" & FechaHasta & "') as totalmalas, 0 from records AS a where start_time >= '" & FechaDesde & "'"
        Comando.Connection = MiConexion

        Dim MisDatos As OdbcDataReader
        Dim Punto As Integer = 0
        Dim GrafOtras As Double = 0
        If Limites = 0 Then Limites = 999999
        Dim dstData As DataTable = New DataTable("Table1")
        dstData.Columns.Add("Tipo", GetType(String))
        dstData.Columns.Add("Valor", GetType(System.Int32))
        Dim TOtros As Integer = 0
        MisDatos = Comando.ExecuteReader
        If MisDatos.HasRows Then
            MisDatos.Read()
            dstData.Rows.Add(Eti3, MisDatos!totalbuenas)
            dstData.Rows.Add(Eti2, MisDatos!totalaceptables)
            dstData.Rows.Add(Eti1, MisDatos!totalmalas)
        End If
        MisDatos.Close()
        ChartControl1.Series.Clear()
        ChartControl1.Titles.Clear()
        Dim bcsSeries As Series = New Series("Series 1", ViewType.Bar)
        ChartControl1.Width = 1200
        ChartControl1.Height = 760

        bcsSeries.DataSource = dstData
        bcsSeries.ArgumentScaleType = ScaleType.Qualitative
        bcsSeries.ArgumentDataMember = "Tipo"
        bcsSeries.ValueScaleType = ScaleType.Numerical
        bcsSeries.ValueDataMembers.AddRange(New String() {"Valor"})
        ChartControl1.Series.Add(bcsSeries)
        bcsSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True

        Dim chartTitle1 As New ChartTitle()

        ' Define the text for the titles.
        chartTitle1.Text = ElTitulo & " desde: " & FechaDesde & " hasta: " & FechaHasta

        ' Define the alignment of the titles.
        chartTitle1.Alignment = StringAlignment.Center

        ' Place the titles where it's required.
        chartTitle1.Dock = ChartTitleDockStyle.Top

        ' Customize a title's appearance.
        chartTitle1.Antialiasing = True
        chartTitle1.Font = New Font("Tahoma", 12, FontStyle.Bold)
        chartTitle1.TextColor = Color.Black
        chartTitle1.Indent = 10

        ChartControl1.Titles.AddRange(New ChartTitle() {chartTitle1})

        Dim diagram As XYDiagram = CType(ChartControl1.Diagram, XYDiagram)

        ' Customize the appearance of the X-axis title.
        diagram.AxisX.Title.Visible = True
        diagram.AxisX.Title.Alignment = StringAlignment.Center
        diagram.AxisX.Title.Text = "CLASIFICACION DEL SERVICIO"
        diagram.AxisX.Title.TextColor = Color.Tomato
        diagram.AxisX.Title.Antialiasing = True
        diagram.AxisX.Title.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisX.Label.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisX.Label.TextColor = Color.Tomato

        ' Customize the appearance of the Y-axis title.
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Center
        diagram.AxisY.Title.Text = "NÚMERO DE LLAMADAS EN EL PERÍODO"
        diagram.AxisY.Title.TextColor = Color.DodgerBlue
        diagram.AxisY.Title.Antialiasing = True
        diagram.AxisY.Title.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisY.Label.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisY.Label.TextColor = Color.DodgerBlue


        Dim label As SideBySideBarSeriesLabel = TryCast(ChartControl1.Series(0).Label, SideBySideBarSeriesLabel)
        If label IsNot Nothing Then
            label.Position = BarSeriesLabelPosition.Top
            label.Font = New Font("Tahoma", 12, FontStyle.Bold)
        End If

        CType(bcsSeries.View, SideBySideBarSeriesView).ColorEach = True
        ChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
        ChartControl1.Dock = DockStyle.Fill
        NGrafica02 = "grafico02 (" & Format(DateAndTime.Now, "yyyyMMddHHmmss") & ").png"
        Try
            ChartControl1.ExportToImage(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NGrafica02, Imaging.ImageFormat.Png)
        Catch ex As Exception

        End Try

    End Sub

    Sub Graficas3(FechaDesde As String, FechaHasta As String)
        'Se generan las 3 gráficos
        'Grafica1
        Dim Comando As OdbcCommand = New OdbcCommand("Select * from z_graficos where z_tipo = 5")
        Comando.Connection = MiConexion
        Dim MisGraficos As OdbcDataReader

        MisGraficos = Comando.ExecuteReader

        Dim ElTitulo As String

        Dim ApliTol As Boolean
        Dim VerLeyenda As Boolean
        Dim Tol1 As Double
        Dim Color1 As String
        Dim Eti1 As String
        Dim Tol2 As Double
        Dim Color2 As String
        Dim Eti2 As String
        Dim Tol3 As Double
        Dim Color3 As String
        Dim Eti3 As String
        Dim TLl1 As Integer
        Dim TLl2 As Integer
        Dim TLl3 As Integer
        Dim EjeX As String
        Dim Ejey As String
        Dim Limites As Integer = 0
        Dim Otros As String = ""
        Dim GDuracion As Integer
        Dim Agrupado As Integer = 0
        Dim MisDatosClave As OdbcDataReader
        Dim MiClave As String = ""
        Dim Limite As Integer = 10
        Dim Col0 As Integer, Col1 As Integer, Col2 As Integer, Col3 As Integer, Col4 As Integer


        Dim PrimerGrafico = False
        If MisGraficos.HasRows Then
            If MisGraficos.Read Then
                ElTitulo = ValNull(MisGraficos!z_titulo, "A")
                '''''
                ApliTol = ValNull(MisGraficos!z_aplicar_tol, "A") = "S"
                VerLeyenda = ValNull(MisGraficos!z_ver_leyenda, "A") = "S"
                Tol1 = ValNull(MisGraficos!z_tolerancia1, "N")
                If ValNull(MisGraficos!z_color1, "A") = "" Then
                    Color1 = "R"
                Else
                    Color1 = ValNull(MisGraficos!z_color1, "A")
                End If
                Eti1 = ValNull(MisGraficos!z_texto1, "A")
                Tol2 = ValNull(MisGraficos!z_tolerancia2, "N")
                If ValNull(MisGraficos!z_color2, "A") = "" Then
                    Color2 = "R"
                Else
                    Color2 = ValNull(MisGraficos!z_color2, "A")
                End If
                Eti2 = ValNull(MisGraficos!z_texto2, "A")
                Tol3 = ValNull(MisGraficos!z_tolerancia3, "N")
                If ValNull(MisGraficos!z_color3, "A") = "" Then
                    Color3 = "R"
                Else
                    Color3 = ValNull(MisGraficos!z_color3, "A")
                End If
                Eti3 = ValNull(MisGraficos!z_texto3, "A")
                EjeX = ValNull(MisGraficos!z_ejex, "A")
                Ejey = ValNull(MisGraficos!z_ejey, "A")
                Limites = ValNull(MisGraficos!z_maximo, "N")
                Otros = Strings.Trim(ValNull(MisGraficos!z_otros, "A"))
                MisGraficos.Close()

            End If
        End If
        'Label3.Text = Cache("restan") & " seg."

        Comando.CommandText = "select z_causas.z_nombre, count(*) as total from records inner join z_causas on records.z_reason = z_causas.z_id where start_time >= '" & FechaDesde & "' and start_time <= '" & FechaHasta & "' group by z_causas.z_nombre order by 2 desc"
        Comando.Connection = MiConexion


        Dim MisDatos As OdbcDataReader
        Dim Punto As Integer = 0
        Dim GrafOtras As Double = 0
        If Limites = 0 Then Limites = 999999
        Dim dstData As DataTable = New DataTable("Table1")
        dstData.Columns.Add("Tipo", GetType(String))
        dstData.Columns.Add("Valor", GetType(System.Int32))
        Dim TOtros As Integer = 0
        MisDatos = Comando.ExecuteReader
        If MisDatos.HasRows Then
            Do While MisDatos.Read
                If MisDatos!total <> 0 Then
                    If Punto + 1 <= Limites Then
                        dstData.Rows.Add(MisDatos!z_nombre, MisDatos!total)
                        Punto = Punto + 1
                    ElseIf Otros.Length > 0 Then
                        TOtros = TOtros + 1
                        GrafOtras = GrafOtras + MisDatos!total
                    End If
                End If
            Loop
            If GrafOtras > 0 Then
                dstData.Rows.Add(Otros & " (" & TOtros & ")", GrafOtras)
            End If
        End If
        MisDatos.Close()
        ChartControl1.Series.Clear()
        ChartControl1.Titles.Clear()
        Dim bcsSeries As Series = New Series("Series 1", ViewType.Bar)
        ChartControl1.Width = 1200
        ChartControl1.Height = 760

        bcsSeries.DataSource = dstData
        bcsSeries.ArgumentScaleType = ScaleType.Qualitative
        bcsSeries.ArgumentDataMember = "Tipo"
        bcsSeries.ValueScaleType = ScaleType.Numerical
        bcsSeries.ValueDataMembers.AddRange(New String() {"Valor"})
        ChartControl1.Series.Add(bcsSeries)
        bcsSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True

        Dim chartTitle1 As New ChartTitle()

        ' Define the text for the titles.
        chartTitle1.Text = ElTitulo & " desde: " & FechaDesde & " hasta: " & FechaHasta

        ' Define the alignment of the titles.
        chartTitle1.Alignment = StringAlignment.Center

        ' Place the titles where it's required.
        chartTitle1.Dock = ChartTitleDockStyle.Top

        ' Customize a title's appearance.
        chartTitle1.Antialiasing = True
        chartTitle1.Font = New Font("Tahoma", 12, FontStyle.Bold)
        chartTitle1.TextColor = Color.Black
        chartTitle1.Indent = 10

        ChartControl1.Titles.AddRange(New ChartTitle() {chartTitle1})

        Dim diagram As XYDiagram = CType(ChartControl1.Diagram, XYDiagram)

        ' Customize the appearance of the X-axis title.
        diagram.AxisX.Title.Visible = True
        diagram.AxisX.Title.Alignment = StringAlignment.Center
        diagram.AxisX.Title.Text = "CLASIFICACION DEL SERVICIO"
        diagram.AxisX.Title.TextColor = Color.Tomato
        diagram.AxisX.Title.Antialiasing = True
        diagram.AxisX.Title.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisX.Label.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisX.Label.TextColor = Color.Tomato

        ' Customize the appearance of the Y-axis title.
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Center
        diagram.AxisY.Title.Text = "NÚMERO DE LLAMADAS EN EL PERÍODO"
        diagram.AxisY.Title.TextColor = Color.DodgerBlue
        diagram.AxisY.Title.Antialiasing = True
        diagram.AxisY.Title.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisY.Label.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisY.Label.TextColor = Color.DodgerBlue


        Dim label As SideBySideBarSeriesLabel = TryCast(ChartControl1.Series(0).Label, SideBySideBarSeriesLabel)
        If label IsNot Nothing Then
            label.Position = BarSeriesLabelPosition.Top
            label.Font = New Font("Tahoma", 12, FontStyle.Bold)
        End If

        CType(bcsSeries.View, SideBySideBarSeriesView).ColorEach = True
        ChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
        ChartControl1.Dock = DockStyle.Fill
        NGrafica03 = "grafico03 (" & Format(DateAndTime.Now, "yyyyMMddHHmmss") & ").png"
        Try
            ChartControl1.ExportToImage(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NGrafica03, Imaging.ImageFormat.Png)
        Catch ex As Exception

        End Try

    End Sub

    Sub Graficas4(FechaDesde As String, FechaHasta As String)
        'Se generan las 3 gráficos
        'Grafica1
        Dim Comando As OdbcCommand = New OdbcCommand("select * from z_graficos where z_tipo = 9")
        Comando.Connection = MiConexion
        Dim MisGraficos As OdbcDataReader

        MisGraficos = Comando.ExecuteReader

        Dim ElTitulo As String

        Dim ApliTol As Boolean
        Dim VerLeyenda As Boolean
        Dim Tol1 As Double
        Dim Color1 As String
        Dim Eti1 As String
        Dim Tol2 As Double
        Dim Color2 As String
        Dim Eti2 As String
        Dim Tol3 As Double
        Dim Color3 As String
        Dim Eti3 As String
        Dim TLl1 As Integer
        Dim TLl2 As Integer
        Dim TLl3 As Integer
        Dim EjeX As String
        Dim Ejey As String
        Dim Limites As Integer = 0
        Dim Otros As String = ""
        Dim GDuracion As Integer
        Dim Agrupado As Integer = 0
        Dim MisDatosClave As OdbcDataReader
        Dim Limite As Integer = 10
        Dim Col0 As Integer, Col1 As Integer, Col2 As Integer, Col3 As Integer, Col4 As Integer


        Dim PrimerGrafico = False
        If MisGraficos.HasRows Then
            If MisGraficos.Read Then
                ElTitulo = ValNull(MisGraficos!z_titulo, "A")
                '''''
                ApliTol = ValNull(MisGraficos!z_aplicar_tol, "A") = "S"
                VerLeyenda = ValNull(MisGraficos!z_ver_leyenda, "A") = "S"
                Tol1 = ValNull(MisGraficos!z_tolerancia1, "N")
                If ValNull(MisGraficos!z_color1, "A") = "" Then
                    Color1 = "R"
                Else
                    Color1 = ValNull(MisGraficos!z_color1, "A")
                End If
                Eti1 = ValNull(MisGraficos!z_texto1, "A")
                Tol2 = ValNull(MisGraficos!z_tolerancia2, "N")
                If ValNull(MisGraficos!z_color2, "A") = "" Then
                    Color2 = "R"
                Else
                    Color2 = ValNull(MisGraficos!z_color2, "A")
                End If
                Eti2 = ValNull(MisGraficos!z_texto2, "A")
                Tol3 = ValNull(MisGraficos!z_tolerancia3, "N")
                If ValNull(MisGraficos!z_color3, "A") = "" Then
                    Color3 = "R"
                Else
                    Color3 = ValNull(MisGraficos!z_color3, "A")
                End If
                Eti3 = ValNull(MisGraficos!z_texto3, "A")
                EjeX = ValNull(MisGraficos!z_ejex, "A")
                Ejey = ValNull(MisGraficos!z_ejey, "A")
                Limites = ValNull(MisGraficos!z_maximo, "N")
                Otros = Strings.Trim(ValNull(MisGraficos!z_otros, "A"))
                MisGraficos.Close()

            End If
        End If
        'Label3.Text = Cache("restan") & " seg."

        Dim Comando9 As OdbcCommand = New OdbcCommand("select requester_name, count(*) as cuenta from records where start_time >= '" & FechaDesde & "' and start_time <= '" & FechaHasta & "' group by requester_name order by 2 desc limit 3")
        Comando9.Connection = MiConexion

        Dim MisDatos As OdbcDataReader
        MisDatos = Comando9.ExecuteReader

        Dim MisDatos2 As OdbcDataReader
        Dim MisDatos3 As OdbcDataReader
        Dim Prefijo As String
        Dim TotalEquipos As Integer = 0
        Dim dstData As DataTable = New DataTable("Table1")
        dstData.Columns.Add("Tipo", GetType(String))
        dstData.Columns.Add("Valor", GetType(System.Int32))
        Dim TOtros As Integer = 0
        If MisDatos.HasRows Then
            Do While MisDatos.Read
                If MisDatos!cuenta <> 0 Then
                    TotalEquipos = TotalEquipos + 1
                    If TotalEquipos = 1 Then
                        Prefijo = "."
                    ElseIf TotalEquipos = 2 Then
                        Prefijo = "~"
                    Else
                        Prefijo = ":"
                    End If
                    dstData.Rows.Add(Prefijo & MisDatos!requester_name, MisDatos!cuenta)
                    'se buscan las áreas con más llamadas
                    Dim Comando2 As OdbcCommand = New OdbcCommand("select key_name, count(*) as cuenta from records where requester_name = '" & MisDatos!requester_name & "' and start_time >= '" & FechaDesde & "' and start_time <= '" & FechaHasta & "' group by key_name order by 2 desc limit 1")
                    Comando2.Connection = MiConexion
                    MisDatos2 = Comando2.ExecuteReader

                    If MisDatos2.HasRows Then
                        MisDatos2.Read()
                        dstData.Rows.Add(Prefijo & MisDatos2!key_name, MisDatos2!cuenta)
                    Else
                        dstData.Rows.Add(Prefijo & "Area N/A", 0)
                    End If

                    Dim Comando3 As OdbcCommand = New OdbcCommand("select z_causas.z_nombre, count(*) as total from records inner join z_causas on records.z_reason = z_causas.z_id where requester_name = '" & MisDatos!requester_name & "' and start_time >= '" & FechaDesde & "' and start_time <= '" & FechaHasta & "' group by z_causas.z_nombre order by 2 desc limit 1")
                    Comando3.Connection = MiConexion
                    MisDatos3 = Comando3.ExecuteReader

                    If MisDatos3.HasRows Then
                        MisDatos3.Read()
                        dstData.Rows.Add(Prefijo & MisDatos3!z_nombre, MisDatos3!total)
                    Else
                        dstData.Rows.Add(Prefijo & "Causa N/A", 0)
                    End If
                End If
            Loop
        End If
        If TotalEquipos = 0 Then
            dstData.Rows.Add(".Equipo N/A", 0)
            dstData.Rows.Add(".Area N/A", 0)
            dstData.Rows.Add(".Causa N/A", 0)
            dstData.Rows.Add("~Equipo N/A", 0)
            dstData.Rows.Add("~Area N/A", 0)
            dstData.Rows.Add("~Causa N/A", 0)
            dstData.Rows.Add(":Equipo N/A", 0)
            dstData.Rows.Add(":Area N/A", 0)
            dstData.Rows.Add(":Causa N/A", 0)
        End If
        If TotalEquipos = 1 Then
            dstData.Rows.Add("~Equipo N/A", 0)
            dstData.Rows.Add("~Area N/A", 0)
            dstData.Rows.Add("~Causa N/A", 0)
            dstData.Rows.Add(";Equipo N/A", 0)
            dstData.Rows.Add(":Area N/A", 0)
            dstData.Rows.Add(":Causa N/A", 0)
        End If
        If TotalEquipos = 2 Then
            dstData.Rows.Add(":Equipo N/A", 0)
            dstData.Rows.Add(":Area N/A", 0)
            dstData.Rows.Add(":Causa N/A", 0)
        End If
        MisDatos.Close()
        MisDatos2.Close()
        MisDatos3.Close()
        ChartControl2.Series.Clear()
        ChartControl2.Titles.Clear()
        Dim bcsSeries As Series = New Series("Series 1", ViewType.Bar)
        ChartControl2.Width = 1200
        ChartControl2.Height = 760

        bcsSeries.DataSource = dstData
        bcsSeries.ArgumentScaleType = ScaleType.Qualitative
        bcsSeries.ArgumentDataMember = "Tipo"
        bcsSeries.ValueScaleType = ScaleType.Numerical
        bcsSeries.ValueDataMembers.AddRange(New String() {"Valor"})
        ChartControl2.Series.Add(bcsSeries)
        bcsSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True
        Dim chartTitle1 As New ChartTitle()

        ' Define the text for the titles.
        chartTitle1.Text = "TOP 3 DE EQUIPOS CON MAS INCIDENCIAS desde: " & FechaDesde & " hasta: " & FechaHasta

        ' Define the alignment of the titles.
        chartTitle1.Alignment = StringAlignment.Center

        ' Place the titles where it's required.
        chartTitle1.Dock = ChartTitleDockStyle.Top

        ' Customize a title's appearance.
        chartTitle1.Antialiasing = True
        chartTitle1.Font = New Font("Tahoma", 12, FontStyle.Bold)
        chartTitle1.TextColor = Color.Black
        chartTitle1.Indent = 10

        ChartControl2.Titles.AddRange(New ChartTitle() {chartTitle1})

        Dim diagram As XYDiagram = CType(ChartControl2.Diagram, XYDiagram)

        ' Customize the appearance of the X-axis title.
        diagram.AxisX.Title.Visible = True
        diagram.AxisX.Title.Alignment = StringAlignment.Center
        diagram.AxisX.Title.Text = "EQUIPO/ÁREA DE SERVICIO/CAUSA"
        diagram.AxisX.Title.TextColor = Color.Tomato
        diagram.AxisX.Title.Antialiasing = True
        diagram.AxisX.Title.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisX.Label.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisX.Label.TextColor = Color.Tomato

        ' Customize the appearance of the Y-axis title.
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Center
        diagram.AxisY.Title.Text = "NÚMERO DE LLAMADAS EN EL PERÍODO"
        diagram.AxisY.Title.TextColor = Color.DodgerBlue
        diagram.AxisY.Title.Antialiasing = True
        diagram.AxisY.Title.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisY.Label.Font = New Font("Tahoma", 12, FontStyle.Bold)
        diagram.AxisY.Label.TextColor = Color.DodgerBlue


        Dim label As SideBySideBarSeriesLabel = TryCast(ChartControl2.Series(0).Label, SideBySideBarSeriesLabel)
        If label IsNot Nothing Then
            label.Position = BarSeriesLabelPosition.Top
            label.Font = New Font("Tahoma", 12, FontStyle.Bold)
        End If

        CType(bcsSeries.View, SideBySideBarSeriesView).ColorEach = True
        ChartControl2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
        ChartControl2.Dock = DockStyle.Fill
        NGrafica04 = "grafico04 (" & Format(DateAndTime.Now, "yyyyMMddHHmmss") & ").png"
        Try
            ChartControl2.ExportToImage(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & NGrafica04, Imaging.ImageFormat.Png)
        Catch ex As Exception

        End Try


    End Sub
    Sub SimpleButton8_Clickbkp()
        'Dim Speech
        Dim synth = New SpeechSynthesizer

        synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult)
        synth.Volume = 100
        synth.Rate = 0
        synth.Speak("Esto es una prueba")
    End Sub

    Private Sub CheckEdit11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit11.CheckedChanged
        LabelControl21.Enabled = CheckEdit11.Checked
        LabelControl22.Enabled = LabelControl21.Enabled
        LabelControl23.Enabled = LabelControl21.Enabled
        LabelControl24.Enabled = LabelControl21.Enabled
        LabelControl25.Enabled = LabelControl21.Enabled
        LabelControl26.Enabled = LabelControl21.Enabled
        LabelControl27.Enabled = LabelControl21.Enabled
        LabelControl28.Enabled = LabelControl21.Enabled
        LabelControl29.Enabled = LabelControl21.Enabled
        ComboBoxEdit5.Enabled = LabelControl21.Enabled
        ComboBoxEdit6.Enabled = LabelControl21.Enabled
        ComboBoxEdit7.Enabled = LabelControl21.Enabled
        ComboBoxEdit8.Enabled = LabelControl21.Enabled
        ComboBoxEdit9.Enabled = LabelControl21.Enabled
        SimpleButton8.Enabled = LabelControl21.Enabled
        SimpleButton11.Enabled = LabelControl21.Enabled
        SimpleButton12.Enabled = LabelControl21.Enabled
        SimpleButton13.Enabled = LabelControl21.Enabled
        TextEdit16.Enabled = LabelControl21.Enabled
        TextEdit17.Enabled = LabelControl21.Enabled
        TextEdit18.Enabled = LabelControl21.Enabled
        TrackBarControl1.Enabled = LabelControl21.Enabled
        CambiarBotones(1)
    End Sub

    Private Sub ComboBoxEdit5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit5.SelectedIndexChanged
        CambiarBotones(1)
    End Sub

    Private Sub ComboBoxEdit6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit6.SelectedIndexChanged
        CambiarBotones(1)
    End Sub

    Private Sub ComboBoxEdit7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit7.SelectedIndexChanged
        CambiarBotones(1)
    End Sub

    Private Sub ComboBoxEdit8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit8.SelectedIndexChanged
        CambiarBotones(1)
    End Sub

    Private Sub ComboBoxEdit9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit9.SelectedIndexChanged
        CambiarBotones(1)
    End Sub

    Private Sub TrackBarControl1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBarControl1.ValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit16_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit16.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        Procesando = True
        XtraFolderBrowserDialog1.SelectedPath = TextEdit16.Text
        XtraFolderBrowserDialog1.ShowDialog()
        TextEdit16.Text = XtraFolderBrowserDialog1.SelectedPath
        TextEdit16.Focus()
        CambiarBotones(1)
        Procesando = False
    End Sub

    Sub synth_SpeakCompleted(sender As Object, e As SpeakCompletedEventArgs)
        Dim m_SoundPlayer As New System.Media.SoundPlayer(RutaAudio)
        m_SoundPlayer.Play()
    End Sub

    Function AplicarXOR() As Boolean
        Dim i As Integer
        AplicarXOR = True
        For i = 1 To MiSerial.Length
            If Microsoft.VisualBasic.Strings.Left(Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Mid(MiSerial, i, 1)) + 14 Xor Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Mid(MiFrase, i, 1)) + 14, 1) <> Microsoft.VisualBasic.Strings.Mid(MiClave, i, 1) Then
                AplicarXOR = False
                Exit Function
            End If
        Next
    End Function

    Function AplicarXOR2() As Boolean
        Dim i As Integer
        AplicarXOR2 = True
        For i = 1 To MiSerial.Length
            If Microsoft.VisualBasic.Strings.Left(Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Mid(MiSerial, i, 1)) + 33 Xor Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Mid(MiFrase, i, 1)) + 33, 1) <> Microsoft.VisualBasic.Strings.Mid(MiClave, i, 1) Then
                AplicarXOR2 = False
                Exit Function
            End If
        Next
    End Function

    Private Sub ChartControl2_CustomDrawSeriesPoint(sender As Object, e As CustomDrawSeriesPointEventArgs) Handles ChartControl2.CustomDrawSeriesPoint
        If Strings.Left(e.SeriesPoint.Argument, 1) = "." Then
            e.SeriesDrawOptions.Color = Color.Salmon
            e.SeriesPoint.Color = Color.Salmon
        ElseIf Strings.Left(e.SeriesPoint.Argument, 1) = "~" Then
            e.SeriesDrawOptions.Color = Color.DodgerBlue
            e.SeriesPoint.Color = Color.DodgerBlue
        Else
            e.SeriesDrawOptions.Color = Color.LightSeaGreen

        End If

    End Sub

    Private Sub LabelControl22_Click(sender As Object, e As EventArgs) Handles LabelControl22.Click

    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        Procesando = True
        XtraFolderBrowserDialog1.SelectedPath = TextEdit17.Text
        XtraFolderBrowserDialog1.ShowDialog()
        TextEdit17.Text = XtraFolderBrowserDialog1.SelectedPath
        TextEdit17.Focus()
        CambiarBotones(1)
        Procesando = False
    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        Procesando = True
        XtraFolderBrowserDialog1.SelectedPath = TextEdit18.Text
        XtraFolderBrowserDialog1.ShowDialog()
        TextEdit18.Text = XtraFolderBrowserDialog1.SelectedPath
        TextEdit18.Focus()
        CambiarBotones(1)
        Procesando = False
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        Procesando = True
        Dim Forma As New Form8
        Forma.ShowDialog()
        CambiarBotones(1)
        Procesando = False
    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        Procesando = True
        Dim Forma As New Form2
        Forma.ShowDialog()
        CambiarBotones(1)
        Procesando = False

    End Sub

    Private Sub TextEdit17_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit17.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub TextEdit18_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit18.EditValueChanged
        CambiarBotones(1)
    End Sub

    Private Sub GroupControl3_Paint(sender As Object, e As PaintEventArgs) Handles GroupControl3.Paint

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(LinkLabel1.Text)
    End Sub

    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click
        Procesando = True
        Dim Forma As New Form12
        Forma.ShowDialog()
        CambiarBotones(1)
        Procesando = False
    End Sub
End Class
