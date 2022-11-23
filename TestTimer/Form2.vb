Public Class Form2
    Private DelayTextChangeEvent As Boolean = True
    Private propQuestionQty As Integer
    Private propTotalTime As Integer  'Total time in Seconds
    Private propAutoAdvanceQuestion As Boolean

    Public Property AutoAdvanceQuestion As Boolean
        Get
            Return propAutoAdvanceQuestion
        End Get
        Set(value As Boolean)
            propAutoAdvanceQuestion = value
        End Set
    End Property

    Public Property QuestionQty As Integer
        Get
            Return propQuestionQty
        End Get
        Set(value As Integer)
            propQuestionQty = value
        End Set
    End Property

    Public Property TotalTime As Integer
        Get
            Return propTotalTime
        End Get
        Set(value As Integer)
            propTotalTime = value
        End Set
    End Property

    Private Sub RefreshForm()
        txtQuestionQty.Text = QuestionQty
        txtTotalTime.Text = TotalTime / 60
        txtInterval.Text = TotalTime / QuestionQty
        chkAutoAdvance.Checked = AutoAdvanceQuestion
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        QuestionQty = Form1.QuestionTotal
        TotalTime = Form1.TestTime
        AutoAdvanceQuestion = Form1.AutoAdvanceQuestion
        RefreshForm()
        DelayTextChangeEvent = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Form1.ResetTest(CInt(txtQuestionQty.Text), (CInt(txtTotalTime.Text) * 60), chkAutoAdvance.Checked)
        Me.Close()
    End Sub

    Private Sub txtQuestionQty_TextChanged(sender As Object, e As EventArgs) Handles txtQuestionQty.TextChanged
        If Not DelayTextChangeEvent Then
            txtInterval.Text = CStr(CInt(txtTotalTime.Text) * 60 / CInt(txtQuestionQty.Text))
        End If
    End Sub

    Private Sub txtTotalTime_TextChanged(sender As Object, e As EventArgs) Handles txtTotalTime.TextChanged
        If Not DelayTextChangeEvent Then
            txtInterval.Text = CStr(CInt(txtTotalTime.Text) * 60 / CInt(txtQuestionQty.Text))
        End If
    End Sub
End Class