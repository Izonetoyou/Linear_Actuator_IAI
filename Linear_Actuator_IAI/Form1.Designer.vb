<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ChkShoPosi = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Speedtextbox = New System.Windows.Forms.TextBox()
        Me.lblZPosition = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.lblYPosition = New System.Windows.Forms.Label()
        Me.lblXPosition = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CboStep_Pos_IAI = New System.Windows.Forms.ComboBox()
        Me.BtY_P_MOVE = New System.Windows.Forms.Button()
        Me.BtY_N_MOVE = New System.Windows.Forms.Button()
        Me.lbStatusZ = New System.Windows.Forms.Label()
        Me.lbStatusX = New System.Windows.Forms.Label()
        Me.lbStatusY = New System.Windows.Forms.Label()
        Me.BtHome_IAI = New System.Windows.Forms.Button()
        Me.BtEnable_IAI = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusIAI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Lb_code = New System.Windows.Forms.Label()
        Me.Lb_Case = New System.Windows.Forms.Label()
        Me.Lb_Action = New System.Windows.Forms.Label()
        Me.TimerIAI = New System.Windows.Forms.Timer(Me.components)
        Me.SpeedTeackbar = New System.Windows.Forms.TrackBar()
        Me.LbStatusDisplay = New System.Windows.Forms.Label()
        Me.BtCon_IAI = New System.Windows.Forms.Button()
        Me.bt_jogorfast = New System.Windows.Forms.Button()
        Me.Bt_reset = New System.Windows.Forms.Button()
        Me.BtX_P_MOVE = New System.Windows.Forms.Button()
        Me.BtX_N_MOVE = New System.Windows.Forms.Button()
        Me.BtZ_N_MOVE = New System.Windows.Forms.Button()
        Me.BtZ_P_MOVE = New System.Windows.Forms.Button()
        Me.txt_P1_X = New System.Windows.Forms.TextBox()
        Me.txt_P1_Y = New System.Windows.Forms.TextBox()
        Me.txt_P2_X = New System.Windows.Forms.TextBox()
        Me.txt_P2_Y = New System.Windows.Forms.TextBox()
        Me.bt_P1 = New System.Windows.Forms.Button()
        Me.bt_P2 = New System.Windows.Forms.Button()
        Me.txt_P2_Z = New System.Windows.Forms.TextBox()
        Me.txt_P1_Z = New System.Windows.Forms.TextBox()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SpeedTeackbar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChkShoPosi
        '
        Me.ChkShoPosi.AutoSize = True
        Me.ChkShoPosi.Location = New System.Drawing.Point(169, 96)
        Me.ChkShoPosi.Name = "ChkShoPosi"
        Me.ChkShoPosi.Size = New System.Drawing.Size(93, 17)
        Me.ChkShoPosi.TabIndex = 200
        Me.ChkShoPosi.Text = "Show Position"
        Me.ChkShoPosi.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.Location = New System.Drawing.Point(18, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 15)
        Me.Label11.TabIndex = 196
        Me.Label11.Text = "Speed"
        '
        'Speedtextbox
        '
        Me.Speedtextbox.Location = New System.Drawing.Point(67, 94)
        Me.Speedtextbox.Name = "Speedtextbox"
        Me.Speedtextbox.Size = New System.Drawing.Size(82, 20)
        Me.Speedtextbox.TabIndex = 195
        Me.Speedtextbox.Text = "700"
        '
        'lblZPosition
        '
        Me.lblZPosition.AutoSize = True
        Me.lblZPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblZPosition.Location = New System.Drawing.Point(187, 289)
        Me.lblZPosition.Name = "lblZPosition"
        Me.lblZPosition.Size = New System.Drawing.Size(15, 16)
        Me.lblZPosition.TabIndex = 199
        Me.lblZPosition.Text = "0"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label34.Location = New System.Drawing.Point(93, 289)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(88, 16)
        Me.Label34.TabIndex = 198
        Me.Label34.Text = "POSITION Z :"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label53.Location = New System.Drawing.Point(93, 266)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(89, 16)
        Me.Label53.TabIndex = 193
        Me.Label53.Text = "POSITION Y :"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label52.Location = New System.Drawing.Point(93, 245)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(88, 16)
        Me.Label52.TabIndex = 192
        Me.Label52.Text = "POSITION X :"
        '
        'lblYPosition
        '
        Me.lblYPosition.AutoSize = True
        Me.lblYPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblYPosition.Location = New System.Drawing.Point(187, 266)
        Me.lblYPosition.Name = "lblYPosition"
        Me.lblYPosition.Size = New System.Drawing.Size(15, 16)
        Me.lblYPosition.TabIndex = 191
        Me.lblYPosition.Text = "0"
        '
        'lblXPosition
        '
        Me.lblXPosition.AutoSize = True
        Me.lblXPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblXPosition.Location = New System.Drawing.Point(187, 245)
        Me.lblXPosition.Name = "lblXPosition"
        Me.lblXPosition.Size = New System.Drawing.Size(15, 16)
        Me.lblXPosition.TabIndex = 190
        Me.lblXPosition.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label19.Location = New System.Drawing.Point(24, 209)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(66, 16)
        Me.Label19.TabIndex = 189
        Me.Label19.Text = "Step SET"
        '
        'CboStep_Pos_IAI
        '
        Me.CboStep_Pos_IAI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboStep_Pos_IAI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CboStep_Pos_IAI.FormattingEnabled = True
        Me.CboStep_Pos_IAI.Items.AddRange(New Object() {"0.05", "0.1", "0.2", "0.5", "1", "2", "5", "10", "20", "50", "100"})
        Me.CboStep_Pos_IAI.Location = New System.Drawing.Point(96, 207)
        Me.CboStep_Pos_IAI.Name = "CboStep_Pos_IAI"
        Me.CboStep_Pos_IAI.Size = New System.Drawing.Size(99, 24)
        Me.CboStep_Pos_IAI.TabIndex = 188
        '
        'BtY_P_MOVE
        '
        Me.BtY_P_MOVE.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtY_P_MOVE.Location = New System.Drawing.Point(388, 176)
        Me.BtY_P_MOVE.Name = "BtY_P_MOVE"
        Me.BtY_P_MOVE.Size = New System.Drawing.Size(110, 37)
        Me.BtY_P_MOVE.TabIndex = 6
        Me.BtY_P_MOVE.Tag = "Y"
        Me.BtY_P_MOVE.Text = "Y Jog +"
        Me.BtY_P_MOVE.UseVisualStyleBackColor = False
        '
        'BtY_N_MOVE
        '
        Me.BtY_N_MOVE.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtY_N_MOVE.Location = New System.Drawing.Point(388, 255)
        Me.BtY_N_MOVE.Name = "BtY_N_MOVE"
        Me.BtY_N_MOVE.Size = New System.Drawing.Size(110, 37)
        Me.BtY_N_MOVE.TabIndex = 7
        Me.BtY_N_MOVE.Tag = "Y"
        Me.BtY_N_MOVE.Text = "Y Jog -"
        Me.BtY_N_MOVE.UseVisualStyleBackColor = False
        '
        'lbStatusZ
        '
        Me.lbStatusZ.AutoSize = True
        Me.lbStatusZ.Location = New System.Drawing.Point(583, 149)
        Me.lbStatusZ.Name = "lbStatusZ"
        Me.lbStatusZ.Size = New System.Drawing.Size(14, 13)
        Me.lbStatusZ.TabIndex = 206
        Me.lbStatusZ.Text = "Z"
        '
        'lbStatusX
        '
        Me.lbStatusX.AutoSize = True
        Me.lbStatusX.Location = New System.Drawing.Point(285, 149)
        Me.lbStatusX.Name = "lbStatusX"
        Me.lbStatusX.Size = New System.Drawing.Size(14, 13)
        Me.lbStatusX.TabIndex = 204
        Me.lbStatusX.Text = "X"
        '
        'lbStatusY
        '
        Me.lbStatusY.AutoSize = True
        Me.lbStatusY.Location = New System.Drawing.Point(432, 149)
        Me.lbStatusY.Name = "lbStatusY"
        Me.lbStatusY.Size = New System.Drawing.Size(14, 13)
        Me.lbStatusY.TabIndex = 203
        Me.lbStatusY.Text = "Y"
        '
        'BtHome_IAI
        '
        Me.BtHome_IAI.BackColor = System.Drawing.Color.Yellow
        Me.BtHome_IAI.Location = New System.Drawing.Point(315, 12)
        Me.BtHome_IAI.Name = "BtHome_IAI"
        Me.BtHome_IAI.Size = New System.Drawing.Size(142, 66)
        Me.BtHome_IAI.TabIndex = 2
        Me.BtHome_IAI.Text = "HOME"
        Me.BtHome_IAI.UseVisualStyleBackColor = False
        '
        'BtEnable_IAI
        '
        Me.BtEnable_IAI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BtEnable_IAI.Location = New System.Drawing.Point(169, 12)
        Me.BtEnable_IAI.Name = "BtEnable_IAI"
        Me.BtEnable_IAI.Size = New System.Drawing.Size(140, 66)
        Me.BtEnable_IAI.TabIndex = 1
        Me.BtEnable_IAI.Text = "Enable"
        Me.BtEnable_IAI.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusIAI})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 545)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(696, 22)
        Me.StatusStrip1.TabIndex = 207
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusIAI
        '
        Me.ToolStripStatusIAI.Name = "ToolStripStatusIAI"
        Me.ToolStripStatusIAI.Size = New System.Drawing.Size(21, 17)
        Me.ToolStripStatusIAI.Text = "IAI"
        '
        'Lb_code
        '
        Me.Lb_code.AutoSize = True
        Me.Lb_code.Location = New System.Drawing.Point(20, 433)
        Me.Lb_code.Name = "Lb_code"
        Me.Lb_code.Size = New System.Drawing.Size(32, 13)
        Me.Lb_code.TabIndex = 208
        Me.Lb_code.Text = "Code"
        '
        'Lb_Case
        '
        Me.Lb_Case.AutoSize = True
        Me.Lb_Case.Location = New System.Drawing.Point(20, 458)
        Me.Lb_Case.Name = "Lb_Case"
        Me.Lb_Case.Size = New System.Drawing.Size(31, 13)
        Me.Lb_Case.TabIndex = 209
        Me.Lb_Case.Text = "Case"
        '
        'Lb_Action
        '
        Me.Lb_Action.AutoSize = True
        Me.Lb_Action.Location = New System.Drawing.Point(20, 486)
        Me.Lb_Action.Name = "Lb_Action"
        Me.Lb_Action.Size = New System.Drawing.Size(37, 13)
        Me.Lb_Action.TabIndex = 210
        Me.Lb_Action.Text = "Action"
        '
        'TimerIAI
        '
        Me.TimerIAI.Interval = 80
        '
        'SpeedTeackbar
        '
        Me.SpeedTeackbar.Location = New System.Drawing.Point(23, 120)
        Me.SpeedTeackbar.Maximum = 1000
        Me.SpeedTeackbar.Minimum = 100
        Me.SpeedTeackbar.Name = "SpeedTeackbar"
        Me.SpeedTeackbar.Size = New System.Drawing.Size(126, 45)
        Me.SpeedTeackbar.TabIndex = 211
        Me.SpeedTeackbar.Value = 100
        '
        'LbStatusDisplay
        '
        Me.LbStatusDisplay.AutoSize = True
        Me.LbStatusDisplay.Location = New System.Drawing.Point(20, 398)
        Me.LbStatusDisplay.Name = "LbStatusDisplay"
        Me.LbStatusDisplay.Size = New System.Drawing.Size(71, 13)
        Me.LbStatusDisplay.TabIndex = 213
        Me.LbStatusDisplay.Text = "StatusDisplay"
        '
        'BtCon_IAI
        '
        Me.BtCon_IAI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BtCon_IAI.Location = New System.Drawing.Point(23, 12)
        Me.BtCon_IAI.Name = "BtCon_IAI"
        Me.BtCon_IAI.Size = New System.Drawing.Size(140, 66)
        Me.BtCon_IAI.TabIndex = 0
        Me.BtCon_IAI.Text = "Connect"
        Me.BtCon_IAI.UseVisualStyleBackColor = True
        '
        'bt_jogorfast
        '
        Me.bt_jogorfast.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.bt_jogorfast.Location = New System.Drawing.Point(96, 176)
        Me.bt_jogorfast.Name = "bt_jogorfast"
        Me.bt_jogorfast.Size = New System.Drawing.Size(99, 25)
        Me.bt_jogorfast.TabIndex = 214
        Me.bt_jogorfast.Text = "Fast"
        Me.bt_jogorfast.UseVisualStyleBackColor = True
        '
        'Bt_reset
        '
        Me.Bt_reset.BackColor = System.Drawing.Color.GreenYellow
        Me.Bt_reset.Location = New System.Drawing.Point(475, 12)
        Me.Bt_reset.Name = "Bt_reset"
        Me.Bt_reset.Size = New System.Drawing.Size(142, 66)
        Me.Bt_reset.TabIndex = 3
        Me.Bt_reset.Text = "Reset"
        Me.Bt_reset.UseVisualStyleBackColor = False
        '
        'BtX_P_MOVE
        '
        Me.BtX_P_MOVE.Location = New System.Drawing.Point(253, 177)
        Me.BtX_P_MOVE.Name = "BtX_P_MOVE"
        Me.BtX_P_MOVE.Size = New System.Drawing.Size(105, 36)
        Me.BtX_P_MOVE.TabIndex = 4
        Me.BtX_P_MOVE.TabStop = False
        Me.BtX_P_MOVE.Tag = "X"
        Me.BtX_P_MOVE.Text = "X Jog +"
        Me.BtX_P_MOVE.UseVisualStyleBackColor = True
        '
        'BtX_N_MOVE
        '
        Me.BtX_N_MOVE.Location = New System.Drawing.Point(253, 256)
        Me.BtX_N_MOVE.Name = "BtX_N_MOVE"
        Me.BtX_N_MOVE.Size = New System.Drawing.Size(105, 36)
        Me.BtX_N_MOVE.TabIndex = 5
        Me.BtX_N_MOVE.Tag = "X"
        Me.BtX_N_MOVE.Text = "X Jog -"
        Me.BtX_N_MOVE.UseVisualStyleBackColor = True
        '
        'BtZ_N_MOVE
        '
        Me.BtZ_N_MOVE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtZ_N_MOVE.Location = New System.Drawing.Point(538, 255)
        Me.BtZ_N_MOVE.Name = "BtZ_N_MOVE"
        Me.BtZ_N_MOVE.Size = New System.Drawing.Size(110, 37)
        Me.BtZ_N_MOVE.TabIndex = 216
        Me.BtZ_N_MOVE.Tag = "Z"
        Me.BtZ_N_MOVE.Text = "Z Jog -"
        Me.BtZ_N_MOVE.UseVisualStyleBackColor = False
        '
        'BtZ_P_MOVE
        '
        Me.BtZ_P_MOVE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtZ_P_MOVE.Location = New System.Drawing.Point(538, 176)
        Me.BtZ_P_MOVE.Name = "BtZ_P_MOVE"
        Me.BtZ_P_MOVE.Size = New System.Drawing.Size(110, 37)
        Me.BtZ_P_MOVE.TabIndex = 215
        Me.BtZ_P_MOVE.Tag = "Z"
        Me.BtZ_P_MOVE.Text = "Z Jog +"
        Me.BtZ_P_MOVE.UseVisualStyleBackColor = False
        '
        'txt_P1_X
        '
        Me.txt_P1_X.Location = New System.Drawing.Point(267, 334)
        Me.txt_P1_X.Name = "txt_P1_X"
        Me.txt_P1_X.Size = New System.Drawing.Size(82, 20)
        Me.txt_P1_X.TabIndex = 217
        Me.txt_P1_X.Text = "100"
        '
        'txt_P1_Y
        '
        Me.txt_P1_Y.Location = New System.Drawing.Point(401, 334)
        Me.txt_P1_Y.Name = "txt_P1_Y"
        Me.txt_P1_Y.Size = New System.Drawing.Size(82, 20)
        Me.txt_P1_Y.TabIndex = 218
        Me.txt_P1_Y.Text = "19"
        '
        'txt_P2_X
        '
        Me.txt_P2_X.Location = New System.Drawing.Point(267, 360)
        Me.txt_P2_X.Name = "txt_P2_X"
        Me.txt_P2_X.Size = New System.Drawing.Size(82, 20)
        Me.txt_P2_X.TabIndex = 219
        Me.txt_P2_X.Text = "350"
        '
        'txt_P2_Y
        '
        Me.txt_P2_Y.Location = New System.Drawing.Point(401, 360)
        Me.txt_P2_Y.Name = "txt_P2_Y"
        Me.txt_P2_Y.Size = New System.Drawing.Size(82, 20)
        Me.txt_P2_Y.TabIndex = 220
        Me.txt_P2_Y.Text = "5"
        '
        'bt_P1
        '
        Me.bt_P1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.bt_P1.Location = New System.Drawing.Point(162, 329)
        Me.bt_P1.Name = "bt_P1"
        Me.bt_P1.Size = New System.Drawing.Size(99, 25)
        Me.bt_P1.TabIndex = 221
        Me.bt_P1.Text = "P1"
        Me.bt_P1.UseVisualStyleBackColor = True
        '
        'bt_P2
        '
        Me.bt_P2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.bt_P2.Location = New System.Drawing.Point(163, 360)
        Me.bt_P2.Name = "bt_P2"
        Me.bt_P2.Size = New System.Drawing.Size(99, 25)
        Me.bt_P2.TabIndex = 222
        Me.bt_P2.Text = "P2"
        Me.bt_P2.UseVisualStyleBackColor = True
        '
        'txt_P2_Z
        '
        Me.txt_P2_Z.Location = New System.Drawing.Point(535, 355)
        Me.txt_P2_Z.Name = "txt_P2_Z"
        Me.txt_P2_Z.Size = New System.Drawing.Size(82, 20)
        Me.txt_P2_Z.TabIndex = 224
        Me.txt_P2_Z.Text = "5"
        '
        'txt_P1_Z
        '
        Me.txt_P1_Z.Location = New System.Drawing.Point(535, 329)
        Me.txt_P1_Z.Name = "txt_P1_Z"
        Me.txt_P1_Z.Size = New System.Drawing.Size(82, 20)
        Me.txt_P1_Z.TabIndex = 223
        Me.txt_P1_Z.Text = "19"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 567)
        Me.Controls.Add(Me.txt_P2_Z)
        Me.Controls.Add(Me.txt_P1_Z)
        Me.Controls.Add(Me.bt_P2)
        Me.Controls.Add(Me.bt_P1)
        Me.Controls.Add(Me.txt_P2_Y)
        Me.Controls.Add(Me.txt_P2_X)
        Me.Controls.Add(Me.txt_P1_Y)
        Me.Controls.Add(Me.txt_P1_X)
        Me.Controls.Add(Me.BtZ_N_MOVE)
        Me.Controls.Add(Me.BtZ_P_MOVE)
        Me.Controls.Add(Me.BtX_N_MOVE)
        Me.Controls.Add(Me.BtX_P_MOVE)
        Me.Controls.Add(Me.Bt_reset)
        Me.Controls.Add(Me.BtCon_IAI)
        Me.Controls.Add(Me.bt_jogorfast)
        Me.Controls.Add(Me.BtEnable_IAI)
        Me.Controls.Add(Me.LbStatusDisplay)
        Me.Controls.Add(Me.SpeedTeackbar)
        Me.Controls.Add(Me.Lb_Action)
        Me.Controls.Add(Me.Lb_Case)
        Me.Controls.Add(Me.Lb_code)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lbStatusZ)
        Me.Controls.Add(Me.lbStatusX)
        Me.Controls.Add(Me.lbStatusY)
        Me.Controls.Add(Me.BtHome_IAI)
        Me.Controls.Add(Me.ChkShoPosi)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BtY_N_MOVE)
        Me.Controls.Add(Me.Speedtextbox)
        Me.Controls.Add(Me.BtY_P_MOVE)
        Me.Controls.Add(Me.CboStep_Pos_IAI)
        Me.Controls.Add(Me.lblZPosition)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lblXPosition)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.lblYPosition)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label53)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.SpeedTeackbar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChkShoPosi As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Speedtextbox As TextBox
    Friend WithEvents lblZPosition As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents lblYPosition As Label
    Friend WithEvents lblXPosition As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents CboStep_Pos_IAI As ComboBox
    Friend WithEvents BtY_P_MOVE As Button
    Friend WithEvents BtY_N_MOVE As Button
    Friend WithEvents lbStatusZ As Label
    Friend WithEvents lbStatusX As Label
    Friend WithEvents lbStatusY As Label
    Friend WithEvents BtHome_IAI As Button
    Friend WithEvents BtEnable_IAI As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusIAI As ToolStripStatusLabel
    Friend WithEvents Lb_code As Label
    Friend WithEvents Lb_Case As Label
    Friend WithEvents Lb_Action As Label
    Friend WithEvents TimerIAI As Timer
    Friend WithEvents SpeedTeackbar As TrackBar
    Friend WithEvents LbStatusDisplay As Label
    Friend WithEvents BtCon_IAI As Button
    Friend WithEvents bt_jogorfast As Button
    Friend WithEvents Bt_reset As Button
    Friend WithEvents BtX_P_MOVE As Button
    Friend WithEvents BtX_N_MOVE As Button
    Friend WithEvents BtZ_N_MOVE As Button
    Friend WithEvents BtZ_P_MOVE As Button
    Friend WithEvents txt_P1_X As TextBox
    Friend WithEvents txt_P1_Y As TextBox
    Friend WithEvents txt_P2_X As TextBox
    Friend WithEvents txt_P2_Y As TextBox
    Friend WithEvents bt_P1 As Button
    Friend WithEvents bt_P2 As Button
    Friend WithEvents txt_P2_Z As TextBox
    Friend WithEvents txt_P1_Z As TextBox
End Class
