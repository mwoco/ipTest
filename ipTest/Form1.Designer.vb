<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.sendData = New System.Windows.Forms.Button()
        Me.logArea = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rxAddress = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txMessage = New System.Windows.Forms.TextBox()
        Me.txMode = New System.Windows.Forms.ComboBox()
        Me.rxPort = New System.Windows.Forms.NumericUpDown()
        Me.txAddress = New System.Windows.Forms.TextBox()
        Me.txPort = New System.Windows.Forms.NumericUpDown()
        CType(Me.rxPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(307, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Port"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Tx Destination"
        '
        'sendData
        '
        Me.sendData.Location = New System.Drawing.Point(543, 31)
        Me.sendData.Name = "sendData"
        Me.sendData.Size = New System.Drawing.Size(72, 49)
        Me.sendData.TabIndex = 5
        Me.sendData.Text = "Send Message"
        Me.sendData.UseVisualStyleBackColor = True
        '
        'logArea
        '
        Me.logArea.Location = New System.Drawing.Point(12, 85)
        Me.logArea.Multiline = True
        Me.logArea.Name = "logArea"
        Me.logArea.ReadOnly = True
        Me.logArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.logArea.Size = New System.Drawing.Size(603, 292)
        Me.logArea.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(307, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Port"
        '
        'rxAddress
        '
        Me.rxAddress.Location = New System.Drawing.Point(93, 6)
        Me.rxAddress.Name = "rxAddress"
        Me.rxAddress.ReadOnly = True
        Me.rxAddress.Size = New System.Drawing.Size(208, 20)
        Me.rxAddress.TabIndex = 11
        Me.rxAddress.Text = "localhost"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Rx Destination"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(416, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Mode"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Tx Message"
        '
        'txMessage
        '
        Me.txMessage.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ipTest.My.MySettings.Default, "txMessage", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txMessage.Location = New System.Drawing.Point(93, 59)
        Me.txMessage.Name = "txMessage"
        Me.txMessage.Size = New System.Drawing.Size(444, 20)
        Me.txMessage.TabIndex = 15
        Me.txMessage.Text = Global.ipTest.My.MySettings.Default.txMessage
        '
        'txMode
        '
        Me.txMode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ipTest.My.MySettings.Default, "txMode", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txMode.FormattingEnabled = True
        Me.txMode.Items.AddRange(New Object() {"UDP & TCP", "UDP", "TCP"})
        Me.txMode.Location = New System.Drawing.Point(456, 32)
        Me.txMode.Name = "txMode"
        Me.txMode.Size = New System.Drawing.Size(81, 21)
        Me.txMode.TabIndex = 14
        Me.txMode.Text = Global.ipTest.My.MySettings.Default.txMode
        '
        'rxPort
        '
        Me.rxPort.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ipTest.My.MySettings.Default, "rxPort", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.rxPort.Location = New System.Drawing.Point(339, 7)
        Me.rxPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.rxPort.Name = "rxPort"
        Me.rxPort.Size = New System.Drawing.Size(71, 20)
        Me.rxPort.TabIndex = 9
        Me.rxPort.Value = Global.ipTest.My.MySettings.Default.rxPort
        '
        'txAddress
        '
        Me.txAddress.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ipTest.My.MySettings.Default, "txAddress", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txAddress.Location = New System.Drawing.Point(93, 33)
        Me.txAddress.Name = "txAddress"
        Me.txAddress.Size = New System.Drawing.Size(208, 20)
        Me.txAddress.TabIndex = 3
        Me.txAddress.Text = Global.ipTest.My.MySettings.Default.txAddress
        '
        'txPort
        '
        Me.txPort.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ipTest.My.MySettings.Default, "txPort", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txPort.Location = New System.Drawing.Point(339, 33)
        Me.txPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.txPort.Name = "txPort"
        Me.txPort.Size = New System.Drawing.Size(71, 20)
        Me.txPort.TabIndex = 0
        Me.txPort.Value = Global.ipTest.My.MySettings.Default.txPort
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 390)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txMessage)
        Me.Controls.Add(Me.txMode)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.rxAddress)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rxPort)
        Me.Controls.Add(Me.logArea)
        Me.Controls.Add(Me.sendData)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txAddress)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txPort)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "mainForm"
        Me.Text = "ipTest"
        CType(Me.rxPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txPort As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents txAddress As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents sendData As Button
    Friend WithEvents logArea As TextBox
    Friend WithEvents rxPort As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents rxAddress As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txMode As ComboBox
    Friend WithEvents txMessage As TextBox
    Friend WithEvents Label6 As Label
End Class
