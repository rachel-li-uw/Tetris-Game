<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class splashScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.picLOGO = New System.Windows.Forms.PictureBox()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.timerSplashScreen = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picLOGO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picLOGO
        '
        Me.picLOGO.BackColor = System.Drawing.Color.Transparent
        Me.picLOGO.Image = Global.summative.My.Resources.Resources.logo
        Me.picLOGO.Location = New System.Drawing.Point(31, 28)
        Me.picLOGO.Name = "picLOGO"
        Me.picLOGO.Size = New System.Drawing.Size(136, 119)
        Me.picLOGO.TabIndex = 0
        Me.picLOGO.TabStop = False
        '
        'ProgressBar
        '
        Me.ProgressBar.BackColor = System.Drawing.Color.White
        Me.ProgressBar.Location = New System.Drawing.Point(50, 153)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar.TabIndex = 1
        '
        'timerSplashScreen
        '
        Me.timerSplashScreen.Enabled = True
        '
        'splashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.summative.My.Resources.Resources.bgTetris
        Me.ClientSize = New System.Drawing.Size(200, 200)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.picLOGO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "splashScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "splashScreen"
        CType(Me.picLOGO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picLOGO As PictureBox
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents timerSplashScreen As Timer
End Class
