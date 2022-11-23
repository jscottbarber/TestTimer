Public Class Form1
    Declare Function SendMessage Lib "User32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Private propQuestionNum As Integer
    Private propQuestionTotal As Integer
    Private propQuestionsLeft As Integer
    Private propTestTime As Integer  'Total time, in seconds
    Private propTestStatus As TestStatusEnum
    Private propAutoAdvanceQuestion As Boolean 'If True, question is advanced with question timer and next question button, if false, question timer does not advance question

    Dim TestTimeLeft As Long  'Total Time Left, in Seconds
    Dim QuestionTimeLeft As Integer   'Time left for a single question, in seconds
    Dim FinalQuestionTimeSet As Boolean

    Public Enum TestStatusEnum
        Initialized
        FirstQuestion
        NextQuestion
        LastQuestion
        EndTest
    End Enum

    Public Property AutoAdvanceQuestion As Boolean
        Get
            Return propAutoAdvanceQuestion
        End Get
        Set(value As Boolean)
            propAutoAdvanceQuestion = value
        End Set
    End Property

    Public Property TestStatus As TestStatusEnum
        Get
            Return propTestStatus
        End Get
        Set(value As TestStatusEnum)
            propTestStatus = value
        End Set
    End Property

    Public Property QuestionNum As Integer
        Get
            Return propQuestionNum
        End Get
        Set(value As Integer)
            propQuestionNum = value
        End Set
    End Property

    Public Property QuestionTotal As Integer
        Get
            Return propQuestionTotal
        End Get
        Set(value As Integer)
            propQuestionTotal = value
        End Set
    End Property

    Public Property TestTime As Integer
        Get
            Return propTestTime
        End Get
        Set(value As Integer)
            propTestTime = value
        End Set
    End Property

    Public Property QuestionsLeft As Integer
        Get
            Return propQuestionsLeft
        End Get
        Set(value As Integer)
            propQuestionsLeft = value
        End Set
    End Property

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load  'Form Initialization
        Dim InitialQuesitonCount As Integer = 50 '50 Questions
        Dim InitialTestTime As Long = 1320 '1320 seconds (22 minutes)
        AutoAdvanceQuestion = True

        ResetTest(InitialQuesitonCount, InitialTestTime, AutoAdvanceQuestion)
    End Sub

    Friend Sub ResetTest(ByVal QuestionCount As Integer, ByVal TotalTimeSec As Long, ByVal AAQuestion As Boolean)
        If Not Timer1.Enabled Then
            QuestionNum = 1
            QuestionTotal = QuestionCount
            QuestionsLeft = QuestionTotal
            ProgBar.Minimum = 0
            ProgBar.Step = 1
            TestTime = TotalTimeSec
            TestTimeLeft = TestTime  'TestTimeLeft only set here and in Timer1_Tick
            AutoAdvanceQuestion = AAQuestion
            TestStatus = TestStatusEnum.Initialized

            RefreshTestTimer()
            RefreshQuestionCount()
            ResetQuestionTimer()
            RefreshButtonText(TestStatus)
        End If
    End Sub

    Private Sub RefreshButtonText(ByVal TestState As TestStatusEnum)
        btnSubtractQuestion.Enabled = False
        Select Case TestState
            Case TestStatusEnum.Initialized
                btnMain.Text = "Start Test"
                StatusBar.Text = "Status: Test Initialized"
            Case TestStatusEnum.FirstQuestion
                btnMain.Text = "Next Question"
                If QuestionTotal > 1 And QuestionNum > 1 Then
                    btnSubtractQuestion.Enabled = True
                End If
                StatusBar.Text = "Status: First Question"
            Case TestStatusEnum.NextQuestion
                btnMain.Text = "Next Question"
                If QuestionTotal > 1 And QuestionNum > 1 Then
                    btnSubtractQuestion.Enabled = True
                End If
                StatusBar.Text = "Status: " + QuestionsLeft.ToString + " Questions Remaining"
            Case TestStatusEnum.LastQuestion
                btnMain.Text = "End Test/Stop Timer"
                If QuestionTotal > 1 And QuestionNum > 1 Then
                    btnSubtractQuestion.Enabled = True
                End If
                StatusBar.Text = "Status: Final Question"
            Case TestStatusEnum.EndTest
                btnMain.Text = "Reset Timer"
                StatusBar.Text = "Status: Test Completed"
        End Select

        If AutoAdvanceQuestion Then
            StatusAdvance.Text = "Auto Advance: ON"
        Else
            StatusAdvance.Text = "Auto Advance: OFF"
        End If
    End Sub

    Private Sub TestParamsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestParamsToolStripMenuItem.Click
        If Not Timer1.Enabled Then
            Form2.Show()
        End If
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ResetQuestionTimer()
        QuestionTimeLeft = DetermineQuestionTimeLeft() 'Should only get called after a change in question number (not timer)
        RefreshQuestionTimer()
    End Sub

    Private Sub RefreshQuestionTimer()
        Dim tsLeft As TimeSpan

        tsLeft = New TimeSpan(0, 0, QuestionTimeLeft)
        lblQuestionTime.Text = tsLeft.ToString()
        UpdateProgressBar()

    End Sub

    Private Sub UpdateProgressBar()
        ProgBar.Width = lblQuestionTime.Width

        If QuestionTimeLeft >= 0 Then
            If TestStatus = TestStatusEnum.LastQuestion Then
                If Not FinalQuestionTimeSet Then
                    FinalQuestionTimeSet = True
                    ProgBar.Maximum = TestTimeLeft
                End If
            Else
                FinalQuestionTimeSet = False
                ProgBar.Maximum = TestTimeLeft / QuestionsLeft
            End If
            If ProgBar.Maximum >= QuestionTimeLeft Then
                ProgBar.Value = QuestionTimeLeft
                SendMessage(ProgBar.Handle, 1040, 1, 0)  'wparam: 1=green, 2=red, 3=yellow
                lblQuestionTime.BackColor = System.Drawing.SystemColors.HotTrack
            End If
        Else
            ProgBar.Maximum = TestTimeLeft / QuestionsLeft
            ProgBar.Value = ProgBar.Maximum
            SendMessage(ProgBar.Handle, 1040, 2, 0)  'wparam: 1=green, 2=red, 3=yellow
            lblQuestionTime.BackColor = System.Drawing.Color.Red
        End If
    End Sub

    Private Sub RefreshTestTimer()
        Dim tsTotalLeft As TimeSpan

        If TestTimeLeft >= 0 Then
            tsTotalLeft = New TimeSpan(0, 0, TestTimeLeft)
            lblTotalTimeLeft.Text = tsTotalLeft.ToString
        End If
    End Sub

    Private Sub RefreshQuestionCount()
        lblQuestions.Text = CStr(QuestionNum) + " of " + CStr(QuestionTotal)
    End Sub

    Private Function UpdateStatusByQuestionNum() As TestStatusEnum
        ' NOTE: DO NOT add call to DeterminQuestionsLeft() in this function, it will result in a recursive loop
        Dim TS As TestStatusEnum

        If QuestionNum = 1 Then
            If Timer1.Enabled Then
                TS = TestStatusEnum.FirstQuestion
            Else
                TS = TestStatusEnum.Initialized
            End If
        ElseIf QuestionNum = QuestionTotal Then
            If Timer1.Enabled Then
                TS = TestStatusEnum.LastQuestion
            Else
                TS = TestStatusEnum.EndTest
            End If
        Else
            TS = TestStatusEnum.NextQuestion
        End If

        Return TS
    End Function

    Private Sub AdvanceQuestionNum()
        If QuestionNum < QuestionTotal Then
            QuestionNum += 1
            QuestionsLeft = DetermineQuestionsLeft()
            RefreshQuestionCount()
        End If
        TestStatus = UpdateStatusByQuestionNum()
    End Sub

    Private Sub ReduceQuestionNum()
        If QuestionNum > 1 Then
            QuestionNum -= 1
            QuestionsLeft = DetermineQuestionsLeft()
            RefreshQuestionCount()
        End If
        TestStatus = UpdateStatusByQuestionNum()
    End Sub

    Private Function DetermineQuestionTimeLeft() As Integer
        Dim QTL As Integer

        QTL = 0
        If QuestionsLeft > 0 And TestTimeLeft > 0 Then
            QTL = TestTimeLeft / QuestionsLeft
        End If

        Return QTL
    End Function

    Private Sub StopTimerAndEndTest()
        Timer1.Stop()
        TestStatus = TestStatusEnum.EndTest
        RefreshButtonText(TestStatus)
        RefreshQuestionCount()
        ResetQuestionTimer()
    End Sub

    Private Function DetermineQuestionsLeft() As Integer
        Dim QL As Integer

        TestStatus = UpdateStatusByQuestionNum()  'Just in case the TestStatus is not up to date

        If TestStatus = TestStatusEnum.EndTest Then 'Need to account for TestStatus because QuestionNum = QuestionTotal even after the test is complete (timer is disabled)
            QL = 0
        Else
            QL = (QuestionTotal + 1) - QuestionNum
        End If
        If QL < 0 Then
            MsgBox("Error: Current Question Number cannot be greater than Question Total", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Fatal Error")
            StopTimerAndEndTest()
            QL = 0
        End If

        Return QL
    End Function

    Public Sub ReduceQuestionTime()
        QuestionTimeLeft -= 1
        If AutoAdvanceQuestion Then
            If QuestionTimeLeft < 0 Then
                MsgBox("Question Time Remaining Should Not Be Less Than Zero", vbOKOnly + vbCritical, "Logic Error")
                RefreshQuestionTimer()
            ElseIf QuestionTimeLeft = 0 Then
                AdvanceQuestionNum()  'This also updates Status
                ResetQuestionTimer()
            Else    'QuestionTimeLeft > 0
                If TestStatus = TestStatusEnum.LastQuestion Then
                    ResetQuestionTimer()
                Else
                    RefreshQuestionTimer()
                End If
            End If
        Else
            If QuestionTimeLeft < 0 Then
                RefreshQuestionTimer()
            ElseIf QuestionTimeLeft = 0 Then
                RefreshQuestionTimer()
            Else    'QuestionTimeLeft > 0
                RefreshQuestionTimer()
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        QuestionsLeft = DetermineQuestionsLeft()
        If QuestionsLeft > 0 And TestTimeLeft > 0 Then
            TestTimeLeft -= 1
            RefreshTestTimer()
            ReduceQuestionTime()
        Else
            StopTimerAndEndTest()
        End If

        RefreshButtonText(TestStatus)
        RefreshQuestionTimer()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMain.Click
        'UpdateStatusByEvent(TestStatus)
        Select Case TestStatus
            Case TestStatusEnum.Initialized
                TestStatus = TestStatusEnum.FirstQuestion
                Timer1.Start()
            Case TestStatusEnum.LastQuestion
                Timer1.Stop()
                TestStatus = TestStatusEnum.EndTest
            Case TestStatusEnum.EndTest
                ResetTest(QuestionTotal, TestTime, AutoAdvanceQuestion)
                Exit Sub
            Case Else  'FirstQuestion and NextQuestion
                If QuestionNum < QuestionTotal Then
                    AdvanceQuestionNum()  'This also updates the status
                End If
        End Select
        RefreshButtonText(TestStatus)
        ResetQuestionTimer()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSubtractQuestion.Click
        If QuestionNum > 1 Then
            ReduceQuestionNum() 'This also updates the status
            RefreshButtonText(TestStatus)
            ResetQuestionTimer()
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim x, y As Integer

        x = (Me.Width - lblQuestionTime.Width) / 2
        y = lblQuestionTime.Top
        lblQuestionTime.Location = New Point(x, y)

        ProgBar.Width = lblQuestionTime.Width
        x = (Me.Width - ProgBar.Width) / 2
        y = ProgBar.Top
        ProgBar.Location = New Point(x, y)
    End Sub

    Private Sub ResetTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetTestToolStripMenuItem.Click
        Dim Response As MsgBoxResult

        If Timer1.Enabled Then
            Response = MsgBox("Cancel this test timer?", vbYesNo + vbQuestion, "Confirm Cancel")
            If Response = MsgBoxResult.Yes Then
                Timer1.Stop()
                ResetTest(QuestionTotal, TestTime, AutoAdvanceQuestion)
            End If
        Else
            MsgBox("Sorry, There is no active timer to reset.", vbOKOnly + vbInformation, "Reset Error")
        End If

    End Sub
End Class
