<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMED_Show_Object_Time_Series
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnTommorow = New System.Windows.Forms.Button()
        Me.btnYesterday = New System.Windows.Forms.Button()
        Me.btnAfterEvent = New System.Windows.Forms.Button()
        Me.btnBeforeEvent = New System.Windows.Forms.Button()
        Me.dbdtpTime = New mandara10.DbDateTimePicker()
        Me.cbEventTime = New mandara10.ComboBoxEx()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnAllShow = New System.Windows.Forms.Button()
        Me.picMap = New System.Windows.Forms.PictureBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lvTimeSeries = New mandara10.ListViewEX()
        Me.lbDefAttr = New mandara10.ListViewEX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(644, 69)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 26)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "戻る"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnTommorow)
        Me.GroupBox1.Controls.Add(Me.btnYesterday)
        Me.GroupBox1.Controls.Add(Me.btnAfterEvent)
        Me.GroupBox1.Controls.Add(Me.btnBeforeEvent)
        Me.GroupBox1.Controls.Add(Me.dbdtpTime)
        Me.GroupBox1.Controls.Add(Me.cbEventTime)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 96)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "表示時期"
        '
        'btnTommorow
        '
        Me.btnTommorow.Location = New System.Drawing.Point(251, 20)
        Me.btnTommorow.Name = "btnTommorow"
        Me.btnTommorow.Size = New System.Drawing.Size(55, 19)
        Me.btnTommorow.TabIndex = 2
        Me.btnTommorow.Text = "翌日"
        Me.btnTommorow.UseVisualStyleBackColor = True
        '
        'btnYesterday
        '
        Me.btnYesterday.Location = New System.Drawing.Point(190, 20)
        Me.btnYesterday.Name = "btnYesterday"
        Me.btnYesterday.Size = New System.Drawing.Size(55, 19)
        Me.btnYesterday.TabIndex = 1
        Me.btnYesterday.Text = "前日"
        Me.btnYesterday.UseVisualStyleBackColor = True
        '
        'btnAfterEvent
        '
        Me.btnAfterEvent.Location = New System.Drawing.Point(113, 69)
        Me.btnAfterEvent.Name = "btnAfterEvent"
        Me.btnAfterEvent.Size = New System.Drawing.Size(91, 19)
        Me.btnAfterEvent.TabIndex = 5
        Me.btnAfterEvent.Text = "次のイベント日"
        Me.btnAfterEvent.UseVisualStyleBackColor = True
        '
        'btnBeforeEvent
        '
        Me.btnBeforeEvent.Location = New System.Drawing.Point(16, 69)
        Me.btnBeforeEvent.Name = "btnBeforeEvent"
        Me.btnBeforeEvent.Size = New System.Drawing.Size(91, 19)
        Me.btnBeforeEvent.TabIndex = 4
        Me.btnBeforeEvent.Text = "前のイベント日"
        Me.btnBeforeEvent.UseVisualStyleBackColor = True
        '
        'dbdtpTime
        '
        Me.dbdtpTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dbdtpTime.Location = New System.Drawing.Point(16, 18)
        Me.dbdtpTime.Name = "dbdtpTime"
        Me.dbdtpTime.ShowCheckBox = True
        Me.dbdtpTime.Size = New System.Drawing.Size(168, 19)
        Me.dbdtpTime.TabIndex = 0
        '
        'cbEventTime
        '
        Me.cbEventTime.AsteriskSelectEnabled = False
        Me.cbEventTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEventTime.FormattingEnabled = True
        Me.cbEventTime.IntegralHeight = False
        Me.cbEventTime.Location = New System.Drawing.Point(16, 43)
        Me.cbEventTime.Name = "cbEventTime"
        Me.cbEventTime.Size = New System.Drawing.Size(168, 20)
        Me.cbEventTime.TabIndex = 3
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnAllShow)
        Me.SplitContainer1.Panel1.Controls.Add(Me.picMap)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(754, 456)
        Me.SplitContainer1.SplitterDistance = 332
        Me.SplitContainer1.TabIndex = 0
        '
        'btnAllShow
        '
        Me.btnAllShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAllShow.Location = New System.Drawing.Point(3, 430)
        Me.btnAllShow.Name = "btnAllShow"
        Me.btnAllShow.Size = New System.Drawing.Size(65, 23)
        Me.btnAllShow.TabIndex = 0
        Me.btnAllShow.Text = "全体表示"
        Me.btnAllShow.UseVisualStyleBackColor = True
        '
        'picMap
        '
        Me.picMap.BackColor = System.Drawing.Color.White
        Me.picMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picMap.Location = New System.Drawing.Point(0, 0)
        Me.picMap.Name = "picMap"
        Me.picMap.Size = New System.Drawing.Size(332, 456)
        Me.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picMap.TabIndex = 1
        Me.picMap.TabStop = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.lvTimeSeries)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.lbDefAttr)
        Me.SplitContainer2.Size = New System.Drawing.Size(418, 456)
        Me.SplitContainer2.SplitterDistance = 245
        Me.SplitContainer2.TabIndex = 0
        '
        'lvTimeSeries
        '
        Me.lvTimeSeries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvTimeSeries.GridLines = True
        Me.lvTimeSeries.Location = New System.Drawing.Point(0, 0)
        Me.lvTimeSeries.Name = "lvTimeSeries"
        Me.lvTimeSeries.Size = New System.Drawing.Size(418, 245)
        Me.lvTimeSeries.TabIndex = 0
        Me.lvTimeSeries.UseCompatibleStateImageBehavior = False
        Me.lvTimeSeries.View = System.Windows.Forms.View.Details
        '
        'lbDefAttr
        '
        Me.lbDefAttr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbDefAttr.GridLines = True
        Me.lbDefAttr.Location = New System.Drawing.Point(0, 0)
        Me.lbDefAttr.Name = "lbDefAttr"
        Me.lbDefAttr.Size = New System.Drawing.Size(418, 207)
        Me.lbDefAttr.TabIndex = 1
        Me.lbDefAttr.UseCompatibleStateImageBehavior = False
        Me.lbDefAttr.View = System.Windows.Forms.View.Details
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 456)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(754, 112)
        Me.Panel1.TabIndex = 1
        '
        'frmMED_Show_Object_Time_Series
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(754, 568)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMED_Show_Object_Time_Series"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オブジェクトの時間変化"
        Me.GroupBox1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbEventTime As mandara10.ComboBoxEx
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents lvTimeSeries As mandara10.ListViewEX
    Friend WithEvents dbdtpTime As mandara10.DbDateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAllShow As System.Windows.Forms.Button
    Friend WithEvents btnTommorow As System.Windows.Forms.Button
    Friend WithEvents btnYesterday As System.Windows.Forms.Button
    Friend WithEvents btnAfterEvent As System.Windows.Forms.Button
    Friend WithEvents btnBeforeEvent As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents lbDefAttr As mandara10.ListViewEX
End Class
