<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_Cross
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain_Cross))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboLayer = New mandara10.ComboBoxEx()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboZData = New mandara10.ComboBoxEx()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbData = New System.Windows.Forms.RadioButton()
        Me.rbHorizontalData = New System.Windows.Forms.RadioButton()
        Me.rbObjectList = New System.Windows.Forms.RadioButton()
        Me.rbObjNumber = New System.Windows.Forms.RadioButton()
        Me.chkConditionUse = New System.Windows.Forms.CheckBox()
        Me.btnVerticalIn = New System.Windows.Forms.Button()
        Me.btnHorizonalIn = New System.Windows.Forms.Button()
        Me.btnVerticalOut = New System.Windows.Forms.Button()
        Me.btnHorizonalOut = New System.Windows.Forms.Button()
        Me.gbHorizonalData = New System.Windows.Forms.GroupBox()
        Me.rbHObjectNumber = New System.Windows.Forms.RadioButton()
        Me.rbHStandard = New System.Windows.Forms.RadioButton()
        Me.rbHAverage = New System.Windows.Forms.RadioButton()
        Me.rbHSum = New System.Windows.Forms.RadioButton()
        Me.gbData = New System.Windows.Forms.GroupBox()
        Me.rbDValue = New System.Windows.Forms.RadioButton()
        Me.cboData = New mandara10.ComboBoxEx()
        Me.rbDobjectNumber = New System.Windows.Forms.RadioButton()
        Me.rbDStandard = New System.Windows.Forms.RadioButton()
        Me.rbDAverage = New System.Windows.Forms.RadioButton()
        Me.rbDSum = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbHorizonalData = New mandara10.ListBoxEx()
        Me.lbVerticalData = New mandara10.ListBoxEx()
        Me.lbOriginData = New mandara10.ListBoxEx()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbHorizonalData.SuspendLayout()
        Me.gbData.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(384, 567)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "終了"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(306, 567)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "集計"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(262, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "縦方向"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboLayer)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(197, 55)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "レイヤ"
        '
        'cboLayer
        '
        Me.cboLayer.AsteriskSelectEnabled = False
        Me.cboLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayer.FormattingEnabled = True
        Me.cboLayer.IntegralHeight = False
        Me.cboLayer.Location = New System.Drawing.Point(19, 19)
        Me.cboLayer.Name = "cboLayer"
        Me.cboLayer.Size = New System.Drawing.Size(158, 20)
        Me.cboLayer.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboZData)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 312)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(197, 55)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "３つめの次元のデータ項目"
        '
        'cboZData
        '
        Me.cboZData.AsteriskSelectEnabled = False
        Me.cboZData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZData.FormattingEnabled = True
        Me.cboZData.IntegralHeight = False
        Me.cboZData.Location = New System.Drawing.Point(19, 18)
        Me.cboZData.Name = "cboZData"
        Me.cboZData.Size = New System.Drawing.Size(158, 20)
        Me.cboZData.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbData)
        Me.GroupBox3.Controls.Add(Me.rbHorizontalData)
        Me.GroupBox3.Controls.Add(Me.rbObjectList)
        Me.GroupBox3.Controls.Add(Me.rbObjNumber)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 382)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(197, 147)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "集計項目"
        '
        'rbData
        '
        Me.rbData.AutoSize = True
        Me.rbData.Location = New System.Drawing.Point(26, 117)
        Me.rbData.Name = "rbData"
        Me.rbData.Size = New System.Drawing.Size(99, 16)
        Me.rbData.TabIndex = 3
        Me.rbData.TabStop = True
        Me.rbData.Text = "データ項目集計"
        Me.rbData.UseVisualStyleBackColor = True
        '
        'rbHorizontalData
        '
        Me.rbHorizontalData.AutoSize = True
        Me.rbHorizontalData.Location = New System.Drawing.Point(26, 86)
        Me.rbHorizontalData.Name = "rbHorizontalData"
        Me.rbHorizontalData.Size = New System.Drawing.Size(135, 16)
        Me.rbHorizontalData.TabIndex = 2
        Me.rbHorizontalData.TabStop = True
        Me.rbHorizontalData.Text = "横方向データ項目集計"
        Me.rbHorizontalData.UseVisualStyleBackColor = True
        '
        'rbObjectList
        '
        Me.rbObjectList.AutoSize = True
        Me.rbObjectList.Location = New System.Drawing.Point(26, 55)
        Me.rbObjectList.Name = "rbObjectList"
        Me.rbObjectList.Size = New System.Drawing.Size(139, 16)
        Me.rbObjectList.TabIndex = 1
        Me.rbObjectList.TabStop = True
        Me.rbObjectList.Text = "含まれるオブジェクト一覧"
        Me.rbObjectList.UseVisualStyleBackColor = True
        '
        'rbObjNumber
        '
        Me.rbObjNumber.AutoSize = True
        Me.rbObjNumber.Location = New System.Drawing.Point(26, 24)
        Me.rbObjNumber.Name = "rbObjNumber"
        Me.rbObjNumber.Size = New System.Drawing.Size(127, 16)
        Me.rbObjNumber.TabIndex = 0
        Me.rbObjNumber.Text = "含まれるオブジェクト数"
        Me.rbObjNumber.UseVisualStyleBackColor = True
        '
        'chkConditionUse
        '
        Me.chkConditionUse.Location = New System.Drawing.Point(237, 312)
        Me.chkConditionUse.Name = "chkConditionUse"
        Me.chkConditionUse.Size = New System.Drawing.Size(182, 36)
        Me.chkConditionUse.TabIndex = 10
        Me.chkConditionUse.Text = "表示オブジェクト限定・属性検索の条件設定を使用する"
        Me.chkConditionUse.UseVisualStyleBackColor = True
        '
        'btnVerticalIn
        '
        Me.btnVerticalIn.Image = CType(resources.GetObject("btnVerticalIn.Image"), System.Drawing.Image)
        Me.btnVerticalIn.Location = New System.Drawing.Point(215, 93)
        Me.btnVerticalIn.Name = "btnVerticalIn"
        Me.btnVerticalIn.Size = New System.Drawing.Size(40, 40)
        Me.btnVerticalIn.TabIndex = 3
        Me.btnVerticalIn.UseVisualStyleBackColor = True
        '
        'btnHorizonalIn
        '
        Me.btnHorizonalIn.Image = CType(resources.GetObject("btnHorizonalIn.Image"), System.Drawing.Image)
        Me.btnHorizonalIn.Location = New System.Drawing.Point(215, 199)
        Me.btnHorizonalIn.Name = "btnHorizonalIn"
        Me.btnHorizonalIn.Size = New System.Drawing.Size(40, 40)
        Me.btnHorizonalIn.TabIndex = 6
        Me.btnHorizonalIn.UseVisualStyleBackColor = True
        '
        'btnVerticalOut
        '
        Me.btnVerticalOut.Image = CType(resources.GetObject("btnVerticalOut.Image"), System.Drawing.Image)
        Me.btnVerticalOut.Location = New System.Drawing.Point(215, 141)
        Me.btnVerticalOut.Name = "btnVerticalOut"
        Me.btnVerticalOut.Size = New System.Drawing.Size(40, 40)
        Me.btnVerticalOut.TabIndex = 4
        Me.btnVerticalOut.UseVisualStyleBackColor = True
        '
        'btnHorizonalOut
        '
        Me.btnHorizonalOut.Image = CType(resources.GetObject("btnHorizonalOut.Image"), System.Drawing.Image)
        Me.btnHorizonalOut.Location = New System.Drawing.Point(215, 245)
        Me.btnHorizonalOut.Name = "btnHorizonalOut"
        Me.btnHorizonalOut.Size = New System.Drawing.Size(40, 40)
        Me.btnHorizonalOut.TabIndex = 7
        Me.btnHorizonalOut.UseVisualStyleBackColor = True
        '
        'gbHorizonalData
        '
        Me.gbHorizonalData.Controls.Add(Me.rbHObjectNumber)
        Me.gbHorizonalData.Controls.Add(Me.rbHStandard)
        Me.gbHorizonalData.Controls.Add(Me.rbHAverage)
        Me.gbHorizonalData.Controls.Add(Me.rbHSum)
        Me.gbHorizonalData.Location = New System.Drawing.Point(218, 382)
        Me.gbHorizonalData.Name = "gbHorizonalData"
        Me.gbHorizonalData.Size = New System.Drawing.Size(244, 89)
        Me.gbHorizonalData.TabIndex = 36
        Me.gbHorizonalData.TabStop = False
        Me.gbHorizonalData.Text = "集計する項目"
        '
        'rbHObjectNumber
        '
        Me.rbHObjectNumber.AutoSize = True
        Me.rbHObjectNumber.Location = New System.Drawing.Point(145, 56)
        Me.rbHObjectNumber.Name = "rbHObjectNumber"
        Me.rbHObjectNumber.Size = New System.Drawing.Size(86, 16)
        Me.rbHObjectNumber.TabIndex = 3
        Me.rbHObjectNumber.TabStop = True
        Me.rbHObjectNumber.Text = "オブジェクト数"
        Me.rbHObjectNumber.UseVisualStyleBackColor = True
        '
        'rbHStandard
        '
        Me.rbHStandard.AutoSize = True
        Me.rbHStandard.Location = New System.Drawing.Point(22, 56)
        Me.rbHStandard.Name = "rbHStandard"
        Me.rbHStandard.Size = New System.Drawing.Size(71, 16)
        Me.rbHStandard.TabIndex = 0
        Me.rbHStandard.TabStop = True
        Me.rbHStandard.Text = "標準偏差"
        Me.rbHStandard.UseVisualStyleBackColor = True
        '
        'rbHAverage
        '
        Me.rbHAverage.AutoSize = True
        Me.rbHAverage.Location = New System.Drawing.Point(145, 24)
        Me.rbHAverage.Name = "rbHAverage"
        Me.rbHAverage.Size = New System.Drawing.Size(59, 16)
        Me.rbHAverage.TabIndex = 1
        Me.rbHAverage.TabStop = True
        Me.rbHAverage.Text = "平均値"
        Me.rbHAverage.UseVisualStyleBackColor = True
        '
        'rbHSum
        '
        Me.rbHSum.AutoSize = True
        Me.rbHSum.Checked = True
        Me.rbHSum.Location = New System.Drawing.Point(22, 26)
        Me.rbHSum.Name = "rbHSum"
        Me.rbHSum.Size = New System.Drawing.Size(59, 16)
        Me.rbHSum.TabIndex = 0
        Me.rbHSum.TabStop = True
        Me.rbHSum.Text = "合計値"
        Me.rbHSum.UseVisualStyleBackColor = True
        '
        'gbData
        '
        Me.gbData.Controls.Add(Me.rbDValue)
        Me.gbData.Controls.Add(Me.cboData)
        Me.gbData.Controls.Add(Me.rbDobjectNumber)
        Me.gbData.Controls.Add(Me.rbDStandard)
        Me.gbData.Controls.Add(Me.rbDAverage)
        Me.gbData.Controls.Add(Me.rbDSum)
        Me.gbData.Location = New System.Drawing.Point(218, 382)
        Me.gbData.Name = "gbData"
        Me.gbData.Size = New System.Drawing.Size(244, 166)
        Me.gbData.TabIndex = 12
        Me.gbData.TabStop = False
        Me.gbData.Text = "集計するデータ項目"
        '
        'rbDValue
        '
        Me.rbDValue.AutoSize = True
        Me.rbDValue.Location = New System.Drawing.Point(29, 131)
        Me.rbDValue.Name = "rbDValue"
        Me.rbDValue.Size = New System.Drawing.Size(85, 16)
        Me.rbDValue.TabIndex = 5
        Me.rbDValue.TabStop = True
        Me.rbDValue.Text = "データの数値"
        Me.rbDValue.UseVisualStyleBackColor = True
        '
        'cboData
        '
        Me.cboData.AsteriskSelectEnabled = False
        Me.cboData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboData.FormattingEnabled = True
        Me.cboData.IntegralHeight = False
        Me.cboData.Location = New System.Drawing.Point(29, 27)
        Me.cboData.Name = "cboData"
        Me.cboData.Size = New System.Drawing.Size(158, 20)
        Me.cboData.TabIndex = 0
        '
        'rbDobjectNumber
        '
        Me.rbDobjectNumber.AutoSize = True
        Me.rbDobjectNumber.Location = New System.Drawing.Point(128, 99)
        Me.rbDobjectNumber.Name = "rbDobjectNumber"
        Me.rbDobjectNumber.Size = New System.Drawing.Size(86, 16)
        Me.rbDobjectNumber.TabIndex = 4
        Me.rbDobjectNumber.TabStop = True
        Me.rbDobjectNumber.Text = "オブジェクト数"
        Me.rbDobjectNumber.UseVisualStyleBackColor = True
        '
        'rbDStandard
        '
        Me.rbDStandard.AutoSize = True
        Me.rbDStandard.Location = New System.Drawing.Point(30, 99)
        Me.rbDStandard.Name = "rbDStandard"
        Me.rbDStandard.Size = New System.Drawing.Size(71, 16)
        Me.rbDStandard.TabIndex = 3
        Me.rbDStandard.TabStop = True
        Me.rbDStandard.Text = "標準偏差"
        Me.rbDStandard.UseVisualStyleBackColor = True
        '
        'rbDAverage
        '
        Me.rbDAverage.AutoSize = True
        Me.rbDAverage.Location = New System.Drawing.Point(128, 69)
        Me.rbDAverage.Name = "rbDAverage"
        Me.rbDAverage.Size = New System.Drawing.Size(59, 16)
        Me.rbDAverage.TabIndex = 2
        Me.rbDAverage.TabStop = True
        Me.rbDAverage.Text = "平均値"
        Me.rbDAverage.UseVisualStyleBackColor = True
        '
        'rbDSum
        '
        Me.rbDSum.AutoSize = True
        Me.rbDSum.Checked = True
        Me.rbDSum.Location = New System.Drawing.Point(30, 69)
        Me.rbDSum.Name = "rbDSum"
        Me.rbDSum.Size = New System.Drawing.Size(59, 16)
        Me.rbDSum.TabIndex = 1
        Me.rbDSum.TabStop = True
        Me.rbDSum.Text = "合計値"
        Me.rbDSum.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(267, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "横方向"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "データ項目の設定"
        '
        'lbHorizonalData
        '
        Me.lbHorizonalData.AsteriskSelectEnabled = False
        Me.lbHorizonalData.FormattingEnabled = True
        Me.lbHorizonalData.ItemHeight = 12
        Me.lbHorizonalData.Location = New System.Drawing.Point(268, 199)
        Me.lbHorizonalData.Name = "lbHorizonalData"
        Me.lbHorizonalData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbHorizonalData.Size = New System.Drawing.Size(193, 88)
        Me.lbHorizonalData.TabIndex = 8
        '
        'lbVerticalData
        '
        Me.lbVerticalData.AsteriskSelectEnabled = False
        Me.lbVerticalData.FormattingEnabled = True
        Me.lbVerticalData.ItemHeight = 12
        Me.lbVerticalData.Location = New System.Drawing.Point(268, 93)
        Me.lbVerticalData.Name = "lbVerticalData"
        Me.lbVerticalData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbVerticalData.Size = New System.Drawing.Size(194, 88)
        Me.lbVerticalData.TabIndex = 5
        '
        'lbOriginData
        '
        Me.lbOriginData.AsteriskSelectEnabled = False
        Me.lbOriginData.FormattingEnabled = True
        Me.lbOriginData.ItemHeight = 12
        Me.lbOriginData.Location = New System.Drawing.Point(13, 89)
        Me.lbOriginData.Name = "lbOriginData"
        Me.lbOriginData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbOriginData.Size = New System.Drawing.Size(195, 196)
        Me.lbOriginData.TabIndex = 2
        '
        'frmMain_Cross
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(471, 606)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbHorizonalData)
        Me.Controls.Add(Me.lbVerticalData)
        Me.Controls.Add(Me.lbOriginData)
        Me.Controls.Add(Me.gbData)
        Me.Controls.Add(Me.gbHorizonalData)
        Me.Controls.Add(Me.btnHorizonalOut)
        Me.Controls.Add(Me.btnVerticalOut)
        Me.Controls.Add(Me.btnHorizonalIn)
        Me.Controls.Add(Me.btnVerticalIn)
        Me.Controls.Add(Me.chkConditionUse)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_Cross"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "クロス集計"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbHorizonalData.ResumeLayout(False)
        Me.gbHorizonalData.PerformLayout()
        Me.gbData.ResumeLayout(False)
        Me.gbData.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboLayer As mandara10.ComboBoxEx
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboZData As mandara10.ComboBoxEx
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbData As System.Windows.Forms.RadioButton
    Friend WithEvents rbHorizontalData As System.Windows.Forms.RadioButton
    Friend WithEvents rbObjectList As System.Windows.Forms.RadioButton
    Friend WithEvents rbObjNumber As System.Windows.Forms.RadioButton
    Friend WithEvents chkConditionUse As System.Windows.Forms.CheckBox
    Friend WithEvents btnVerticalIn As System.Windows.Forms.Button
    Friend WithEvents btnHorizonalIn As System.Windows.Forms.Button
    Friend WithEvents btnVerticalOut As System.Windows.Forms.Button
    Friend WithEvents btnHorizonalOut As System.Windows.Forms.Button
    Friend WithEvents gbHorizonalData As System.Windows.Forms.GroupBox
    Friend WithEvents rbHObjectNumber As System.Windows.Forms.RadioButton
    Friend WithEvents rbHStandard As System.Windows.Forms.RadioButton
    Friend WithEvents rbHAverage As System.Windows.Forms.RadioButton
    Friend WithEvents rbHSum As System.Windows.Forms.RadioButton
    Friend WithEvents gbData As System.Windows.Forms.GroupBox
    Friend WithEvents rbDValue As System.Windows.Forms.RadioButton
    Friend WithEvents cboData As mandara10.ComboBoxEx
    Friend WithEvents rbDobjectNumber As System.Windows.Forms.RadioButton
    Friend WithEvents rbDStandard As System.Windows.Forms.RadioButton
    Friend WithEvents rbDAverage As System.Windows.Forms.RadioButton
    Friend WithEvents rbDSum As System.Windows.Forms.RadioButton
    Friend WithEvents lbOriginData As mandara10.ListBoxEx
    Friend WithEvents lbVerticalData As mandara10.ListBoxEx
    Friend WithEvents lbHorizonalData As mandara10.ListBoxEx
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
