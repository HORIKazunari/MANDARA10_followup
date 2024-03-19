<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint_PrintOut
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnPrinterSettings = New System.Windows.Forms.Button()
        Me.lblPrinter = New System.Windows.Forms.Label()
        Me.picOuter = New System.Windows.Forms.PictureBox()
        Me.picPaper = New System.Windows.Forms.PictureBox()
        Me.picPrintArea = New System.Windows.Forms.PictureBox()
        Me.picMapArea = New System.Windows.Forms.PictureBox()
        Me.gbSize = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSize = New System.Windows.Forms.ComboBox()
        CType(Me.picOuter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPaper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPrintArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMapArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSize.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnPrint.Location = New System.Drawing.Point(349, 244)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(83, 30)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(349, 296)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 30)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnPrinterSettings
        '
        Me.btnPrinterSettings.Location = New System.Drawing.Point(364, 16)
        Me.btnPrinterSettings.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPrinterSettings.Name = "btnPrinterSettings"
        Me.btnPrinterSettings.Size = New System.Drawing.Size(93, 30)
        Me.btnPrinterSettings.TabIndex = 2
        Me.btnPrinterSettings.Text = "プリンタ設定"
        Me.btnPrinterSettings.UseVisualStyleBackColor = True
        '
        'lblPrinter
        '
        Me.lblPrinter.BackColor = System.Drawing.Color.White
        Me.lblPrinter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrinter.Location = New System.Drawing.Point(17, 16)
        Me.lblPrinter.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPrinter.Name = "lblPrinter"
        Me.lblPrinter.Size = New System.Drawing.Size(331, 26)
        Me.lblPrinter.TabIndex = 3
        Me.lblPrinter.Text = "Label1"
        '
        'picOuter
        '
        Me.picOuter.Location = New System.Drawing.Point(25, 64)
        Me.picOuter.Margin = New System.Windows.Forms.Padding(4)
        Me.picOuter.Name = "picOuter"
        Me.picOuter.Size = New System.Drawing.Size(280, 262)
        Me.picOuter.TabIndex = 4
        Me.picOuter.TabStop = False
        '
        'picPaper
        '
        Me.picPaper.BackColor = System.Drawing.Color.White
        Me.picPaper.Location = New System.Drawing.Point(48, 78)
        Me.picPaper.Margin = New System.Windows.Forms.Padding(4)
        Me.picPaper.Name = "picPaper"
        Me.picPaper.Size = New System.Drawing.Size(205, 222)
        Me.picPaper.TabIndex = 5
        Me.picPaper.TabStop = False
        '
        'picPrintArea
        '
        Me.picPrintArea.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.picPrintArea.Location = New System.Drawing.Point(73, 98)
        Me.picPrintArea.Margin = New System.Windows.Forms.Padding(4)
        Me.picPrintArea.Name = "picPrintArea"
        Me.picPrintArea.Size = New System.Drawing.Size(133, 176)
        Me.picPrintArea.TabIndex = 6
        Me.picPrintArea.TabStop = False
        '
        'picMapArea
        '
        Me.picMapArea.BackColor = System.Drawing.Color.White
        Me.picMapArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picMapArea.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picMapArea.Location = New System.Drawing.Point(101, 146)
        Me.picMapArea.Margin = New System.Windows.Forms.Padding(4)
        Me.picMapArea.Name = "picMapArea"
        Me.picMapArea.Size = New System.Drawing.Size(67, 50)
        Me.picMapArea.TabIndex = 7
        Me.picMapArea.TabStop = False
        '
        'gbSize
        '
        Me.gbSize.Controls.Add(Me.Label1)
        Me.gbSize.Controls.Add(Me.cboSize)
        Me.gbSize.Location = New System.Drawing.Point(313, 64)
        Me.gbSize.Margin = New System.Windows.Forms.Padding(4)
        Me.gbSize.Name = "gbSize"
        Me.gbSize.Padding = New System.Windows.Forms.Padding(4)
        Me.gbSize.Size = New System.Drawing.Size(144, 78)
        Me.gbSize.TabIndex = 8
        Me.gbSize.TabStop = False
        Me.gbSize.Text = "サイズ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(112, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "%"
        '
        'cboSize
        '
        Me.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSize.FormattingEnabled = True
        Me.cboSize.Location = New System.Drawing.Point(36, 29)
        Me.cboSize.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSize.Name = "cboSize"
        Me.cboSize.Size = New System.Drawing.Size(68, 23)
        Me.cboSize.TabIndex = 0
        '
        'frmPrint_PrintOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(465, 341)
        Me.Controls.Add(Me.gbSize)
        Me.Controls.Add(Me.picMapArea)
        Me.Controls.Add(Me.picPrintArea)
        Me.Controls.Add(Me.picPaper)
        Me.Controls.Add(Me.picOuter)
        Me.Controls.Add(Me.lblPrinter)
        Me.Controls.Add(Me.btnPrinterSettings)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnPrint)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint_PrintOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "印刷"
        CType(Me.picOuter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPaper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPrintArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMapArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSize.ResumeLayout(False)
        Me.gbSize.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnPrinterSettings As System.Windows.Forms.Button
    Friend WithEvents lblPrinter As System.Windows.Forms.Label
    Friend WithEvents picOuter As System.Windows.Forms.PictureBox
    Friend WithEvents picPaper As System.Windows.Forms.PictureBox
    Friend WithEvents picPrintArea As System.Windows.Forms.PictureBox
    Friend WithEvents picMapArea As System.Windows.Forms.PictureBox
    Friend WithEvents gbSize As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSize As System.Windows.Forms.ComboBox
End Class
