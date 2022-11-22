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
        Dim InitialQuesitonCount As Integer = 12 '50 Questions
        Dim InitialTestTime As Long = 60 '1320 seconds (22 minutes)
        AutoAdvanceQuestion = True

        ResetTest(InitialQuesitonCount, InitialTestTime)
    End Sub

    Friend Sub ResetTest(ByVal QuestionCount As Integer, ByVal TotalTimeSec As Long)
        If Not Timer1.Enabled Then
            QuestionNum = 1
            QuestionTotal = QuestionCount
            QuestionsLeft = QuestionTotal
            ProgBar.Minimum = 0
            ProgBar.Step = 1
            TestTime = TotalTimeSec
            TestTimeLeft = TestTime  'TestTimeLeft only set here and in Timer1_Tick
            TestStatus = TestStatusEnum.Initialized

            RefreshTestTimer()
            RefreshQuestionCount()
            'DetermineQuestionTimeLeft() 'Now done in RefreshQuestionTimer
            ResetQuestionTimer()
            RefreshButtonText(TestStatus)
        End If
    End Sub

    Private Sub RefreshButtonText(ByVal TestState As TestStatusEnum)
        btnSubtractQuestion.Enabled = False
        Select Case TestState
            Case TestStatusEnum.Initialized
                btnMain.Text = "Start Test"
            Case TestStatusEnum.FirstQuestion
                btnMain.Text = "Next Question"
                If QuestionTotal > 1 And QuestionNum > 1 Then
                    btnSubtractQuestion.Enabled = True
                End If
            Case TestStatusEnum.NextQuestion
                btnMain.Text = "Next Question"
                If QuestionTotal > 1 And QuestionNum > 1 Then
                    btnSubtractQuestion.Enabled = True
                End If
            Case TestStatusEnum.LastQuestion
                btnMain.Text = "End Test/Stop Timer"
                If QuestionTotal > 1 And QuestionNum > 1 Then
                    btnSubtractQuestion.Enabled = True
                End If
            Case TestStatusEnum.EndTest
                btnMain.Text = "Reset Timer"
        End Select
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

        If AutoAdvanceQuestion Then

            If QuestionsLeft > 0 Then
                'This should be TotalTimeLeft / QuestionsLeft
                tsLeft = New TimeSpan(0, 0, QuestionTimeLeft)
                lblQuestionTime.Text = tsLeft.ToString()
            End If
        Else
            If QuestionsLeft > 0 Then
                tsLeft = New TimeSpan(0, 0, QuestionTimeLeft)
                lblQuestionTime.Text = tsLeft.ToString()
                If QuestionTimeLeft >= 0 Then
                    'ProgBar.Maximum = TestTimeLeft / QuestionsLeft
                    'If ProgBar.Maximum >= QuestionTimeLeft Then
                    '    ProgBar.Value = QuestionTimeLeft
                    '    SendMessage(ProgBar.Handle, 1040, 1, 0)  'wParam: 1=Green, 2=Red, 3=Yellow
                    'End If
                Else
                    'ProgBar.Maximum = TestTimeLeft / QuestionsLeft
                    'ProgBar.Value = ProgBar.Maximum
                    'SendMessage(ProgBar.Handle, 1040, 2, 0)  'wParam: 1=Green, 2=Red, 3=Yellow
                End If
            End If
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
        'QuestionsLeft = (QuestionTotal + 1) - QuestionNum  'Add one to total because when QuestionTotal = QuestionNum, they are working on the final question
        'RefreshQuestionTimer()
        'If QuestionsLeft > 0 And TestTimeLeft > 0 Then
        'QuestionsLeft = QuestionsLeft - 1  'Adjust QuestionsLeft
        'QuestionTimeLeft = TestTimeLeft / QuestionsLeft
        'RefreshQuestionTimer()
        'Else
        'Timer1.Stop()
        'End If
    End Sub

    Private Sub AdvanceQuestionNum()
        If QuestionNum < QuestionTotal Then
            QuestionNum += 1
            QuestionsLeft = DetermineQuestionsLeft()
            RefreshQuestionCount()
        End If
    End Sub

    Private Sub ReduceQuestionNum()
        If QuestionNum > 1 Then
            QuestionNum -= 1
            QuestionsLeft = DetermineQuestionsLeft()
            RefreshQuestionCount()
        End If
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
        UpdateStatusByEvent(TestStatusEnum.LastQuestion) 'Ends Test and stops timer
    End Sub

    Private Function DetermineQuestionsLeft() As Integer
        Dim QL As Integer

        If TestStatus = TestStatusEnum.EndTest Then
            QL = 0
        Else
            QL = (QuestionTotal + 1) - QuestionNum
        End If
        If QL < 0 Then
            MsgBox("Error: Current Question Number cannot be greater than Question Total", MsgBoxStyle.Critical And MsgBoxStyle.OkOnly, "Fatal Error")
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
                AdvanceQuestionNum()
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
            'QuestionTimeLeft -= 1
            'RefreshQuestionTimer()
            ReduceQuestionTime()
        Else
            StopTimerAndEndTest()
        End If
        RefreshButtonText(TestStatus)

        'If TestStatus = TestStatusEnum.FirstQuestion Then
        'ElseIf TestStatus = TestStatusEnum.NextQuestion Then
        'ElseIf TestStatus = TestStatusEnum.LastQuestion Then
        'End If

        'If TestTimeLeft >= 0 Then
        '    If QuestionTimeLeft > 1 Then
        '        QuestionTimeLeft -= 1
        '        RefreshQuestionTimer()
        '    Else
        '        Timer1.Stop()  'temporarily stop the timer to refresh ui
        '        If QuestionTotal > QuestionNum Then
        '            QuestionNum += 1
        '            RefreshQuestionCount()
        '            Timer1.Start()
        '        Else
        '            QuestionTimeLeft = 0
        '        End If
        '        RefreshQuestionTimer()
        '    End If
        '    TestTimeLeft -= 1
        '    RefreshTestTimer()
        'Else
        '    Timer1.Stop()
        'End If
    End Sub

    Private Sub UpdateStatusByEvent(CurrentTestState As TestStatusEnum)
        ' Uses the current status to determine what status should be set next when the main button is clicked
        Dim NewTestState As TestStatusEnum = TestStatusEnum.Initialized

        Select Case CurrentTestState  'Initial Status when function is called
            Case TestStatusEnum.Initialized 'User Starting the test
                Timer1.Start()
                If QuestionNum = QuestionTotal Then
                    NewTestState = TestStatusEnum.LastQuestion
                Else
                    QuestionNum = 1
                    NewTestState = TestStatusEnum.FirstQuestion
                End If
            Case TestStatusEnum.FirstQuestion
                If QuestionNum = QuestionTotal Then
                    NewTestState = TestStatusEnum.LastQuestion
                Else
                    QuestionNum += 1
                    If QuestionNum = QuestionTotal Then
                        NewTestState = TestStatusEnum.LastQuestion
                    Else
                        NewTestState = TestStatusEnum.NextQuestion
                    End If
                End If
            Case TestStatusEnum.NextQuestion
                If QuestionNum = QuestionTotal Then
                    NewTestState = TestStatusEnum.LastQuestion
                Else
                    QuestionNum += 1
                    If QuestionNum = QuestionTotal Then
                        NewTestState = TestStatusEnum.LastQuestion
                    Else
                        NewTestState = TestStatusEnum.NextQuestion
                    End If
                End If
            Case TestStatusEnum.LastQuestion
                Timer1.Stop()
                NewTestState = TestStatusEnum.EndTest
            Case TestStatusEnum.EndTest
                ResetTest(QuestionTotal, TestTime)
                Exit Sub
        End Select
        TestStatus = NewTestState
        RefreshButtonText(TestStatus)
        RefreshQuestionCount()
        ResetQuestionTimer()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMain.Click
        UpdateStatusByEvent(TestStatus)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSubtractQuestion.Click
        If QuestionNum > 1 Then
            ReduceQuestionNum()
            If QuestionNum = 1 Then
                TestStatus = TestStatusEnum.FirstQuestion
            ElseIf QuestionNum = QuestionTotal Then
                TestStatus = TestStatusEnum.LastQuestion
            Else
                TestStatus = TestStatusEnum.NextQuestion
            End If
            RefreshButtonText(TestStatus)
            ResetQuestionTimer()
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim x, y As Integer

        x = (Me.Width - lblQuestionTime.Width) / 2
        y = lblQuestionTime.Top
        lblQuestionTime.Location = New Point(x, y)

        x = (Me.Width - ProgBar.Width) / 2
        y = ProgBar.Top
        ProgBar.Location = New Point(x, y)
    End Sub
End Class
