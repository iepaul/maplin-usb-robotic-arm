<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnLightOn = New System.Windows.Forms.Button()
        Me.btnLightOff = New System.Windows.Forms.Button()
        Me.btnLeft = New System.Windows.Forms.Button()
        Me.btnRight = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnLightOn
        '
        Me.btnLightOn.Location = New System.Drawing.Point(13, 13)
        Me.btnLightOn.Name = "btnLightOn"
        Me.btnLightOn.Size = New System.Drawing.Size(75, 28)
        Me.btnLightOn.TabIndex = 0
        Me.btnLightOn.Text = "Light On"
        Me.btnLightOn.UseVisualStyleBackColor = True
        '
        'btnLightOff
        '
        Me.btnLightOff.Location = New System.Drawing.Point(195, 13)
        Me.btnLightOff.Name = "btnLightOff"
        Me.btnLightOff.Size = New System.Drawing.Size(75, 28)
        Me.btnLightOff.TabIndex = 1
        Me.btnLightOff.Text = "Light Off"
        Me.btnLightOff.UseVisualStyleBackColor = True
        '
        'btnLeft
        '
        Me.btnLeft.Location = New System.Drawing.Point(13, 112)
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Size = New System.Drawing.Size(38, 31)
        Me.btnLeft.TabIndex = 2
        Me.btnLeft.Text = "<"
        Me.btnLeft.UseVisualStyleBackColor = True
        '
        'btnRight
        '
        Me.btnRight.Location = New System.Drawing.Point(232, 112)
        Me.btnRight.Name = "btnRight"
        Me.btnRight.Size = New System.Drawing.Size(38, 31)
        Me.btnRight.TabIndex = 3
        Me.btnRight.Text = ">"
        Me.btnRight.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 255)
        Me.Controls.Add(Me.btnRight)
        Me.Controls.Add(Me.btnLeft)
        Me.Controls.Add(Me.btnLightOff)
        Me.Controls.Add(Me.btnLightOn)
        Me.Name = "frmMain"
        Me.Text = "Robot Arm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLightOn As System.Windows.Forms.Button
    Friend WithEvents btnLightOff As System.Windows.Forms.Button
    Friend WithEvents btnLeft As System.Windows.Forms.Button
    Friend WithEvents btnRight As System.Windows.Forms.Button
End Class
