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
                Case "J1"
                    Class_Var.IAI.Axis = "001"
                Case "J2"
                    Class_Var.IAI.Axis = "010"
                Case "J2J1"
                    Class_Var.IAI.Axis = "011"
                Case "J3"
                    Class_Var.IAI.Axis = "100"
                Case "J3J1"
                    Class_Var.IAI.Axis = "101"
                Case "J3J2"
                    Class_Var.IAI.Axis = "110"
                Case "J3J2J1"
                    Class_Var.IAI.Axis = "111"
            End Select

            Class_Var.IAI.Address = .IniGetValue(Section2, "ADDRESS")

            Class_Var.IAI.CboPort_IAI = .IniGetValue(Section2, "COMPORT")
            Class_Var.IAI.CboRate_IAI = .IniGetValue(Section2, "BAUDRATE")
            Class_Var.IAI.CboParity_IAI = .IniGetValue(Section2, "PARITY")
            Class_Var.IAI.CboData_IAI = .IniGetValue(Section2, "DATABIT")
            Class_Var.IAI.CboStop_IAI = .IniGetValue(Section2, "STOPBIT")
            Class_Var.IAI.Speed = .IniGetValue(Section2, "SPEED")
            SpeedTeackbar.Value = Class_Var.IAI.Speed

            Class_Var.IAI.AxisJ1dimension = .IniGetValue(Section2, "AxisJ1dimension")
            Class_Var.IAI.AxisJ2dimension = .IniGetValue(Section2, "AxisJ2dimension")
            Class_Var.IAI.AxisJ3dimension = .IniGetValue(Section2, "AxisJ3dimension")


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
        Try
            ' Disable the button to prevent multiple clicks
            BtHome_IAI.Enabled = False

            ' Display status message: Homing in progress
            Show_Label_Display("IAI", "Homing IAI, IAI กำลังกลับไปจุดเริ่มต้น", "Waiting IAI", Color.Orange)

            ' Execute homing operation
            ClsIAI.IAI_HOME()
            ClsIAI.Check_Status_Home_IAI()

            ' Check homing status
            If ClsIAI.CheckIAIStatus() Then
                Show_Label_Display("IAI", "Home IAI Success, IAI กลับไปจุดเริ่มต้นสำเร็จ", "Ready IAI", Color.Green)
            Else
                Show_Label_Display("IAI", "Home IAI Error, IAI กลับไปจุดเริ่มต้นไม่ได้", "Check IAI", Color.Red)
            End If

        Catch ex As Exception
            ' Handle any unexpected errors
            Show_Label_Display("IAI", $"Error: {ex.Message}", "Error IAI", Color.Red)
        Finally
            ' Ensure button is re-enabled even if an error occurs
            BtHome_IAI.Enabled = True
        End Try
    End Sub


    Private Sub TimerIAI_Tick(sender As Object, e As EventArgs) Handles TimerIAI.Tick

        TimerIAI.Enabled = False

        If Class_IAI.IAIJ1Status = True Then

            lbStatusX.Text = "J1 = Ready"

        Else
            lbStatusX.Text = "J1 = Busy !"

        End If
        If Class_IAI.IAIJ2Status = True Then
            lbStatusY.Text = "J2 = Ready"

        Else
            lbStatusY.Text = "J2 = Busy !"
        End If
        If Class_IAI.IAIJ3Status = True Then
            lbStatusZ.Text = "J3 = Ready"

        Else
            lbStatusZ.Text = "J3 = Busy !"
        End If
        Class_IAI.IAI_Check_Position = ChkShoPosi.Checked
        If Class_IAI.IAI_Check_Position = True Or ChkShoPosi.Checked = True Then  'Class_IAI.IAI_Check_Position = True Or

            lblJ1Position.Text = Class_IAI.IAIJ1Position
            lblJ2Position.Text = Class_IAI.IAIJ2Position
            lblJ3Position.Text = Class_IAI.IAIJ3Position
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


    Private Sub Bt_P_MOVE_MouseDown(sender As Object, e As MouseEventArgs) Handles BtJ1_P_MOVE.MouseDown, BtJ2_P_MOVE.MouseDown, BtJ3_P_MOVE.MouseDown
        Try
            Dim axis As String = Class_Var.IAI.Axis
            Dim axisbt As String = CType(sender, Button).Tag.ToString()
            Dim PosiJ1 As Double = CDbl(lblJ1Position.Text)
            Dim PosiJ2 As Double = CDbl(lblJ2Position.Text)
            Dim PosiJ3 As Double = CDbl(lblJ3Position.Text)
            Class_IAI.IAI_Check_Position = True

            If bt_jogorfast.Text = "Jog" Then
                Select Case axisbt
                    Case "J1"
                        axis = "001"
                        ClsIAI.JogFW_IAI(axis, PosiJ1)
                    Case "J2"
                        axis = "010"

                        ClsIAI.JogFW_IAI(axis, PosiJ2)
                    Case "J3"
                        axis = "100"
                        ClsIAI.JogFW_IAI(axis, PosiJ3)
                End Select
            Else
                Select Case axisbt
                    Case "J1"
                        PosiJ1 += CDbl(CboStep_Pos_IAI.Text)
                    Case "J2"
                        PosiJ2 += CDbl(CboStep_Pos_IAI.Text)
                    Case "J3"
                        PosiJ3 += CDbl(CboStep_Pos_IAI.Text)
                End Select

                ClsIAI.Position_IAI(axis, PosiJ2, PosiJ1, PosiJ3)
                ClsIAI.CheckIAIStatus()
            End If

            Class_IAI.IAI_Check_Position = False

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Bt_P_MOVE_MouseUp(sender As Object, e As MouseEventArgs) Handles BtJ1_P_MOVE.MouseUp, BtJ2_P_MOVE.MouseUp, BtJ3_P_MOVE.MouseUp
        Try
            Dim axisbt As String = CType(sender, Button).Tag.ToString()

            If bt_jogorfast.Text = "Jog" Then
                If axisbt = "J1" Then
                    BtJ1_P_MOVE.Enabled = False
                Else
                    BtJ2_P_MOVE.Enabled = False
                End If

                ClsIAI.JogStop_IAI(Class_Var.IAI.Axis)
                ClsIAI.IAI_Send_Check_Status()
                ClsIAI.CheckIAIStatus()

                BtJ1_P_MOVE.Enabled = True
                BtJ2_P_MOVE.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Bt_N_MOVE_MouseDown(sender As Object, e As MouseEventArgs) Handles BtJ1_N_MOVE.MouseDown, BtJ2_N_MOVE.MouseDown, BtJ3_N_MOVE.MouseDown
        Try
            Dim axis As String = Class_Var.IAI.Axis
            Dim axisbt As String = CType(sender, Button).Tag.ToString()
            Dim PosiJ1 As Double = CDbl(lblJ1Position.Text)
            Dim PosiJ2 As Double = CDbl(lblJ2Position.Text)
            Dim PosiJ3 As Double = CDbl(lblJ3Position.Text)

            Class_IAI.IAI_Check_Position = True

            If bt_jogorfast.Text = "Jog" Then
                Select Case axisbt
                    Case "J1"
                        axis = "001"
                        ClsIAI.JogRW_IAI(axis, PosiJ1)
                    Case "J2"
                        axis = "010"
                        ClsIAI.JogRW_IAI(axis, PosiJ2)
                    Case "J3"
                        axis = "100"
                        ClsIAI.JogRW_IAI(axis, PosiJ3)
                End Select
            Else
                Select Case axisbt
                    Case "J1"
                        PosiJ1 -= CDbl(CboStep_Pos_IAI.Text)
                    Case "J2"
                        PosiJ2 -= CDbl(CboStep_Pos_IAI.Text)
                    Case "J3"
                        PosiJ3 -= CDbl(CboStep_Pos_IAI.Text)
                End Select

                ClsIAI.Position_IAI(axis, PosiJ2, PosiJ1, PosiJ3)
                ClsIAI.CheckIAIStatus()
            End If

            Class_IAI.IAI_Check_Position = False

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Bt_N_MOVE_MouseUp(sender As Object, e As MouseEventArgs) Handles BtJ1_N_MOVE.MouseUp, BtJ2_N_MOVE.MouseUp
        Try
            Dim axisbt As String = CType(sender, Button).Tag.ToString()

            If bt_jogorfast.Text = "Jog" Then
                If axisbt = "J1" Then
                    BtJ1_N_MOVE.Enabled = False
                Else
                    BtJ2_N_MOVE.Enabled = False
                End If

                ClsIAI.JogStop_IAI(Class_Var.IAI.Axis)
                ClsIAI.IAI_Send_Check_Status()
                ClsIAI.CheckIAIStatus()

                BtJ1_N_MOVE.Enabled = True
                BtJ2_N_MOVE.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub bt_jogorfast_Click(sender As Object, e As EventArgs) Handles bt_jogorfast.Click
        If bt_jogorfast.Text = "Fast" Then
            bt_jogorfast.Text = "Jog"
        Else
            bt_jogorfast.Text = "Fast"
        End If
    End Sub

    Private Sub Bt_reset_Click(sender As Object, e As EventArgs) Handles Bt_reset.Click
        Try
            Bt_reset.Enabled = False ' Disable button during reset
            ClsIAI.IAI_ResetError()

            ' Optional: Provide feedback to the user
            Show_Label_Display("IAI", "Resetting IAI errors...", "Reset", Color.Orange)

            ' Re-enable home button after reset
            BtHome_IAI.Enabled = True
            Delay(15000)
            ' Optional: Confirm reset success
            Show_Label_Display("IAI", "IAI errors reset successfully.", "Ready", Color.Green)
            Class_IAI.IAI_Enable_Dis = False
        Catch ex As Exception
            MessageBox.Show($"Error resetting IAI: {ex.Message}", "Reset Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Bt_reset.Enabled = True ' Re-enable button in any case
        End Try
    End Sub

    Private Sub bt_P1_Click(sender As Object, e As EventArgs) Handles bt_P1.Click
        Try
            Dim axis As String = Class_Var.IAI.Axis
            Class_IAI.IAI_Check_Position = True
            ClsIAI.Position_IAI(axis, txt_P1_J2.Text, txt_P1_J1.Text, txt_P1_J3.Text)
            ClsIAI.CheckIAIStatus()
            Class_IAI.IAI_Check_Position = False

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub bt_P2_Click(sender As Object, e As EventArgs) Handles bt_P2.Click
        Try
            Dim axis As String = Class_Var.IAI.Axis


            Class_IAI.IAI_Check_Position = True

            ClsIAI.Position_IAI(axis, txt_P2_J2.Text, txt_P2_J1.Text, txt_P2_J3.Text)
            ClsIAI.CheckIAIStatus()

            Class_IAI.IAI_Check_Position = False

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ClsIAI.Disconnect_Port()

        If Class_Var.IAI.Connect = False Then
            BtCon_IAI.Text = "Connect"
            Show_Label_ToolStrip("IAI", "IAI Status : Disconnect.", Color.Red)
        Else

        End If
    End Sub
End Class
