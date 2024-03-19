<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_GetDistance
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
        Me.components = New System.ComponentModel.Container()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.gbDistance = New System.Windows.Forms.GroupBox()
        Me.rbEveryDistance = New System.Windows.Forms.RadioButton()
        Me.rbNearestDistance = New System.Windows.Forms.RadioButton()
        Me.btnObject = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnLatLon = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLayerObject = New System.Windows.Forms.Button()
        Me.lbList = New mandara10.ListBoxEx()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.cboScaleUnit = New mandara10.ComboBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbDistance.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(364, 232)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(284, 232)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'gbDistance
        '
        Me.gbDistance.Controls.Add(Me.Label2)
        Me.gbDistance.Controls.Add(Me.cboScaleUnit)
        Me.gbDistance.Controls.Add(Me.rbEveryDistance)
        Me.gbDistance.Controls.Add(Me.rbNearestDistance)
        Me.gbDistance.Location = New System.Drawing.Point(218, 28)
        Me.gbDistance.Name = "gbDistance"
        Me.gbDistance.Size = New System.Drawing.Size(208, 166)
        Me.gbDistance.TabIndex = 6
        Me.gbDistance.TabStop = False
        Me.gbDistance.Text = "距離取得方法"
        '
        'rbEveryDistance
        '
        Me.rbEveryDistance.Checked = True
        Me.rbEveryDistance.Location = New System.Drawing.Point(21, 72)
        Me.rbEveryDistance.Name = "rbEveryDistance"
        Me.rbEveryDistance.Size = New System.Drawing.Size(181, 33)
        Me.rbEveryDistance.TabIndex = 1
        Me.rbEveryDistance.TabStop = True
        Me.rbEveryDistance.Text = "取得元それぞれとの距離を取得"
        Me.rbEveryDistance.UseVisualStyleBackColor = True
        '
        'rbNearestDistance
        '
        Me.rbNearestDistance.Location = New System.Drawing.Point(21, 27)
        Me.rbNearestDistance.Name = "rbNearestDistance"
        Me.rbNearestDistance.Size = New System.Drawing.Size(170, 39)
        Me.rbNearestDistance.TabIndex = 0
        Me.rbNearestDistance.Text = "取得元からの距離のうち、最も近い距離を取得"
        Me.rbNearestDistance.UseVisualStyleBackColor = True
        '
        'btnObject
        '
        Me.btnObject.Location = New System.Drawing.Point(22, 239)
        Me.btnObject.Name = "btnObject"
        Me.btnObject.Size = New System.Drawing.Size(175, 24)
        Me.btnObject.TabIndex = 5
        Me.btnObject.Text = "地図ファイルオブジェクトから選択"
        Me.btnObject.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(137, 172)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 22)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "消去"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnLatLon
        '
        Me.btnLatLon.Location = New System.Drawing.Point(22, 170)
        Me.btnLatLon.Name = "btnLatLon"
        Me.btnLatLon.Size = New System.Drawing.Size(106, 24)
        Me.btnLatLon.TabIndex = 2
        Me.btnLatLon.Text = "緯度経度で指定"
        Me.btnLatLon.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "距離の取得元"
        '
        'btnLayerObject
        '
        Me.btnLayerObject.Location = New System.Drawing.Point(22, 203)
        Me.btnLayerObject.Name = "btnLayerObject"
        Me.btnLayerObject.Size = New System.Drawing.Size(175, 24)
        Me.btnLayerObject.TabIndex = 4
        Me.btnLayerObject.Text = "レイヤ内オブジェクトから選択"
        Me.btnLayerObject.UseVisualStyleBackColor = True
        '
        'lbList
        '
        Me.lbList.AsteriskSelectEnabled = False
        Me.lbList.FormattingEnabled = True
        Me.lbList.ItemHeight = 12
        Me.lbList.Location = New System.Drawing.Point(22, 28)
        Me.lbList.Name = "lbList"
        Me.lbList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbList.Size = New System.Drawing.Size(175, 136)
        Me.lbList.TabIndex = 1
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(227, 203)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(182, 20)
        Me.ProgressBar.TabIndex = 7
        '
        'cboScaleUnit
        '
        Me.cboScaleUnit.AsteriskSelectEnabled = False
        Me.cboScaleUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScaleUnit.FormattingEnabled = True
        Me.cboScaleUnit.IntegralHeight = False
        Me.cboScaleUnit.Location = New System.Drawing.Point(89, 125)
        Me.cboScaleUnit.Margin = New System.Windows.Forms.Padding(2)
        Me.cboScaleUnit.MaxDropDownItems = 15
        Me.cboScaleUnit.Name = "cboScaleUnit"
        Me.cboScaleUnit.Size = New System.Drawing.Size(72, 20)
        Me.cboScaleUnit.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "取得単位"
        '
        'frmMain_GetDistance
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(446, 275)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.btnLayerObject)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnLatLon)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lbList)
        Me.Controls.Add(Me.btnObject)
        Me.Controls.Add(Me.gbDistance)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_GetDistance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "距離測定"
        Me.gbDistance.ResumeLayout(False)
        Me.gbDistance.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents gbDistance As System.Windows.Forms.GroupBox
    Friend WithEvents rbEveryDistance As System.Windows.Forms.RadioButton
    Friend WithEvents rbNearestDistance As System.Windows.Forms.RadioButton
    Friend WithEvents btnObject As System.Windows.Forms.Button
    Friend WithEvents lbList As mandara10.ListBoxEx
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnLatLon As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLayerObject As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboScaleUnit As mandara10.ComboBoxEx
End Class
