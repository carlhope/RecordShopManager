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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        dgvArtists = New DataGridView()
        TableLayoutPanel1 = New TableLayoutPanel()
        btnAddArtist = New Button()
        CType(dgvArtists, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(123, 15)
        Label1.TabIndex = 0
        Label1.Text = "This is the Artist panel"
        ' 
        ' dgvArtists
        ' 
        dgvArtists.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvArtists.Dock = DockStyle.Fill
        dgvArtists.Location = New Point(3, 49)
        dgvArtists.Name = "dgvArtists"
        dgvArtists.Size = New Size(144, 98)
        dgvArtists.TabIndex = 1
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Controls.Add(btnAddArtist, 0, 1)
        TableLayoutPanel1.Controls.Add(dgvArtists, 0, 2)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel1.Size = New Size(150, 150)
        TableLayoutPanel1.TabIndex = 2
        ' 
        ' btnAddArtist
        ' 
        btnAddArtist.AutoSize = True
        btnAddArtist.Location = New Point(3, 18)
        btnAddArtist.Name = "btnAddArtist"
        btnAddArtist.Size = New Size(75, 25)
        btnAddArtist.TabIndex = 1
        btnAddArtist.Text = "Add Artist"
        AddHandler btnAddArtist.Click, AddressOf btnAddArtist_Click
        ' 
        ' ArtistPanel
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(TableLayoutPanel1)
        Name = "ArtistPanel"
        CType(dgvArtists, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Private Async Sub btnAddArtist_Click(sender As Object, e As EventArgs)
        Dim addForm As New AddArtistForm()
        If addForm.ShowDialog() = DialogResult.OK Then
            Await LoadArtistDataAsync()
        End If
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dgvArtists As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnAddArtist As Button

End Class
