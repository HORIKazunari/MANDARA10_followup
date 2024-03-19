<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain_SetSeriesMode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain_SetSeriesMode))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.tabData = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbString = New System.Windows.Forms.RadioButton()
        Me.rbContour = New System.Windows.Forms.RadioButton()
        Me.rbBar = New System.Windows.Forms.RadioButton()
        Me.rbTurn = New System.Windows.Forms.RadioButton()
        Me.rbBlock = New System.Windows.Forms.RadioButton()
        Me.rbSize = New System.Windows.Forms.RadioButton()
        Me.rbOD = New System.Windows.Forms.RadioButton()
        Me.rbClassMark = New System.Windows.Forms.RadioButton()
        Me.rbHarch = New System.Windows.Forms.RadioButton()
        Me.rbPaint = New System.Windows.Forms.RadioButton()
        Me.lbSoloDataItem = New mandara10.ListBoxEx()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboLayerSolo = New mandara10.ComboBoxEx()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lbGraphDataSet = New mandara10.ListBoxEx()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboLayerGraph = New mandara10.ComboBoxEx()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lbLabelDataSet = New mandara10.ListBoxEx()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cboLayerLabel = New mandara10.ComboBoxEx()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lbTripDataSet = New mandara10.ListBoxEx()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cboLayerTrip = New mandara10.ComboBoxEx()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.lbOverLayDataSet = New mandara10.ListBoxEx()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.ListViewSeries = New mandara10.ListViewEX()
        Me.txtNewDataSet = New System.Windows.Forms.TextBox()
        Me.cboExsistingDataSet = New mandara10.ComboBoxEx()
        Me.rbNewDataSet = New System.Windows.Forms.RadioButton()
        Me.rbExsistingDataSet = New System.Windows.Forms.RadioButton()
        Me.btnSet = New System.Windows.Forms.Button()
        Me.tabData.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(712, 345)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(637, 345)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'tabData
        '
        Me.tabData.Controls.Add(Me.TabPage1)
        Me.tabData.Controls.Add(Me.TabPage2)
        Me.tabData.Controls.Add(Me.TabPage3)
        Me.tabData.Controls.Add(Me.TabPage4)
        Me.tabData.Controls.Add(Me.TabPage5)
        Me.tabData.Location = New System.Drawing.Point(12, 23)
        Me.tabData.Name = "tabData"
        Me.tabData.SelectedIndex = 0
        Me.tabData.Size = New System.Drawing.Size(360, 316)
        Me.tabData.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.lbSoloDataItem)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(352, 290)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "単独表示"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbString)
        Me.GroupBox3.Controls.Add(Me.rbContour)
        Me.GroupBox3.Controls.Add(Me.rbBar)
        Me.GroupBox3.Controls.Add(Me.rbTurn)
        Me.GroupBox3.Controls.Add(Me.rbBlock)
        Me.GroupBox3.Controls.Add(Me.rbSize)
        Me.GroupBox3.Controls.Add(Me.rbOD)
        Me.GroupBox3.Controls.Add(Me.rbClassMark)
        Me.GroupBox3.Controls.Add(Me.rbHarch)
        Me.GroupBox3.Controls.Add(Me.rbPaint)
        Me.GroupBox3.Location = New System.Drawing.Point(200, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(146, 266)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "表示モード"
        '
        'rbString
        '
        Me.rbString.AutoSize = True
        Me.rbString.Location = New System.Drawing.Point(17, 230)
        Me.rbString.Name = "rbString"
        Me.rbString.Size = New System.Drawing.Size(47, 16)
        Me.rbString.TabIndex = 10
        Me.rbString.Text = "文字"
        Me.rbString.UseVisualStyleBackColor = True
        '
        'rbContour
        '
        Me.rbContour.AutoSize = True
        Me.rbContour.Location = New System.Drawing.Point(17, 208)
        Me.rbContour.Name = "rbContour"
        Me.rbContour.Size = New System.Drawing.Size(59, 16)
        Me.rbContour.TabIndex = 9
        Me.rbContour.Text = "等値線"
        Me.rbContour.UseVisualStyleBackColor = True
        '
        'rbBar
        '
        Me.rbBar.AutoSize = True
        Me.rbBar.Location = New System.Drawing.Point(17, 186)
        Me.rbBar.Name = "rbBar"
        Me.rbBar.Size = New System.Drawing.Size(65, 16)
        Me.rbBar.TabIndex = 8
        Me.rbBar.Text = "棒の高さ"
        Me.rbBar.UseVisualStyleBackColor = True
        '
        'rbTurn
        '
        Me.rbTurn.AutoSize = True
        Me.rbTurn.Location = New System.Drawing.Point(17, 164)
        Me.rbTurn.Name = "rbTurn"
        Me.rbTurn.Size = New System.Drawing.Size(81, 16)
        Me.rbTurn.TabIndex = 7
        Me.rbTurn.Text = "記号の回転"
        Me.rbTurn.UseVisualStyleBackColor = True
        '
        'rbBlock
        '
        Me.rbBlock.AutoSize = True
        Me.rbBlock.Location = New System.Drawing.Point(17, 142)
        Me.rbBlock.Name = "rbBlock"
        Me.rbBlock.Size = New System.Drawing.Size(69, 16)
        Me.rbBlock.TabIndex = 6
        Me.rbBlock.Text = "記号の数"
        Me.rbBlock.UseVisualStyleBackColor = True
        '
        'rbSize
        '
        Me.rbSize.AutoSize = True
        Me.rbSize.Location = New System.Drawing.Point(17, 120)
        Me.rbSize.Name = "rbSize"
        Me.rbSize.Size = New System.Drawing.Size(86, 16)
        Me.rbSize.TabIndex = 5
        Me.rbSize.Text = "記号の大きさ"
        Me.rbSize.UseVisualStyleBackColor = True
        '
        'rbOD
        '
        Me.rbOD.AutoSize = True
        Me.rbOD.Location = New System.Drawing.Point(17, 98)
        Me.rbOD.Name = "rbOD"
        Me.rbOD.Size = New System.Drawing.Size(35, 16)
        Me.rbOD.TabIndex = 4
        Me.rbOD.Text = "線"
        Me.rbOD.UseVisualStyleBackColor = True
        '
        'rbClassMark
        '
        Me.rbClassMark.AutoSize = True
        Me.rbClassMark.Location = New System.Drawing.Point(17, 76)
        Me.rbClassMark.Name = "rbClassMark"
        Me.rbClassMark.Size = New System.Drawing.Size(71, 16)
        Me.rbClassMark.TabIndex = 3
        Me.rbClassMark.Text = "階級記号"
        Me.rbClassMark.UseVisualStyleBackColor = True
        '
        'rbHarch
        '
        Me.rbHarch.AutoSize = True
        Me.rbHarch.Location = New System.Drawing.Point(17, 54)
        Me.rbHarch.Name = "rbHarch"
        Me.rbHarch.Size = New System.Drawing.Size(49, 16)
        Me.rbHarch.TabIndex = 2
        Me.rbHarch.Text = "ハッチ"
        Me.rbHarch.UseVisualStyleBackColor = True
        '
        'rbPaint
        '
        Me.rbPaint.AutoSize = True
        Me.rbPaint.Checked = True
        Me.rbPaint.Location = New System.Drawing.Point(17, 32)
        Me.rbPaint.Name = "rbPaint"
        Me.rbPaint.Size = New System.Drawing.Size(59, 16)
        Me.rbPaint.TabIndex = 1
        Me.rbPaint.TabStop = True
        Me.rbPaint.Text = "ペイント"
        Me.rbPaint.UseVisualStyleBackColor = True
        '
        'lbSoloDataItem
        '
        Me.lbSoloDataItem.AsteriskSelectEnabled = False
        Me.lbSoloDataItem.FormattingEnabled = True
        Me.lbSoloDataItem.ItemHeight = 12
        Me.lbSoloDataItem.Location = New System.Drawing.Point(15, 87)
        Me.lbSoloDataItem.Name = "lbSoloDataItem"
        Me.lbSoloDataItem.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbSoloDataItem.Size = New System.Drawing.Size(174, 196)
        Me.lbSoloDataItem.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboLayerSolo)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(179, 52)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "レイヤ"
        '
        'cboLayerSolo
        '
        Me.cboLayerSolo.AsteriskSelectEnabled = False
        Me.cboLayerSolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayerSolo.FormattingEnabled = True
        Me.cboLayerSolo.IntegralHeight = False
        Me.cboLayerSolo.Location = New System.Drawing.Point(26, 15)
        Me.cboLayerSolo.Name = "cboLayerSolo"
        Me.cboLayerSolo.Size = New System.Drawing.Size(126, 20)
        Me.cboLayerSolo.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lbGraphDataSet)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(352, 290)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "グラフ表示"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lbGraphDataSet
        '
        Me.lbGraphDataSet.AsteriskSelectEnabled = False
        Me.lbGraphDataSet.FormattingEnabled = True
        Me.lbGraphDataSet.ItemHeight = 12
        Me.lbGraphDataSet.Location = New System.Drawing.Point(43, 91)
        Me.lbGraphDataSet.Name = "lbGraphDataSet"
        Me.lbGraphDataSet.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbGraphDataSet.Size = New System.Drawing.Size(249, 136)
        Me.lbGraphDataSet.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboLayerGraph)
        Me.GroupBox4.Location = New System.Drawing.Point(43, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(179, 52)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "レイヤ"
        '
        'cboLayerGraph
        '
        Me.cboLayerGraph.AsteriskSelectEnabled = False
        Me.cboLayerGraph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayerGraph.FormattingEnabled = True
        Me.cboLayerGraph.IntegralHeight = False
        Me.cboLayerGraph.Location = New System.Drawing.Point(26, 15)
        Me.cboLayerGraph.Name = "cboLayerGraph"
        Me.cboLayerGraph.Size = New System.Drawing.Size(126, 20)
        Me.cboLayerGraph.TabIndex = 3
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lbLabelDataSet)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(352, 290)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "ラベル表示"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lbLabelDataSet
        '
        Me.lbLabelDataSet.AsteriskSelectEnabled = False
        Me.lbLabelDataSet.FormattingEnabled = True
        Me.lbLabelDataSet.ItemHeight = 12
        Me.lbLabelDataSet.Location = New System.Drawing.Point(43, 90)
        Me.lbLabelDataSet.Name = "lbLabelDataSet"
        Me.lbLabelDataSet.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbLabelDataSet.Size = New System.Drawing.Size(249, 136)
        Me.lbLabelDataSet.TabIndex = 3
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboLayerLabel)
        Me.GroupBox5.Location = New System.Drawing.Point(43, 15)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(179, 52)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "レイヤ"
        '
        'cboLayerLabel
        '
        Me.cboLayerLabel.AsteriskSelectEnabled = False
        Me.cboLayerLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayerLabel.FormattingEnabled = True
        Me.cboLayerLabel.IntegralHeight = False
        Me.cboLayerLabel.Location = New System.Drawing.Point(26, 15)
        Me.cboLayerLabel.Name = "cboLayerLabel"
        Me.cboLayerLabel.Size = New System.Drawing.Size(126, 20)
        Me.cboLayerLabel.TabIndex = 3
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.lbTripDataSet)
        Me.TabPage4.Controls.Add(Me.GroupBox6)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(352, 290)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "移動表示"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'lbTripDataSet
        '
        Me.lbTripDataSet.AsteriskSelectEnabled = False
        Me.lbTripDataSet.FormattingEnabled = True
        Me.lbTripDataSet.ItemHeight = 12
        Me.lbTripDataSet.Location = New System.Drawing.Point(43, 83)
        Me.lbTripDataSet.Name = "lbTripDataSet"
        Me.lbTripDataSet.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbTripDataSet.Size = New System.Drawing.Size(249, 136)
        Me.lbTripDataSet.TabIndex = 4
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cboLayerTrip)
        Me.GroupBox6.Location = New System.Drawing.Point(43, 16)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(179, 52)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "レイヤ"
        '
        'cboLayerTrip
        '
        Me.cboLayerTrip.AsteriskSelectEnabled = False
        Me.cboLayerTrip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayerTrip.FormattingEnabled = True
        Me.cboLayerTrip.IntegralHeight = False
        Me.cboLayerTrip.Location = New System.Drawing.Point(26, 15)
        Me.cboLayerTrip.Name = "cboLayerTrip"
        Me.cboLayerTrip.Size = New System.Drawing.Size(126, 20)
        Me.cboLayerTrip.TabIndex = 3
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.lbOverLayDataSet)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(352, 290)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "重ね合わせ"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'lbOverLayDataSet
        '
        Me.lbOverLayDataSet.AsteriskSelectEnabled = False
        Me.lbOverLayDataSet.FormattingEnabled = True
        Me.lbOverLayDataSet.ItemHeight = 12
        Me.lbOverLayDataSet.Location = New System.Drawing.Point(52, 55)
        Me.lbOverLayDataSet.Name = "lbOverLayDataSet"
        Me.lbOverLayDataSet.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbOverLayDataSet.Size = New System.Drawing.Size(249, 184)
        Me.lbOverLayDataSet.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnRemove)
        Me.GroupBox1.Controls.Add(Me.ListViewSeries)
        Me.GroupBox1.Controls.Add(Me.txtNewDataSet)
        Me.GroupBox1.Controls.Add(Me.cboExsistingDataSet)
        Me.GroupBox1.Controls.Add(Me.rbNewDataSet)
        Me.GroupBox1.Controls.Add(Me.rbExsistingDataSet)
        Me.GroupBox1.Location = New System.Drawing.Point(439, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(342, 316)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "設定先連続表示データセット"
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(273, 284)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(55, 26)
        Me.btnRemove.TabIndex = 4
        Me.btnRemove.Text = "削除"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'ListViewSeries
        '
        Me.ListViewSeries.FullRowSelect = True
        Me.ListViewSeries.GridLines = True
        Me.ListViewSeries.HideSelection = False
        Me.ListViewSeries.Location = New System.Drawing.Point(22, 125)
        Me.ListViewSeries.Margin = New System.Windows.Forms.Padding(2)
        Me.ListViewSeries.Name = "ListViewSeries"
        Me.ListViewSeries.Size = New System.Drawing.Size(308, 151)
        Me.ListViewSeries.TabIndex = 3
        Me.ListViewSeries.UseCompatibleStateImageBehavior = False
        Me.ListViewSeries.View = System.Windows.Forms.View.Details
        '
        'txtNewDataSet
        '
        Me.txtNewDataSet.Location = New System.Drawing.Point(44, 101)
        Me.txtNewDataSet.Name = "txtNewDataSet"
        Me.txtNewDataSet.Size = New System.Drawing.Size(212, 19)
        Me.txtNewDataSet.TabIndex = 2
        '
        'cboExsistingDataSet
        '
        Me.cboExsistingDataSet.AsteriskSelectEnabled = False
        Me.cboExsistingDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExsistingDataSet.FormattingEnabled = True
        Me.cboExsistingDataSet.IntegralHeight = False
        Me.cboExsistingDataSet.Location = New System.Drawing.Point(44, 49)
        Me.cboExsistingDataSet.Name = "cboExsistingDataSet"
        Me.cboExsistingDataSet.Size = New System.Drawing.Size(212, 20)
        Me.cboExsistingDataSet.TabIndex = 1
        '
        'rbNewDataSet
        '
        Me.rbNewDataSet.AutoSize = True
        Me.rbNewDataSet.Location = New System.Drawing.Point(22, 79)
        Me.rbNewDataSet.Name = "rbNewDataSet"
        Me.rbNewDataSet.Size = New System.Drawing.Size(107, 16)
        Me.rbNewDataSet.TabIndex = 5
        Me.rbNewDataSet.TabStop = True
        Me.rbNewDataSet.Text = "新しいデータセット"
        Me.rbNewDataSet.UseVisualStyleBackColor = True
        '
        'rbExsistingDataSet
        '
        Me.rbExsistingDataSet.AutoSize = True
        Me.rbExsistingDataSet.Location = New System.Drawing.Point(22, 27)
        Me.rbExsistingDataSet.Name = "rbExsistingDataSet"
        Me.rbExsistingDataSet.Size = New System.Drawing.Size(110, 16)
        Me.rbExsistingDataSet.TabIndex = 0
        Me.rbExsistingDataSet.TabStop = True
        Me.rbExsistingDataSet.Text = "既存のデータセット"
        Me.rbExsistingDataSet.UseVisualStyleBackColor = True
        '
        'btnSet
        '
        Me.btnSet.Image = CType(resources.GetObject("btnSet.Image"), System.Drawing.Image)
        Me.btnSet.Location = New System.Drawing.Point(385, 172)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(40, 36)
        Me.btnSet.TabIndex = 8
        Me.btnSet.UseVisualStyleBackColor = True
        '
        'frmMain_SetSeriesMode
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(793, 378)
        Me.Controls.Add(Me.btnSet)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tabData)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain_SetSeriesMode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "連続表示モードにまとめて設定"
        Me.tabData.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents tabData As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSet As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents txtNewDataSet As System.Windows.Forms.TextBox
    Friend WithEvents cboExsistingDataSet As mandara10.ComboBoxEx
    Friend WithEvents rbNewDataSet As System.Windows.Forms.RadioButton
    Friend WithEvents rbExsistingDataSet As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbContour As System.Windows.Forms.RadioButton
    Friend WithEvents rbBar As System.Windows.Forms.RadioButton
    Friend WithEvents rbTurn As System.Windows.Forms.RadioButton
    Friend WithEvents rbBlock As System.Windows.Forms.RadioButton
    Friend WithEvents rbSize As System.Windows.Forms.RadioButton
    Friend WithEvents rbOD As System.Windows.Forms.RadioButton
    Friend WithEvents rbClassMark As System.Windows.Forms.RadioButton
    Friend WithEvents rbHarch As System.Windows.Forms.RadioButton
    Friend WithEvents rbPaint As System.Windows.Forms.RadioButton
    Friend WithEvents lbSoloDataItem As mandara10.ListBoxEx
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboLayerSolo As mandara10.ComboBoxEx
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboLayerGraph As mandara10.ComboBoxEx
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cboLayerLabel As mandara10.ComboBoxEx
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cboLayerTrip As mandara10.ComboBoxEx
    Friend WithEvents ListViewSeries As mandara10.ListViewEX
    Friend WithEvents lbGraphDataSet As mandara10.ListBoxEx
    Friend WithEvents lbLabelDataSet As mandara10.ListBoxEx
    Friend WithEvents lbTripDataSet As mandara10.ListBoxEx
    Friend WithEvents lbOverLayDataSet As mandara10.ListBoxEx
    Friend WithEvents rbString As System.Windows.Forms.RadioButton
End Class
