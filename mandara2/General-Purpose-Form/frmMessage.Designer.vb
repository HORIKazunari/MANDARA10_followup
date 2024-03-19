<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMessage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMessage))
        Me.TextBox = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.ListViewEX = New mandara10.ListViewEX()
        Me.ktGrid = New KTGISUserControl.KTGISGrid()
        Me.SuspendLayout()
        '
        'TextBox
        '
        Me.TextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox.BackColor = System.Drawing.Color.White
        Me.TextBox.Location = New System.Drawing.Point(10, 13)
        Me.TextBox.Multiline = True
        Me.TextBox.Name = "TextBox"
        Me.TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox.Size = New System.Drawing.Size(336, 223)
        Me.TextBox.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(286, 254)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(211, 254)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCopy.Location = New System.Drawing.Point(13, 254)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(69, 24)
        Me.btnCopy.TabIndex = 2
        Me.btnCopy.Text = "コピー"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'ListViewEX
        '
        Me.ListViewEX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewEX.GridLines = True
        Me.ListViewEX.Location = New System.Drawing.Point(10, 13)
        Me.ListViewEX.Name = "ListViewEX"
        Me.ListViewEX.Size = New System.Drawing.Size(333, 223)
        Me.ListViewEX.TabIndex = 9
        Me.ListViewEX.UseCompatibleStateImageBehavior = False
        Me.ListViewEX.View = System.Windows.Forms.View.Details
        '
        'ktGrid
        '
        Me.ktGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ktGrid.DefaultFixedUpperLeftAlligntment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultFixedXNumberingWidth = 50
        Me.ktGrid.DefaultFixedXSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultFixedXWidth = 150
        Me.ktGrid.DefaultFixedYSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultGridAlligntment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ktGrid.DefaultGridWidth = 100
        Me.ktGrid.DefaultNumberingAlligntment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ktGrid.FixedGridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.ktGrid.FrameColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.ktGrid.GridColor = System.Drawing.Color.White
        Me.ktGrid.GridFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ktGrid.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ktGrid.Layer = 0
        Me.ktGrid.LayerCaption = Nothing
        Me.ktGrid.Location = New System.Drawing.Point(10, 13)
        Me.ktGrid.MsgBoxTitle = ""
        Me.ktGrid.Name = "ktGrid"
        Me.ktGrid.RowCaption = Nothing
        Me.ktGrid.Size = New System.Drawing.Size(336, 223)
        Me.ktGrid.TabClickEnabled = False
        Me.ktGrid.TabIndex = 10
        '
        'frmMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(359, 293)
        Me.Controls.Add(Me.ktGrid)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.TextBox)
        Me.Controls.Add(Me.ListViewEX)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMessage"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmMessage"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents ListViewEX As mandara10.ListViewEX
    Friend WithEvents ktGrid As KTGISUserControl.KTGISGrid
End Class
