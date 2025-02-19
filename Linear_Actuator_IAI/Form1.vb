Public Class Form1
    Dim Clsini As Cls_Ini.IniFile
    Dim ClsIAI As Class_IAI

    Friend Sub Show_Label_Display(Code As String, Cause As String, Action As String, Colorr As Color)

        Lb_code.Text = Code
        Lb_Case.Text = Cause
        Lb_Case.ForeColor = Colorr
        Lb_Action.Text = Action

    End Sub

    Friend Sub Show_Label_ToolStrip(StripStatusLable As String, Code As String, Colorr As Color)
        If StripStatusLable = "IAI" Then
            ToolStripStatusIAI.Text = Code
            ToolStripStatusIAI.BackColor = Colorr

        End If

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsIAI = New Class_IAI() ' Initialize ClsIAI
        Clsini = New Cls_Ini.IniFile(Application.StartupPath & "\Config.ini")
        Load_Config()
        Show_Label_Display("Initial", "Please Initial Machine.. ,กรุณาเริ่มต้นเครื่องใหม่...", "Click Button Initial ,", Color.Orange)

    End Sub
    Public Sub Load_Config()


        Dim Section2 As String = "IAI"
        With Clsini
            Dim axisValue As String = .IniGetValue(Section2, "Axis")
            Select Case axisValue
                Case "X"
                    Class_Var.IAI.Axis = "001"
                Case "Y"
                    Class_Var.IAI.Axis = "010"
                Case "XY"
                    Class_Var.IAI.Axis = "011"
                Case "Z"
                    Class_Var.IAI.Axis = "100"
                Case "ZX"
                    Class_Var.IAI.Axis = "101"
                Case "ZY"
                    Class_Var.IAI.Axis = "110"
                Case "XYZ"
                    Class_Var.IAI.Axis = "111"
            End Select



            Class_Var.IAI.CboPort_IAI = .IniGetValue(Section2, "COMPORT")
            Class_Var.IAI.CboRate_IAI = .IniGetValue(Section2, "BAUDRATE")
            Class_Var.IAI.CboParity_IAI = .IniGetValue(Section2, "PARITY")
            Class_Var.IAI.CboData_IAI = .IniGetValue(Section2, "DATABIT")
            Class_Var.IAI.CboStop_IAI = .IniGetValue(Section2, "STOPBIT")
            Class_Var.IAI.Speed = .IniGetValue(Section2, "SPEED")
            SpeedTeackbar.Value = Class_Var.IAI.Speed
        End With


    End Sub

    Private Sub BtCon_IAI_Click(sender As Object, e As EventArgs) Handles BtCon_IAI.Click
        If BtCon_IAI.Text = "Connect" Then
            ClsIAI.Connect_Port()
            If Class_Var.IAI.Connect = True Then
                BtCon_IAI.Text = "Disconnect"
                Show_Label_ToolStrip("IAI", "IAI Status : Connected.", Color.Green)
                TimerIAI.Enabled = True
                ChkShoPosi.Checked = True
            Else
                BtCon_IAI.Text = "Connect"
                Show_Label_ToolStrip("IAI", "IAI Status : not connect.", Color.Red)
            End If
        Else
            ClsIAI.Disconnect_Port()

            If Class_Var.IAI.Connect = False Then
                BtCon_IAI.Text = "Connect"
                Show_Label_ToolStrip("IAI", "IAI Status : Disconnect.", Color.Red)
            Else

            End If
        End If

    End Sub
    Private Sub BtHome_IAI_Click(sender As Object, e As EventArgs) Handles BtHome_IAI.Click
        BtHome_IAI.Enabled = False


        ClsIAI.IAI_HOME()
        ClsIAI.Check_Status_Home_IAI()


        If ClsIAI.CheckIAIStatus() = False Then

            Show_Label_Display("IAI", "Home IAI Error ,IAI กลับไปจุดเริ่มต้นไม่ได้", "Check IAI", Color.Red)

        End If

        BtHome_IAI.Enabled = True
    End Sub

    Private Sub TimerIAI_Tick(sender As Object, e As EventArgs) Handles TimerIAI.Tick

        TimerIAI.Enabled = False

        If Class_IAI.IAIxStatus = True Then

            lbStatusX.Text = "X = Ready"

        Else
            lbStatusX.Text = "X = Busy !"

        End If
        If Class_IAI.IAIyStatus = True Then
            lbStatusY.Text = "Y = Ready"

        Else
            lbStatusY.Text = "Y = Busy !"
        End If
        Class_IAI.IAI_Check_Position = ChkShoPosi.Checked
        If Class_IAI.IAI_Check_Position = True Or ChkShoPosi.Checked = True Then  'Class_IAI.IAI_Check_Position = True Or

            lblXPosition.Text = Class_IAI.IAIxPosition
            lblYPosition.Text = Class_IAI.IAIyPosition

        End If
        Speedtextbox.Text = SpeedTeackbar.Value
        If Class_IAI.IAI_Enable_Dis = True Then

            BtEnable_IAI.Text = "Disable"

        Else
            BtEnable_IAI.Text = "Enable"

        End If

        TimerIAI.Enabled = True
    End Sub
    Private Sub BtEnable_IAI_Click(sender As Object, e As EventArgs) Handles BtEnable_IAI.Click

        If BtEnable_IAI.Text = "Disable" Then
            ClsIAI.IAI_Disable()
            BtEnable_IAI.Text = "Enable"
        Else
            ClsIAI.IAI_Enable()
            BtEnable_IAI.Text = "Disable"
        End If

    End Sub


    Private Sub Bt_P_MOVE_MouseDown(sender As Object, e As MouseEventArgs) Handles BtX_P_MOVE.MouseDown, BtY_P_MOVE.MouseDown
        Dim axis As String = Class_Var.IAI.Axis
        Dim axisbt As String = CType(sender, Button).Tag.ToString()
        Dim PosiX As Double = CDbl(lblXPosition.Text)
        Dim PosiY As Double = CDbl(lblYPosition.Text)
        Dim PosiZ As Double = CDbl(lblZPosition.Text)


        If bt_jogorfast.Text = "Jog" Then

            If axisbt = "X" Then
                PosiX = CDbl(lblXPosition.Text)
                axis = "001"
                ClsIAI.JogFW_IAI(axis, PosiX)
            ElseIf axisbt = "Y" Then
                PosiY = CDbl(lblYPosition.Text)
                axis = "010"
                ClsIAI.JogFW_IAI(axis, PosiY)
            Else
                PosiZ = CDbl(lblZPosition.Text)
                axis = "100"
                ClsIAI.JogFW_IAI(axis, PosiZ)
            End If



        Else
            Class_IAI.IAI_Check_Position = True

            If axisbt = "X" Then
                PosiX = CDbl(lblXPosition.Text) + CDbl(CboStep_Pos_IAI.Text)
            ElseIf axisbt = "Y" Then
                PosiY = CDbl(lblYPosition.Text) + CDbl(CboStep_Pos_IAI.Text)
            Else
                PosiZ = CDbl(lblZPosition.Text) + CDbl(CboStep_Pos_IAI.Text)
            End If

            ClsIAI.Position_IAI(axis, PosiY, PosiX)
            ClsIAI.CheckIAIStatus()
            Class_IAI.IAI_Check_Position = False
        End If




    End Sub

    Private Sub Bt_P_MOVE_MouseUp(sender As Object, e As MouseEventArgs) Handles BtX_P_MOVE.MouseUp, BtY_P_MOVE.MouseUp
        If bt_jogorfast.Text = "Jog" Then
            Dim axisbt As String = CType(sender, Button).Tag.ToString()
            BtX_P_MOVE.Enabled = False
            If axisbt = "X" Then

                axisbt = "001"
                ClsIAI.JogStop_IAI(axisbt)
            ElseIf axisbt = "Y" Then

                axisbt = "010"
                ClsIAI.JogStop_IAI(axisbt)
            Else

                axisbt = "100"
                ClsIAI.JogStop_IAI(axisbt)
            End If

            ClsIAI.IAI_Send_Check_Status()
            ClsIAI.CheckIAIStatus()

            BtX_P_MOVE.Enabled = True

        End If
    End Sub


    Private Sub Bt_N_MOVE_MouseDown(sender As Object, e As MouseEventArgs) Handles BtX_N_MOVE.MouseDown, BtY_N_MOVE.MouseDown
        Dim axis As String = Class_Var.IAI.Axis
        Dim axisbt As String = CType(sender, Button).Tag.ToString()
        Dim PosiX As Double = CDbl(lblXPosition.Text)
        Dim PosiY As Double = CDbl(lblYPosition.Text)
        Dim PosiZ As Double = CDbl(lblZPosition.Text)


        If bt_jogorfast.Text = "Jog" Then

            If axisbt = "X" Then
                PosiX = CDbl(lblXPosition.Text)
                axis = "001"
                ClsIAI.JogRW_IAI(axis, PosiX)
            ElseIf axisbt = "Y" Then
                PosiY = CDbl(lblYPosition.Text)
                axis = "010"
                ClsIAI.JogRW_IAI(axis, PosiY)
            Else
                PosiZ = CDbl(lblZPosition.Text)
                axis = "100"
                ClsIAI.JogRW_IAI(axis, PosiZ)
            End If



        Else
            Class_IAI.IAI_Check_Position = True

            If axisbt = "X" Then
                PosiX = CDbl(lblXPosition.Text) - CDbl(CboStep_Pos_IAI.Text)
            ElseIf axisbt = "Y" Then
                PosiY = CDbl(lblYPosition.Text) - CDbl(CboStep_Pos_IAI.Text)
            Else
                PosiZ = CDbl(lblZPosition.Text) - CDbl(CboStep_Pos_IAI.Text)
            End If

            ClsIAI.Position_IAI(axis, PosiY, PosiX)
            ClsIAI.CheckIAIStatus()
            Class_IAI.IAI_Check_Position = False
        End If


    End Sub

    Private Sub Bt_N_MOVE_MouseUp(sender As Object, e As MouseEventArgs) Handles BtX_N_MOVE.MouseUp, BtY_N_MOVE.MouseUp


        If bt_jogorfast.Text = "Jog" Then
            Dim axisbt As String = CType(sender, Button).Tag.ToString()
            BtX_N_MOVE.Enabled = False
            If axisbt = "X" Then

                axisbt = "001"
                ClsIAI.JogStop_IAI(axisbt)
            ElseIf axisbt = "Y" Then

                axisbt = "010"
                ClsIAI.JogStop_IAI(axisbt)
            Else

                axisbt = "100"
                ClsIAI.JogStop_IAI(axisbt)
            End If

            ClsIAI.IAI_Send_Check_Status()
            ClsIAI.CheckIAIStatus()

            BtX_N_MOVE.Enabled = True

        End If
    End Sub

    Private Sub bt_jogorfast_Click(sender As Object, e As EventArgs) Handles bt_jogorfast.Click
        If bt_jogorfast.Text = "Fast" Then
            bt_jogorfast.Text = "Jog"
        Else
            bt_jogorfast.Text = "Fast"
        End If
    End Sub

    Private Sub Bt_reset_Click(sender As Object, e As EventArgs) Handles Bt_reset.Click
        ClsIAI.IAI_ResetError()
        BtHome_IAI.Enabled = True
    End Sub
End Class
