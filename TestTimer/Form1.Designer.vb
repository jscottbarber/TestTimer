<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnMain = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestParamsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblQuestionTime = New System.Windows.Forms.Label()
        Me.lblQuestions = New System.Windows.Forms.Label()
        Me.btnSubtractQuestion = New System.Windows.Forms.Button()
        Me.lblTotalTimeLeft = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgBar = New System.Windows.Forms.ProgressBar()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusBar = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusAdvance = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnMain
        '
        Me.btnMain.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnMain.Location = New System.Drawing.Point(146, 346)
        Me.btnMain.Name = "btnMain"
        Me.btnMain.Size = New System.Drawing.Size(624, 154)
        Me.btnMain.TabIndex = 0
        Me.btnMain.Text = "Start Test"
        Me.btnMain.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.TestParamsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 40)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(71, 36)
        Me.FileToolStripMenuItem.Text = "Exit"
        '
        'TestParamsToolStripMenuItem
        '
        Me.TestParamsToolStripMenuItem.Name = "TestParamsToolStripMenuItem"
        Me.TestParamsToolStripMenuItem.Size = New System.Drawing.Size(200, 36)
        Me.TestParamsToolStripMenuItem.Text = "Test Parameters"
        '
        'lblQuestionTime
        '
        Me.lblQuestionTime.AutoSize = True
        Me.lblQuestionTime.BackColor = System.Drawing.SystemColors.HotTrack
        Me.lblQuestionTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblQuestionTime.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblQuestionTime.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblQuestionTime.Location = New System.Drawing.Point(24, 40)
        Me.lblQuestionTime.Name = "lblQuestionTime"
        Me.lblQuestionTime.Size = New System.Drawing.Size(595, 172)
        Me.lblQuestionTime.TabIndex = 2
        Me.lblQuestionTime.Text = "-00:00:26"
        Me.lblQuestionTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQuestions
        '
        Me.lblQuestions.AutoSize = True
        Me.lblQuestions.BackColor = System.Drawing.SystemColors.Info
        Me.lblQuestions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblQuestions.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblQuestions.Location = New System.Drawing.Point(162, 287)
        Me.lblQuestions.Name = "lblQuestions"
        Me.lblQuestions.Size = New System.Drawing.Size(120, 47)
        Me.lblQuestions.TabIndex = 3
        Me.lblQuestions.Text = "1 of 50"
        '
        'btnSubtractQuestion
        '
        Me.btnSubtractQuestion.Font = New System.Drawing.Font("Segoe UI", 7.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnSubtractQuestion.Location = New System.Drawing.Point(24, 346)
        Me.btnSubtractQuestion.Name = "btnSubtractQuestion"
        Me.btnSubtractQuestion.Size = New System.Drawing.Size(116, 154)
        Me.btnSubtractQuestion.TabIndex = 4
        Me.btnSubtractQuestion.Text = "Previous Question"
        Me.btnSubtractQuestion.UseVisualStyleBackColor = True
        '
        'lblTotalTimeLeft
        '
        Me.lblTotalTimeLeft.AutoSize = True
        Me.lblTotalTimeLeft.BackColor = System.Drawing.SystemColors.Info
        Me.lblTotalTimeLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalTimeLeft.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblTotalTimeLeft.Location = New System.Drawing.Point(612, 287)
        Me.lblTotalTimeLeft.Name = "lblTotalTimeLeft"
        Me.lblTotalTimeLeft.Size = New System.Drawing.Size(138, 47)
        Me.lblTotalTimeLeft.TabIndex = 6
        Me.lblTotalTimeLeft.Text = "00:22:00"
        Me.lblTotalTimeLeft.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(414, 297)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 32)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Remaining Time:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 297)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 32)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Question:"
        '
        'ProgBar
        '
        Me.ProgBar.Location = New System.Drawing.Point(24, 226)
        Me.ProgBar.Name = "ProgBar"
        Me.ProgBar.Size = New System.Drawing.Size(595, 46)
        Me.ProgBar.TabIndex = 9
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusBar, Me.ToolStripStatusLabel1, Me.StatusAdvance})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 518)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 42)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusBar
        '
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(112, 32)
        Me.StatusBar.Text = "StatusBar"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(448, 32)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'StatusAdvance
        '
        Me.StatusAdvance.Name = "StatusAdvance"
        Me.StatusAdvance.Size = New System.Drawing.Size(163, 32)
        Me.StatusAdvance.Text = "Auto Advance"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 560)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ProgBar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTotalTimeLeft)
        Me.Controls.Add(Me.btnSubtractQuestion)
        Me.Controls.Add(Me.lblQuestions)
        Me.Controls.Add(Me.lblQuestionTime)
        Me.Controls.Add(Me.btnMain)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Test Timer"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnMain As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestParamsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblQuestionTime As Label
    Friend WithEvents lblQuestions As Label
    Friend WithEvents btnSubtractQuestion As Button
    Friend WithEvents lblTotalTimeLeft As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ProgBar As ProgressBar
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents StatusBar As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents StatusAdvance As ToolStripStatusLabel
End Class
