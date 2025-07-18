Imports System.IO.Ports
Imports System.Net.NetworkInformation

Public Class Class_IAI
    ReadOnly Ctrol As New Control

    Private ReadOnly MPortIAI As New SerialPort
    Private ReadOnly ReceivedBuffer As Integer = 3       'Monitor command , Must least than 2
    Private IAI_SendCommandCheck As String
    Private ReadySend As Boolean

    Friend Shared Position_Motor1, Position_Motor2 As Integer
    Friend Shared IAIxStatus,
                  IAIyStatus,
                  IAIzStatus,
                  IAI_Check_Position As Boolean

    Friend Shared IAIxPosition,
                  IAIyPosition,
                  IAIzPosition As Double

    Friend Shared IAI_Error_DoubleCmd As Boolean
    Friend Shared IAI_Enable_Dis As Boolean

    Dim IAI_BlBfSlow As Boolean
    Dim IAI_PisitionBfSlow As Double

    Friend Sub Connect_Port()

        '--------------- I/O 1 Start connect -------------------------------------------
        'close port
        If MPortIAI IsNot Nothing Then MPortIAI.Close()

        'set port properties
        MPortIAI.PortName = Class_Var.IAI.CboPort_IAI
        MPortIAI.BaudRate = Convert.ToInt32(Class_Var.IAI.CboRate_IAI)
        MPortIAI.DataBits = Convert.ToInt32(Class_Var.IAI.CboData_IAI)
        MPortIAI.Parity = CType([Enum].Parse(GetType(Parity), Class_Var.IAI.CboParity_IAI), Parity)
        MPortIAI.StopBits = CType([Enum].Parse(GetType(StopBits), Class_Var.IAI.CboStop_IAI), StopBits)

        'try connection
        Try

            MPortIAI.Open()
            AddHandler MPortIAI.DataReceived, AddressOf DataReceived_IAI
            Class_Var.IAI.Connect = True

        Catch ex As Exception

            If MPortIAI.IsOpen Then

                Class_Var.IAI.Connect = False
                MPortIAI.Close()
                RemoveHandler MPortIAI.DataReceived, AddressOf DataReceived_IAI

            End If
            Return

        End Try

        If MPortIAI.IsOpen Then

            IAI_Enable()

        End If

    End Sub
    Friend Sub Disconnect_Port()

        If MPortIAI.IsOpen Then

            Class_Var.IAI.Connect = False
            MPortIAI.Close()

        End If

    End Sub

    Private Sub DataReceived_IAI(sender As Object, e As SerialDataReceivedEventArgs)
        If e.EventType = IO.Ports.SerialData.Chars Then ShowReceived_COMIAI()
    End Sub
    Public Sub ShowReceived_COMIAI()

        Dim s1 As String = ""
        Dim sArry() As String
        Dim tmp_check1 As String = ""
        Dim tmp_check2 As String = ""
        Dim sArry2() As String



        s1 = MPortIAI.ReadExisting()
        If s1.Trim <> "" Then
            sArry = s1.Split(vbCrLf)

            tmp_check1 = sArry(sArry.Length - 2).Trim    'Get last command
            tmp_check2 = Mid(tmp_check1, 4, 3)

            If IAI_SendCommandCheck <> tmp_check2 Then   'Crosscheck send and receive command

                ReadySend = False
            Else
                ReadySend = True

            End If

            If ReceivedBuffer < sArry.Length Then

                'MessageBox.Show("IAI : send more than 2 command per time")
                IAI_Error_DoubleCmd = True
                Exit Sub
            Else
                IAI_Error_DoubleCmd = False

            End If

            If tmp_check2 = "212" Then

                sArry2 = CheckStatusTotal(tmp_check1).Split("_")
                If sArry2(0) = "00011100" Or sArry2(0) = "00001100" Then
                    IAIxStatus = True
                Else
                    IAIxStatus = False

                End If

                If sArry2(2) = "00011100" Or sArry2(2) = "00001100" Then
                    IAIyStatus = True
                Else
                    IAIyStatus = False
                End If
                If sArry2(4) = "00011100" Or sArry2(4) = "00001100" Then
                    IAIzStatus = True
                Else
                    IAIzStatus = False
                End If

            End If

            If IAI_Check_Position = True Then
                Dim Position() As String = Split(CheckStatusTotal(s1), "_")
                If Position.Length >= 4 Then

                    IAIxPosition = Position(1)
                    IAIxPosition = Math.Round(Val(IAIxPosition), 3)

                    IAIyPosition = Position(3)
                    IAIyPosition = Math.Round(Val(IAIyPosition), 3)

                    IAIzPosition = Position(5)
                    IAIzPosition = Math.Round(Val(IAIzPosition), 3)

                End If
            End If

        End If

    End Sub


    Friend Sub IAI_Enable()
        If MPortIAI.IsOpen Then
            MPortIAI.Write(ServoOnOff(Class_Var.IAI.Axis, True))
            Delay(300)
            IAI_Enable_Dis = True
            'BtEnable_IAI.Text = "Disable"
        End If
    End Sub

    Friend Sub IAI_Disable()
        If MPortIAI.IsOpen Then

            MPortIAI.Write(ServoOnOff(Class_Var.IAI.Axis, False))
            Delay(300)
            IAI_Enable_Dis = False
            'BtEnable_IAI.Text = "Enable"
        End If
    End Sub

    Friend Sub IAI_HOME()

        IAI_BlBfSlow = False

        'Home IAI 
        IAI_SendCommandCheck = ""
        IAI_SendCommandCheck = Mid(Trim(HomeMotor_IAI(Class_Var.IAI.Axis)), 4, 3)
        MPortIAI.Write(HomeMotor_IAI(Class_Var.IAI.Axis))
        Delay(3000)



    End Sub
    Friend Sub IAI_ResetError()
        If MPortIAI.IsOpen Then
            MPortIAI.Write(IAI_Reset_Error())
        End If
    End Sub
    Friend Sub IAI_Send_Check_Status()

        IAI_SendCommandCheck = ""
        IAI_SendCommandCheck = Mid(Trim(AxisStatus(Class_Var.IAI.Axis)), 4, 3)
        MPortIAI.Write(AxisStatus(Class_Var.IAI.Axis))

    End Sub

    Friend Sub Check_Status_Home_IAI()

        Dim CountCommand As Integer = 0
        Do

            If ReadySend = True Then

                IAI_Send_Check_Status()

                Delay(1000)
                CountCommand += 1

                If CountCommand > 50 Then

                    MessageBox.Show("IAI Overflow !")
                    Exit Sub

                End If

            End If

            Application.DoEvents()

        Loop Until IAIxStatus = True And IAIyStatus = True ' And IAIzStatus = True
        '------------------------------------ Check status of IAI

    End Sub
    Friend Function CheckIAIStatus() As Boolean

        '------------------------------------ Check status of IAI
        Dim CountCommand As Integer = 0
        Delay(100)
        Do
            '----------------
            'If blExit = True Then Exit Sub
            '----------------


            If ReadySend = True Then
                IAI_Send_Check_Status()

                Delay(20)
                CountCommand += 1
                If CountCommand > 100 Then Return False

            End If

            Application.DoEvents()


        Loop Until IAIxStatus = True And IAIyStatus = True 'And IAIzStatus = True

        Return True





    End Function
    Friend Function Position_IAI(axis As String, ByVal PosiY As String, ByVal PosiX As String, ByVal PosiZ As String)

        Dim ReSendCmd As Integer = 0

