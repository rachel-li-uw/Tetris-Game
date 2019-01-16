Public Class tetris

    ' this is a simple tetris game simulated by the change of colors (backgroundimage) of the 200 blocks on a grid dependent on user choices and a timer
    ' built by Rachel Li for ICS 2O

    Dim grid(9, 19) As PictureBox ' the 10 by 20 grid
    Dim lastTop(1), lastBottom(1), lastLeft(1), lastRight(1) As Integer ' the last  4 locations (the X value and Y value) of the 4 blocks that constitue a tetromino
    Dim tTop(1), tBottom(1), tLeft(1), tRight(1) As Integer  ' the 4 locations (the X value and Y value) of the 4 blocks that constitue a tetromino
    Dim fallTop(1), fallBottom(1), fallLeft(1), fallRight(1) As Integer
    Dim t, tHold, r As Integer ' the type of tetromino atm, the type stored, the rotation it is in 
    Dim t2, t3, t4, t5, t6 ' the next 5 types of tetrominos
    Dim lines, level As Integer ' the user's scores
    Dim ResourceFilePathPrefix As String

    Private Sub tetris_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Randomize()

        createNewGrid()

        ' the start and quit buttons are shown
        btnStart.Visible = True
        btnQuit.Visible = True
        lblLevel.Left = (375 - lblLevel.Width) / 2
        lblLine.Left = (375 - lblLine.Width) / 2

        If System.Diagnostics.Debugger.IsAttached() Then
            ResourceFilePathPrefix = System.IO.Path.GetFullPath(Application.StartupPath & "\..\..\resources\")
        Else
            ResourceFilePathPrefix = Application.StartupPath & "\resources\"
        End If


    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        ' all values are cleared
        For i = 0 To 9
            For j = 0 To 19
                grid(i, j).Visible = False
                grid(i, j).AccessibleDescription = Nothing
            Next
        Next
        lines = 0
        level = 0
        tHold = 0
        picBoxHold.Visible = False
        r = 1

        ' the first 6 tetrominos are randomly generated
        createNewT(t)
        createNewT(t2)
        createNewT(t3)
        createNewT(t4)
        createNewT(t5)
        createNewT(t6)
        placeT(t, tTop, tBottom, tLeft, tRight)

        ' the previews are changed
        changePreview()

        ' the grid colors are changed
        gridChange()

        ' the timer that controls the fall of the tetrominos starts
        timerFall.Enabled = True

        btnStart.Visible = False
        btnQuit.Visible = False

        Dim bgMusic As String
        bgMusic = ResourceFilePathPrefix & "tetrisMusic.wav"
        My.Computer.Audio.Play(bgMusic, AudioPlayMode.BackgroundLoop)

    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub btnStart_MouseHover(sender As Object, e As EventArgs) Handles btnStart.MouseHover
        btnStart.Height *= 1.15
        btnStart.Width *= 1.15
        btnStart.Left = (375 - btnStart.Width) / 2 - 10
    End Sub

    Private Sub btnStart_MouseLeave(sender As Object, e As EventArgs) Handles btnStart.MouseLeave
        btnStart.Height /= 1.15
        btnStart.Width /= 1.15
        btnStart.Left = (375 - btnStart.Width) / 2 - 10
    End Sub

    Private Sub btnQuit_MouseHover(sender As Object, e As EventArgs) Handles btnQuit.MouseHover
        btnQuit.Height *= 1.15
        btnQuit.Width *= 1.15
        btnQuit.Left = (375 - btnQuit.Width) / 2 - 10
    End Sub

    Private Sub btnQuit_MouseLeave(sender As Object, e As EventArgs) Handles btnQuit.MouseLeave
        btnQuit.Height /= 1.15
        btnQuit.Width /= 1.15
        btnQuit.Left = (375 - btnQuit.Width) / 2 - 10
    End Sub

    Private Sub tetris_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Up Then

            ' if the tetromino will not interfere with other pieces / the boundary, it will rotate
            ' all the rotation values are based on the pic "tetris rotation" (included in the resources)
            If canRotate(t, r, tTop, tBottom, tLeft, tRight) = True Then
                rotateT()
            End If

        ElseIf e.KeyCode = Keys.Down Then

            ' if the tetromino is not at the bottom  or intefering with other pieces, it will move down one block
            If (canMoveDown(tTop, tBottom, tLeft, tRight)) Then
                tTop(1) += 1
                tBottom(1) += 1
                tLeft(1) += 1
                tRight(1) += 1
            End If

        ElseIf e.KeyCode = Keys.Left Then

            ' if the tetromino is in bound and not interfering, it will move left one blcok
            If (canMoveLeft(tTop, tBottom, tLeft, tRight)) Then
                tTop(0) -= 1
                tBottom(0) -= 1
                tLeft(0) -= 1
                tRight(0) -= 1
            End If

        ElseIf e.KeyCode = Keys.Right Then

            ' if the tetromino is in bound and not interfering, it will move right one block
            If (canMoveRight(tTop, tBottom, tLeft, tRight)) Then
                tTop(0) += 1
                tBottom(0) += 1
                tLeft(0) += 1
                tRight(0) += 1
            End If

        ElseIf e.KeyCode = Keys.Space Then

            ' directly moves the piece to the bottom
            Do While canMoveDown(tTop, tBottom, tLeft, tRight)
                tTop(1) += 1
                tBottom(1) += 1
                tLeft(1) += 1
                tRight(1) += 1
            Loop
            ' ****** note: it is not locked to the bottom, further movement is possible

        ElseIf e.KeyCode = Keys.ShiftKey Then

            ' the current tetromino will be put "on hold"
            If tHold = 0 Then
                ' if the hold slot is empty, the next one will appear
                tHold = t
                t = t2
                t2 = t3
                t3 = t4
                t4 = t5
                t5 = t6
                createNewT(t6)
                changePreview()
            Else
                ' if the hold slot is not empty, the tetromino in the hold slot will appear, while the current tetromino will be in the hold slot
                Dim holder As Integer
                holder = tHold
                tHold = t
                t = holder
                r = 1
            End If

            ' the picture box shows the held tetromino accordingly
            picBoxHold.Visible = True
            Select Case tHold
                Case 1
                    picBoxHold.BackgroundImage = My.Resources.Resources.wholeT1
                Case 2
                    picBoxHold.BackgroundImage = My.Resources.Resources.wholeT2
                Case 3
                    picBoxHold.BackgroundImage = My.Resources.Resources.wholeT3
                Case 4
                    picBoxHold.BackgroundImage = My.Resources.Resources.wholeT4
                Case 5
                    picBoxHold.BackgroundImage = My.Resources.Resources.wholeT5
                Case 6
                    picBoxHold.BackgroundImage = My.Resources.Resources.wholeT6
                Case Else
                    picBoxHold.BackgroundImage = My.Resources.Resources.wholeT7
            End Select

            ' the tetromino locations re-start at the top
            placeT(t, tTop, tBottom, tLeft, tRight)

        End If

        ' the grid changes for all the changes
        gridChange()

    End Sub

    Private Sub timerFall_Tick(sender As Object, e As EventArgs) Handles timerFall.Tick

        If (canMoveDown(tTop, tBottom, tLeft, tRight)) Then

            ' if the tetromino can move down, it will at every tick
            tTop(1) += 1
            tBottom(1) += 1
            tLeft(1) += 1
            tRight(1) += 1

        Else

            ' if the tetromino cannot move down, it is at the bottom...

            ' if it cannot move and it is at the top, it is a loss
            If tTop(1) = 0 Then
                timerFall.Enabled = False
                MsgBox("YOU LOSE!" & vbCrLf & "YOU HAVE REACHED LEVEL " & level & " AND CLEARED " & lines & " LINES!")
                btnStart.Visible = True
                btnQuit.Visible = True

                Dim bgMusic As String
                bgMusic = ResourceFilePathPrefix & "tetrisMusic.wav"
                My.Computer.Audio.Stop()
            End If

            ' the tetromino become part of the non-cleared blocks, identified with an accessibledescription of "t"
            grid(tTop(0), tTop(1)).AccessibleDescription = "t"
            grid(tBottom(0), tBottom(1)).AccessibleDescription = "t"
            grid(tLeft(0), tLeft(1)).AccessibleDescription = "t"
            grid(tRight(0), tRight(1)).AccessibleDescription = "t"


            Dim fullLine(3) As Integer

            ' at the bottom, there is a chance that one of the 4 blocks of the tetromino may be causing a full line

            ' if the block is causing a full line (and not already recorded because its value is identical to another line), the Y value is recorded, else, 0 is recorded
            If isFullLine(tTop) Then
                fullLine(0) = tTop(1)
                lines += 1
            Else
                fullLine(0) = 0
            End If
            If isFullLine(tBottom) And tBottom(1) <> tTop(1) Then
                fullLine(1) = tBottom(1)
                lines += 1
            Else
                fullLine(1) = 0
            End If
            If isFullLine(tLeft) And tLeft(1) <> tTop(1) And tLeft(1) <> tBottom(1) Then
                fullLine(2) = tLeft(1)
                lines += 1
            Else
                fullLine(2) = 0
            End If
            If isFullLine(tRight) And tRight(1) <> tTop(1) And tRight(1) <> tBottom(1) And tRight(1) <> tLeft(1) Then
                fullLine(3) = tRight(1)
                lines += 1
            Else
                fullLine(3) = 0
            End If

            ' every line that is cleared will add one to the "lines" variable and presented to the user through the label
            lblLine.Text = "LINES" & Space(1) & lines
            lblLine.Left = (375 - lblLine.Width) / 2


            ' depending on the number of lines the user has cleared, the level and falling speed will alter
            If lines >= 2000 Then
                level = 10
                timerFall.Interval = 5
            ElseIf lines >= 1000 Then
                level = 9
                timerFall.Interval = 10
            ElseIf lines >= 500 Then
                level = 8
                timerFall.Interval = 20
            ElseIf lines >= 200 Then
                level = 7
                timerFall.Interval = 50
            ElseIf lines >= 150 Then
                level = 6
                timerFall.Interval = 100
            ElseIf lines >= 100 Then
                level = 5
                timerFall.Interval = 150
            ElseIf lines >= 50 Then
                level = 4
                timerFall.Interval = 200
            ElseIf lines >= 30 Then
                timerFall.Interval = 350
                level = 3
                timerFall.Interval = 500
            ElseIf lines >= 15 Then
                level = 2
                timerFall.Interval = 650
            ElseIf lines > 5 Then
                level = 1
                timerFall.Interval = 800
            Else
                level = 0
                timerFall.Interval = 1000
            End If

            ' the level is dependent on the number of cleared lines and shown to the user through another label
            lblLevel.Text = "LEVEL" & Space(1) & level
            lblLevel.Left = (375 - lblLevel.Width) / 2

            ' the full lines are recorded in ascending order and cleared from top to bottom (due to the method of clearing lines)
            Array.Sort(fullLine)
            clearLine(fullLine(0))
            clearLine(fullLine(1))
            clearLine(fullLine(2))
            clearLine(fullLine(3))

            ' the last locations will be cleared, this will ensure the tetromino can stay at the bottom
            lastTop = {0, 0}
            lastBottom = {0, 0}
            lastLeft = {0, 0}
            lastRight = {0, 0}

            ' as the tetromino has reached the bottom, the next ones appear and a new one is generated
            t = t2
            t2 = t3
            t3 = t4
            t4 = t5
            t5 = t6
            createNewT(t6)
            changePreview()

            ' the new locations are set as a new tetromino is generated
            placeT(t, tTop, tBottom, tLeft, tRight)

        End If

        ' the grid changes since there are changes in the locations
        gridChange()

    End Sub

    Sub createNewGrid()

        ' a 10 by 20 grid is created
        Dim i As Integer
        For x = 95 To 240.8 Step 16.2
            Dim j = 0
            For y = 129 To 436.8 Step 16.2
                grid(i, j) = New PictureBox
                grid(i, j).Left = x
                grid(i, j).Top = y

                grid(i, j).Width = 15
                grid(i, j).Height = 15
                grid(i, j).AccessibleDescription = Nothing
                grid(i, j).BackgroundImageLayout = ImageLayout.Stretch
                grid(i, j).Visible = False

                Me.Controls.Add(grid(i, j))
                j += 1
            Next
            i += 1
        Next

        ' the picBox is sent to back (or it would block the grid)
        bgTetrisGrid.SendToBack()

    End Sub

    Sub createNewT(ByRef t As Integer)
        ' a random number between 1 and 7 is generated and rotation is set back to 1
        t = Rnd() * 7 + 0.5
        r = 1
    End Sub

    Sub placeT(ByRef t As Integer, ByRef tTop() As Integer, ByRef tBottom() As Integer, ByRef tLeft() As Integer, ByRef tRight() As Integer)

        ' depending on which tetromino is generated, different locations are created to simulate different shapes
        Select Case t
            Case 1
                tTop = {4, 0}
                tBottom = {5, 0}
                tLeft = {3, 0}
                tRight = {6, 0}
                ' - - - -
            Case 2
                tTop = {3, 0}
                tBottom = {4, 1}
                tLeft = {3, 1}
                tRight = {5, 1}
                ' -
                ' - - -
            Case 3
                tTop = {5, 0}
                tBottom = {4, 1}
                tLeft = {3, 1}
                tRight = {5, 1}
                '     -
                ' - - -
            Case 4
                tTop = {5, 0}
                tBottom = {4, 1}
                tLeft = {4, 0}
                tRight = {5, 1}
                ' - -
                ' - -
            Case 5
                tTop = {4, 0}
                tBottom = {4, 1}
                tLeft = {3, 1}
                tRight = {5, 0}
                '   - -
                ' - -
            Case 6
                tTop = {4, 0}
                tBottom = {4, 1}
                tLeft = {3, 1}
                tRight = {5, 1}
                '   -
                ' - - -
            Case Else
                tTop = {4, 0}
                tBottom = {4, 1}
                tLeft = {3, 0}
                tRight = {5, 1}
                ' - -
                '   - -
        End Select

    End Sub

    Sub gridChange()

        'the last locations of the tetromino is cleared (on the falling progress)
        grid(lastTop(0), lastTop(1)).Visible = False
        grid(lastBottom(0), lastBottom(1)).Visible = False
        grid(lastLeft(0), lastLeft(1)).Visible = False
        grid(lastRight(0), lastRight(1)).Visible = False

        ' different images / colors are used for each tetromino
        Dim gridImage As Image
        Select Case t
            Case 1
                gridImage = My.Resources.Resources.t1
            Case 2
                gridImage = My.Resources.Resources.t2
            Case 3
                gridImage = My.Resources.Resources.t3
            Case 4
                gridImage = My.Resources.Resources.t4
            Case 5
                gridImage = My.Resources.Resources.t5
            Case 6
                gridImage = My.Resources.Resources.t6
            Case Else
                gridImage = My.Resources.Resources.t7
        End Select

        grid(tTop(0), tTop(1)).Visible = True
        grid(tBottom(0), tBottom(1)).Visible = True
        grid(tLeft(0), tLeft(1)).Visible = True
        grid(tRight(0), tRight(1)).Visible = True
        grid(tTop(0), tTop(1)).BackgroundImage = gridImage
        grid(tBottom(0), tBottom(1)).BackgroundImage = gridImage
        grid(tLeft(0), tLeft(1)).BackgroundImage = gridImage
        grid(tRight(0), tRight(1)).BackgroundImage = gridImage

        ' the current locations become the "last" locations
        lastTop(0) = tTop(0)
        lastTop(1) = tTop(1)
        lastBottom(0) = tBottom(0)
        lastBottom(1) = tBottom(1)
        lastLeft(0) = tLeft(0)
        lastLeft(1) = tLeft(1)
        lastRight(0) = tRight(0)
        lastRight(1) = tRight(1)

        ' the shadow / fall preview is generated if it is not already at the bottom
        If canMoveDown(tTop, tBottom, tLeft, tRight) Then
            createTFall()
        End If

    End Sub

    Sub rotateT()

        ' depending on the type of tetromino and the rotation it is in, the tetromino will rotate into different shapes
        Select Case t
            Case 1
                Select Case r
                    Case 1
                        tTop(0) += 1
                        tTop(1) -= 1
                        tBottom(1) += 2
                        tLeft(0) += 2
                        tRight(0) -= 1
                        tRight(1) += 1
                    Case 2
                        tTop(0) -= 1
                        tTop(1) += 2
                        tBottom(1) -= 1
                        tLeft(0) -= 2
                        tLeft(1) += 1
                        tRight(0) += 1
                    Case 3
                        tTop(1) -= 2
                        tBottom(0) -= 1
                        tBottom(1) += 1
                        tLeft(0) += 1
                        tLeft(1) -= 1
                        tRight(0) -= 2
                    Case Else
                        tTop(1) += 1
                        tBottom(0) += 1
                        tBottom(1) -= 2
                        tLeft(0) -= 1
                        tRight(0) += 2
                        tRight(1) -= 1
                End Select
            Case 2
                Select Case r
                    Case 1
                        tTop(0) += 1
                        tBottom(1) += 1
                        tLeft(0) += 1
                        tRight(1) -= 1
                    Case 2
                        tTop(1) += 1
                        tBottom(0) += 1
                        tLeft(0) -= 1
                        tRight(1) += 1
                    Case 3
                        tTop(1) -= 1
                        tBottom(0) -= 1
                        tLeft(1) += 1
                        tRight(0) -= 1
                    Case Else
                        tTop(0) -= 1
                        tBottom(1) -= 1
                        tLeft(1) -= 1
                        tRight(0) += 1
                End Select
            Case 3
                Select Case r
                    Case 1
                        tTop(0) -= 1
                        tBottom(1) += 1
                        tLeft(0) += 1
                        tRight(1) += 1
                    Case 2
                        tTop(1) += 1
                        tBottom(0) -= 1
                        tLeft(0) -= 1
                        tRight(1) -= 1
                    Case 3
                        tTop(1) -= 1
                        tBottom(0) += 1
                        tLeft(1) -= 1
                        tRight(0) -= 1
                    Case Else
                        tTop(0) += 1
                        tBottom(1) -= 1
                        tLeft(1) += 1
                        tRight(0) += 1
                End Select
            Case 5
                Select Case r
                    Case 1
                        tBottom(0) += 1
                        tBottom(1) += 1
                        tLeft(0) += 1
                        tRight(1) += 1
                    Case 2
                        tTop(1) += 1
                        tBottom(0) -= 1
                        tLeft(0) -= 1
                        tLeft(1) += 1
                    Case 3
                        tTop(0) -= 1
                        tTop(1) -= 1
                        tLeft(1) -= 1
                        tRight(0) -= 1
                    Case Else
                        tTop(0) += 1
                        tBottom(1) -= 1
                        tRight(0) += 1
                        tRight(1) -= 1
                End Select
            Case 6
                Select Case r
                    Case 1
                        tBottom(1) += 1
                        tLeft(0) += 1
                    Case 2
                        tTop(1) += 1
                        tLeft(0) -= 1
                    Case 3
                        tTop(1) -= 1
                        tRight(0) -= 1
                    Case Else
                        tBottom(1) -= 1
                        tRight(0) += 1
                End Select
            Case 7
                Select Case r
                    Case 1
                        tTop(0) += 1
                        tBottom(1) += 1
                        tLeft(0) += 1
                        tLeft(1) += 1
                    Case 2
                        tTop(0) -= 1
                        tTop(1) += 1
                        tLeft(0) -= 1
                        tRight(1) += 1
                    Case 3
                        tTop(1) -= 1
                        tBottom(0) -= 1
                        tRight(0) -= 1
                        tRight(1) -= 1
                    Case Else
                        tBottom(0) += 1
                        tBottom(1) -= 1
                        tLeft(1) -= 1
                        tRight(0) += 1
                End Select
        End Select

        ' after rotation, the tetromino becomes the next rotation; there are 4 types of possible rotations for each tetromino
        r += 1
        r = r Mod 4

    End Sub

    Sub clearLine(ByVal tBottom As Integer)

        ' each line gets the values of the line above (which is why the clearing line process starts from top to bottom)
        For i = tBottom To 1 Step -1
            For j = 0 To 9
                If (grid(j, i - 1).Visible) = True Then
                    grid(j, i).Visible = True
                    grid(j, i).BackgroundImage = grid(j, i - 1).BackgroundImage
                    grid(j, i).AccessibleDescription = "t"
                Else
                    grid(j, i).Visible = False
                    grid(j, i).AccessibleDescription = Nothing
                End If
            Next
        Next

        ' the top line is set to blank
        For i = 0 To 9
            grid(i, 0).AccessibleDescription = Nothing
            grid(i, 0).Visible = False
        Next

    End Sub

    Sub changePreview()

        ' depending on the tetromino, the preview images will alter
        Select Case t2
            Case 1
                picBoxT2.BackgroundImage = My.Resources.Resources.wholeT1
            Case 2
                picBoxT2.BackgroundImage = My.Resources.Resources.wholeT2
            Case 3
                picBoxT2.BackgroundImage = My.Resources.Resources.wholeT3
            Case 4
                picBoxT2.BackgroundImage = My.Resources.Resources.wholeT4
            Case 5
                picBoxT2.BackgroundImage = My.Resources.Resources.wholeT5
            Case 6
                picBoxT2.BackgroundImage = My.Resources.Resources.wholeT6
            Case Else
                picBoxT2.BackgroundImage = My.Resources.Resources.wholeT7
        End Select
        Select Case t3
            Case 1
                picBoxT3.BackgroundImage = My.Resources.Resources.wholeT1
            Case 2
                picBoxT3.BackgroundImage = My.Resources.Resources.wholeT2
            Case 3
                picBoxT3.BackgroundImage = My.Resources.Resources.wholeT3
            Case 4
                picBoxT3.BackgroundImage = My.Resources.Resources.wholeT4
            Case 5
                picBoxT3.BackgroundImage = My.Resources.Resources.wholeT5
            Case 6
                picBoxT3.BackgroundImage = My.Resources.Resources.wholeT6
            Case Else
                picBoxT3.BackgroundImage = My.Resources.Resources.wholeT7
        End Select
        Select Case t4
            Case 1
                picBoxT4.BackgroundImage = My.Resources.Resources.wholeT1
            Case 2
                picBoxT4.BackgroundImage = My.Resources.Resources.wholeT2
            Case 3
                picBoxT4.BackgroundImage = My.Resources.Resources.wholeT3
            Case 4
                picBoxT4.BackgroundImage = My.Resources.Resources.wholeT4
            Case 5
                picBoxT4.BackgroundImage = My.Resources.Resources.wholeT5
            Case 6
                picBoxT4.BackgroundImage = My.Resources.Resources.wholeT6
            Case Else
                picBoxT4.BackgroundImage = My.Resources.Resources.wholeT7
        End Select
        Select Case t5
            Case 1
                picBoxT5.BackgroundImage = My.Resources.Resources.wholeT1
            Case 2
                picBoxT5.BackgroundImage = My.Resources.Resources.wholeT2
            Case 3
                picBoxT5.BackgroundImage = My.Resources.Resources.wholeT3
            Case 4
                picBoxT5.BackgroundImage = My.Resources.Resources.wholeT4
            Case 5
                picBoxT5.BackgroundImage = My.Resources.Resources.wholeT5
            Case 6
                picBoxT5.BackgroundImage = My.Resources.Resources.wholeT6
            Case Else
                picBoxT5.BackgroundImage = My.Resources.Resources.wholeT7
        End Select
        Select Case t6
            Case 1
                picBoxT6.BackgroundImage = My.Resources.Resources.wholeT1
            Case 2
                picBoxT6.BackgroundImage = My.Resources.Resources.wholeT2
            Case 3
                picBoxT6.BackgroundImage = My.Resources.Resources.wholeT3
            Case 4
                picBoxT6.BackgroundImage = My.Resources.Resources.wholeT4
            Case 5
                picBoxT6.BackgroundImage = My.Resources.Resources.wholeT5
            Case 6
                picBoxT6.BackgroundImage = My.Resources.Resources.wholeT6
            Case Else
                picBoxT6.BackgroundImage = My.Resources.Resources.wholeT7
        End Select

    End Sub

    Sub createTFall()

        ' every time it is called, the last shadow / fall preview is gone
        For i = 0 To 9
            For j = 0 To 19
                If (grid(i, j).AccessibleName = "fall") Then
                    grid(i, j).AccessibleName = Nothing
                    If grid(i, j).AccessibleDescription <> "t" Then
                        grid(i, j).Visible = False
                        grid(i, j).BackgroundImage = Nothing
                    End If
                End If
            Next
        Next

        ' the values are equivalent to the current locations
        fallTop(0) = tTop(0)
        fallTop(1) = tTop(1)
        fallBottom(0) = tBottom(0)
        fallBottom(1) = tBottom(1)
        fallLeft(0) = tLeft(0)
        fallLeft(1) = tLeft(1)
        fallRight(0) = tRight(0)
        fallRight(1) = tRight(1)

        ' the blocks determine the bottom
        Do While canMoveDown(fallTop, fallBottom, fallLeft, fallRight)
            fallTop(1) += 1
            fallBottom(1) += 1
            fallLeft(1) += 1
            fallRight(1) += 1
        Loop

        ' the block is shown with the tFall image and identified by their accessibleName of "fall"
        grid(fallTop(0), fallTop(1)).Visible = True
        grid(fallBottom(0), fallBottom(1)).Visible = True
        grid(fallLeft(0), fallLeft(1)).Visible = True
        grid(fallRight(0), fallRight(1)).Visible = True

        grid(fallTop(0), fallTop(1)).AccessibleName = "fall"
        grid(fallBottom(0), fallBottom(1)).AccessibleName = "fall"
        grid(fallLeft(0), fallLeft(1)).AccessibleName = "fall"
        grid(fallRight(0), fallRight(1)).AccessibleName = "fall"

        grid(fallTop(0), fallTop(1)).BackgroundImage = My.Resources.Resources.tFall
        grid(fallBottom(0), fallBottom(1)).BackgroundImage = My.Resources.Resources.tFall
        grid(fallLeft(0), fallLeft(1)).BackgroundImage = My.Resources.Resources.tFall
        grid(fallRight(0), fallRight(1)).BackgroundImage = My.Resources.Resources.tFall
    End Sub

    Function canMoveLeft(ByVal tTop() As Integer, ByVal tBottom() As Integer, ByVal tLeft() As Integer, ByVal tRight() As Integer) As Boolean

        ' if the tetromino is not at the border and there are no pieces in the way, it will be able to move left
        If (tLeft(0) > 0) Then
            Return (grid(tTop(0) - 1, tTop(1)).AccessibleDescription <> "t") And (grid(tBottom(0) - 1, tBottom(1)).AccessibleDescription <> "t") And (grid(tLeft(0) - 1, tLeft(1)).AccessibleDescription <> "t") And (grid(tRight(0) - 1, tRight(1)).AccessibleDescription <> "t")
        Else
            Return False
        End If

    End Function

    Function canMoveRight(ByVal tTop() As Integer, ByVal tBottom() As Integer, ByVal tLeft() As Integer, ByVal tRight() As Integer) As Boolean

        ' if the tetromino is not at the border and there are no pieces in the way, it will be able to move right
        If ((tRight(0) < 9)) Then
            Return (grid(tTop(0) + 1, tTop(1)).AccessibleDescription <> "t") And (grid(tBottom(0) + 1, tBottom(1)).AccessibleDescription <> "t") And (grid(tLeft(0) + 1, tLeft(1)).AccessibleDescription <> "t") And (grid(tRight(0) + 1, tRight(1)).AccessibleDescription <> "t")
        Else
            Return False
        End If

    End Function

    Function canMoveDown(ByVal tTop() As Integer, ByVal tBottom() As Integer, ByVal tLeft() As Integer, ByVal tRight() As Integer) As Boolean

        ' if the tetromino is not at the border and there are no pieces in the way, it will be able to move down
        If ((tBottom(1) <= 18)) Then
            Return (grid(tTop(0), tTop(1) + 1).AccessibleDescription <> "t") And (grid(tBottom(0), tBottom(1) + 1).AccessibleDescription <> "t") And (grid(tLeft(0), tLeft(1) + 1).AccessibleDescription <> "t") And (grid(tRight(0), tRight(1) + 1).AccessibleDescription <> "t")
        Else
            Return False
        End If

    End Function

    Function canRotate(ByVal t As Integer, ByVal r As Integer, ByVal tTop() As Integer, ByVal tBottom() As Integer, ByVal tLeft() As Integer, ByVal tRight() As Integer) As Boolean

        ' the ability to rotate is dependent on whether the locations to which the tetromino will be in after rotation is "full" or not
        ' in short terms, if there is a block in the way of its rotation, nothing will occur
        ' the conditions vary according to the type of tetromino and the rotation it is in
        Select Case t
            Case 1
                Select Case r
                    Case 1
                        If (tTop(1) > 0) And (tBottom(1) < 18) Then
                            Return (grid(tBottom(0), tBottom(1) - 1).AccessibleDescription <> "t") And (grid(tBottom(0), tBottom(1) + 1).AccessibleDescription <> "t") And (grid(tBottom(0), tBottom(1) + 2).AccessibleDescription <> "t")
                        End If
                    Case 2
                        If (tLeft(0) > 1) And (tRight(0) < 9) Then
                            Return (grid(tRight(0) - 2, tRight(1)).AccessibleDescription <> "t") And (grid(tRight(0) - 1, tRight(1)).AccessibleDescription <> "t") And (grid(tRight(0) + 1, tRight(1)).AccessibleDescription <> "t")
                        End If
                    Case 3
                        If (tTop(1) > 1) And (tBottom(1) < 19) Then
                            Return (grid(tTop(0), tTop(1) - 2).AccessibleDescription <> "t") And (grid(tTop(0), tTop(1) - 1).AccessibleDescription <> "t") And (grid(tTop(0), tTop(1) + 1).AccessibleDescription <> "t")
                        End If
                    Case Else
                        If (tLeft(0) > 0) And (tRight(0) < 8) Then
                            Return (grid(tLeft(0) - 1, tLeft(1)).AccessibleDescription <> "t") And (grid(tLeft(0) + 1, tLeft(1)).AccessibleDescription <> "t") And (grid(tLeft(0) + 2, tLeft(1)).AccessibleDescription <> "t")
                        End If
                End Select
            Case 2
                Select Case r
                    Case 1
                        If tBottom(1) < 19 Then
                            Return ((grid(tBottom(0), tBottom(1) + 1).AccessibleDescription <> "t") And (grid(tBottom(0), tBottom(1) - 1).AccessibleDescription <> "t") And (grid(tBottom(0) + 1, tBottom(1) - 1).AccessibleDescription <> "t"))
                        End If
                    Case 2
                        If tLeft(0) > 0 Then
                            Return (grid(tLeft(0) - 1, tLeft(1)).AccessibleDescription <> "t") And (grid(tLeft(0) + 1, tLeft(1)).AccessibleDescription <> "t") And (grid(tLeft(0) + 1, tLeft(1) + 1).AccessibleDescription <> "t")
                        End If
                    Case 3
                        Return (grid(tTop(0), tTop(1) + 1).AccessibleDescription <> "t") And (grid(tTop(0), tTop(1) - 1).AccessibleDescription <> "t") And (grid(tTop(0) - 1, tTop(1) + 1).AccessibleDescription <> "t")
                    Case Else
                        If tRight(0) < 9 Then
                            Return (grid(tRight(0) - 1, tRight(1)).AccessibleDescription <> "t") And (grid(tRight(0) + 1, tRight(1)).AccessibleDescription <> "t") And (grid(tRight(0) - 1, tRight(1) - 1).AccessibleDescription <> "t")
                        End If
                End Select
            Case 3
                Select Case r
                    Case 1
                        If tBottom(1) < 19 Then
                            Return (grid(tBottom(0), tBottom(1) - 1).AccessibleDescription <> "t") And (grid(tBottom(0), tBottom(1) + 1).AccessibleDescription <> "t") And (grid(tBottom(0) + 1, tBottom(1) + 1).AccessibleDescription <> "t")
                        End If
                    Case 2
                        If tLeft(0) > 0 Then
                            Return (grid(tLeft(0) - 1, tLeft(1)).AccessibleDescription <> "t") And (grid(tLeft(0) + 1, tLeft(1)).AccessibleDescription <> "t") And (grid(tLeft(0) - 1, tLeft(1) + 1).AccessibleDescription <> "t")
                        End If
                    Case 3
                        Return (grid(tTop(0), tTop(1) - 1).AccessibleDescription <> "t") And (grid(tTop(0), tTop(1) + 1).AccessibleDescription <> "t") And (grid(tTop(0) - 1, tTop(1) - 1).AccessibleDescription <> "t")
                    Case Else
                        If tRight(0) < 9 Then
                            Return (grid(tRight(0) - 1, tRight(1)).AccessibleDescription <> "t") And (grid(tRight(0) + 1, tRight(1)).AccessibleDescription <> "t") And (grid(tRight(0) + 1, tRight(1) - 1).AccessibleDescription <> "t")
                        End If
                End Select
            Case 5
                Select Case r
                    Case 1
                        If tBottom(1) < 19 Then
                            Return (grid(tBottom(0) + 1, tBottom(1)).AccessibleDescription <> "t") And (grid(tBottom(0) + 1, tBottom(1) + 1).AccessibleDescription <> "t")
                        End If
                    Case 2
                        If tLeft(0) > 0 Then
                            Return (grid(tLeft(0), tLeft(1) + 1).AccessibleDescription <> "t") And (grid(tLeft(0) - 1, tLeft(1) + 1).AccessibleDescription <> "t")
                        End If
                    Case 3
                        Return (grid(tTop(0) - 1, tTop(1)).AccessibleDescription <> "t") And (grid(tTop(0) - 1, tTop(1) - 1).AccessibleDescription <> "t")
                    Case Else
                        If tRight(0) < 9 Then
                            Return (grid(tRight(0), tRight(1) - 1).AccessibleDescription <> "t") And (grid(tRight(0) + 1, tRight(1) - 1).AccessibleDescription <> "t")
                        End If
                End Select
            Case 6
                Select Case r
                    Case 1
                        If tBottom(1) < 19 Then
                            Return (grid(tBottom(0), tBottom(1) + 1).AccessibleDescription <> "t")
                        End If
                    Case 2
                        If tLeft(0) > 0 Then
                            Return (grid(tLeft(0) - 1, tLeft(1)).AccessibleDescription <> "t")
                        End If
                    Case 3
                        Return (grid(tTop(0), tTop(1) - 1).AccessibleDescription <> "t")
                    Case Else
                        If tRight(0) < 9 Then
                            Return (grid(tRight(0) + 1, tRight(1)).AccessibleDescription <> "t")
                        End If
                End Select
            Case 7
                Select Case r
                    Case 1
                        If tBottom(1) < 19 Then
                            Return (grid(tBottom(0), tBottom(1) + 1).AccessibleDescription <> "t") And (grid(tBottom(0) + 1, tBottom(1) - 1).AccessibleDescription <> "t")
                        End If
                    Case 2
                        If tLeft(0) > 0 Then
                            Return (grid(tLeft(0) - 1, tLeft(1)).AccessibleDescription <> "t") And (grid(tLeft(0) + 1, tLeft(1) + 1).AccessibleDescription <> "t")
                        End If
                    Case 3
                        Return (grid(tTop(0), tTop(1) - 1).AccessibleDescription <> "t") And (grid(tTop(0) - 1, tTop(1) + 1).AccessibleDescription <> "t")
                    Case Else
                        If tRight(0) < 9 Then
                            Return (grid(tRight(0) + 1, tRight(1)).AccessibleDescription <> "t") And (grid(tRight(0) - 1, tRight(1) - 1).AccessibleDescription <> "t")
                        End If
                End Select
        End Select

        Return False

    End Function

    Function isFullLine(ByVal t() As Integer) As Boolean

        ' a full line is determined by whether all pieces are part of the tetrominos or empty
        Dim i As Integer
        Do
            If grid(i, t(1)).AccessibleDescription <> "t" Then
                i = -2
            End If
            i += 1
        Loop Until (i = -1) Or (i >= 10)
        If i = -1 Then
            Return False
        Else
            Return True
        End If

    End Function

End Class