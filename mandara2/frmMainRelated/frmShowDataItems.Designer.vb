<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowDataItems
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
        Me.ktGrid = New KTGISUserControl.KTGISGrid()
        Me.SuspendLayout()
        '
        'ktGrid
        '
        Me.ktGrid.DefaultFixedUpperLeftAlligntment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultFixedXNumberingWidth = 50
        Me.ktGrid.DefaultFixedXSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultFixedXWidth = 150
        Me.ktGrid.DefaultFixedYSAllignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.ktGrid.DefaultGridAlligntment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ktGrid.DefaultGridWidth = 100
        Me.ktGrid.DefaultNumberingAlligntment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ktGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ktGrid.FixedGridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.ktGrid.FrameColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.ktGrid.GridColor = System.Drawing.Color.White
        Me.ktGrid.GridFont = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ktGrid.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ktGrid.Layer = 0
        Me.ktGrid.LayerCaption = Nothing
        Me.ktGrid.Location = New System.Drawing.Point(0, 0)
        Me.ktGrid.MsgBoxTitle = ""
        Me.ktGrid.Name = "ktGrid"
        Me.ktGrid.RowCaption = Nothing
        Me.ktGrid.Size = New System.Drawing.Size(682, 395)
        Me.ktGrid.TabClickEnabled = False
        Me.ktGrid.TabIndex = 3
        '
        'frmShowDataItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 395)
        Me.Controls.Add(Me.ktGrid)
        Me.MinimizeBox = False
        Me.Name = "frmShowDataItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "データ項目一覧"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ktGrid As KTGISUserControl.KTGISGrid
End Class
