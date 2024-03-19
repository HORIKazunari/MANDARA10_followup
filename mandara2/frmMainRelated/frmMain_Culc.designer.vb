<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_Culc
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
        Me.gbCulc = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkPercent = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDenominatorDataBox = New mandara10.TextNumberBox()
        Me.txtnumeratorData = New mandara10.TextNumberBox()
        Me.txtMultiInput = New mandara10.TextNumberBox()
        Me.txtPlusInput = New mandara10.TextNumberBox()
        Me.txtMinusInput = New mandara10.TextNumberBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboMulti2 = New mandara10.ComboBoxEx()
        Me.cboMulti1 = New mandara10.ComboBoxEx()
        Me.rbMultipli = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDif2 = New mandara10.ComboBoxEx()
        Me.cboDif1 = New mandara10.ComboBoxEx()
        Me.lbSumData = New mandara10.ListBoxEx()
        Me.rbDifference = New System.Windows.Forms.RadioButton()
        Me.rbSum = New System.Windows.Forms.RadioButton()
        Me.cboEndData = New mandara10.ComboBoxEx()
        Me.cboStartData = New mandara10.ComboBoxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboDenominatorData = New mandara10.ComboBoxEx()
        Me.cbonumeratorData = New mandara10.ComboBoxEx()
        Me.cboDensityData = New mandara10.ComboBoxEx()
        Me.rbRateOfChange = New System.Windows.Forms.RadioButton()
        Me.rbRatio = New System.Windows.Forms.RadioButton()
        Me.rbDensity = New System.Windows.Forms.RadioButton()
        Me.gbCulc.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(393, 472)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "終了"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(326, 472)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'gbCulc
        '
        Me.gbCulc.Controls.Add(Me.Label3)
        Me.gbCulc.Controls.Add(Me.chkPercent)
        Me.gbCulc.Controls.Add(Me.Label7)
        Me.gbCulc.Controls.Add(Me.txtDenominatorDataBox)
        Me.gbCulc.Controls.Add(Me.txtnumeratorData)
        Me.gbCulc.Controls.Add(Me.txtMultiInput)
        Me.gbCulc.Controls.Add(Me.txtPlusInput)
        Me.gbCulc.Controls.Add(Me.txtMinusInput)
        Me.gbCulc.Controls.Add(Me.Label6)
        Me.gbCulc.Controls.Add(Me.cboMulti2)
        Me.gbCulc.Controls.Add(Me.cboMulti1)
        Me.gbCulc.Controls.Add(Me.rbMultipli)
        Me.gbCulc.Controls.Add(Me.Label2)
        Me.gbCulc.Controls.Add(Me.cboDif2)
        Me.gbCulc.Controls.Add(Me.cboDif1)
        Me.gbCulc.Controls.Add(Me.lbSumData)
        Me.gbCulc.Controls.Add(Me.rbDifference)
        Me.gbCulc.Controls.Add(Me.rbSum)
        Me.gbCulc.Controls.Add(Me.cboEndData)
        Me.gbCulc.Controls.Add(Me.cboStartData)
        Me.gbCulc.Controls.Add(Me.Label5)
        Me.gbCulc.Controls.Add(Me.Label4)
        Me.gbCulc.Controls.Add(Me.cboDenominatorData)
        Me.gbCulc.Controls.Add(Me.cbonumeratorData)
        Me.gbCulc.Controls.Add(Me.cboDensityData)
        Me.gbCulc.Controls.Add(Me.rbRateOfChange)
        Me.gbCulc.Controls.Add(Me.rbRatio)
        Me.gbCulc.Controls.Add(Me.rbDensity)
        Me.gbCulc.Location = New System.Drawing.Point(12, 12)
        Me.gbCulc.Name = "gbCulc"
        Me.gbCulc.Size = New System.Drawing.Size(443, 442)
        Me.gbCulc.TabIndex = 3
        Me.gbCulc.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(124, 271)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 12)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "÷"
        '
        'chkPercent
        '
        Me.chkPercent.AutoSize = True
        Me.chkPercent.Location = New System.Drawing.Point(100, 303)
        Me.chkPercent.Name = "chkPercent"
        Me.chkPercent.Size = New System.Drawing.Size(147, 16)
        Me.chkPercent.TabIndex = 57
        Me.chkPercent.Text = "100倍してパーセントにする"
        Me.chkPercent.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(343, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "数値入力"
        '
        'txtDenominatorDataBox
        '
        Me.txtDenominatorDataBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtDenominatorDataBox.Location = New System.Drawing.Point(314, 269)
        Me.txtDenominatorDataBox.MaxValue = 0.0R
        Me.txtDenominatorDataBox.MaxValueFlag = False
        Me.txtDenominatorDataBox.MinValue = 0.0R
        Me.txtDenominatorDataBox.MinValueFlag = True
        Me.txtDenominatorDataBox.Name = "txtDenominatorDataBox"
        Me.txtDenominatorDataBox.NumberPoint = True
        Me.txtDenominatorDataBox.Size = New System.Drawing.Size(112, 19)
        Me.txtDenominatorDataBox.TabIndex = 56
        Me.txtDenominatorDataBox.Tag = "0"
        Me.txtDenominatorDataBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDenominatorDataBox.ValueErrorMessageFlag = True
        '
        'txtnumeratorData
        '
        Me.txtnumeratorData.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtnumeratorData.Location = New System.Drawing.Point(252, 235)
        Me.txtnumeratorData.MaxValue = 0.0R
        Me.txtnumeratorData.MaxValueFlag = False
        Me.txtnumeratorData.MinValue = 0.0R
        Me.txtnumeratorData.MinValueFlag = True
        Me.txtnumeratorData.Name = "txtnumeratorData"
        Me.txtnumeratorData.NumberPoint = True
        Me.txtnumeratorData.Size = New System.Drawing.Size(112, 19)
        Me.txtnumeratorData.TabIndex = 55
        Me.txtnumeratorData.Tag = "0"
        Me.txtnumeratorData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtnumeratorData.ValueErrorMessageFlag = True
        '
        'txtMultiInput
        '
        Me.txtMultiInput.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMultiInput.Location = New System.Drawing.Point(314, 199)
        Me.txtMultiInput.MaxValue = 0.0R
        Me.txtMultiInput.MaxValueFlag = False
        Me.txtMultiInput.MinValue = 0.0R
        Me.txtMultiInput.MinValueFlag = True
        Me.txtMultiInput.Name = "txtMultiInput"
        Me.txtMultiInput.NumberPoint = True
        Me.txtMultiInput.Size = New System.Drawing.Size(112, 19)
        Me.txtMultiInput.TabIndex = 54
        Me.txtMultiInput.Tag = "0"
        Me.txtMultiInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMultiInput.ValueErrorMessageFlag = True
        '
        'txtPlusInput
        '
        Me.txtPlusInput.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPlusInput.Location = New System.Drawing.Point(314, 87)
        Me.txtPlusInput.MaxValue = 0.0R
        Me.txtPlusInput.MaxValueFlag = False
        Me.txtPlusInput.MinValue = 0.0R
        Me.txtPlusInput.MinValueFlag = True
        Me.txtPlusInput.Name = "txtPlusInput"
        Me.txtPlusInput.NumberPoint = True
        Me.txtPlusInput.Size = New System.Drawing.Size(112, 19)
        Me.txtPlusInput.TabIndex = 53
        Me.txtPlusInput.Tag = "0"
        Me.txtPlusInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPlusInput.ValueErrorMessageFlag = True
        '
        'txtMinusInput
        '
        Me.txtMinusInput.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMinusInput.Location = New System.Drawing.Point(314, 150)
        Me.txtMinusInput.MaxValue = 0.0R
        Me.txtMinusInput.MaxValueFlag = False
        Me.txtMinusInput.MinValue = 0.0R
        Me.txtMinusInput.MinValueFlag = True
        Me.txtMinusInput.Name = "txtMinusInput"
        Me.txtMinusInput.NumberPoint = True
        Me.txtMinusInput.Size = New System.Drawing.Size(112, 19)
        Me.txtMinusInput.TabIndex = 42
        Me.txtMinusInput.Tag = "0"
        Me.txtMinusInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMinusInput.ValueErrorMessageFlag = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(124, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 12)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "×"
        '
        'cboMulti2
        '
        Me.cboMulti2.AsteriskSelectEnabled = False
        Me.cboMulti2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMulti2.FormattingEnabled = True
        Me.cboMulti2.IntegralHeight = False
        Me.cboMulti2.Location = New System.Drawing.Point(157, 199)
        Me.cboMulti2.MaxDropDownItems = 20
        Me.cboMulti2.Name = "cboMulti2"
        Me.cboMulti2.Size = New System.Drawing.Size(140, 20)
        Me.cboMulti2.TabIndex = 51
        '
        'cboMulti1
        '
        Me.cboMulti1.AsteriskSelectEnabled = False
        Me.cboMulti1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMulti1.FormattingEnabled = True
        Me.cboMulti1.IntegralHeight = False
        Me.cboMulti1.Location = New System.Drawing.Point(94, 176)
        Me.cboMulti1.MaxDropDownItems = 20
        Me.cboMulti1.Name = "cboMulti1"
        Me.cboMulti1.Size = New System.Drawing.Size(140, 20)
        Me.cboMulti1.TabIndex = 50
        '
        'rbMultipli
        '
        Me.rbMultipli.AutoSize = True
        Me.rbMultipli.Location = New System.Drawing.Point(23, 180)
        Me.rbMultipli.Name = "rbMultipli"
        Me.rbMultipli.Size = New System.Drawing.Size(55, 16)
        Me.rbMultipli.TabIndex = 49
        Me.rbMultipli.TabStop = True
        Me.rbMultipli.Text = "かけ算"
        Me.rbMultipli.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(125, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 12)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "－"
        '
        'cboDif2
        '
        Me.cboDif2.AsteriskSelectEnabled = False
        Me.cboDif2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDif2.FormattingEnabled = True
        Me.cboDif2.IntegralHeight = False
        Me.cboDif2.Location = New System.Drawing.Point(158, 147)
        Me.cboDif2.MaxDropDownItems = 20
        Me.cboDif2.Name = "cboDif2"
        Me.cboDif2.Size = New System.Drawing.Size(140, 20)
        Me.cboDif2.TabIndex = 8
        '
        'cboDif1
        '
        Me.cboDif1.AsteriskSelectEnabled = False
        Me.cboDif1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDif1.FormattingEnabled = True
        Me.cboDif1.IntegralHeight = False
        Me.cboDif1.Location = New System.Drawing.Point(95, 124)
        Me.cboDif1.MaxDropDownItems = 20
        Me.cboDif1.Name = "cboDif1"
        Me.cboDif1.Size = New System.Drawing.Size(140, 20)
        Me.cboDif1.TabIndex = 7
        '
        'lbSumData
        '
        Me.lbSumData.AsteriskSelectEnabled = False
        Me.lbSumData.FormattingEnabled = True
        Me.lbSumData.ItemHeight = 12
        Me.lbSumData.Location = New System.Drawing.Point(91, 18)
        Me.lbSumData.Name = "lbSumData"
        Me.lbSumData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbSumData.Size = New System.Drawing.Size(207, 88)
        Me.lbSumData.TabIndex = 6
        '
        'rbDifference
        '
        Me.rbDifference.AutoSize = True
        Me.rbDifference.Location = New System.Drawing.Point(23, 125)
        Me.rbDifference.Name = "rbDifference"
        Me.rbDifference.Size = New System.Drawing.Size(35, 16)
        Me.rbDifference.TabIndex = 1
        Me.rbDifference.TabStop = True
        Me.rbDifference.Text = "差"
        Me.rbDifference.UseVisualStyleBackColor = True
        '
        'rbSum
        '
        Me.rbSum.AutoSize = True
        Me.rbSum.Location = New System.Drawing.Point(23, 18)
        Me.rbSum.Name = "rbSum"
        Me.rbSum.Size = New System.Drawing.Size(35, 16)
        Me.rbSum.TabIndex = 0
        Me.rbSum.TabStop = True
        Me.rbSum.Text = "和"
        Me.rbSum.UseVisualStyleBackColor = True
        '
        'cboEndData
        '
        Me.cboEndData.AsteriskSelectEnabled = False
        Me.cboEndData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEndData.FormattingEnabled = True
        Me.cboEndData.IntegralHeight = False
        Me.cboEndData.Location = New System.Drawing.Point(156, 364)
        Me.cboEndData.MaxDropDownItems = 20
        Me.cboEndData.Name = "cboEndData"
        Me.cboEndData.Size = New System.Drawing.Size(141, 20)
        Me.cboEndData.TabIndex = 12
        '
        'cboStartData
        '
        Me.cboStartData.AsteriskSelectEnabled = False
        Me.cboStartData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStartData.FormattingEnabled = True
        Me.cboStartData.IntegralHeight = False
        Me.cboStartData.Location = New System.Drawing.Point(156, 338)
        Me.cboStartData.MaxDropDownItems = 20
        Me.cboStartData.Name = "cboStartData"
        Me.cboStartData.Size = New System.Drawing.Size(141, 20)
        Me.cboStartData.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(93, 367)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 12)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "期末データ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(93, 341)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 12)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "期首データ"
        '
        'cboDenominatorData
        '
        Me.cboDenominatorData.AsteriskSelectEnabled = False
        Me.cboDenominatorData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDenominatorData.FormattingEnabled = True
        Me.cboDenominatorData.IntegralHeight = False
        Me.cboDenominatorData.Location = New System.Drawing.Point(156, 268)
        Me.cboDenominatorData.MaxDropDownItems = 20
        Me.cboDenominatorData.Name = "cboDenominatorData"
        Me.cboDenominatorData.Size = New System.Drawing.Size(140, 20)
        Me.cboDenominatorData.TabIndex = 10
        '
        'cbonumeratorData
        '
        Me.cbonumeratorData.AsteriskSelectEnabled = False
        Me.cbonumeratorData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbonumeratorData.FormattingEnabled = True
        Me.cbonumeratorData.IntegralHeight = False
        Me.cbonumeratorData.Location = New System.Drawing.Point(96, 231)
        Me.cbonumeratorData.MaxDropDownItems = 20
        Me.cbonumeratorData.Name = "cbonumeratorData"
        Me.cbonumeratorData.Size = New System.Drawing.Size(140, 20)
        Me.cbonumeratorData.TabIndex = 9
        '
        'cboDensityData
        '
        Me.cboDensityData.AsteriskSelectEnabled = False
        Me.cboDensityData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDensityData.FormattingEnabled = True
        Me.cboDensityData.IntegralHeight = False
        Me.cboDensityData.Location = New System.Drawing.Point(96, 396)
        Me.cboDensityData.MaxDropDownItems = 20
        Me.cboDensityData.Name = "cboDensityData"
        Me.cboDensityData.Size = New System.Drawing.Size(140, 20)
        Me.cboDensityData.TabIndex = 13
        '
        'rbRateOfChange
        '
        Me.rbRateOfChange.AutoSize = True
        Me.rbRateOfChange.Location = New System.Drawing.Point(22, 339)
        Me.rbRateOfChange.Name = "rbRateOfChange"
        Me.rbRateOfChange.Size = New System.Drawing.Size(73, 16)
        Me.rbRateOfChange.TabIndex = 4
        Me.rbRateOfChange.TabStop = True
        Me.rbRateOfChange.Text = "増減率(%)"
        Me.rbRateOfChange.UseVisualStyleBackColor = True
        '
        'rbRatio
        '
        Me.rbRatio.AutoSize = True
        Me.rbRatio.Location = New System.Drawing.Point(23, 235)
        Me.rbRatio.Name = "rbRatio"
        Me.rbRatio.Size = New System.Drawing.Size(55, 16)
        Me.rbRatio.TabIndex = 2
        Me.rbRatio.TabStop = True
        Me.rbRatio.Text = "割り算"
        Me.rbRatio.UseVisualStyleBackColor = True
        '
        'rbDensity
        '
        Me.rbDensity.AutoSize = True
        Me.rbDensity.Location = New System.Drawing.Point(22, 397)
        Me.rbDensity.Name = "rbDensity"
        Me.rbDensity.Size = New System.Drawing.Size(47, 16)
        Me.rbDensity.TabIndex = 5
        Me.rbDensity.TabStop = True
        Me.rbDensity.Text = "密度"
        Me.rbDensity.UseVisualStyleBackColor = True
        '
        'frmMain_Culc
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(471, 508)
        Me.Controls.Add(Me.gbCulc)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_Culc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "データ計算"
        Me.gbCulc.ResumeLayout(False)
        Me.gbCulc.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents gbCulc As System.Windows.Forms.GroupBox
    Friend WithEvents cboDensityData As mandara10.ComboBoxEx
    Friend WithEvents rbRateOfChange As System.Windows.Forms.RadioButton
    Friend WithEvents rbRatio As System.Windows.Forms.RadioButton
    Friend WithEvents rbDensity As System.Windows.Forms.RadioButton
    Friend WithEvents cboEndData As mandara10.ComboBoxEx
    Friend WithEvents cboStartData As mandara10.ComboBoxEx
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboDenominatorData As mandara10.ComboBoxEx
    Friend WithEvents cbonumeratorData As mandara10.ComboBoxEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDif2 As mandara10.ComboBoxEx
    Friend WithEvents cboDif1 As mandara10.ComboBoxEx
    Friend WithEvents lbSumData As mandara10.ListBoxEx
    Friend WithEvents rbDifference As System.Windows.Forms.RadioButton
    Friend WithEvents rbSum As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboMulti2 As mandara10.ComboBoxEx
    Friend WithEvents cboMulti1 As mandara10.ComboBoxEx
    Friend WithEvents rbMultipli As System.Windows.Forms.RadioButton
    Friend WithEvents txtMinusInput As mandara10.TextNumberBox
    Friend WithEvents txtPlusInput As mandara10.TextNumberBox
    Friend WithEvents txtDenominatorDataBox As mandara10.TextNumberBox
    Friend WithEvents txtnumeratorData As mandara10.TextNumberBox
    Friend WithEvents txtMultiInput As mandara10.TextNumberBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkPercent As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
