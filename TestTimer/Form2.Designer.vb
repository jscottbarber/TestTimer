<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtQuestionQty = New System.Windows.Forms.TextBox()
        Me.txtTotalTime = New System.Windows.Forms.TextBox()
        Me.txtInterval = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkAutoAdvance = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(327, 45)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Number of Questions"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(82, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(257, 45)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total Time (min.)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtQuestionQty
        '
        Me.txtQuestionQty.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtQuestionQty.Location = New System.Drawing.Point(345, 18)
        Me.txtQuestionQty.Name = "txtQuestionQty"
        Me.txtQuestionQty.Size = New System.Drawing.Size(200, 50)
        Me.txtQuestionQty.TabIndex = 2
        Me.txtQuestionQty.Text = "50"
        Me.txtQuestionQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalTime
        '
        Me.txtTotalTime.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtTotalTime.Location = New System.Drawing.Point(345, 81)
        Me.txtTotalTime.Name = "txtTotalTime"
        Me.txtTotalTime.Size = New System.Drawing.Size(200, 50)
        Me.txtTotalTime.TabIndex = 3
        Me.txtTotalTime.Text = "22"
        Me.txtTotalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtInterval
        '
        Me.txtInterval.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtInterval.Location = New System.Drawing.Point(345, 148)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.ReadOnly = True
        Me.txtInterval.Size = New System.Drawing.Size(200, 50)
        Me.txtInterval.TabIndex = 4
        Me.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(26, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(313, 45)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Time/Question (sec.)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(98, 308)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(150, 46)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(345, 308)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(150, 46)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(12, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(371, 45)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Auto Advance Questions"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkAutoAdvance
        '
        Me.chkAutoAdvance.AutoSize = True
        Me.chkAutoAdvance.Location = New System.Drawing.Point(419, 233)
        Me.chkAutoAdvance.Name = "chkAutoAdvance"
        Me.chkAutoAdvance.Size = New System.Drawing.Size(28, 27)
        Me.chkAutoAdvance.TabIndex = 9
        Me.chkAutoAdvance.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 388)
        Me.Controls.Add(Me.chkAutoAdvance)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtInterval)
        Me.Controls.Add(Me.txtTotalTime)
        Me.Controls.Add(Me.txtQuestionQty)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Test Parameters"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtQuestionQty As TextBox
    Friend WithEvents txtTotalTime As TextBox
    Friend WithEvents txtInterval As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents chkAutoAdvance As CheckBox
End Class