startt:

        If ReSendCmd > 2 Then

            MessageBox.Show("Error !!!")
            Application.Exit()

        End If

        Try

            IAI_SendCommandCheck = ""
            If Val(PosiX) >= 500 Or Val(PosiX) < -1 Then
                Form1.LbStatusDisplay.Text = "X Position Over Limit"
                Exit Function
            ElseIf Val(PosiY) >= 600 Or Val(PosiY) < -1 Then
                Form1.LbStatusDisplay.Text = "Y Position Over Limit"
                Exit Function
            ElseIf Val(PosiZ) >= 50 Or Val(PosiZ) < -1 Then
                Form1.LbStatusDisplay.Text = "Z Position Over Limit"
                Exit Function
            End If


            If MPortIAI.IsOpen Then

                IAI_SendCommandCheck = Mid(Trim(XYZMove(axis, 0, Val(PosiY.Trim), Val(PosiX.Trim), Form1.Speedtextbox.Text, 0.5)), 4, 3)
                MPortIAI.Write(XYZMove(axis, 0, Val(PosiY.Trim), Val(PosiX.Trim), Form1.Speedtextbox.Text, 0.5))


                Delay(20)
            Else

                Try
                    MPortIAI.Open()
                    IAI_SendCommandCheck = Mid(Trim(XYZMove(axis, 0, Val(PosiY.Trim), Val(PosiX.Trim), Form1.Speedtextbox.Text, 0.5)), 4, 3)
                    MPortIAI.Write(XYZMove(axis, 0, Val(PosiY.Trim), Val(PosiX.Trim), Form1.Speedtextbox.Text, 0.5))

                    Delay(20)
                Catch ex As Exception

                    MessageBox.Show(ex.ToString)
                    Application.Exit()

                End Try

            End If


        Catch ex As Exception

            ReSendCmd += 1
            Delay(200)
            GoTo startt

        End Try

    End Function
    Friend Function JogStop_IAI(axis As String)


        IAI_SendCommandCheck = ""
        If MPortIAI.IsOpen Then

            IAI_SendCommandCheck = Mid(Trim(StopMotor_IAI(axis)), 4, 3)
            MPortIAI.Write(StopMotor_IAI(axis))
            Delay(20)

        Else

            Try
                MPortIAI.Open()
                IAI_SendCommandCheck = Mid(Trim(StopMotor_IAI(axis)), 4, 3)
                MPortIAI.Write(StopMotor_IAI(axis))
                Delay(20)
            Catch ex As Exception

                MessageBox.Show(ex.ToString)
                Application.Exit()

            End Try

        End If

    End Function
    Friend Function JogFW_IAI(axis As String, ByVal PosiZ As String)

        IAI_SendCommandCheck = ""
        If Val(PosiZ) <= 499 Then
            If MPortIAI.IsOpen Then



                IAI_SendCommandCheck = Mid(Trim(JogInDec(axis, 0.3, Form1.Speedtextbox.Text, 0, True)), 4, 3)
                MPortIAI.Write(JogInDec(axis, 0.3, Form1.Speedtextbox.Text, 0, True))
                Delay(20)
            Else

                Try
                    MPortIAI.Open()

                    IAI_SendCommandCheck = Mid(Trim(JogInDec(axis, 0.3, Form1.Speedtextbox.Text, 0, True)), 4, 3)
                    MPortIAI.Write(JogInDec(axis, 0.3, Form1.Speedtextbox.Text, 0, True))
                    Delay(20)
                Catch ex As Exception

                    MessageBox.Show(ex.ToString)
                    Application.Exit()

                End Try

            End If
        Else
            'Form1.red_blink()
            ' LampRed_ON()
            Form1.LbStatusDisplay.Text = "Position Over Limit"

        End If



    End Function

    Friend Function JogRW_IAI(axis As String, ByVal PosiZ As String)



        IAI_SendCommandCheck = ""
        If Val(PosiZ) >= 1 Then
            If MPortIAI.IsOpen Then

                IAI_SendCommandCheck = Mid(Trim(JogInDec(axis, 0.5, Form1.Speedtextbox.Text, 0, False)), 4, 3)
                MPortIAI.Write(JogInDec(axis, 0.5, Form1.Speedtextbox.Text, 0, False))
                Delay(20)
            Else

                Try
                    MPortIAI.Open()

                    IAI_SendCommandCheck = Mid(Trim(JogInDec(axis, 0.5, Form1.Speedtextbox.Text, 0, False)), 4, 3)
                    MPortIAI.Write(JogInDec(axis, 0.5, Form1.Speedtextbox.Text, 0, False))
                    Delay(20)
                Catch ex As Exception

                    MessageBox.Show(ex.ToString)
                    Application.Exit()

                End Try

            End If
        Else

            ' LampRed_ON()
            Form1.LbStatusDisplay.Text = "Position Over Limit"

        End If



    End Function

