<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.cboConnections = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.cmdGetConnection = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'cboConnections
        '
        Me.cboConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConnections.FormattingEnabled = true
        Me.cboConnections.Location = New System.Drawing.Point(35, 55)
        Me.cboConnections.Margin = New System.Windows.Forms.Padding(2)
        Me.cboConnections.Name = "cboConnections"
        Me.cboConnections.Size = New System.Drawing.Size(218, 21)
        Me.cboConnections.TabIndex = 4
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = true
        Me.ComboBox1.Location = New System.Drawing.Point(77, 103)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(176, 21)
        Me.ComboBox1.TabIndex = 6
        '
        'cmdGetConnection
        '
        Me.cmdGetConnection.Location = New System.Drawing.Point(320, 57)
        Me.cmdGetConnection.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdGetConnection.Name = "cmdGetConnection"
        Me.cmdGetConnection.Size = New System.Drawing.Size(114, 19)
        Me.cmdGetConnection.TabIndex = 7
        Me.cmdGetConnection.Text = "Get current"
        Me.cmdGetConnection.UseVisualStyleBackColor = true
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(320, 81)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdGetConnection)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.cboConnections)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cboConnections As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents cmdGetConnection As Button
    Friend WithEvents Button1 As Button
End Class
