<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class tetris
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.timerFall = New System.Windows.Forms.Timer(Me.components)
        Me.picBoxT6 = New System.Windows.Forms.PictureBox()
        Me.picBoxT5 = New System.Windows.Forms.PictureBox()
        Me.picBoxT4 = New System.Windows.Forms.PictureBox()
        Me.picBoxT3 = New System.Windows.Forms.PictureBox()
        Me.picBoxT2 = New System.Windows.Forms.PictureBox()
        Me.picBoxHold = New System.Windows.Forms.PictureBox()
        Me.bgTetrisGrid = New System.Windows.Forms.PictureBox()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.btnQuit = New System.Windows.Forms.PictureBox()
        Me.btnStart = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.picBoxT6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxT5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxT4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxT3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxT2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxHold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgTetrisGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnQuit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'timerFall
        '
        Me.timerFall.Interval = 1000
        '
        'picBoxT6
        '
        Me.picBoxT6.BackColor = System.Drawing.Color.Transparent
        Me.picBoxT6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picBoxT6.Location = New System.Drawing.Point(277, 360)
        Me.picBoxT6.Name = "picBoxT6"
        Me.picBoxT6.Size = New System.Drawing.Size(34, 34)
        Me.picBoxT6.TabIndex = 26
        Me.picBoxT6.TabStop = False
        '
        'picBoxT5
        '
        Me.picBoxT5.BackColor = System.Drawing.Color.Transparent
        Me.picBoxT5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picBoxT5.Location = New System.Drawing.Point(277, 310)
        Me.picBoxT5.Name = "picBoxT5"
        Me.picBoxT5.Size = New System.Drawing.Size(34, 34)
        Me.picBoxT5.TabIndex = 25
        Me.picBoxT5.TabStop = False
        '
        'picBoxT4
        '
        Me.picBoxT4.BackColor = System.Drawing.Color.Transparent
        Me.picBoxT4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picBoxT4.Location = New System.Drawing.Point(277, 265)
        Me.picBoxT4.Name = "picBoxT4"
        Me.picBoxT4.Size = New System.Drawing.Size(34, 34)
        Me.picBoxT4.TabIndex = 24
        Me.picBoxT4.TabStop = False
        '
        'picBoxT3
        '
        Me.picBoxT3.BackColor = System.Drawing.Color.Transparent
        Me.picBoxT3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picBoxT3.Location = New System.Drawing.Point(277, 215)
        Me.picBoxT3.Name = "picBoxT3"
        Me.picBoxT3.Size = New System.Drawing.Size(34, 34)
        Me.picBoxT3.TabIndex = 23
        Me.picBoxT3.TabStop = False
        '
        'picBoxT2
        '
        Me.picBoxT2.BackColor = System.Drawing.Color.Transparent
        Me.picBoxT2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picBoxT2.Location = New System.Drawing.Point(273, 150)
        Me.picBoxT2.Name = "picBoxT2"
        Me.picBoxT2.Size = New System.Drawing.Size(42, 42)
        Me.picBoxT2.TabIndex = 22
        Me.picBoxT2.TabStop = False
        '
        'picBoxHold
        '
        Me.picBoxHold.BackColor = System.Drawing.Color.Transparent
        Me.picBoxHold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picBoxHold.Location = New System.Drawing.Point(38, 149)
        Me.picBoxHold.Name = "picBoxHold"
        Me.picBoxHold.Size = New System.Drawing.Size(42, 43)
        Me.picBoxHold.TabIndex = 21
        Me.picBoxHold.TabStop = False
        Me.picBoxHold.Visible = False
        '
        'bgTetrisGrid
        '
        Me.bgTetrisGrid.BackColor = System.Drawing.Color.Transparent
        Me.bgTetrisGrid.BackgroundImage = Global.summative.My.Resources.Resources.tetrisBG
        Me.bgTetrisGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bgTetrisGrid.Location = New System.Drawing.Point(20, 100)
        Me.bgTetrisGrid.Name = "bgTetrisGrid"
        Me.bgTetrisGrid.Size = New System.Drawing.Size(312, 387)
        Me.bgTetrisGrid.TabIndex = 19
        Me.bgTetrisGrid.TabStop = False
        '
        'lblLevel
        '
        Me.lblLevel.AutoSize = True
        Me.lblLevel.BackColor = System.Drawing.Color.Transparent
        Me.lblLevel.Font = New System.Drawing.Font("Impact", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevel.Location = New System.Drawing.Point(65, 17)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(220, 80)
        Me.lblLevel.TabIndex = 27
        Me.lblLevel.Text = "LEVEL 0"
        '
        'lblLine
        '
        Me.lblLine.AutoSize = True
        Me.lblLine.BackColor = System.Drawing.Color.Transparent
        Me.lblLine.Font = New System.Drawing.Font("Impact", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine.Location = New System.Drawing.Point(75, 502)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(220, 80)
        Me.lblLine.TabIndex = 28
        Me.lblLine.Text = "LEVEL 0"
        '
        'btnQuit
        '
        Me.btnQuit.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnQuit.BackgroundImage = Global.summative.My.Resources.Resources.btnQuit
        Me.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuit.Location = New System.Drawing.Point(110, 298)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(132, 36)
        Me.btnQuit.TabIndex = 29
        Me.btnQuit.TabStop = False
        Me.btnQuit.Visible = False
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnStart.BackgroundImage = Global.summative.My.Resources.Resources.btnStart
        Me.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStart.Location = New System.Drawing.Point(110, 239)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(132, 53)
        Me.btnStart.TabIndex = 30
        Me.btnStart.TabStop = False
        Me.btnStart.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Impact", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(387, 189)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 80)
        Me.Label1.TabIndex = 31
        '
        'tetris
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BackgroundImage = Global.summative.My.Resources.Resources.bgTetris
        Me.ClientSize = New System.Drawing.Size(375, 600)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.lblLine)
        Me.Controls.Add(Me.lblLevel)
        Me.Controls.Add(Me.picBoxT6)
        Me.Controls.Add(Me.picBoxT5)
        Me.Controls.Add(Me.picBoxT4)
        Me.Controls.Add(Me.picBoxT3)
        Me.Controls.Add(Me.picBoxT2)
        Me.Controls.Add(Me.picBoxHold)
        Me.Controls.Add(Me.bgTetrisGrid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "tetris"
        Me.Text = "tetris"
        CType(Me.picBoxT6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxT5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxT4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxT3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxT2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxHold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgTetrisGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnQuit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bgTetrisGrid As PictureBox
    Friend WithEvents timerFall As Timer
    Friend WithEvents picBoxHold As PictureBox
    Friend WithEvents picBoxT2 As PictureBox
    Friend WithEvents picBoxT3 As PictureBox
    Friend WithEvents picBoxT4 As PictureBox
    Friend WithEvents picBoxT5 As PictureBox
    Friend WithEvents picBoxT6 As PictureBox
    Friend WithEvents lblLevel As Label
    Friend WithEvents lblLine As Label
    Friend WithEvents btnQuit As PictureBox
    Friend WithEvents btnStart As PictureBox
    Friend WithEvents Label1 As Label
End Class