#Region "IAI_Protocal"

    Private Function DecToHex(data As Integer) As String

        Dim hexResult As String = Hex(data)
        Return hexResult

    End Function

    Private Function StrToDec(data As String) As Integer

        Dim tempCharArray() As Char = data.ToCharArray
        Dim drr As Char
        Dim summ As Integer = 0

        For Each drr In tempCharArray

            summ += Asc(drr)

        Next

        Return summ

    End Function

    Private Function CheckSum(dataa As String) As String

        Dim tempSum As String = DecToHex(StrToDec(dataa))
        Dim checkS As String = Right(tempSum, 2)
        Return checkS

    End Function

    Private Function EachAxis(ByVal axis As String) As String

        If (axis = "001") Then            ' Which axis will move         ' X = 01

            axis = "01"

        ElseIf (axis = "010") Then       ' Y = 02

            axis = "02"

        ElseIf (axis = "011") Then       ' XY = 03

            axis = "03"

        ElseIf (axis = "100") Then       ' Z = 04

            axis = "04"

        ElseIf (axis = "101") Then       'ZX = 05

            axis = "05"

        ElseIf (axis = "110") Then       'ZY = 06

            axis = "06"

        ElseIf (axis = "111") Then       'XYZ = 07

            axis = "07"
        Else

            Return "err"

        End If
        Return axis


    End Function

    Function XYZMove(zyx As String, ByVal distanceZ As Double, ByVal distanceY As Double, ByVal distanceX As Double, ByVal speed As Integer, ByVal accDcl As Double) As String
        Dim distanceHex As String
        Dim axis = EachAxis(zyx)

        '  mPortCom3.Write(abMove("011", 0, Val(Pick_InUp_Z.Text), Val(IAI_X_Pos.Text), 1000, 0.5)) 'yzx,yzx,speed,acc

        If (axis = "01") Then            ' Which axis will move         ' X = 01

            distanceHex = Right("00000000" + DecToHex(Convert.ToInt32(distanceX * 1000)), 8)        ' Format = x + y + z

        ElseIf (axis = "02") Then       ' Y = 02

            distanceHex = Right("00000000" + DecToHex(Convert.ToInt32(distanceY * 1000)), 8)

        ElseIf (axis = "03") Then       ' XY = 03

            distanceHex = Right("00000000" + DecToHex(Convert.ToInt32(distanceX * 1000)), 8) + Right("00000000" + DecToHex(Convert.ToInt32(distanceY * 1000)), 8)

        ElseIf (axis = "04") Then       ' Z = 04

            distanceHex = Right("00000000" + DecToHex(Convert.ToInt32(distanceZ * 1000)), 8)

        ElseIf (axis = "05") Then       'ZX = 05


            distanceHex = Right("00000000" + DecToHex(Convert.ToInt32(distanceX * 1000)), 8) + Right("00000000" + DecToHex(Convert.ToInt32(distanceZ * 1000)), 8)

        ElseIf (axis = "06") Then       'ZY = 06


            distanceHex = Right("00000000" + DecToHex(Convert.ToInt32(distanceY * 1000)), 8) + Right("00000000" + DecToHex(Convert.ToInt32(distanceZ * 1000)), 8)

        ElseIf (axis = "07") Then       'XYZ = 07

            distanceHex = Right("00000000" + DecToHex(Convert.ToInt32(distanceX * 1000)), 8) + Right("00000000" + DecToHex(Convert.ToInt32(distanceY * 1000)), 8) + Right("00000000" + DecToHex(Convert.ToInt32(distanceZ * 1000)), 8)

        Else
            Return "err"

        End If

        Dim speedHex As String = Right("00000000" + DecToHex(speed), 4)                         'mm/s
        Dim accDclHex As String = Right("00000000" + DecToHex(Convert.ToInt32(accDcl * 100)), 4)               'G
        Dim scHex As String = CheckSum("!00234" + axis + accDclHex + accDclHex + speedHex + distanceHex)    'Check sum

        Return ("!00234" + axis + accDclHex + accDclHex + speedHex + distanceHex + scHex + vbCr + vbLf)

    End Function

    Function ServoOnOff(ByVal zyx As String, ByVal OnOff As Boolean) As String

        Dim axis = EachAxis(zyx)

        Dim ofStatus As String
        If OnOff = True Then

            ofStatus = "1"
        Else
            ofStatus = "0"

        End If

        Dim scHex As String = CheckSum("!00232" + axis + ofStatus)    'Check sum
        Return ("!00232" + axis + ofStatus + scHex + vbCr + vbLf)

    End Function

    Function HomeMotor_IAI(ByVal zyx As String)

        Dim axis = EachAxis(zyx)
        Dim scHex As String = CheckSum("!00233" + axis + "000000")    'Check sum
        Return ("!00233" + axis + "000000" + scHex + vbCr + vbLf)

    End Function

    Function Alarm_IAI_Reset() As String

        Return "!002521A" + vbCr + vbLf

    End Function

    Function Software_IAI_Reset() As String

        Return "!0025B2A" + vbCr + vbLf

    End Function

    Function JogInDec(ByVal zyx As String, ByVal accDcl As Double, ByVal speed As Integer, ByVal distance As Double, ByVal forwordReword As Boolean) As String

        Dim axis = EachAxis(zyx)
        Dim distanceHex As String
        Dim moveFR As String

        If (axis = "01") Then            ' Which axis will move         ' X = 01

            distanceHex = Right("00000000" + DecToHex(Convert.ToInt32(distance * 1000)), 8)        ' Format = x + y + z

        ElseIf (axis = "02") Then       ' Y = 02

            distanceHex = Right("00000000" + DecToHex(Convert.ToInt32(distance * 1000)), 8)

        ElseIf (axis = "04") Then       ' Z = 04

            distanceHex = Right("00000000" + DecToHex(Convert.ToInt32(distance * 1000)), 8)

        Else

            Return "err"

        End If

        If forwordReword = True Then

            moveFR = "1"
        Else
            moveFR = "0"

        End If

        Dim speedHex As String = Right("00000000" + DecToHex(speed), 4)                                         'mm/s
        Dim accDclHex As String = Right("00000000" + DecToHex(Convert.ToInt32(accDcl * 100)), 4)                'G
        Dim scHex As String = CheckSum("!00236" + axis + accDclHex + accDclHex + speedHex + distanceHex + moveFR)    'Check sum

        Return "!00236" + axis + accDclHex + accDclHex + speedHex + distanceHex + moveFR + scHex + vbCr + vbLf

    End Function

    Function StopMotor_IAI(ByVal zyx As String) As String

        Dim axis = EachAxis(zyx)
        Dim scHex As String = CheckSum("!00238" + axis + "00")    'Check sum
        Debug.Print("!00238" + axis + "00" + scHex + vbCr + vbLf)
        Return "!00238" + axis + "00" + scHex + vbCr + vbLf

    End Function

    Function AxisStatus(ByVal zyx As String) As String

        Dim axis = EachAxis(zyx)
        Dim scHex As String = CheckSum("!00212" + axis)    'Check sum

        Return "!00212" + axis + scHex + vbCr + vbLf


    End Function

    Private Function ConvertHextoBi(ByVal HexStr As String) As String

        Dim i As Integer = Convert.ToInt32(HexStr, 16)            'Change to Hex first
        Dim s2 As String = Convert.ToString(i, 2)                   'Change to Binary in string

        Return Right("0000000000000000" + s2, 8)

    End Function

    Private Function ConvertHextoDec(ByRef HexStr As String) As String

        Dim i As Integer = Convert.ToInt32(HexStr, 16)            'Change to Hex first
        Dim s2 As String = Convert.ToString(i, 2)                   'Change to Binary in string
        Dim decCon As Integer = Convert.ToInt32(s2, 2)

        Return decCon.ToString

    End Function

    Private Function CheckAxis(ByVal responeAx As String) As String

        Dim tempS As String = responeAx.Trim
        Dim axisAx As String = tempS.Substring(6, 2)

        Return axisAx

    End Function

    Function CheckStatusTotal(ByVal responeS As String) As String

        Dim tempS As String = responeS.Trim
        Dim axisAll As String = CheckAxis(tempS)

        Dim axisXstatus As String
        Dim axisYstatus As String
        Dim axisZstatus As String
        Dim distanceX As String
        Dim distanceY As String
        Dim distanceZ As String
        Dim allResult As String = ""

        'zyx
        If axisAll = "01" Then      'x

            axisXstatus = ConvertHextoBi(tempS.Substring(8, 2))
            distanceX = (CDbl(ConvertHextoDec(tempS.Substring(16, 8))) / 1000).ToString

            'allResult = "X = " & axisXstatus & "_" & distanceX
            allResult = axisXstatus & "_" & distanceX

        ElseIf axisAll = "02" Then  'y

            axisYstatus = ConvertHextoBi(tempS.Substring(8, 2))
            distanceY = (CDbl(ConvertHextoDec(tempS.Substring(16, 8))) / 1000).ToString

            'allResult = "Y = " & axisYstatus & "_" & distanceY
            allResult = axisYstatus & "_" & distanceY

        ElseIf axisAll = "03" Then  'yx

            axisXstatus = ConvertHextoBi(tempS.Substring(8, 2))
            axisYstatus = ConvertHextoBi(tempS.Substring(24, 2))

            distanceX = (CDbl(ConvertHextoDec(tempS.Substring(16, 8))) / 1000).ToString
            distanceY = (CDbl(ConvertHextoDec(tempS.Substring(32, 8))) / 1000).ToString

            'allResult = "XY = " & axisXstatus & "_" & distanceX & "_" & axisYstatus & "_" & distanceY
            allResult = axisXstatus & "_" & distanceX & "_" & axisYstatus & "_" & distanceY

        ElseIf axisAll = "04" Then  'z

            axisZstatus = ConvertHextoBi(tempS.Substring(8, 2))
            distanceZ = (CDbl(ConvertHextoDec(tempS.Substring(16, 8))) / 1000).ToString

            'allResult = "Z = " & axisZstatus & "_" & distanceZ
            allResult = axisZstatus & "_" & distanceZ

        ElseIf axisAll = "05" Then  'zx

            axisXstatus = ConvertHextoBi(tempS.Substring(8, 2))
            axisZstatus = ConvertHextoBi(tempS.Substring(24, 2))

            distanceX = (CDbl(ConvertHextoDec(tempS.Substring(16, 8))) / 1000).ToString
            distanceZ = (CDbl(ConvertHextoDec(tempS.Substring(32, 8))) / 1000).ToString

            ' allResult = "XZ = " & axisXstatus & "_" & distanceX & "_" & axisZstatus & "_" & distanceZ
            allResult = axisXstatus & "_" & distanceX & "_" & axisZstatus & "_" & distanceZ


        ElseIf axisAll = "06" Then  'zy

            axisYstatus = ConvertHextoBi(tempS.Substring(8, 2))
            axisZstatus = ConvertHextoBi(tempS.Substring(24, 2))

            distanceY = (CDbl(ConvertHextoDec(tempS.Substring(16, 8))) / 1000).ToString
            distanceZ = (CDbl(ConvertHextoDec(tempS.Substring(32, 8))) / 1000).ToString

            'allResult = "YZ = " & axisYstatus & "_" & distanceY & "_" & axisZstatus & "_" & distanceZ
            allResult = axisYstatus & "_" & distanceY & "_" & axisZstatus & "_" & distanceZ

        ElseIf axisAll = "07" Then  'zyx

            'Dim xx As String = tempS.Substring(16, 2)
            'Dim yy As String = tempS.Substring(32, 2)
            'Dim zz As String = tempS.Substring(40, 2)

            axisXstatus = ConvertHextoBi(tempS.Substring(8, 2))
            axisYstatus = ConvertHextoBi(tempS.Substring(24, 2))
            axisZstatus = ConvertHextoBi(tempS.Substring(40, 2))

            distanceX = (CDbl(ConvertHextoDec(tempS.Substring(16, 8))) / 1000).ToString
            distanceY = (CDbl(ConvertHextoDec(tempS.Substring(32, 8))) / 1000).ToString
            distanceZ = (CDbl(ConvertHextoDec(tempS.Substring(48, 8))) / 1000).ToString
            allResult = axisXstatus & "_" & distanceX & "_" & axisYstatus & "_" & distanceY & "_" & axisZstatus & "_" & distanceZ

        End If
        Return allResult

    End Function
    Function IAI_Reset_Error()

        Dim scHex As String = CheckSum("!0025B") ' Compute checksum
        Return "!0025B" + scHex + vbCr + vbLf
    End Function


#End Region




End Class
