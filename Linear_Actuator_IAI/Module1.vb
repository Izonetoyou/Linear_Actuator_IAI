Module Module1


    Public Sub Delay(milliSec As Integer)

        Dim sw2 As New Stopwatch
        sw2.Start()
        Do
            Application.DoEvents()
        Loop Until sw2.ElapsedMilliseconds >= milliSec

    End Sub


End Module
