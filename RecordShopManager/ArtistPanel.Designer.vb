<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArtistPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Label1 = New Label()
        dgvArtists = New DataGridView()
        CType(dgvArtists, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(123, 15)
        Label1.TabIndex = 0
        Label1.Text = "This is the Artist panel"
        ' 
        ' dgvArtists
        ' 
        dgvArtists.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvArtists.Dock = DockStyle.Fill
        dgvArtists.Location = New Point(0, 0)
        dgvArtists.Name = "dgvArtists"
        dgvArtists.Size = New Size(150, 150)
        dgvArtists.TabIndex = 1
        ' 
        ' ArtistPanel
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(dgvArtists)
        Controls.Add(Label1)
        Name = "ArtistPanel"
        CType(dgvArtists, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dgvArtists As DataGridView

End Class
