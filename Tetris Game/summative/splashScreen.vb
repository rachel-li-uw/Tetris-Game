Public Class splashScreen
    Dim time As Integer

    Private Sub timerSplashScreen_Tick(sender As Object, e As EventArgs) Handles timerSplashScreen.Tick
        ProgressBar.Increment(10)
        If ProgressBar.Value = ProgressBar.Maximum Then
            Me.Visible = False
            tetris.Show()
        End If
    End Sub

End Class