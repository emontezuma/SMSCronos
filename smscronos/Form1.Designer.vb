Partial Public Class Form1
    Inherits DevExpress.XtraEditors.XtraForm

    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim TrackBarLabel1 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim TrackBarLabel2 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim TrackBarLabel3 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim TrackBarLabel4 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim TrackBarLabel5 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim TrackBarLabel6 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim TrackBarLabel7 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim TrackBarLabel8 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim TrackBarLabel9 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim TrackBarLabel10 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim XyDiagram2 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl35 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit22 = New DevExpress.XtraEditors.TextEdit()
        Me.CheckEdit7 = New DevExpress.XtraEditors.CheckEdit()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        Me.TextEdit10 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit11 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.ComboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit4 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit3 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.CheckEdit3 = New DevExpress.XtraEditors.CheckEdit()
        Me.TextEdit8 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit7 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit6 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit5 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckEdit2 = New DevExpress.XtraEditors.CheckEdit()
        Me.XtraTabPage4 = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl5 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton13 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton12 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton11 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton10 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEdit18 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl29 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton9 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEdit17 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl28 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton8 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEdit16 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl27 = New DevExpress.XtraEditors.LabelControl()
        Me.ComboBoxEdit9 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ComboBoxEdit8 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TrackBarControl1 = New DevExpress.XtraEditors.TrackBarControl()
        Me.ComboBoxEdit7 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ComboBoxEdit5 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.ComboBoxEdit6 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl22 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl23 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl24 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl25 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl26 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckEdit11 = New DevExpress.XtraEditors.CheckEdit()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl30 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.ComboBoxEdit3 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.ComboBoxEdit2 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckEdit8 = New DevExpress.XtraEditors.CheckEdit()
        Me.TextEdit12 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit13 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit14 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit15 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckEdit9 = New DevExpress.XtraEditors.CheckEdit()
        Me.XtraTabPage5 = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl6 = New DevExpress.XtraEditors.GroupControl()
        Me.CheckEdit13 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEdit10 = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl34 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit21 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl32 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit20 = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton14 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl31 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit19 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl33 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckEdit12 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEdit6 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEdit5 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEdit4 = New DevExpress.XtraEditors.CheckEdit()
        Me.TextEdit9 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.XtraFolderBrowserDialog1 = New DevExpress.XtraEditors.XtraFolderBrowserDialog(Me.components)
        Me.ChartControl2 = New DevExpress.XtraCharts.ChartControl()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.LabelControl36 = New DevExpress.XtraEditors.LabelControl()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.TextEdit22.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit7.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit10.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit11.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit8.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit7.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage4.SuspendLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl5.SuspendLayout()
        CType(Me.TextEdit18.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit17.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit16.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit9.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit8.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit7.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit11.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.ComboBoxEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit8.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit12.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit13.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit14.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit15.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit9.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage5.SuspendLayout()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl6.SuspendLayout()
        CType(Me.CheckEdit13.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit10.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit21.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit20.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit19.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit12.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit9.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Cronos::. Envío de SMS y emails"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripSeparator1, Me.ToolStripMenuItem3})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(259, 140)
        Me.ContextMenuStrip1.Text = "Configuración"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ToolStripMenuItem1.Image = Global.smscronos.My.Resources.Resources._19_gear_icon
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(258, 26)
        Me.ToolStripMenuItem1.Text = "Configuración"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.smscronos.My.Resources.Resources.Messages_icon
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(258, 26)
        Me.ToolStripMenuItem2.Text = "Confección de mensajes"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Image = Global.smscronos.My.Resources.Resources.Pause_icon
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(258, 26)
        Me.ToolStripMenuItem4.Text = "Detener ejecución"
        Me.ToolStripMenuItem4.Visible = False
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Image = Global.smscronos.My.Resources.Resources.Play_icon
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(258, 26)
        Me.ToolStripMenuItem5.Text = "Reanudar ejecución"
        Me.ToolStripMenuItem5.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(255, 6)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = Global.smscronos.My.Resources.Resources.App_logout_icon
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(258, 26)
        Me.ToolStripMenuItem3.Text = "Cerrar"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Appearance.Options.UseFont = True
        Me.LabelControl10.Location = New System.Drawing.Point(12, 666)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(0, 17)
        Me.LabelControl10.TabIndex = 9
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton2.Appearance.Image = CType(resources.GetObject("SimpleButton2.Appearance.Image"), System.Drawing.Image)
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Appearance.Options.UseImage = True
        Me.SimpleButton2.Appearance.Options.UseTextOptions = True
        Me.SimpleButton2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SimpleButton2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(421, 620)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(100, 30)
        Me.SimpleButton2.TabIndex = 6
        Me.SimpleButton2.Text = "&Cerrar"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton1.Appearance.Image = CType(resources.GetObject("SimpleButton1.Appearance.Image"), System.Drawing.Image)
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Appearance.Options.UseImage = True
        Me.SimpleButton1.Appearance.Options.UseTextOptions = True
        Me.SimpleButton1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SimpleButton1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton1.Enabled = False
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(315, 620)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(100, 30)
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "&Guardar"
        '
        'Timer1
        '
        '
        'GroupControl3
        '
        Me.GroupControl3.AppearanceCaption.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupControl3.AppearanceCaption.Options.UseFont = True
        Me.GroupControl3.CaptionImageOptions.Image = CType(resources.GetObject("GroupControl3.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GroupControl3.CaptionImageOptions.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupControl3.Controls.Add(Me.SimpleButton6)
        Me.GroupControl3.Controls.Add(Me.SimpleButton4)
        Me.GroupControl3.Controls.Add(Me.XtraTabControl1)
        Me.GroupControl3.Controls.Add(Me.CheckEdit6)
        Me.GroupControl3.Controls.Add(Me.CheckEdit5)
        Me.GroupControl3.Controls.Add(Me.CheckEdit4)
        Me.GroupControl3.Controls.Add(Me.TextEdit9)
        Me.GroupControl3.Controls.Add(Me.LabelControl11)
        Me.GroupControl3.Location = New System.Drawing.Point(12, 124)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(509, 490)
        Me.GroupControl3.TabIndex = 0
        Me.GroupControl3.Text = "Configuración"
        '
        'SimpleButton6
        '
        Me.SimpleButton6.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.SimpleButton6.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton6.Appearance.Options.UseBackColor = True
        Me.SimpleButton6.Appearance.Options.UseFont = True
        Me.SimpleButton6.Appearance.Options.UseTextOptions = True
        Me.SimpleButton6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SimpleButton6.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton6.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton6.ImageOptions.Image = Global.smscronos.My.Resources.Resources.Play_icon
        Me.SimpleButton6.Location = New System.Drawing.Point(266, 5)
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.Size = New System.Drawing.Size(197, 30)
        Me.SimpleButton6.TabIndex = 7
        Me.SimpleButton6.Text = "Reanudar ejecución"
        Me.SimpleButton6.Visible = False
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Appearance.BackColor = System.Drawing.Color.PeachPuff
        Me.SimpleButton4.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton4.Appearance.Options.UseBackColor = True
        Me.SimpleButton4.Appearance.Options.UseFont = True
        Me.SimpleButton4.Appearance.Options.UseTextOptions = True
        Me.SimpleButton4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SimpleButton4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton4.ImageOptions.Image = Global.smscronos.My.Resources.Resources.Pause_icon
        Me.SimpleButton4.Location = New System.Drawing.Point(266, 5)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(197, 30)
        Me.SimpleButton4.TabIndex = 6
        Me.SimpleButton4.Text = "Detener la ejecución"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.XtraTabControl1.Appearance.Options.UseBackColor = True
        Me.XtraTabControl1.AppearancePage.Header.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XtraTabControl1.AppearancePage.Header.Options.UseFont = True
        Me.XtraTabControl1.AppearancePage.HeaderActive.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XtraTabControl1.AppearancePage.HeaderActive.Options.UseFont = True
        Me.XtraTabControl1.AppearancePage.HeaderHotTracked.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XtraTabControl1.AppearancePage.HeaderHotTracked.Options.UseFont = True
        Me.XtraTabControl1.Location = New System.Drawing.Point(5, 122)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(513, 363)
        Me.XtraTabControl1.TabIndex = 1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.XtraTabPage4, Me.XtraTabPage3, Me.XtraTabPage5})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Appearance.Header.BackColor = System.Drawing.Color.White
        Me.XtraTabPage1.Appearance.Header.BackColor2 = System.Drawing.Color.White
        Me.XtraTabPage1.Appearance.Header.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XtraTabPage1.Appearance.Header.Options.UseBackColor = True
        Me.XtraTabPage1.Appearance.Header.Options.UseFont = True
        Me.XtraTabPage1.Appearance.HeaderActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.XtraTabPage1.Appearance.HeaderActive.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XtraTabPage1.Appearance.HeaderActive.Options.UseBackColor = True
        Me.XtraTabPage1.Appearance.HeaderActive.Options.UseFont = True
        Me.XtraTabPage1.Appearance.HeaderHotTracked.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XtraTabPage1.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.XtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.Red
        Me.XtraTabPage1.Appearance.PageClient.Options.UseBackColor = True
        Me.XtraTabPage1.Controls.Add(Me.GroupControl1)
        Me.XtraTabPage1.ImageOptions.Image = CType(resources.GetObject("XtraTabPage1.ImageOptions.Image"), System.Drawing.Image)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(506, 313)
        Me.XtraTabPage1.Text = "SMS"
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.CaptionImageOptions.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupControl1.Controls.Add(Me.LabelControl35)
        Me.GroupControl1.Controls.Add(Me.TextEdit22)
        Me.GroupControl1.Controls.Add(Me.CheckEdit7)
        Me.GroupControl1.Controls.Add(Me.ChartControl1)
        Me.GroupControl1.Controls.Add(Me.TextEdit10)
        Me.GroupControl1.Controls.Add(Me.TextEdit11)
        Me.GroupControl1.Controls.Add(Me.LabelControl12)
        Me.GroupControl1.Controls.Add(Me.LabelControl13)
        Me.GroupControl1.Controls.Add(Me.SimpleButton3)
        Me.GroupControl1.Controls.Add(Me.ComboBoxEdit1)
        Me.GroupControl1.Controls.Add(Me.LabelControl9)
        Me.GroupControl1.Controls.Add(Me.TextEdit2)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.TextEdit4)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.TextEdit3)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.TextEdit1)
        Me.GroupControl1.Controls.Add(Me.CheckEdit1)
        Me.GroupControl1.Location = New System.Drawing.Point(3, 3)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(500, 315)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Configuración para envió de mensajes de texto (SMS)"
        '
        'LabelControl35
        '
        Me.LabelControl35.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl35.Appearance.Options.UseFont = True
        Me.LabelControl35.Enabled = False
        Me.LabelControl35.Location = New System.Drawing.Point(36, 287)
        Me.LabelControl35.Name = "LabelControl35"
        Me.LabelControl35.Size = New System.Drawing.Size(47, 17)
        Me.LabelControl35.TabIndex = 17
        Me.LabelControl35.Text = "Puerto"
        '
        'TextEdit22
        '
        Me.TextEdit22.EditValue = ""
        Me.TextEdit22.Enabled = False
        Me.TextEdit22.Location = New System.Drawing.Point(127, 282)
        Me.TextEdit22.Name = "TextEdit22"
        Me.TextEdit22.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit22.Properties.Appearance.Options.UseFont = True
        Me.TextEdit22.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit22.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit22.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit22.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit22.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit22.Size = New System.Drawing.Size(75, 26)
        Me.TextEdit22.TabIndex = 18
        '
        'CheckEdit7
        '
        Me.CheckEdit7.Enabled = False
        Me.CheckEdit7.Location = New System.Drawing.Point(251, 155)
        Me.CheckEdit7.Name = "CheckEdit7"
        Me.CheckEdit7.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.CheckEdit7.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit7.Properties.Caption = "Usar conexión SSL"
        Me.CheckEdit7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckEdit7.Size = New System.Drawing.Size(179, 21)
        Me.CheckEdit7.TabIndex = 9
        '
        'ChartControl1
        '
        XyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.ChartControl1.Diagram = XyDiagram1
        Me.ChartControl1.Legend.Name = "Default Legend"
        Me.ChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.ChartControl1.Location = New System.Drawing.Point(-42, 302)
        Me.ChartControl1.Name = "ChartControl1"
        Series1.Name = "Serie1"
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        Me.ChartControl1.SeriesTemplate.SeriesColorizer = Nothing
        Me.ChartControl1.Size = New System.Drawing.Size(364, 268)
        Me.ChartControl1.TabIndex = 8
        Me.ChartControl1.Visible = False
        '
        'TextEdit10
        '
        Me.TextEdit10.EditValue = ""
        Me.TextEdit10.Enabled = False
        Me.TextEdit10.Location = New System.Drawing.Point(127, 187)
        Me.TextEdit10.Name = "TextEdit10"
        Me.TextEdit10.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit10.Properties.Appearance.Options.UseFont = True
        Me.TextEdit10.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit10.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit10.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit10.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit10.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit10.Properties.MaxLength = 100
        Me.TextEdit10.Size = New System.Drawing.Size(303, 26)
        Me.TextEdit10.TabIndex = 11
        '
        'TextEdit11
        '
        Me.TextEdit11.EditValue = ""
        Me.TextEdit11.Enabled = False
        Me.TextEdit11.Location = New System.Drawing.Point(127, 155)
        Me.TextEdit11.Name = "TextEdit11"
        Me.TextEdit11.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit11.Properties.Appearance.Options.UseFont = True
        Me.TextEdit11.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit11.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit11.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit11.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit11.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit11.Properties.MaxLength = 100
        Me.TextEdit11.Size = New System.Drawing.Size(85, 26)
        Me.TextEdit11.TabIndex = 8
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Appearance.Options.UseFont = True
        Me.LabelControl12.Enabled = False
        Me.LabelControl12.Location = New System.Drawing.Point(36, 191)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(34, 17)
        Me.LabelControl12.TabIndex = 10
        Me.LabelControl12.Text = "&Host"
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Appearance.Options.UseFont = True
        Me.LabelControl13.Enabled = False
        Me.LabelControl13.Location = New System.Drawing.Point(36, 159)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(47, 17)
        Me.LabelControl13.TabIndex = 7
        Me.LabelControl13.Text = "&Puerto"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton3.Appearance.Image = CType(resources.GetObject("SimpleButton3.Appearance.Image"), System.Drawing.Image)
        Me.SimpleButton3.Appearance.Options.UseFont = True
        Me.SimpleButton3.Appearance.Options.UseImage = True
        Me.SimpleButton3.Appearance.Options.UseTextOptions = True
        Me.SimpleButton3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SimpleButton3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(127, 251)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(303, 30)
        Me.SimpleButton3.TabIndex = 16
        Me.SimpleButton3.Text = "&Registrar recarga de mensajes"
        '
        'ComboBoxEdit1
        '
        Me.ComboBoxEdit1.Enabled = False
        Me.ComboBoxEdit1.Location = New System.Drawing.Point(127, 123)
        Me.ComboBoxEdit1.Name = "ComboBoxEdit1"
        Me.ComboBoxEdit1.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit1.Properties.Appearance.Options.UseFont = True
        Me.ComboBoxEdit1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ComboBoxEdit1.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit1.Properties.AppearanceDropDown.Options.UseFont = True
        Me.ComboBoxEdit1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboBoxEdit1.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.ComboBoxEdit1.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ComboBoxEdit1.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.ComboBoxEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.ComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit1.Properties.Items.AddRange(New Object() {"Mas Mensajes (México)"})
        Me.ComboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit1.Size = New System.Drawing.Size(303, 26)
        Me.ComboBoxEdit1.TabIndex = 6
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Appearance.Options.UseFont = True
        Me.LabelControl9.Enabled = False
        Me.LabelControl9.Location = New System.Drawing.Point(36, 126)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(77, 17)
        Me.LabelControl9.TabIndex = 5
        Me.LabelControl9.Text = "&Manejador"
        '
        'TextEdit2
        '
        Me.TextEdit2.EditValue = ""
        Me.TextEdit2.Enabled = False
        Me.TextEdit2.Location = New System.Drawing.Point(127, 91)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit2.Properties.Appearance.Options.UseFont = True
        Me.TextEdit2.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit2.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit2.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit2.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit2.Properties.MaxLength = 100
        Me.TextEdit2.Size = New System.Drawing.Size(303, 26)
        Me.TextEdit2.TabIndex = 4
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Enabled = False
        Me.LabelControl4.Location = New System.Drawing.Point(206, 223)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(105, 17)
        Me.LabelControl4.TabIndex = 14
        Me.LabelControl4.Text = "&Última recarga"
        '
        'TextEdit4
        '
        Me.TextEdit4.EditValue = ""
        Me.TextEdit4.Enabled = False
        Me.TextEdit4.Location = New System.Drawing.Point(342, 219)
        Me.TextEdit4.Name = "TextEdit4"
        Me.TextEdit4.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit4.Properties.Appearance.Options.UseFont = True
        Me.TextEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit4.Size = New System.Drawing.Size(88, 26)
        Me.TextEdit4.TabIndex = 15
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Enabled = False
        Me.LabelControl3.Location = New System.Drawing.Point(36, 223)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(49, 17)
        Me.LabelControl3.TabIndex = 12
        Me.LabelControl3.Text = "Restan"
        '
        'TextEdit3
        '
        Me.TextEdit3.EditValue = "10"
        Me.TextEdit3.Enabled = False
        Me.TextEdit3.Location = New System.Drawing.Point(127, 219)
        Me.TextEdit3.Name = "TextEdit3"
        Me.TextEdit3.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit3.Properties.Appearance.Options.UseFont = True
        Me.TextEdit3.Properties.Appearance.Options.UseTextOptions = True
        Me.TextEdit3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit3.Size = New System.Drawing.Size(59, 26)
        Me.TextEdit3.TabIndex = 13
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Enabled = False
        Me.LabelControl2.Location = New System.Drawing.Point(36, 94)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(80, 17)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "&Contraseña"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Enabled = False
        Me.LabelControl1.Location = New System.Drawing.Point(36, 63)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(56, 17)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "&Usuario"
        '
        'TextEdit1
        '
        Me.TextEdit1.EditValue = ""
        Me.TextEdit1.Enabled = False
        Me.TextEdit1.Location = New System.Drawing.Point(127, 59)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit1.Properties.Appearance.Options.UseFont = True
        Me.TextEdit1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit1.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit1.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit1.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit1.Properties.MaxLength = 100
        Me.TextEdit1.Size = New System.Drawing.Size(303, 26)
        Me.TextEdit1.TabIndex = 2
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(15, 29)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.CheckEdit1.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit1.Properties.Caption = "Activar el envío de SMS"
        Me.CheckEdit1.Size = New System.Drawing.Size(195, 21)
        Me.CheckEdit1.TabIndex = 0
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GroupControl2)
        Me.XtraTabPage2.ImageOptions.Image = CType(resources.GetObject("XtraTabPage2.ImageOptions.Image"), System.Drawing.Image)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(506, 313)
        Me.XtraTabPage2.Text = "Email"
        '
        'GroupControl2
        '
        Me.GroupControl2.AppearanceCaption.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupControl2.AppearanceCaption.Options.UseFont = True
        Me.GroupControl2.CaptionImageOptions.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupControl2.Controls.Add(Me.CheckEdit3)
        Me.GroupControl2.Controls.Add(Me.TextEdit8)
        Me.GroupControl2.Controls.Add(Me.TextEdit7)
        Me.GroupControl2.Controls.Add(Me.TextEdit6)
        Me.GroupControl2.Controls.Add(Me.TextEdit5)
        Me.GroupControl2.Controls.Add(Me.LabelControl6)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.LabelControl7)
        Me.GroupControl2.Controls.Add(Me.LabelControl8)
        Me.GroupControl2.Controls.Add(Me.CheckEdit2)
        Me.GroupControl2.Location = New System.Drawing.Point(3, 3)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(500, 315)
        Me.GroupControl2.TabIndex = 3
        Me.GroupControl2.Text = "Configuración para envió de correos electrónicos"
        '
        'CheckEdit3
        '
        Me.CheckEdit3.Enabled = False
        Me.CheckEdit3.Location = New System.Drawing.Point(251, 121)
        Me.CheckEdit3.Name = "CheckEdit3"
        Me.CheckEdit3.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.CheckEdit3.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit3.Properties.Caption = "Usar conexión SSL"
        Me.CheckEdit3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckEdit3.Size = New System.Drawing.Size(179, 21)
        Me.CheckEdit3.TabIndex = 7
        '
        'TextEdit8
        '
        Me.TextEdit8.EditValue = ""
        Me.TextEdit8.Enabled = False
        Me.TextEdit8.Location = New System.Drawing.Point(127, 57)
        Me.TextEdit8.Name = "TextEdit8"
        Me.TextEdit8.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit8.Properties.Appearance.Options.UseFont = True
        Me.TextEdit8.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit8.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit8.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit8.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit8.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit8.Properties.MaxLength = 100
        Me.TextEdit8.Size = New System.Drawing.Size(303, 26)
        Me.TextEdit8.TabIndex = 2
        '
        'TextEdit7
        '
        Me.TextEdit7.EditValue = ""
        Me.TextEdit7.Enabled = False
        Me.TextEdit7.Location = New System.Drawing.Point(127, 89)
        Me.TextEdit7.Name = "TextEdit7"
        Me.TextEdit7.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit7.Properties.Appearance.Options.UseFont = True
        Me.TextEdit7.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit7.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit7.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit7.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit7.Properties.MaxLength = 100
        Me.TextEdit7.Size = New System.Drawing.Size(303, 26)
        Me.TextEdit7.TabIndex = 4
        '
        'TextEdit6
        '
        Me.TextEdit6.EditValue = ""
        Me.TextEdit6.Enabled = False
        Me.TextEdit6.Location = New System.Drawing.Point(127, 153)
        Me.TextEdit6.Name = "TextEdit6"
        Me.TextEdit6.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit6.Properties.Appearance.Options.UseFont = True
        Me.TextEdit6.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit6.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit6.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit6.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit6.Properties.MaxLength = 100
        Me.TextEdit6.Size = New System.Drawing.Size(303, 26)
        Me.TextEdit6.TabIndex = 8
        '
        'TextEdit5
        '
        Me.TextEdit5.EditValue = ""
        Me.TextEdit5.Enabled = False
        Me.TextEdit5.Location = New System.Drawing.Point(127, 121)
        Me.TextEdit5.Name = "TextEdit5"
        Me.TextEdit5.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit5.Properties.Appearance.Options.UseFont = True
        Me.TextEdit5.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit5.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit5.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit5.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit5.Properties.MaxLength = 100
        Me.TextEdit5.Size = New System.Drawing.Size(85, 26)
        Me.TextEdit5.TabIndex = 6
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Appearance.Options.UseFont = True
        Me.LabelControl6.Enabled = False
        Me.LabelControl6.Location = New System.Drawing.Point(36, 157)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(34, 17)
        Me.LabelControl6.TabIndex = 7
        Me.LabelControl6.Text = "&Host"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Enabled = False
        Me.LabelControl5.Location = New System.Drawing.Point(36, 125)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(47, 17)
        Me.LabelControl5.TabIndex = 5
        Me.LabelControl5.Text = "&Puerto"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.Options.UseFont = True
        Me.LabelControl7.Enabled = False
        Me.LabelControl7.Location = New System.Drawing.Point(36, 92)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(80, 17)
        Me.LabelControl7.TabIndex = 3
        Me.LabelControl7.Text = "&Contraseña"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Appearance.Options.UseFont = True
        Me.LabelControl8.Enabled = False
        Me.LabelControl8.Location = New System.Drawing.Point(36, 61)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(56, 17)
        Me.LabelControl8.TabIndex = 1
        Me.LabelControl8.Text = "&Usuario"
        '
        'CheckEdit2
        '
        Me.CheckEdit2.Location = New System.Drawing.Point(15, 30)
        Me.CheckEdit2.Name = "CheckEdit2"
        Me.CheckEdit2.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.CheckEdit2.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit2.Properties.Caption = "Activar el envío de correos electrónicos"
        Me.CheckEdit2.Size = New System.Drawing.Size(332, 21)
        Me.CheckEdit2.TabIndex = 0
        '
        'XtraTabPage4
        '
        Me.XtraTabPage4.Controls.Add(Me.GroupControl5)
        Me.XtraTabPage4.ImageOptions.Image = Global.smscronos.My.Resources.Resources.Play_icon
        Me.XtraTabPage4.Name = "XtraTabPage4"
        Me.XtraTabPage4.Size = New System.Drawing.Size(506, 313)
        Me.XtraTabPage4.Text = "VOZ"
        '
        'GroupControl5
        '
        Me.GroupControl5.AppearanceCaption.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupControl5.AppearanceCaption.Options.UseFont = True
        Me.GroupControl5.CaptionImageOptions.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupControl5.Controls.Add(Me.SimpleButton13)
        Me.GroupControl5.Controls.Add(Me.SimpleButton12)
        Me.GroupControl5.Controls.Add(Me.SimpleButton11)
        Me.GroupControl5.Controls.Add(Me.SimpleButton10)
        Me.GroupControl5.Controls.Add(Me.TextEdit18)
        Me.GroupControl5.Controls.Add(Me.LabelControl29)
        Me.GroupControl5.Controls.Add(Me.SimpleButton9)
        Me.GroupControl5.Controls.Add(Me.TextEdit17)
        Me.GroupControl5.Controls.Add(Me.LabelControl28)
        Me.GroupControl5.Controls.Add(Me.SimpleButton8)
        Me.GroupControl5.Controls.Add(Me.TextEdit16)
        Me.GroupControl5.Controls.Add(Me.LabelControl27)
        Me.GroupControl5.Controls.Add(Me.ComboBoxEdit9)
        Me.GroupControl5.Controls.Add(Me.ComboBoxEdit8)
        Me.GroupControl5.Controls.Add(Me.TrackBarControl1)
        Me.GroupControl5.Controls.Add(Me.ComboBoxEdit7)
        Me.GroupControl5.Controls.Add(Me.ComboBoxEdit5)
        Me.GroupControl5.Controls.Add(Me.LabelControl21)
        Me.GroupControl5.Controls.Add(Me.ComboBoxEdit6)
        Me.GroupControl5.Controls.Add(Me.LabelControl22)
        Me.GroupControl5.Controls.Add(Me.LabelControl23)
        Me.GroupControl5.Controls.Add(Me.LabelControl24)
        Me.GroupControl5.Controls.Add(Me.LabelControl25)
        Me.GroupControl5.Controls.Add(Me.LabelControl26)
        Me.GroupControl5.Controls.Add(Me.CheckEdit11)
        Me.GroupControl5.Location = New System.Drawing.Point(3, 3)
        Me.GroupControl5.Name = "GroupControl5"
        Me.GroupControl5.Size = New System.Drawing.Size(500, 315)
        Me.GroupControl5.TabIndex = 5
        Me.GroupControl5.Text = "Configuración para generación de mensajes de audio"
        '
        'SimpleButton13
        '
        Me.SimpleButton13.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton13.Appearance.Image = CType(resources.GetObject("SimpleButton13.Appearance.Image"), System.Drawing.Image)
        Me.SimpleButton13.Appearance.Options.UseFont = True
        Me.SimpleButton13.Appearance.Options.UseImage = True
        Me.SimpleButton13.Appearance.Options.UseTextOptions = True
        Me.SimpleButton13.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SimpleButton13.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton13.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton13.ImageOptions.Image = CType(resources.GetObject("SimpleButton13.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton13.Location = New System.Drawing.Point(202, 267)
        Me.SimpleButton13.Name = "SimpleButton13"
        Me.SimpleButton13.Size = New System.Drawing.Size(228, 30)
        Me.SimpleButton13.TabIndex = 21
        Me.SimpleButton13.Text = "Agregar prefijo de audios"
        '
        'SimpleButton12
        '
        Me.SimpleButton12.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton12.Appearance.Image = CType(resources.GetObject("SimpleButton12.Appearance.Image"), System.Drawing.Image)
        Me.SimpleButton12.Appearance.Options.UseFont = True
        Me.SimpleButton12.Appearance.Options.UseImage = True
        Me.SimpleButton12.Appearance.Options.UseTextOptions = True
        Me.SimpleButton12.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SimpleButton12.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton12.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton12.ImageOptions.Image = CType(resources.GetObject("SimpleButton12.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton12.Location = New System.Drawing.Point(202, 231)
        Me.SimpleButton12.Name = "SimpleButton12"
        Me.SimpleButton12.Size = New System.Drawing.Size(228, 30)
        Me.SimpleButton12.TabIndex = 20
        Me.SimpleButton12.Text = "Carpeta por área"
        '
        'SimpleButton11
        '
        Me.SimpleButton11.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton11.Appearance.Image = CType(resources.GetObject("SimpleButton11.Appearance.Image"), System.Drawing.Image)
        Me.SimpleButton11.Appearance.Options.UseFont = True
        Me.SimpleButton11.Appearance.Options.UseImage = True
        Me.SimpleButton11.Appearance.Options.UseTextOptions = True
        Me.SimpleButton11.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SimpleButton11.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton11.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton11.ImageOptions.Image = CType(resources.GetObject("SimpleButton11.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton11.Location = New System.Drawing.Point(15, 231)
        Me.SimpleButton11.Name = "SimpleButton11"
        Me.SimpleButton11.Size = New System.Drawing.Size(181, 30)
        Me.SimpleButton11.TabIndex = 19
        Me.SimpleButton11.Text = "Traducir contenido"
        '
        'SimpleButton10
        '
        Me.SimpleButton10.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton10.Appearance.Image = CType(resources.GetObject("SimpleButton10.Appearance.Image"), System.Drawing.Image)
        Me.SimpleButton10.Appearance.Options.UseFont = True
        Me.SimpleButton10.Appearance.Options.UseImage = True
        Me.SimpleButton10.Appearance.Options.UseTextOptions = True
        Me.SimpleButton10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SimpleButton10.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton10.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton10.Location = New System.Drawing.Point(402, 398)
        Me.SimpleButton10.Name = "SimpleButton10"
        Me.SimpleButton10.Size = New System.Drawing.Size(28, 25)
        Me.SimpleButton10.TabIndex = 18
        Me.SimpleButton10.Text = "..."
        Me.SimpleButton10.Visible = False
        '
        'TextEdit18
        '
        Me.TextEdit18.EditValue = ""
        Me.TextEdit18.Enabled = False
        Me.TextEdit18.Location = New System.Drawing.Point(169, 398)
        Me.TextEdit18.Name = "TextEdit18"
        Me.TextEdit18.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit18.Properties.Appearance.Options.UseFont = True
        Me.TextEdit18.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit18.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit18.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit18.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit18.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit18.Properties.MaxLength = 500
        Me.TextEdit18.Size = New System.Drawing.Size(227, 26)
        Me.TextEdit18.TabIndex = 17
        Me.TextEdit18.Visible = False
        '
        'LabelControl29
        '
        Me.LabelControl29.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl29.Appearance.Options.UseFont = True
        Me.LabelControl29.Enabled = False
        Me.LabelControl29.Location = New System.Drawing.Point(36, 402)
        Me.LabelControl29.Name = "LabelControl29"
        Me.LabelControl29.Size = New System.Drawing.Size(127, 17)
        Me.LabelControl29.TabIndex = 16
        Me.LabelControl29.Text = "&
a guardar (3)"
        Me.LabelControl29.Visible = False
        '
        'SimpleButton9
        '
        Me.SimpleButton9.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton9.Appearance.Image = CType(resources.GetObject("SimpleButton9.Appearance.Image"), System.Drawing.Image)
        Me.SimpleButton9.Appearance.Options.UseFont = True
        Me.SimpleButton9.Appearance.Options.UseImage = True
        Me.SimpleButton9.Appearance.Options.UseTextOptions = True
        Me.SimpleButton9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SimpleButton9.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton9.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton9.Location = New System.Drawing.Point(402, 194)
        Me.SimpleButton9.Name = "SimpleButton9"
        Me.SimpleButton9.Size = New System.Drawing.Size(28, 25)
        Me.SimpleButton9.TabIndex = 15
        Me.SimpleButton9.Text = "..."
        '
        'TextEdit17
        '
        Me.TextEdit17.EditValue = ""
        Me.TextEdit17.Enabled = False
        Me.TextEdit17.Location = New System.Drawing.Point(169, 195)
        Me.TextEdit17.Name = "TextEdit17"
        Me.TextEdit17.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit17.Properties.Appearance.Options.UseFont = True
        Me.TextEdit17.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit17.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit17.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit17.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit17.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit17.Properties.MaxLength = 500
        Me.TextEdit17.Size = New System.Drawing.Size(227, 26)
        Me.TextEdit17.TabIndex = 14
        '
        'LabelControl28
        '
        Me.LabelControl28.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl28.Appearance.Options.UseFont = True
        Me.LabelControl28.Enabled = False
        Me.LabelControl28.Location = New System.Drawing.Point(36, 198)
        Me.LabelControl28.Name = "LabelControl28"
        Me.LabelControl28.Size = New System.Drawing.Size(127, 17)
        Me.LabelControl28.TabIndex = 13
        Me.LabelControl28.Text = "&Ruta a guardar (2)"
        '
        'SimpleButton8
        '
        Me.SimpleButton8.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton8.Appearance.Image = CType(resources.GetObject("SimpleButton8.Appearance.Image"), System.Drawing.Image)
        Me.SimpleButton8.Appearance.Options.UseFont = True
        Me.SimpleButton8.Appearance.Options.UseImage = True
        Me.SimpleButton8.Appearance.Options.UseTextOptions = True
        Me.SimpleButton8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SimpleButton8.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton8.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton8.Location = New System.Drawing.Point(402, 163)
        Me.SimpleButton8.Name = "SimpleButton8"
        Me.SimpleButton8.Size = New System.Drawing.Size(28, 25)
        Me.SimpleButton8.TabIndex = 12
        Me.SimpleButton8.Text = "..."
        '
        'TextEdit16
        '
        Me.TextEdit16.EditValue = ""
        Me.TextEdit16.Enabled = False
        Me.TextEdit16.Location = New System.Drawing.Point(169, 163)
        Me.TextEdit16.Name = "TextEdit16"
        Me.TextEdit16.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit16.Properties.Appearance.Options.UseFont = True
        Me.TextEdit16.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit16.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit16.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit16.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit16.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit16.Properties.MaxLength = 500
        Me.TextEdit16.Size = New System.Drawing.Size(227, 26)
        Me.TextEdit16.TabIndex = 11
        '
        'LabelControl27
        '
        Me.LabelControl27.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl27.Appearance.Options.UseFont = True
        Me.LabelControl27.Enabled = False
        Me.LabelControl27.Location = New System.Drawing.Point(36, 167)
        Me.LabelControl27.Name = "LabelControl27"
        Me.LabelControl27.Size = New System.Drawing.Size(109, 17)
        Me.LabelControl27.TabIndex = 10
        Me.LabelControl27.Text = "&Ruta a guardar "
        '
        'ComboBoxEdit9
        '
        Me.ComboBoxEdit9.Enabled = False
        Me.ComboBoxEdit9.Location = New System.Drawing.Point(127, 56)
        Me.ComboBoxEdit9.Name = "ComboBoxEdit9"
        Me.ComboBoxEdit9.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit9.Properties.Appearance.Options.UseFont = True
        Me.ComboBoxEdit9.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit9.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ComboBoxEdit9.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit9.Properties.AppearanceDropDown.Options.UseFont = True
        Me.ComboBoxEdit9.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboBoxEdit9.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.ComboBoxEdit9.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ComboBoxEdit9.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.ComboBoxEdit9.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.ComboBoxEdit9.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit9.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit9.Size = New System.Drawing.Size(303, 26)
        Me.ComboBoxEdit9.TabIndex = 4
        '
        'ComboBoxEdit8
        '
        Me.ComboBoxEdit8.Enabled = False
        Me.ComboBoxEdit8.Location = New System.Drawing.Point(127, 56)
        Me.ComboBoxEdit8.Name = "ComboBoxEdit8"
        Me.ComboBoxEdit8.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit8.Properties.Appearance.Options.UseFont = True
        Me.ComboBoxEdit8.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit8.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ComboBoxEdit8.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit8.Properties.AppearanceDropDown.Options.UseFont = True
        Me.ComboBoxEdit8.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboBoxEdit8.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.ComboBoxEdit8.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ComboBoxEdit8.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.ComboBoxEdit8.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.ComboBoxEdit8.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit8.Properties.Items.AddRange(New Object() {"Mujer", "Hombre", "Neutro"})
        Me.ComboBoxEdit8.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit8.Size = New System.Drawing.Size(303, 26)
        Me.ComboBoxEdit8.TabIndex = 2
        Me.ComboBoxEdit8.Visible = False
        '
        'TrackBarControl1
        '
        Me.TrackBarControl1.EditValue = 1
        Me.TrackBarControl1.Location = New System.Drawing.Point(127, 89)
        Me.TrackBarControl1.Name = "TrackBarControl1"
        Me.TrackBarControl1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.TrackBarControl1.Properties.Appearance.Options.UseFont = True
        Me.TrackBarControl1.Properties.AutoSize = False
        Me.TrackBarControl1.Properties.LabelAppearance.Font = New System.Drawing.Font("Tahoma", 6.8!)
        Me.TrackBarControl1.Properties.LabelAppearance.Options.UseFont = True
        Me.TrackBarControl1.Properties.LabelAppearance.Options.UseTextOptions = True
        Me.TrackBarControl1.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        TrackBarLabel1.Label = "lento"
        TrackBarLabel1.Value = 1
        TrackBarLabel2.Label = "2"
        TrackBarLabel2.Value = 2
        TrackBarLabel3.Label = "3"
        TrackBarLabel3.Value = 3
        TrackBarLabel4.Label = "4"
        TrackBarLabel4.Value = 4
        TrackBarLabel5.Label = "5"
        TrackBarLabel5.Value = 5
        TrackBarLabel6.Label = "6"
        TrackBarLabel6.Value = 6
        TrackBarLabel7.Label = "7"
        TrackBarLabel7.Value = 7
        TrackBarLabel8.Label = "8"
        TrackBarLabel8.Value = 8
        TrackBarLabel9.Label = "9"
        TrackBarLabel9.Value = 9
        TrackBarLabel10.Label = "rápido"
        TrackBarLabel10.Value = 10
        Me.TrackBarControl1.Properties.Labels.AddRange(New DevExpress.XtraEditors.Repository.TrackBarLabel() {TrackBarLabel1, TrackBarLabel2, TrackBarLabel3, TrackBarLabel4, TrackBarLabel5, TrackBarLabel6, TrackBarLabel7, TrackBarLabel8, TrackBarLabel9, TrackBarLabel10})
        Me.TrackBarControl1.Properties.Minimum = 1
        Me.TrackBarControl1.Properties.ShowLabels = True
        Me.TrackBarControl1.Properties.ShowLabelsForHiddenTicks = True
        Me.TrackBarControl1.Properties.ShowValueToolTip = True
        Me.TrackBarControl1.Properties.SmallChangeUseMode = DevExpress.XtraEditors.Repository.SmallChangeUseMode.ArrowKeysAndMouse
        Me.TrackBarControl1.Size = New System.Drawing.Size(303, 68)
        Me.TrackBarControl1.TabIndex = 6
        Me.TrackBarControl1.Value = 1
        '
        'ComboBoxEdit7
        '
        Me.ComboBoxEdit7.Enabled = False
        Me.ComboBoxEdit7.Location = New System.Drawing.Point(222, 338)
        Me.ComboBoxEdit7.Name = "ComboBoxEdit7"
        Me.ComboBoxEdit7.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit7.Properties.Appearance.Options.UseFont = True
        Me.ComboBoxEdit7.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit7.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ComboBoxEdit7.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit7.Properties.AppearanceDropDown.Options.UseFont = True
        Me.ComboBoxEdit7.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboBoxEdit7.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.ComboBoxEdit7.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ComboBoxEdit7.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.ComboBoxEdit7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.ComboBoxEdit7.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit7.Properties.Items.AddRange(New Object() {"No pausar", "1 segundo", "2 segundos", "3 segundos", "5 segundos", "10 segundos", "20 segundos", "30 segundos", "1 minuto", "2 minutos", "5 minutos"})
        Me.ComboBoxEdit7.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit7.Size = New System.Drawing.Size(138, 26)
        Me.ComboBoxEdit7.TabIndex = 8
        Me.ComboBoxEdit7.Visible = False
        '
        'ComboBoxEdit5
        '
        Me.ComboBoxEdit5.Enabled = False
        Me.ComboBoxEdit5.Location = New System.Drawing.Point(302, 303)
        Me.ComboBoxEdit5.Name = "ComboBoxEdit5"
        Me.ComboBoxEdit5.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit5.Properties.Appearance.Options.UseFont = True
        Me.ComboBoxEdit5.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit5.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ComboBoxEdit5.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit5.Properties.AppearanceDropDown.Options.UseFont = True
        Me.ComboBoxEdit5.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboBoxEdit5.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.ComboBoxEdit5.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ComboBoxEdit5.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.ComboBoxEdit5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.ComboBoxEdit5.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit5.Properties.Items.AddRange(New Object() {"Sí", "No"})
        Me.ComboBoxEdit5.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit5.Size = New System.Drawing.Size(138, 26)
        Me.ComboBoxEdit5.TabIndex = 12
        Me.ComboBoxEdit5.Visible = False
        '
        'LabelControl21
        '
        Me.LabelControl21.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl21.Appearance.Options.UseFont = True
        Me.LabelControl21.Enabled = False
        Me.LabelControl21.Location = New System.Drawing.Point(116, 307)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(172, 17)
        Me.LabelControl21.TabIndex = 11
        Me.LabelControl21.Text = "&Reproducir al momento"
        Me.LabelControl21.Visible = False
        '
        'ComboBoxEdit6
        '
        Me.ComboBoxEdit6.Enabled = False
        Me.ComboBoxEdit6.Location = New System.Drawing.Point(222, 369)
        Me.ComboBoxEdit6.Name = "ComboBoxEdit6"
        Me.ComboBoxEdit6.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit6.Properties.Appearance.Options.UseFont = True
        Me.ComboBoxEdit6.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit6.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ComboBoxEdit6.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit6.Properties.AppearanceDropDown.Options.UseFont = True
        Me.ComboBoxEdit6.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboBoxEdit6.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.ComboBoxEdit6.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ComboBoxEdit6.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.ComboBoxEdit6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.ComboBoxEdit6.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit6.Properties.Items.AddRange(New Object() {"Sí", "No"})
        Me.ComboBoxEdit6.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit6.Size = New System.Drawing.Size(138, 26)
        Me.ComboBoxEdit6.TabIndex = 10
        Me.ComboBoxEdit6.Visible = False
        '
        'LabelControl22
        '
        Me.LabelControl22.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl22.Appearance.Options.UseFont = True
        Me.LabelControl22.Enabled = False
        Me.LabelControl22.Location = New System.Drawing.Point(36, 372)
        Me.LabelControl22.Name = "LabelControl22"
        Me.LabelControl22.Size = New System.Drawing.Size(160, 17)
        Me.LabelControl22.TabIndex = 9
        Me.LabelControl22.Text = "&Guardar como archivo"
        Me.LabelControl22.Visible = False
        '
        'LabelControl23
        '
        Me.LabelControl23.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl23.Appearance.Options.UseFont = True
        Me.LabelControl23.Enabled = False
        Me.LabelControl23.Location = New System.Drawing.Point(36, 342)
        Me.LabelControl23.Name = "LabelControl23"
        Me.LabelControl23.Size = New System.Drawing.Size(136, 17)
        Me.LabelControl23.TabIndex = 7
        Me.LabelControl23.Text = "&Pausa entre audios"
        Me.LabelControl23.Visible = False
        '
        'LabelControl24
        '
        Me.LabelControl24.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl24.Appearance.Options.UseFont = True
        Me.LabelControl24.Enabled = False
        Me.LabelControl24.Location = New System.Drawing.Point(36, 101)
        Me.LabelControl24.Name = "LabelControl24"
        Me.LabelControl24.Size = New System.Drawing.Size(74, 17)
        Me.LabelControl24.TabIndex = 5
        Me.LabelControl24.Text = "&Velocidad"
        '
        'LabelControl25
        '
        Me.LabelControl25.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl25.Appearance.Options.UseFont = True
        Me.LabelControl25.Enabled = False
        Me.LabelControl25.Location = New System.Drawing.Point(36, 59)
        Me.LabelControl25.Name = "LabelControl25"
        Me.LabelControl25.Size = New System.Drawing.Size(30, 17)
        Me.LabelControl25.TabIndex = 3
        Me.LabelControl25.Text = "Voz"
        '
        'LabelControl26
        '
        Me.LabelControl26.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl26.Appearance.Options.UseFont = True
        Me.LabelControl26.Enabled = False
        Me.LabelControl26.Location = New System.Drawing.Point(36, 60)
        Me.LabelControl26.Name = "LabelControl26"
        Me.LabelControl26.Size = New System.Drawing.Size(53, 17)
        Me.LabelControl26.TabIndex = 1
        Me.LabelControl26.Text = "Género"
        Me.LabelControl26.Visible = False
        '
        'CheckEdit11
        '
        Me.CheckEdit11.Location = New System.Drawing.Point(15, 29)
        Me.CheckEdit11.Name = "CheckEdit11"
        Me.CheckEdit11.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.CheckEdit11.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit11.Properties.Caption = "Activar la generación de audios"
        Me.CheckEdit11.Size = New System.Drawing.Size(332, 21)
        Me.CheckEdit11.TabIndex = 0
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.GroupControl4)
        Me.XtraTabPage3.ImageOptions.Image = CType(resources.GetObject("XtraTabPage3.ImageOptions.Image"), System.Drawing.Image)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(506, 313)
        Me.XtraTabPage3.Text = "Reportes"
        '
        'GroupControl4
        '
        Me.GroupControl4.AppearanceCaption.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupControl4.AppearanceCaption.Options.UseFont = True
        Me.GroupControl4.CaptionImageOptions.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupControl4.Controls.Add(Me.LabelControl30)
        Me.GroupControl4.Controls.Add(Me.SimpleButton7)
        Me.GroupControl4.Controls.Add(Me.ComboBoxEdit3)
        Me.GroupControl4.Controls.Add(Me.LabelControl20)
        Me.GroupControl4.Controls.Add(Me.ComboBoxEdit2)
        Me.GroupControl4.Controls.Add(Me.LabelControl19)
        Me.GroupControl4.Controls.Add(Me.CheckEdit8)
        Me.GroupControl4.Controls.Add(Me.TextEdit12)
        Me.GroupControl4.Controls.Add(Me.TextEdit13)
        Me.GroupControl4.Controls.Add(Me.TextEdit14)
        Me.GroupControl4.Controls.Add(Me.TextEdit15)
        Me.GroupControl4.Controls.Add(Me.LabelControl15)
        Me.GroupControl4.Controls.Add(Me.LabelControl16)
        Me.GroupControl4.Controls.Add(Me.LabelControl17)
        Me.GroupControl4.Controls.Add(Me.LabelControl18)
        Me.GroupControl4.Controls.Add(Me.CheckEdit9)
        Me.GroupControl4.Location = New System.Drawing.Point(3, 3)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(500, 315)
        Me.GroupControl4.TabIndex = 4
        Me.GroupControl4.Text = "Configuración para envió automático de reportes"
        '
        'LabelControl30
        '
        Me.LabelControl30.Appearance.BackColor = System.Drawing.Color.Tomato
        Me.LabelControl30.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl30.Appearance.Options.UseBackColor = True
        Me.LabelControl30.Appearance.Options.UseFont = True
        Me.LabelControl30.Appearance.Options.UseTextOptions = True
        Me.LabelControl30.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl30.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LabelControl30.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl30.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.LabelControl30.Location = New System.Drawing.Point(127, 285)
        Me.LabelControl30.Name = "LabelControl30"
        Me.LabelControl30.Size = New System.Drawing.Size(303, 24)
        Me.LabelControl30.TabIndex = 18
        Me.LabelControl30.Text = "FUNCIONALIDAD NO ACTIVADA"
        Me.LabelControl30.Visible = False
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton7.Appearance.Image = CType(resources.GetObject("SimpleButton7.Appearance.Image"), System.Drawing.Image)
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.Appearance.Options.UseImage = True
        Me.SimpleButton7.Appearance.Options.UseTextOptions = True
        Me.SimpleButton7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SimpleButton7.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton7.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton7.ImageOptions.Image = CType(resources.GetObject("SimpleButton7.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton7.Location = New System.Drawing.Point(127, 249)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(303, 30)
        Me.SimpleButton7.TabIndex = 17
        Me.SimpleButton7.Text = "Configurar correo electrónico"
        '
        'ComboBoxEdit3
        '
        Me.ComboBoxEdit3.Enabled = False
        Me.ComboBoxEdit3.Location = New System.Drawing.Point(127, 217)
        Me.ComboBoxEdit3.Name = "ComboBoxEdit3"
        Me.ComboBoxEdit3.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit3.Properties.Appearance.Options.UseFont = True
        Me.ComboBoxEdit3.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit3.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ComboBoxEdit3.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit3.Properties.AppearanceDropDown.Options.UseFont = True
        Me.ComboBoxEdit3.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboBoxEdit3.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.ComboBoxEdit3.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ComboBoxEdit3.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.ComboBoxEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.ComboBoxEdit3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit3.Properties.Items.AddRange(New Object() {"Sólo los lunes a las 12 de la noche", "Sólo los martes a las 12 de la noche", "Sólo los miércoles a las 12 de la noche", "Sólo los jueves a las 12 de la noche", "Sólo los viernes a las 12 de la noche", "Sólo los sábados a las 12 de la noche", "Sólo los domingos a las 12 de la noche", "Todos los días a las 12 de la noche", "Todos los días a la 1:00am", "Todos los días a la 3:00am", "Todos los días a la 5:00am", "Todos los días a la 7:00am", "Todos los días a la 9:00am", "Todos los días a la 12:00m", "Todos los días a la 1:00pm", "Todos los días a la 3:00pm", "Todos los días a la 6:00pm", "Todos los días a la 8:00pm", "Todos los días a la 10:00pm"})
        Me.ComboBoxEdit3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit3.Size = New System.Drawing.Size(303, 26)
        Me.ComboBoxEdit3.TabIndex = 12
        '
        'LabelControl20
        '
        Me.LabelControl20.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl20.Appearance.Options.UseFont = True
        Me.LabelControl20.Enabled = False
        Me.LabelControl20.Location = New System.Drawing.Point(36, 220)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(84, 17)
        Me.LabelControl20.TabIndex = 11
        Me.LabelControl20.Text = "&Hora/envío"
        '
        'ComboBoxEdit2
        '
        Me.ComboBoxEdit2.Enabled = False
        Me.ComboBoxEdit2.Location = New System.Drawing.Point(127, 185)
        Me.ComboBoxEdit2.Name = "ComboBoxEdit2"
        Me.ComboBoxEdit2.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit2.Properties.Appearance.Options.UseFont = True
        Me.ComboBoxEdit2.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit2.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ComboBoxEdit2.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.ComboBoxEdit2.Properties.AppearanceDropDown.Options.UseFont = True
        Me.ComboBoxEdit2.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboBoxEdit2.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.ComboBoxEdit2.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ComboBoxEdit2.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.ComboBoxEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.ComboBoxEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit2.Properties.Items.AddRange(New Object() {"7 días atrás incluyendo hoy", "14 días atrás incluyendo hoy", "21 días atrás incluyendo hoy", "30 días atrás incluyendo hoy", "Lo que va del mes", "Lo que va de semana", "Lo que va del día", "Ayer y hoy"})
        Me.ComboBoxEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit2.Size = New System.Drawing.Size(303, 26)
        Me.ComboBoxEdit2.TabIndex = 10
        '
        'LabelControl19
        '
        Me.LabelControl19.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl19.Appearance.Options.UseFont = True
        Me.LabelControl19.Enabled = False
        Me.LabelControl19.Location = New System.Drawing.Point(36, 188)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(57, 17)
        Me.LabelControl19.TabIndex = 9
        Me.LabelControl19.Text = "&Período"
        '
        'CheckEdit8
        '
        Me.CheckEdit8.Enabled = False
        Me.CheckEdit8.Location = New System.Drawing.Point(251, 121)
        Me.CheckEdit8.Name = "CheckEdit8"
        Me.CheckEdit8.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.CheckEdit8.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit8.Properties.Caption = "Usar conexión SSL"
        Me.CheckEdit8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckEdit8.Size = New System.Drawing.Size(179, 21)
        Me.CheckEdit8.TabIndex = 7
        '
        'TextEdit12
        '
        Me.TextEdit12.EditValue = ""
        Me.TextEdit12.Enabled = False
        Me.TextEdit12.Location = New System.Drawing.Point(127, 56)
        Me.TextEdit12.Name = "TextEdit12"
        Me.TextEdit12.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit12.Properties.Appearance.Options.UseFont = True
        Me.TextEdit12.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit12.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit12.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit12.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit12.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit12.Properties.MaxLength = 100
        Me.TextEdit12.Size = New System.Drawing.Size(303, 26)
        Me.TextEdit12.TabIndex = 2
        '
        'TextEdit13
        '
        Me.TextEdit13.EditValue = ""
        Me.TextEdit13.Enabled = False
        Me.TextEdit13.Location = New System.Drawing.Point(127, 89)
        Me.TextEdit13.Name = "TextEdit13"
        Me.TextEdit13.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit13.Properties.Appearance.Options.UseFont = True
        Me.TextEdit13.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit13.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit13.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit13.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit13.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit13.Properties.MaxLength = 100
        Me.TextEdit13.Size = New System.Drawing.Size(303, 26)
        Me.TextEdit13.TabIndex = 4
        '
        'TextEdit14
        '
        Me.TextEdit14.EditValue = ""
        Me.TextEdit14.Enabled = False
        Me.TextEdit14.Location = New System.Drawing.Point(127, 153)
        Me.TextEdit14.Name = "TextEdit14"
        Me.TextEdit14.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit14.Properties.Appearance.Options.UseFont = True
        Me.TextEdit14.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit14.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit14.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit14.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit14.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit14.Properties.MaxLength = 100
        Me.TextEdit14.Size = New System.Drawing.Size(303, 26)
        Me.TextEdit14.TabIndex = 8
        '
        'TextEdit15
        '
        Me.TextEdit15.EditValue = ""
        Me.TextEdit15.Enabled = False
        Me.TextEdit15.Location = New System.Drawing.Point(127, 121)
        Me.TextEdit15.Name = "TextEdit15"
        Me.TextEdit15.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit15.Properties.Appearance.Options.UseFont = True
        Me.TextEdit15.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit15.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit15.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit15.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit15.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit15.Properties.MaxLength = 100
        Me.TextEdit15.Size = New System.Drawing.Size(85, 26)
        Me.TextEdit15.TabIndex = 6
        '
        'LabelControl15
        '
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Appearance.Options.UseFont = True
        Me.LabelControl15.Enabled = False
        Me.LabelControl15.Location = New System.Drawing.Point(36, 157)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(34, 17)
        Me.LabelControl15.TabIndex = 7
        Me.LabelControl15.Text = "&Host"
        '
        'LabelControl16
        '
        Me.LabelControl16.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl16.Appearance.Options.UseFont = True
        Me.LabelControl16.Enabled = False
        Me.LabelControl16.Location = New System.Drawing.Point(36, 125)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(47, 17)
        Me.LabelControl16.TabIndex = 5
        Me.LabelControl16.Text = "&Puerto"
        '
        'LabelControl17
        '
        Me.LabelControl17.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl17.Appearance.Options.UseFont = True
        Me.LabelControl17.Enabled = False
        Me.LabelControl17.Location = New System.Drawing.Point(36, 92)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(80, 17)
        Me.LabelControl17.TabIndex = 3
        Me.LabelControl17.Text = "&Contraseña"
        '
        'LabelControl18
        '
        Me.LabelControl18.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl18.Appearance.Options.UseFont = True
        Me.LabelControl18.Enabled = False
        Me.LabelControl18.Location = New System.Drawing.Point(36, 60)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(56, 17)
        Me.LabelControl18.TabIndex = 1
        Me.LabelControl18.Text = "&Usuario"
        '
        'CheckEdit9
        '
        Me.CheckEdit9.Location = New System.Drawing.Point(15, 29)
        Me.CheckEdit9.Name = "CheckEdit9"
        Me.CheckEdit9.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.CheckEdit9.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit9.Properties.Caption = "Activar el envío de reportes automáticos"
        Me.CheckEdit9.Size = New System.Drawing.Size(332, 21)
        Me.CheckEdit9.TabIndex = 0
        '
        'XtraTabPage5
        '
        Me.XtraTabPage5.Controls.Add(Me.GroupControl6)
        Me.XtraTabPage5.ImageOptions.Image = CType(resources.GetObject("XtraTabPage5.ImageOptions.Image"), System.Drawing.Image)
        Me.XtraTabPage5.Name = "XtraTabPage5"
        Me.XtraTabPage5.Size = New System.Drawing.Size(506, 313)
        Me.XtraTabPage5.Text = "Arduino(r)"
        '
        'GroupControl6
        '
        Me.GroupControl6.AppearanceCaption.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupControl6.AppearanceCaption.Options.UseFont = True
        Me.GroupControl6.CaptionImageOptions.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupControl6.Controls.Add(Me.CheckEdit13)
        Me.GroupControl6.Controls.Add(Me.CheckEdit10)
        Me.GroupControl6.Controls.Add(Me.LabelControl34)
        Me.GroupControl6.Controls.Add(Me.TextEdit21)
        Me.GroupControl6.Controls.Add(Me.LabelControl32)
        Me.GroupControl6.Controls.Add(Me.TextEdit20)
        Me.GroupControl6.Controls.Add(Me.SimpleButton14)
        Me.GroupControl6.Controls.Add(Me.LabelControl31)
        Me.GroupControl6.Controls.Add(Me.TextEdit19)
        Me.GroupControl6.Controls.Add(Me.LabelControl33)
        Me.GroupControl6.Controls.Add(Me.CheckEdit12)
        Me.GroupControl6.Location = New System.Drawing.Point(3, 3)
        Me.GroupControl6.Name = "GroupControl6"
        Me.GroupControl6.Size = New System.Drawing.Size(500, 315)
        Me.GroupControl6.TabIndex = 4
        Me.GroupControl6.Text = "Configuración de llamadas"
        '
        'CheckEdit13
        '
        Me.CheckEdit13.Location = New System.Drawing.Point(15, 42)
        Me.CheckEdit13.Name = "CheckEdit13"
        Me.CheckEdit13.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.CheckEdit13.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit13.Properties.Caption = "Activar SMS"
        Me.CheckEdit13.Size = New System.Drawing.Size(332, 21)
        Me.CheckEdit13.TabIndex = 0
        '
        'CheckEdit10
        '
        Me.CheckEdit10.Location = New System.Drawing.Point(233, 185)
        Me.CheckEdit10.Name = "CheckEdit10"
        Me.CheckEdit10.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.CheckEdit10.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit10.Properties.Caption = "Enviar SMS al vencer intentos"
        Me.CheckEdit10.Size = New System.Drawing.Size(249, 21)
        Me.CheckEdit10.TabIndex = 6
        '
        'LabelControl34
        '
        Me.LabelControl34.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl34.Appearance.Options.UseFont = True
        Me.LabelControl34.Enabled = False
        Me.LabelControl34.Location = New System.Drawing.Point(53, 230)
        Me.LabelControl34.Name = "LabelControl34"
        Me.LabelControl34.Size = New System.Drawing.Size(76, 17)
        Me.LabelControl34.TabIndex = 7
        Me.LabelControl34.Text = "Notificar a"
        '
        'TextEdit21
        '
        Me.TextEdit21.EditValue = ""
        Me.TextEdit21.Enabled = False
        Me.TextEdit21.Location = New System.Drawing.Point(152, 225)
        Me.TextEdit21.Name = "TextEdit21"
        Me.TextEdit21.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit21.Properties.Appearance.Options.UseFont = True
        Me.TextEdit21.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit21.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit21.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit21.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit21.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit21.Size = New System.Drawing.Size(316, 26)
        Me.TextEdit21.TabIndex = 8
        '
        'LabelControl32
        '
        Me.LabelControl32.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl32.Appearance.Options.UseFont = True
        Me.LabelControl32.Enabled = False
        Me.LabelControl32.Location = New System.Drawing.Point(53, 187)
        Me.LabelControl32.Name = "LabelControl32"
        Me.LabelControl32.Size = New System.Drawing.Size(59, 17)
        Me.LabelControl32.TabIndex = 4
        Me.LabelControl32.Text = "Intentos"
        '
        'TextEdit20
        '
        Me.TextEdit20.EditValue = ""
        Me.TextEdit20.Enabled = False
        Me.TextEdit20.Location = New System.Drawing.Point(152, 182)
        Me.TextEdit20.Name = "TextEdit20"
        Me.TextEdit20.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit20.Properties.Appearance.Options.UseFont = True
        Me.TextEdit20.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit20.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit20.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit20.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit20.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit20.Size = New System.Drawing.Size(75, 26)
        Me.TextEdit20.TabIndex = 5
        '
        'SimpleButton14
        '
        Me.SimpleButton14.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton14.Appearance.Image = CType(resources.GetObject("SimpleButton14.Appearance.Image"), System.Drawing.Image)
        Me.SimpleButton14.Appearance.Options.UseFont = True
        Me.SimpleButton14.Appearance.Options.UseImage = True
        Me.SimpleButton14.Appearance.Options.UseTextOptions = True
        Me.SimpleButton14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SimpleButton14.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton14.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton14.Location = New System.Drawing.Point(440, 145)
        Me.SimpleButton14.Name = "SimpleButton14"
        Me.SimpleButton14.Size = New System.Drawing.Size(28, 25)
        Me.SimpleButton14.TabIndex = 14
        Me.SimpleButton14.Text = "..."
        '
        'LabelControl31
        '
        Me.LabelControl31.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl31.Appearance.Options.UseFont = True
        Me.LabelControl31.Enabled = False
        Me.LabelControl31.Location = New System.Drawing.Point(53, 148)
        Me.LabelControl31.Name = "LabelControl31"
        Me.LabelControl31.Size = New System.Drawing.Size(33, 17)
        Me.LabelControl31.TabIndex = 2
        Me.LabelControl31.Text = "&Ruta"
        '
        'TextEdit19
        '
        Me.TextEdit19.EditValue = ""
        Me.TextEdit19.Enabled = False
        Me.TextEdit19.Location = New System.Drawing.Point(152, 145)
        Me.TextEdit19.Name = "TextEdit19"
        Me.TextEdit19.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit19.Properties.Appearance.Options.UseFont = True
        Me.TextEdit19.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit19.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit19.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit19.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit19.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit19.Size = New System.Drawing.Size(278, 26)
        Me.TextEdit19.TabIndex = 3
        '
        'LabelControl33
        '
        Me.LabelControl33.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl33.Appearance.Options.UseFont = True
        Me.LabelControl33.Appearance.Options.UseTextOptions = True
        Me.LabelControl33.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl33.AutoEllipsis = True
        Me.LabelControl33.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.LabelControl33.LineLocation = DevExpress.XtraEditors.LineLocation.Top
        Me.LabelControl33.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal
        Me.LabelControl33.LineVisible = True
        Me.LabelControl33.Location = New System.Drawing.Point(57, 94)
        Me.LabelControl33.Name = "LabelControl33"
        Me.LabelControl33.Size = New System.Drawing.Size(411, 37)
        Me.LabelControl33.TabIndex = 3
        Me.LabelControl33.Text = "Deberá contar con el hardware adecuado para poder realizar llamadas telefónicas."
        '
        'CheckEdit12
        '
        Me.CheckEdit12.Location = New System.Drawing.Point(15, 69)
        Me.CheckEdit12.Name = "CheckEdit12"
        Me.CheckEdit12.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.CheckEdit12.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit12.Properties.Caption = "Activar llamadas telefónicas"
        Me.CheckEdit12.Size = New System.Drawing.Size(332, 21)
        Me.CheckEdit12.TabIndex = 1
        '
        'CheckEdit6
        '
        Me.CheckEdit6.Location = New System.Drawing.Point(253, 96)
        Me.CheckEdit6.Name = "CheckEdit6"
        Me.CheckEdit6.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.CheckEdit6.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit6.Properties.Caption = "Sólo cancelaciones"
        Me.CheckEdit6.Size = New System.Drawing.Size(186, 21)
        Me.CheckEdit6.TabIndex = 4
        '
        'CheckEdit5
        '
        Me.CheckEdit5.Location = New System.Drawing.Point(253, 78)
        Me.CheckEdit5.Name = "CheckEdit5"
        Me.CheckEdit5.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.CheckEdit5.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit5.Properties.Caption = "Sólo repeticiones"
        Me.CheckEdit5.Size = New System.Drawing.Size(186, 21)
        Me.CheckEdit5.TabIndex = 3
        '
        'CheckEdit4
        '
        Me.CheckEdit4.Location = New System.Drawing.Point(253, 60)
        Me.CheckEdit4.Name = "CheckEdit4"
        Me.CheckEdit4.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!)
        Me.CheckEdit4.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit4.Properties.Caption = "Sólo el primer mensaje"
        Me.CheckEdit4.Size = New System.Drawing.Size(204, 21)
        Me.CheckEdit4.TabIndex = 2
        '
        'TextEdit9
        '
        Me.TextEdit9.EditValue = ""
        Me.TextEdit9.Location = New System.Drawing.Point(152, 57)
        Me.TextEdit9.Name = "TextEdit9"
        Me.TextEdit9.Properties.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit9.Properties.Appearance.Options.UseFont = True
        Me.TextEdit9.Properties.Appearance.Options.UseTextOptions = True
        Me.TextEdit9.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TextEdit9.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue
        Me.TextEdit9.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.LightBlue
        Me.TextEdit9.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit9.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.TextEdit9.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextEdit9.Properties.Mask.BeepOnError = True
        Me.TextEdit9.Properties.Mask.EditMask = "n0"
        Me.TextEdit9.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TextEdit9.Properties.MaxLength = 8
        Me.TextEdit9.Size = New System.Drawing.Size(95, 26)
        Me.TextEdit9.TabIndex = 1
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Appearance.Options.UseFont = True
        Me.LabelControl11.Location = New System.Drawing.Point(9, 61)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(128, 17)
        Me.LabelControl11.TabIndex = 0
        Me.LabelControl11.Text = "Sensar cada (seg.)"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton5.Appearance.Image = CType(resources.GetObject("SimpleButton5.Appearance.Image"), System.Drawing.Image)
        Me.SimpleButton5.Appearance.Options.UseFont = True
        Me.SimpleButton5.Appearance.Options.UseImage = True
        Me.SimpleButton5.Appearance.Options.UseTextOptions = True
        Me.SimpleButton5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SimpleButton5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton5.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton5.ImageOptions.Image = CType(resources.GetObject("SimpleButton5.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton5.Location = New System.Drawing.Point(135, 620)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(174, 30)
        Me.SimpleButton5.TabIndex = 4
        Me.SimpleButton5.Text = "&Depurar históricos"
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.BackColor = System.Drawing.Color.Tomato
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl14.Appearance.Options.UseBackColor = True
        Me.LabelControl14.Appearance.Options.UseFont = True
        Me.LabelControl14.Appearance.Options.UseTextOptions = True
        Me.LabelControl14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl14.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LabelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl14.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.LabelControl14.Location = New System.Drawing.Point(12, 662)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(426, 24)
        Me.LabelControl14.TabIndex = 10
        Me.LabelControl14.Text = "La aplicación está DETENIDA"
        Me.LabelControl14.Visible = False
        '
        'XtraFolderBrowserDialog1
        '
        Me.XtraFolderBrowserDialog1.SelectedPath = "XtraFolderBrowserDialog1"
        '
        'ChartControl2
        '
        XyDiagram2.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        XyDiagram2.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram2.AxisY.VisibleInPanesSerializable = "-1"
        Me.ChartControl2.Diagram = XyDiagram2
        Me.ChartControl2.Legend.Name = "Default Legend"
        Me.ChartControl2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.ChartControl2.Location = New System.Drawing.Point(4, 859)
        Me.ChartControl2.Name = "ChartControl2"
        Series2.Name = "Serie1"
        Me.ChartControl2.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series2}
        Me.ChartControl2.SeriesTemplate.SeriesColorizer = Nothing
        Me.ChartControl2.Size = New System.Drawing.Size(364, 268)
        Me.ChartControl2.TabIndex = 11
        Me.ChartControl2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(7, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(514, 102)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(155, 104)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(177, 17)
        Me.LinkLabel1.TabIndex = 13
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "www.mmcallmexico.mx"
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 19200
        Me.SerialPort1.PortName = "COM4"
        '
        'LabelControl36
        '
        Me.LabelControl36.Appearance.BackColor = System.Drawing.Color.Tomato
        Me.LabelControl36.Appearance.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl36.Appearance.Options.UseBackColor = True
        Me.LabelControl36.Appearance.Options.UseFont = True
        Me.LabelControl36.Appearance.Options.UseTextOptions = True
        Me.LabelControl36.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl36.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LabelControl36.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl36.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.LabelControl36.Location = New System.Drawing.Point(447, 661)
        Me.LabelControl36.Name = "LabelControl36"
        Me.LabelControl36.Size = New System.Drawing.Size(73, 24)
        Me.LabelControl36.TabIndex = 14
        '
        'Form1
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 696)
        Me.Controls.Add(Me.LabelControl36)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ChartControl2)
        Me.Controls.Add(Me.LabelControl14)
        Me.Controls.Add(Me.SimpleButton5)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.LabelControl10)
        Me.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.TextEdit22.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit7.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit10.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit11.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit8.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit7.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage4.ResumeLayout(False)
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl5.ResumeLayout(False)
        Me.GroupControl5.PerformLayout()
        CType(Me.TextEdit18.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit17.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit16.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit9.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit8.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit7.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit11.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        Me.GroupControl4.PerformLayout()
        CType(Me.ComboBoxEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit8.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit12.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit13.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit14.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit15.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit9.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage5.ResumeLayout(False)
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl6.ResumeLayout(False)
        Me.GroupControl6.PerformLayout()
        CType(Me.CheckEdit13.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit10.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit21.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit20.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit19.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit12.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit9.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TextEdit9 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CheckEdit6 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEdit5 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEdit4 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CheckEdit3 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TextEdit8 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit7 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit6 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit5 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CheckEdit2 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ComboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit4 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents CheckEdit7 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TextEdit10 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit11 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CheckEdit8 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TextEdit12 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit13 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit14 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit15 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CheckEdit9 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ComboBoxEdit3 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ComboBoxEdit2 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents XtraTabPage4 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl5 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ComboBoxEdit5 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ComboBoxEdit6 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl22 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl23 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl24 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl25 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl26 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CheckEdit11 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TrackBarControl1 As DevExpress.XtraEditors.TrackBarControl
    Friend WithEvents ComboBoxEdit7 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents ComboBoxEdit9 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents ComboBoxEdit8 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TextEdit16 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl27 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton8 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraFolderBrowserDialog1 As DevExpress.XtraEditors.XtraFolderBrowserDialog
    Friend WithEvents ChartControl2 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents SimpleButton10 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEdit18 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl29 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton9 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEdit17 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl28 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton12 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton11 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LabelControl30 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton13 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents XtraTabPage5 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl6 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl33 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CheckEdit12 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl31 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit19 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton14 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl32 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit20 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl34 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit21 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl35 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit22 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CheckEdit13 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEdit10 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl36 As DevExpress.XtraEditors.LabelControl

#End Region

End Class
