<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlbumPanel
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
        dgvAlbums = New DataGridView()
        BtnAddAlbum = New Button()
        layoutPanel = New TableLayoutPanel()
        CType(dgvAlbums, ComponentModel.ISupportInitialize).BeginInit()
        layoutPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(131, 15)
        Label1.TabIndex = 0
        Label1.Text = "This is the Album panel"
        ' 
        ' dgvAlbums
        ' 
        dgvAlbums.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAlbums.Dock = DockStyle.Fill
        dgvAlbums.Location = New Point(3, 47)
        dgvAlbums.Name = "dgvAlbums"
        dgvAlbums.Size = New Size(144, 100)
        dgvAlbums.TabIndex = 1
        ' 
        ' BtnAddAlbum
        ' 
        BtnAddAlbum.Location = New Point(3, 18)
        BtnAddAlbum.Name = "BtnAddAlbum"
        BtnAddAlbum.Size = New Size(109, 23)
        BtnAddAlbum.TabIndex = 2
        BtnAddAlbum.Text = "Add Album"
        BtnAddAlbum.UseVisualStyleBackColor = True
        ' 
        ' layoutPanel
        ' 
        layoutPanel.ColumnCount = 1
        layoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
        layoutPanel.Controls.Add(Label1, 0, 0)
        layoutPanel.Controls.Add(BtnAddAlbum, 0, 1)
        layoutPanel.Controls.Add(dgvAlbums, 0, 2)
        layoutPanel.Dock = DockStyle.Fill
        layoutPanel.Location = New Point(0, 0)
        layoutPanel.Name = "layoutPanel"
        layoutPanel.RowCount = 3
        layoutPanel.RowStyles.Add(New RowStyle())
        layoutPanel.RowStyles.Add(New RowStyle())
        layoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        layoutPanel.Size = New Size(150, 150)
        layoutPanel.TabIndex = 0
        ' 
        ' AlbumPanel
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(layoutPanel)
        Name = "AlbumPanel"
        CType(dgvAlbums, ComponentModel.ISupportInitialize).EndInit()
        layoutPanel.ResumeLayout(False)
        layoutPanel.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dgvAlbums As DataGridView
    Friend WithEvents BtnAddAlbum As Button

    Private Async Function LoadAlbumDataAsync() As Task
        Try
            Dim service As New ApiService()
            Dim albums = Await service.GetAlbumsAsync()

            dgvAlbums.Columns.Clear()
            dgvAlbums.AutoGenerateColumns = True
            dgvAlbums.DataSource = albums
            dgvAlbums.Columns("Title").HeaderText = "Album Title"
            dgvAlbums.Columns("Description").HeaderText = "Description"
            dgvAlbums.Columns("Id").Visible = False ' If you don’t need to show the ID
            If Not dgvAlbums.Columns.Contains("btnEdit") Then
                Dim editButtonColumn As New DataGridViewButtonColumn()
                editButtonColumn.Name = "btnEdit"
                editButtonColumn.HeaderText = "Actions"
                editButtonColumn.Text = "Edit"
                editButtonColumn.UseColumnTextForButtonValue = True
                dgvAlbums.Columns.Add(editButtonColumn)
            End If
            If Not dgvAlbums.Columns.Contains("btnDelete") Then
                Dim deleteButtonColumn As New DataGridViewButtonColumn()
                deleteButtonColumn.Name = "btnDelete"
                deleteButtonColumn.HeaderText = ""
                deleteButtonColumn.Text = "Delete"
                deleteButtonColumn.UseColumnTextForButtonValue = True
                dgvAlbums.Columns.Add(deleteButtonColumn)
            End If

        Catch ex As Exception
            MessageBox.Show("Failed to load albums: " & ex.Message)
        End Try
    End Function
    Private Async Sub dgvAlbums_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAlbums.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Dim selectedAlbum As Album = CType(dgvAlbums.Rows(e.RowIndex).DataBoundItem, Album)

        Select Case dgvAlbums.Columns(e.ColumnIndex).Name
            Case "btnEdit"
                Dim editForm As New EditAlbumForm(selectedAlbum)
                If editForm.ShowDialog() = DialogResult.OK Then
                    Await LoadAlbumDataAsync()
                End If

            Case "btnDelete"
                Dim confirm = MessageBox.Show($"Delete album '{selectedAlbum.Title}'?", "Confirm Delete", MessageBoxButtons.YesNo)
                If confirm = DialogResult.Yes Then
                    Dim service As New ApiService()
                    Dim success = Await service.DeleteAlbumAsync(selectedAlbum.Id)
                    If success Then
                        Await LoadAlbumDataAsync()
                    Else
                        MessageBox.Show("Failed to delete album.")
                    End If
                End If
        End Select
    End Sub

    Friend WithEvents layoutPanel As TableLayoutPanel

End Class
